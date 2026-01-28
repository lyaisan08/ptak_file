using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Users\\Lenovo\\Documents\\Документы\\Дневник\\Дневник настроений.txt";
            Console.WriteLine("ДНЕВНИК НАСТРОЕНИЙ");
            string c = $"Сегодня {DateTime.Now}";
            Console.WriteLine(c);
            Console.Write("Оцените свое настроение (1-5): ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите комментарий: ");
            string b = Console.ReadLine();
            string d = $"[{c}] Настроение: {a}/5 - {b}";
            using (StreamWriter writer = new StreamWriter(fileName, true))
            { 
                writer.WriteLine(d);
            }
            Console.WriteLine("Запись добавлена!");
            Console.WriteLine("Последние 3 записи: ");
            List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                list.Add(line); 
            }
            int koll = 1;
            for (int i = list.Count; i > list.Count - 3; i--)
            {
                Console.WriteLine($"{koll}. {list[i-1]}");
                koll++;
            }
            list.Clear();
        }
    }
}
