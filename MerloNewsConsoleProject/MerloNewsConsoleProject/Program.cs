using MerloNewsConsoleProject.NewsClasses;
using System;
using System.IO;

namespace MerloNewsConsoleProject
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

            var newsStatusDelegate = new NewsStatusDelegate(path, new MerloSubscriber(String.Empty).ItIsSubscriber);
            Console.ReadKey();
        }
    }
}
