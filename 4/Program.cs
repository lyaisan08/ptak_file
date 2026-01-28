using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Users\\Lenovo\\Desktop\\исходный.txt";
            string file = "C:\\Users\\Lenovo\\Desktop\\обработанный.txt";
            Console.WriteLine("Исходный файл (6 строк):");
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("привет");
                writer.WriteLine("");
                writer.WriteLine("я устала!");
                writer.WriteLine("");
                writer.WriteLine("как дела?");
                writer.WriteLine("четвертая строка");
            }
            using (StreamReader reader = new StreamReader(fileName))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
            Console.WriteLine();
            Console.WriteLine("Обработанный файл (4 строки):");
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            List<string> strings = new List<string>();
            int number = 1;
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i] != null && list[i].Length != 0)
                {
                    string a = list[i].ToUpper();
                    string b = $"{number:D2}. {a}";
                    strings.Add(b);
                    number++;
                }
            }
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (string s in strings)
                {
                    writer.WriteLine(s);
                }
            }
            using (StreamReader reader = new StreamReader(file))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
