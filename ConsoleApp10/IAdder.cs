namespace CalculatorApp.Interfaces
{
    /// <summary>
    /// Provides functionality for adding two numbers
    /// </summary>
    public interface IAdder
    {
        /// <summary>
        /// Adds two numbers with overflow check
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>Sum of two numbers</returns>
        /// <exception cref="OverflowException">Thrown when arithmetic overflow occurs</exception>
        double Add(double a, double b);
    }
}