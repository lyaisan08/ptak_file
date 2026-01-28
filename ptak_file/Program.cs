using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ptak_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Users\\Lenovo\\Documents\\Документы\\Дневник\\Моя_биография.txt";
            Console.WriteLine("Создаем файл с данными о биографии...");
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("- Меня зовут Ляйсан");
                writer.WriteLine("- Мне 17 лет");
                writer.WriteLine("- Я учусь программированию");
                writer.WriteLine("- Мое хобби - макраме");
                writer.WriteLine("- Я живу в Казани");
                writer.WriteLine("- Я учусь в КТИТС");
            }
            Console.WriteLine("Файл создан. Исходное содержимое:");
            int lines = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines++;
                    Console.WriteLine($"Строка {lines}: {line}");       
                }
            }
            Console.WriteLine($"Кол-во строк: {lines}");
        }
    }
}
