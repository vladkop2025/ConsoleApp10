namespace CalculatorApp.Services
{
    using System;
    using CalculatorApp.Interfaces;

    /// <summary>
    /// Console-based logger with colored output
    /// </summary>
    public class Logger : ILogger
    {
        /// <inheritdoc/>
        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[EVENT] {DateTime.Now:HH:mm:ss}: {message}");
            Console.ResetColor();
        }

        /// <inheritdoc/>
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {DateTime.Now:HH:mm:ss}: {message}");
            Console.ResetColor();
        }
    }
}