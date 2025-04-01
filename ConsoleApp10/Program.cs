using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем логгер
            ILogger logger = new Logger();

            // Внедряем логгер в калькулятор
            IAdder adder = new Calculator(logger);

            Console.WriteLine("Мини-калькулятор для сложения двух чисел");

            while (true)
            {
                try
                {
                    logger.Event("Начало новой операции");

                    Console.Write("Введите первое число (или 'q' для выхода): ");
                    string input1 = Console.ReadLine();

                    if (input1.ToLower() == "q")
                    {
                        logger.Event("Пользователь завершил работу программы");
                        break;
                    }

                    double num1 = ParseNumber(input1, logger);
                    logger.Event($"Получено первое число: {num1}");

                    Console.Write("Введите второе число: ");
                    double num2 = ParseNumber(Console.ReadLine(), logger);
                    logger.Event($"Получено второе число: {num2}");

                    double result = adder.Add(num1, num2);
                    Console.WriteLine($"\nРезультат: {result}\n");
                    logger.Event($"Операция успешно завершена. Результат: {result}");
                }
                catch (FormatException)
                {
                    string errorMessage = "Ошибка: Введено некорректное число!";
                    logger.Error(errorMessage);
                    Console.WriteLine(errorMessage + "\n");
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

            Console.WriteLine("Работа калькулятора завершена. Нажмите любую клавишу...");
            Console.ReadKey();
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

        // Внедрение зависимости через конструктор
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
