using MerloNewsConsoleProject.NewsClasses;
using System;
using System.IO;

namespace MerloNewsConsoleProject
{
    class Program
    {
        static bool OpenFile(ref string folderPath, ref string path)
        {
            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            folderPath += "\\MerloNews";

            //если папки нет, то выход
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Ошибка. Не удалось найти папку.");
                Console.ReadKey();
                return false;
            }

            path = folderPath + "\\NewsFile.xml";

            //Если файла нет, то выход
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine("Ошибка. Не удалось найти файл.");
                Console.ReadKey();
                return false;
            }

            return true;
        }
 
        static void Main(string[] args)
        {
            string folderPath = "";
            string path = "";

            if (!OpenFile(ref folderPath, ref path))
                return;

            //инцилизируем класс NewsStatusDelegate
            NewsStatusDelegate newsStatusDelegate = new NewsStatusDelegate(path, new MerloSubscriber(String.Empty).ItIsSubscriber);
            Console.ReadKey();
        }
    }
}
