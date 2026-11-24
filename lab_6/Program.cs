using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] titles = new string[100];
            int[] durations = new int[100];
            double[] prices = new double[100];
            int count = 3;
            titles[0] = "Интерстеллар";
            titles[1] = "Начало";
            titles[2] = "Матрица";
            durations[0] = 169;
            durations[1] = 148;
            durations[2] = 136;
            prices[0] = 450;
            prices[1] = 400;
            prices[2] = 350;
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("=== КИНОТЕАТР ===");
                Console.WriteLine("1. Показать фильмы");
                Console.WriteLine("2. Добавить фильм");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите действие: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowFilms(titles, durations, prices, count);
                        break;

                    case "2":
                        AddFilm(titles, durations, prices, ref count);
                        break;

                    case "3":
                        Console.WriteLine("Выход из программы");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            } 
            while (choice != "3");
        }
        static void ShowFilms(string[] titles, int[] durations, double[] prices, int count)
        {
            Console.Clear();
            Console.WriteLine("\n=== СПИСОК ФИЛЬМОВ ===");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Название: " + titles[i]);
                Console.WriteLine("Продолжительность: " + durations[i] + " мин.");
                Console.WriteLine("Цена билета: " + prices[i] + " руб.");
                Console.WriteLine("------------------------");
            }
            string choice;
            do
            {
                Console.WriteLine("\n0. Вернуться в главное меню");
                Console.Write("Выберите действие: ");
                choice = Console.ReadLine();
                if (choice != "0")
                {
                    Console.WriteLine("Неверный выбор!");
                }
            } while (choice != "0");
        }
        static void AddFilm(string[] titles, int[] durations, double[] prices, ref int count)
        {
            Console.Clear();
            Console.WriteLine("=== ДОБАВЛЕНИЕ ФИЛЬМА ===\n");
            int duration;
            double price;
            string title;
            if (count >= titles.Length)
            {
                Console.WriteLine("Каталог фильмов заполнен!");
                Console.ReadKey();
                return;
            }
            Console.Write("Введите название фильма: ");
            title = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Ошибка! Название не может быть пустым.");
                Console.Write("Повторите ввод: ");
                title = Console.ReadLine();
            }
            Console.Write("Введите продолжительность фильма (мин): ");
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.WriteLine("Ошибка! Введите положительное целое число.");
                Console.Write("Повторите ввод: ");
            }
            Console.Write("Введите цену билета: ");
            while (!double.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.WriteLine("Ошибка! Введите положительное число.");
                Console.Write("Повторите ввод: ");
            }
            titles[count] = title;
            durations[count] = duration;
            prices[count] = price;
            count++;
            Console.WriteLine("Фильм успешно добавлен!");
            string choice;
            do
            {
                Console.WriteLine("\n0. Вернуться в главное меню");
                Console.Write("Выберите действие: ");
                choice = Console.ReadLine();
                if (choice != "0")
                {
                    Console.WriteLine("Неверный выбор!");
                }
            } while (choice != "0");
        }
    }
}