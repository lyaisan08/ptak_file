using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Users\\Lenovo\\Documents\\Документы\\Дневник\\учет_учебных_предметов.txt";
            string filed = "C:\\Users\\Lenovo\\Documents\\Документы\\Дневник\\учет_учебных_предметов2.txt";
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                }
            }
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("УЧЕТ УЧЕБНЫХ ПРЕДМЕТОВ");
                Console.WriteLine("1. Показать все предметы");
                Console.WriteLine("2. Добавить предмет");
                Console.WriteLine("3. Изменить оценку");
                Console.WriteLine("4. Удалить предмет");
                Console.WriteLine("5. Посчитать средний балл");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Ваши предметы и оценки: ");
                        int count = 0;
                        using (StreamReader sr = new StreamReader(fileName))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                count++;
                                Console.WriteLine(line);
                            }
                            if (count == 0)
                            {
                                Console.WriteLine("Список пуст!");
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введите название предмета: ");
                        string subject = Console.ReadLine();
                        Console.WriteLine("Введите оценку (1-5): ");
                        string grade = Console.ReadLine();
                        bool exists = false;
                        using (StreamReader reader = new StreamReader(fileName))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] parts = line.Split('=');
                                if (parts[0].ToLower() == subject.ToLower())
                                {
                                    exists = true;
                                    Console.WriteLine("Этот предмет уже существует!");
                                    break;
                                }
                            }
                        }
                        if (!exists)
                        {
                            using (StreamWriter writer = new StreamWriter(fileName, true))
                            {
                                writer.WriteLine($"{subject}={grade}");
                            }
                            Console.WriteLine("Предмет добавлен!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Введите название предмета для изменения: ");
                        string subject2 = Console.ReadLine();
                        Console.WriteLine("Введите новую оценку: ");
                        string newGrade = Console.ReadLine();
                        bool found = false;
                        using (StreamReader reader = new StreamReader(fileName))
                        using (StreamWriter writer = new StreamWriter(filed))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] parts = line.Split('=');
                                if (parts[0].ToLower() == subject2.ToLower() && !found)
                                {
                                    line = $"{subject2}={newGrade}";
                                    Console.WriteLine($"Оценка изменена: {subject2}={newGrade}");
                                    found = true;
                                }
                                writer.WriteLine(line);
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Предмет не найден!");
                        }
                        else
                        {
                            File.Delete(fileName);
                            File.Move(filed, fileName);
                            Console.WriteLine("Файл обновлен!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Введите название предмета для удаления: ");
                        string subjectDel = Console.ReadLine();
                        bool deleted = false;
                        using (StreamReader reader = new StreamReader(fileName))
                        using (StreamWriter writer = new StreamWriter(filed))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] parts = line.Split('=');
                                if (parts[0].ToLower() == subjectDel.ToLower() && !deleted)
                                {
                                    Console.WriteLine($"Предмет удален: {subjectDel}");
                                    deleted = true;
                                }
                                else
                                {
                                    writer.WriteLine(line);
                                }
                            }
                        }
                        if (!deleted)
                        {
                            Console.WriteLine("Предмет не найден!");
                            File.Delete(filed);
                        }
                        else
                        {
                            File.Delete(fileName);
                            File.Move(filed, fileName);
                            Console.WriteLine("Файл обновлен!");
                        }
                        break;
                    case 5:
                        double sum = 0;
                        int kol = 0;
                        string bestSubject = "";
                        string bedSubject = "";
                        int bestGrade = 0;
                        int bedGrade = 6;
                        using (StreamReader reader = new StreamReader(fileName))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] parts = line.Split('=');
                                string subjectName = parts[0];
                                int subjectGrade = Convert.ToInt32(parts[1]);
                                sum += subjectGrade;
                                kol++;
                                if (subjectGrade > bestGrade)
                                {
                                    bestGrade = subjectGrade;
                                    bestSubject = subjectName;
                                }
                                if (subjectGrade < bedGrade)
                                {
                                    bedGrade = subjectGrade;
                                    bedSubject = subjectName;
                                }
                            }
                        }
                        if (kol > 0)
                        {
                            double average = sum / kol;          
                            Console.WriteLine($"Средний балл: {average:F2}");
                            Console.WriteLine($"Лучший предмет: {bestSubject} ({bestGrade})");
                            Console.WriteLine($"Худший предмет: {bedSubject} ({bedGrade})");
                        }
                        else
                        {
                            Console.WriteLine("Список предметов пуст!");
                        }
                        break;
                    case 6:
                        exit = true;
                        Console.WriteLine("Программа завершена!");
                        break;
                    default:
                        Console.WriteLine("Неверно! Выберите цифру от 1 до 6!");
                        break;
                }
            }
        }
    }
}