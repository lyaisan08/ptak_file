using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Users\\Lenovo\\Desktop\\Список покупок.txt";
            string filed = "C:\\Users\\Lenovo\\Desktop\\Список покупок_2.txt";
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                }
            }
            bool exit = false;
            while (!exit) 
            { 
                Console.WriteLine("СПИСОК ПОКУПОК");
                Console.WriteLine("1. Показать список покупок");
                Console.WriteLine("2. Добавить покупку");
                Console.WriteLine("3. Отметить покупку выполненной");
                Console.WriteLine("4. Очистить список");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (a)
                {
                    case 1:
                        Console.WriteLine("Ваш список покупок: ");
                        int lines = 0;
                        using (StreamReader sr = new StreamReader(fileName))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                lines++;
                                Console.WriteLine(sr.ReadToEnd());
                            }
                            if(lines == 0)
                            {
                                Console.WriteLine("Список пуст!");
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введите название покупки: ");
                        string b = Console.ReadLine();
                        using (StreamWriter sw = new StreamWriter(fileName, true))
                        {
                            sw.WriteLine($"[] {b.ToLower()}");
                        }
                        Console.WriteLine("Покупка добавлена!");
                        break;
                    case 3:
                        Console.WriteLine("Введите название покупки, которую хотите отметить: ");
                        string c = Console.ReadLine();
                        bool found = false;
                        using (StreamReader reader = new StreamReader(fileName))
                        using (StreamWriter writer = new StreamWriter(filed))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] parts = line.Split(' ');
                                if (parts[1] == c.ToLower() && !found)
                                {
                                    line = $"[X] {parts[1]}";
                                    Console.WriteLine($"Найдена и изменена: {line}");
                                    found = true;
                                }
                                writer.WriteLine(line);
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Продукт не найден!");
                        }
                        File.Delete(fileName);
                        File.Move(filed, fileName);
                        Console.WriteLine("Файл обновлен. Новое содержимое:");
                        using (StreamReader reader = new StreamReader(fileName))
                        {
                            Console.WriteLine(reader.ReadToEnd());
                        }
                        break;
                    case 4:
                        using (StreamWriter sw = new StreamWriter(fileName))
                        {
                        }
                        Console.WriteLine("Файл очищен.");
                        break;
                    case 5:
                        exit = true;
                        Console.WriteLine("Программа завершена!");
                        break;
                    default:
                        Console.WriteLine("Неверно! Выберите цифру от 1 до 5!");
                        break ;
                }
            }
        }
    }
}
