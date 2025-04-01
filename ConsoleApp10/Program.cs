namespace CalculatorApp
{
    using System;
    using CalculatorApp.Interfaces;
    using CalculatorApp.Services;

    /// <summary>
    /// Console calculator application
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        public static void Main()
        {
            ILogger logger = new Logger();
            IAdder adder = new Calculator(logger);

            Console.WriteLine("Console Calculator Application");
            RunCalculatorLoop(adder, logger);
        }

        private static void RunCalculatorLoop(IAdder adder, ILogger logger)
        {
            while (true)
            {
                try
                {
                    logger.Event("Starting new calculation");

                    double num1 = GetNumberFromUser("Enter first number (or 'q' to quit): ", logger);
                    double num2 = GetNumberFromUser("Enter second number: ", logger);

                    double result = adder.Add(num1, num2);
                    Console.WriteLine($"\nResult: {result}\n");
                    logger.Event($"Calculation completed. Result: {result}");
                }
                catch (OperationCanceledException)
                {
                    logger.Event("User terminated the application");
                    return;
                }
                catch (OverflowException)
                {
                    logger.Error("Calculation resulted in overflow");
                    Console.WriteLine("Error: Calculation overflow!\n");
                }
                catch (Exception ex)
                {
                    logger.Error($"Unexpected error: {ex.Message}");
                    Console.WriteLine($"Error: {ex.Message}\n");
                }
                finally
                {
                    Console.WriteLine("--------------------------");
                }
            }
        }

        private static double GetNumberFromUser(string prompt, ILogger logger)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    logger.Event("User requested exit");
                    throw new OperationCanceledException();
                }

                if (double.TryParse(input, out double number))
                {
                    logger.Event($"Valid number entered: {number}");
                    return number;
                }

                logger.Error($"Invalid number input: {input}");
                Console.WriteLine("Error: Invalid number format. Please try again.\n");
            }
        }
    }
}