using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            IAdder adder = new Calculator(logger);

            Console.WriteLine("Мини-калькулятор для сложения двух чисел");

            while (true)
            {
                try
                {
                    logger.Event("Начало новой операции");

                    // Ввод первого числа
                    double num1;
                    while (true)
                    {
                        Console.Write("Введите первое число (или 'q' для выхода): ");
                        string input1 = Console.ReadLine();

                        if (input1.ToLower() == "q")
                        {
                            logger.Event("Пользователь завершил работу программы");
                            return;
                        }

                        try
                        {
                            num1 = ParseNumber(input1, logger);
                            logger.Event($"Получено первое число: {num1}");
                            break;
                        }
                        catch (FormatException)
                        {
                            string errorMessage = "Ошибка: Введено некорректное число!";
                            logger.Error(errorMessage);
                            Console.WriteLine(errorMessage + "\n");
                        }
                    }

                    // Ввод второго числа (с повторением при ошибке)
                    double num2;
                    while (true)
                    {
                        try
                        {
                            Console.Write("Введите второе число: ");
                            num2 = ParseNumber(Console.ReadLine(), logger);
                            logger.Event($"Получено второе число: {num2}");
                            break;
                        }
                        catch (FormatException)
                        {
                            string errorMessage = "Ошибка: Введено некорректное число!";
                            logger.Error(errorMessage);
                            Console.WriteLine(errorMessage + "\n");
                        }
                    }

                    // Выполнение операции
                    double result = adder.Add(num1, num2);
                    Console.WriteLine($"\nРезультат: {result}\n");
                    logger.Event($"Операция успешно завершена. Результат: {result}");
                }
                catch (OverflowException)
                {
                    string errorMessage = "Ошибка: Переполнение при выполнении операции!";
                    logger.Error(errorMessage);
                    Console.WriteLine(errorMessage + "\n");
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Неизвестная ошибка: {ex.Message}";
                    logger.Error(errorMessage);
                    Console.WriteLine(errorMessage + "\n");
                }
                finally
                {
                    Console.WriteLine("--------------------------");
                }
            }
        }

        static double ParseNumber(string input, ILogger logger)
        {
            if (!double.TryParse(input, out double number))
            {
                logger.Error($"Некорректный ввод: {input}");
                throw new FormatException();
            }
            return number;
        }
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {DateTime.Now:HH:mm:ss}: {message}");
            Console.ResetColor();
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[EVENT] {DateTime.Now:HH:mm:ss}: {message}");
            Console.ResetColor();
        }
    }

    public interface IAdder
    {
        double Add(double a, double b);
    }

    public class Calculator : IAdder
    {
        private readonly ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        public double Add(double a, double b)
        {
            _logger.Event($"Выполняется сложение: {a} + {b}");

            try
            {
                checked
                {
                    double result = a + b;
                    _logger.Event("Сложение выполнено успешно");
                    return result;
                }
            }
            catch (OverflowException ex)
            {
                _logger.Error($"Переполнение при сложении {a} и {b}");
                throw;
            }
        }
    }
}