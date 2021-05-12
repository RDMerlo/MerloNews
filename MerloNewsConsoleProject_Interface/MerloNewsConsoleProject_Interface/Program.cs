using MerloNewsConsoleProject_Interface.NewsClasses;
using System;
using System.IO;

namespace MerloNewsConsoleProject_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            folderPath += "\\MerloNews";

            //если папки нет, то выход
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Ошибка. Не удалось найти папку.");
                Console.ReadKey();
                return;
            }

            string path = folderPath + "\\NewsFile.xml";

            //Если файла нет, то выход
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine("Ошибка. Не удалось найти файл.");
                Console.ReadKey();
                return;
            }

            var provider = new NewsStatusEventObservable(path);
            var observer = new Observer();

            observer.Subscribe(provider);

            Console.ReadKey();
        }
    }
}
