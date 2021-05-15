using MerloNewsConsoleProject_Interface.NewsClasses;
using System;
using System.IO;

namespace MerloNewsConsoleProject_Interface
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

            NewsStatusEventObservable provider = new NewsStatusEventObservable(path);
            Observer observer = new Observer(); //подписчик

            observer.Subscribe(provider); //подписка к провайдеру

            Console.ReadKey();
        }
    }
}
