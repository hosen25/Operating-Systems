using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // List of browsers to monitor
        string[] browsers = { "chrome", "msedge", "firefox", "opera" };

        // Stores previous state: browser name -> PID
        Dictionary<string, int> previousState = new Dictionary<string, int>();

        Console.WriteLine("BrowserMonitor.exe\n");

        while (true)
        {
            foreach (string browser in browsers)
            {
                // Get all running processes with this browser name
                var processes = Process.GetProcessesByName(browser);

                // Check if the browser is currently running
                bool isRunning = processes.Length > 0;

                // Check if we had it running in the previous state
                bool wasRunning = previousState.ContainsKey(browser);

                // =========================
                // Browser started event
                // =========================
                if (isRunning && !wasRunning)
                {
                    int pid = processes[0].Id;

                    // Save current state
                    previousState[browser] = pid;

                    Console.WriteLine($"[+] {browser} (PID: {pid}) has started at {DateTime.Now:HH:mm:ss}");
                }

                // =========================
                // Browser stopped event
                // =========================
                else if (!isRunning && wasRunning)
                {
                    int oldPid = previousState[browser];

                    // Remove from active state
                    previousState.Remove(browser);

                    Console.WriteLine($"[-] {browser} (PID: {oldPid}) has closed at {DateTime.Now:HH:mm:ss}");
                }

                // If still running, do nothing (no repeated output)
            }

            // Wait 1 second before next polling cycle
            Thread.Sleep(1000);
        }
    }
}