using System;
using System.Collections.Generic;
using System.Linq;

namespace CF_module_9_6_2
{
    public class NoCorrectNumberException : Exception
    {
        public NoCorrectNumberException() { }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<string> familyName = new();
            familyName.Add("Моргенштерн");
            familyName.Add("Заболоцкий");
            familyName.Add("Петров");
            familyName.Add("Андриенко");
            familyName.Add("Глушко");

            OrderFamily ordFam = new OrderFamily(familyName);
            ordFam.OrderCompleted += ordFam_OrderCompleted;
            ordFam.StartOrder();

        }
        public static void ordFam_OrderCompleted(List<string> familyName)
        {
            int sortType = 0;
            Console.WriteLine("Начинается процесс сортировки");
            Console.WriteLine("Введите 1(сорт. А-Я), либо 2(сорт Я-А)");
            List<string> sortFamilyName = new();
            try
            {
                sortType = Convert.ToInt32(Console.ReadLine());
                if (sortType == 1)
                {
                    sortFamilyName = familyName.OrderBy(i => i).ToList();
                }
                else if (sortType == 2)
                {
                    sortFamilyName = familyName.OrderByDescending(i => i).ToList();
                }
                else
                {
                    throw new NoCorrectNumberException();
                }
            }
            catch (NoCorrectNumberException)
            {
                Console.WriteLine("Введенное значение отличается от 1 или 2");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенное значение не может быть сконвертировано в число");
            }
            finally
            {
                Console.WriteLine("\nЗначения отсортировано по {0}:", sortType == 1 ? "А-Я" : "Я-А");
                foreach (string famName in sortFamilyName)
                {
                    Console.WriteLine(famName);
                }
            }

            Console.WriteLine("Процесс сортировки завершен");
            Console.ReadKey();
        }

    }
    public delegate void Notify(List<string> familyName); //событие

    public class OrderFamily
    {
        List<string> FamilyName;
        public OrderFamily(List<string> familyName)
        {
            FamilyName = familyName;
        }
        public event Notify OrderCompleted;

        public void StartOrder()
        {
            OnOrderCompleted();
        }

        protected virtual void OnOrderCompleted()
        {
            OrderCompleted?.Invoke(FamilyName);
        }

    }
}
