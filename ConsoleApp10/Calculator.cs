namespace CalculatorApp.Services
{
    using CalculatorApp.Interfaces;
    using System;

    /// <summary>
    /// Performs arithmetic operations with logging
    /// </summary>
    public class Calculator : IAdder
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of Calculator
        /// </summary>
        /// <param name="logger">Logger implementation</param>
        /// <exception cref="ArgumentNullException">Thrown when logger is null</exception>
        public Calculator(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public double Add(double a, double b)
        {
            _logger.Event($"Performing addition: {a} + {b}");

            checked
            {
                try
                {
                    double result = a + b;
                    _logger.Event($"Addition successful. Result: {result}");
                    return result;
                }
                catch (OverflowException ex)
                {
                    _logger.Error($"Overflow while adding {a} and {b}");
                    throw new OverflowException("Arithmetic overflow occurred", ex);
                }
            }
        }
    }
}