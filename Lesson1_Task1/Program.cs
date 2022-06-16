using System;

namespace Lesson1_Task1
{
    /// <summary>
    /// Урок 1. Задача 1.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Класс для тестирования метода IsPrimeNumber.
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
            public bool Expected { get; set; }

            /// <summary>
            /// Ожидается ли исключение ArgumentException.
            /// </summary>
            public bool ExpectedArgumentException { get; set; }
        }

        /// <summary>
        /// Метод для проверки простоты числа.
        /// </summary>
        /// <param name="n">Число для проверки.</param>
        /// <returns>Результат проверки. Возвращает истину, если число простое.</returns>
        /// <exception cref="ArgumentException">Возбуждается, если на вход передано не натуральное число.</exception>
        private static bool IsPrimeNumber(int n)
        {
            if (n <= 0)
                throw new ArgumentException("n должно быть натуральным числом.");
            var d = 0;
            var i = 2;
            while (i < n)
            {
                if (n % i == 0) d++;
                i++;
            }

            return d == 0;
        }

        /// <summary>
        /// Метод для тестирования метода IsPrimeNumber.
        /// </summary>
        /// <param name="testCase">Экземпляр класса для тестирования.</param>
        private static void TestIsPrimeNumber(TestCase testCase)
        {
            string result;
            try
            {
                var actual = IsPrimeNumber(testCase.N);
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
        /// Процесс тестирования метода IsPrimeNumber.
        /// </summary>
        static void TestProcess()
        {
            var testCases = new TestCase[] {
                new TestCase()
                {
                    N = 1,
                    Expected = true,
                    ExpectedArgumentException = false
                },
                new TestCase()
                {
                    N = 4,
                    Expected = false,
                    ExpectedArgumentException = false
                },
                new TestCase()
                {
                    N = 100,
                    Expected = false,
                    ExpectedArgumentException = false
                },
                new TestCase()
                {
                    N = 0,
                    ExpectedArgumentException = true
                },
                new TestCase()
                {
                    N = -1,
                    ExpectedArgumentException = true
                }
            };

            foreach (var testCase in testCases)
            {
                TestIsPrimeNumber(testCase);
                Console.Write($" IsPrimeNumber({testCase.N})");
                Console.WriteLine($" Expected: {(!testCase.ExpectedArgumentException ? testCase.Expected.ToString() : "ArgumentException")}");

            }
            Console.WriteLine();
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
                else if (n <= 0)
                    Console.WriteLine("Введенное число должно быть натуральным! Повторите попытку.");
                else
                    Console.WriteLine($"Число {n} {(IsPrimeNumber(n) ? "простое" : "непростое")}.");
            }
        }
    }
}