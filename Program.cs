using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingNames
{
    internal class Program
    {
        public static event Action<List<string>, bool> SortNames;

        static void Main(string[] args)
        {
            List<string> surname = new List<string> { "Иванов", "Тапочкин", "Фитс", "Морозов", "Афонасьев" };

            SortNames = (names, ascendiing) =>
            {
                names.Sort();
                if (!ascendiing)
                {
                    names.Reverse();
                }
            };

            Console.WriteLine("Выберите способ сортировки: ");
            Console.WriteLine("1 - по возрастанию (А-Я)");
            Console.WriteLine("2 - по убыванию (Я-А)");

            try
            {
                string input = Console.ReadLine();
                int option = Convert.ToInt32(input);

                if (option != 1 && option != 2)
                {
                    throw new InvalidSortOptionException("Недопустимый вариант сортировки. Введите 1 или 2.");

                }

                SortNames?.Invoke(surname, option == 1);

                Console.WriteLine("Отсортированный список фамилий: ");
                foreach (string s in surname) Console.WriteLine(s);
            }
            catch (InvalidSortOptionException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введены некорректные данные. Введите число 1 или 2.");
            }
            finally
            {
                Console.WriteLine("Выполнение программы завершено");
                Console.ReadKey();
            }
        }
    }

    public class InvalidSortOptionException : Exception
    {
        public InvalidSortOptionException(string message) : base(message)
        {
        }
    }
}
