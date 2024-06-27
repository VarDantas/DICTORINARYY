using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Menu() {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] options = { "1. Создать словарь.", "2. Добавить слово и его перевод.", 
                "3. Заменить слово или его перевод.", "4. Удалить слово или перевод.", 
                "5. Искать перевод слова.", "6. Экспортировать слово с переводом в файл.", "7. Выход" };
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.WriteLine("-> " + options[i]);
                    }
                    else
                    {
                        Console.WriteLine("   " + options[i]);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = (selectedOption - 1 + options.Length) % options.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = (selectedOption + 1) % options.Length;
                        break;
                    case ConsoleKey.Enter:
                        if (options[selectedOption] == "1. Создать словарь.") { createDictionary(); }
                        else if (options[selectedOption] == "2. Добавить слово и его перевод.") { AddWord(); }
                        else if (options[selectedOption] == "3. Заменить слово или его перевод.") { ReplaceWord(); }
                        else if(options[selectedOption] == "4. Удалить слово или перевод.") { Delete(); }
                        else if(options[selectedOption] == "5. Искать перевод слова.") { SearchTranslation(); }
                        else if(options[selectedOption] == "6. Экспортировать слово с переводом в файл.") { ExportWord(); }
                        else if(options[selectedOption] == "7. Выход") { return; }
                        Console.ReadKey();
                        Menu();
                        return;
                    default:
                        Console.WriteLine("\nНекорректный выбор");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void createDictionary()
        {
            Console.WriteLine("Введите название файла для словаря: ");
            string file = Console.ReadLine();

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] options = { "1. Англо-русский", "2. Русско-английский", "3. Выход в главное меню" };
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите тип словаря:");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.WriteLine("-> " + options[i]);
                    }
                    else
                    {
                        Console.WriteLine("   " + options[i]);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); 

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = (selectedOption - 1 + options.Length) % options.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = (selectedOption + 1) % options.Length;
                        break;
                    case ConsoleKey.Enter:
                        if (options[selectedOption] == "1. Англо-русский")
                        {
                            File.WriteAllText(file, "Англо-русский словарь");
                            Console.WriteLine("Создан англо-русский словарь");
                        }
                        else if (options[selectedOption] == "2. Русско-английский")
                        {
                            File.WriteAllText(file, "Русско-английский словарь");
                            Console.WriteLine("Создан русско-английский словарь");
                        }
                        else if (options[selectedOption] == "3. Выход в главное меню")
                        {
                            Menu();
                            return;
                        }
                        Console.ReadKey();
                        Menu();
                        return; 
                    default:
                        Console.WriteLine("\nНекорректный выбор");
                        Console.ReadKey(); 
                        break;
                }
            }
        }
        static void AddWord()
        {
            Console.WriteLine("Введите название файла словаря: ");
            string file = Console.ReadLine();
            string[] fileContent = File.ReadAllLines(file);
            Console.Clear();
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine();
            Console.WriteLine("Введите перевод(или несколько переводов через запятую):");
            string translations = Console.ReadLine();
            List<string> newFileContent = fileContent.ToList();
            newFileContent.Add(word + " - " + translations);
            File.WriteAllLines(file, newFileContent);
            Console.WriteLine("Слово и его перевод добавлены в словарь.");
            Console.ReadKey();
            Menu();
        }
        static void ReplaceWord()
        {
            Console.WriteLine("Введите название файла словаря: ");
            string file = Console.ReadLine();
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] options = { "1. Заменить слово", "2. Заменить перевод", "3. Выход в главное меню" };
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.WriteLine("-> " + options[i]);
                    }
                    else
                    {
                        Console.WriteLine("   " + options[i]);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = (selectedOption - 1 + options.Length) % options.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = (selectedOption + 1) % options.Length;
                        break;
                    case ConsoleKey.Enter:
                        if (options[selectedOption] == "1. Заменить слово")
                        {
                            Console.WriteLine("Введите слово: ");
                            string oldWord = Console.ReadLine();
                            Console.WriteLine("Введите новое слово: ");
                            string newWord = Console.ReadLine();
                            string fileContent = File.ReadAllText(file);
                            fileContent = fileContent.Replace(oldWord, newWord);
                            File.WriteAllText(file, fileContent);
                            Console.WriteLine($"Слово '{oldWord}' заменено на '{newWord}'");
                        }
                        else if (options[selectedOption] == "2. Заменить перевод")
                        {
                            Console.WriteLine("Введите перевод: ");
                            string oldTranclations = Console.ReadLine();
                            Console.WriteLine("Введите новый перевод(или несколько переводов через запятую): ");
                            string newTranslations = Console.ReadLine();
                            string fileContent = File.ReadAllText(file);
                            fileContent = fileContent.Replace(oldTranclations, newTranslations);
                            File.WriteAllText(file, fileContent);
                            Console.WriteLine($"Перевод '{oldTranclations}' заменено на '{newTranslations}'");
                        }
                        else if (options[selectedOption] == "3. Выход в главное меню")
                        {
                            Menu();
                            return;
                        }
                        Console.ReadKey();
                        Menu();
                        return;
                    default:
                        Console.WriteLine("\nНекорректный выбор");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Delete() {
            Console.WriteLine("Введите название файла словаря: ");
            string file = Console.ReadLine();
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] options = { "1. Удалить слово", "2. Удалить перевод", "3. Выход в главное меню" };
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.WriteLine("-> " + options[i]);
                    }
                    else
                    {
                        Console.WriteLine("   " + options[i]);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = (selectedOption - 1 + options.Length) % options.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = (selectedOption + 1) % options.Length;
                        break;
                    case ConsoleKey.Enter:
                        if (options[selectedOption] == "1. Удалить слово")
                        {
                            Console.WriteLine("Введите слово: ");
                            string word = Console.ReadLine();
                            string[] fileContent = File.ReadAllLines(file);
                            foreach (string line in fileContent)
                            {
                                if (line.Contains(word))
                                {
                                    string[] newFileContent = fileContent.Where((s, i) => s != line).ToArray();
                                    File.WriteAllLines(file, newFileContent);
                                    Console.WriteLine($"Слово '{word}' удалено");
                                }
                            }
                        }
                        else if (options[selectedOption] == "2. Удалить перевод")
                        {
                            Console.WriteLine("Введите слово: ");
                            string word = Console.ReadLine();
                            Console.WriteLine("Введите перевод, который надо удалить: ");
                            string tranclations = Console.ReadLine();
                            string[] fileContent = File.ReadAllLines(file);
                            for (int i = 0; i < fileContent.Length; i++)
                            {
                                if (fileContent[i].Contains(word) && fileContent[i].Contains(','))
                                {
                                    fileContent[i] = fileContent[i].Replace(tranclations+", ", "");
                                    File.WriteAllLines(file, fileContent);
                                    Console.WriteLine($"Перевод '{tranclations}' удалено");
                                }
                            }
                        }
                        else if (options[selectedOption] == "3. Выход в главное меню")
                        {
                            Menu();
                            return;
                        }
                        Console.ReadKey();
                        Menu();
                        return;
                    default:
                        Console.WriteLine("\nНекорректный выбор");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void SearchTranslation()
        {
            Console.WriteLine("Введите название файла словаря: ");
            string file = Console.ReadLine();
            string[] fileContent = File.ReadAllLines(file);
            Console.Clear();
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine();
            Console.Write("Перевод: ");
            foreach (string line in fileContent)
            {
                if (line.Contains(word))
                {
                    Console.WriteLine(line.Replace(word + " - ", ""));
                }
            }
        }
        static void ExportWord()
        {
            Console.WriteLine("Введите название файла словаря: ");
            string file = Console.ReadLine();
            string[] fileContent = File.ReadAllLines(file);
            Console.Clear();
            Console.WriteLine("Введите слово для экспорта: ");
            string word = Console.ReadLine();
            Console.WriteLine("Введите название файла для экспорта: ");
            string exportFile = Console.ReadLine();
            foreach (string line in fileContent)
            {
                if (line.Contains(word))
                {
                    File.WriteAllText(exportFile, line);
                    Console.WriteLine("Слово " + word + "и его перевод/ы экспортированны в файл " + exportFile);
                }
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
        
    }
}

