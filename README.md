# Operating-Systems
# Browser Monitor

## 📌 Project Overview

This is a C# console application that monitors browser processes in real time.
It detects when common web browsers are opened or closed and logs the events with timestamps.

## ⚙️ Supported Browsers

* Google Chrome
* Microsoft Edge
* Mozilla Firefox
* Opera

## 🧠 How It Works

The program continuously checks running system processes every second using `System.Diagnostics.Process`.

It keeps track of:

* Which browsers are currently running
* Which browsers were previously running
* Changes in state (start / stop events)

When a change is detected, it prints a message to the console.

## 🖥️ Example Output

```
BrowserMonitor.exe

[+] chrome (PID: 1234) has started at 14:32:10
[-] chrome (PID: 1234) has closed at 14:40:05
```

## 🛠️ Technologies Used

* C#
* .NET
* System.Diagnostics
* Multithreading (Thread.Sleep loop)

## 📁 Project Structure

* `Program.cs` – Main monitoring logic
* `.csproj` – Project configuration

## 🚀 How to Run

1. Open the project in Visual Studio
2. Build the solution
3. Run the program
4. Open/close browsers to see monitoring in action

## 👤 Author

* Hoseen Mansour

## 📌 Notes

This project demonstrates basic operating system concepts such as process monitoring and system-level programming in C#.
