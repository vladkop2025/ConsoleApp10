namespace CalculatorApp.Interfaces
{
    /// <summary>
    /// Provides logging functionality
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs an informational event
        /// </summary>
        /// <param name="message">Event message</param>
        void Event(string message);

        /// <summary>
        /// Logs an error
        /// </summary>
        /// <param name="message">Error message</param>
        void Error(string message);
    }
}