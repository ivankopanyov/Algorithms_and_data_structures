using System;

namespace Lesson1_Task3
{
    /// <summary>
    /// Урок 1. Задача 3.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Класс для тестирования методов GetFibonacci и GetFibonacciRecursion.
        /// </summary>
        private class TestCase
        {
            /// <summary>
            /// Число для проверки, переданное в метод.
            /// </summary>
            public int N { get; set; }

            /// <summary>
            /// Ожидаемый результат.
            /// </summary>
            public int Expected { get; set; }

            /// <summary>
            /// Ожидается ли исключение ArgumentException.
            /// </summary>
            public bool ExpectedArgumentException { get; set; }
        }

        /// <summary>
        /// Метод для тестирования метода GetFibonacci.
        /// </summary>
        /// <param name="testCase">Экземпляр класса для тестирования.</param>
        private static void TestGetFibonacci(TestCase testCase)
        {
            string result;
            try
            {
                var actual = GetFibonacci(testCase.N);
                result = actual == testCase.Expected ? "VALID TEST" : "INVALID TEST";
            }
            catch (ArgumentException)
            {
                result = testCase.ExpectedArgumentException ? "VALID TEST" : "INVALID TEST";
            }
            catch
            {
                result = "INVALID TEST";
            }
            Console.Write(result);
        }

        /// <summary>
        /// Метод для тестирования метода GetFibonacciRecursion.
        /// </summary>
        /// <param name="testCase">Экземпляр класса для тестирования.</param>
        private static void TestGetFibonacciRecursion(TestCase testCase)
        {
            string result;
            try
            {
                var actual = GetFibonacciRecursion(testCase.N);
                result = actual == testCase.Expected ? "VALID TEST" : "INVALID TEST";
            }
            catch (ArgumentException)
            {
                result = testCase.ExpectedArgumentException ? "VALID TEST" : "INVALID TEST";
            }
            catch
            {
                result = "INVALID TEST";
            }
            Console.Write(result);
        }


        /// <summary>
        /// Процесс тестирования методов GetFibonacci и GetFibonacciRecursion.
        /// </summary>
        static void TestProcess()
        {
            var testCases = new TestCase[] {
                new TestCase()
                {
                    N = 2,
                    Expected = 1,
                    ExpectedArgumentException = false
                },

                new TestCase()
                {
                    N = 10,
                    Expected = 55,
                    ExpectedArgumentException = false
                },

                new TestCase()
                {
                    N = 17,
                    Expected = 1597,
                    ExpectedArgumentException = false
                },

                new TestCase()
                {
                    N = -1,
                    ExpectedArgumentException = true
                },

                new TestCase()
                {
                    N = -246,
                    ExpectedArgumentException = true
                }
            };

            foreach (var testCase in testCases)
            {
                TestGetFibonacci(testCase);
                Console.Write($" GetFibonacci({testCase.N})");
                Console.WriteLine($" Expected: {(!testCase.ExpectedArgumentException ? testCase.Expected.ToString() : "ArgumentException")}");
                TestGetFibonacciRecursion(testCase);
                Console.Write($" GetFibonacciRecursion({testCase.N})");
                Console.WriteLine($" Expected: {(!testCase.ExpectedArgumentException ? testCase.Expected.ToString() : "ArgumentException")}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Определение числа Фибоначчи с помощью цикла.
        /// </summary>
        /// <param name="n">Число для вычисления.</param>
        /// <returns>Число Фибоначчи.</returns>
        /// <exception cref="ArgumentException">Возбуждается, если на вход передано число меньше 0.</exception>
        private static int GetFibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException("Число должно быть большо нуля.");
            if (n == 0) return 0;
            if (n <= 2) return 1;

            int number = 1;
            int result = 1;

            for (var i = 3; i <= n; i++)
            {
                result += number;
                number = result - number;
            }

            return result;
        }

        /// <summary>
        /// Определение числа Фибоначчи рекурсивным методом.
        /// </summary>
        /// <param name="n">Число для вычисления.</param>
        /// <returns>Число Фибоначчи.</returns>
        /// <exception cref="ArgumentException">Возбуждается, если на вход передано число меньше 0.</exception>
        private static int GetFibonacciRecursion(int n)
        {
            if (n < 0)
                throw new ArgumentException("Число должно быть большо нуля.");
            if (n == 0) return 0;
            if (n <= 2) return 1;

            return GetFibonacciRecursion(n - 1) + GetFibonacciRecursion(n - 2);
        }

        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            TestProcess();

            while (true)
            {
                Console.Write("Введите число: ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) return;

                if (!int.TryParse(input, out int n))
                    Console.WriteLine("Некорректный ввод! Повторите попытку.");
                else if (n < 0)
                    Console.WriteLine("Введенное число не должно быть меньше 0! Повторите попытку.");
                else
                {
                    Console.WriteLine($"F({n}) = {GetFibonacci(n)} (цикл).");
                    Console.WriteLine($"F({n}) = {GetFibonacciRecursion(n)} (рекурсия).");
                }
            }
        }
    }
}