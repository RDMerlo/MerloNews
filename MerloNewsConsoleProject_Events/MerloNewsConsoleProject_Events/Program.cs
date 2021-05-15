using MerloNewsConsoleProject_Event.NewsClasses;
using System;
using System.IO;

namespace MerloNewsConsoleProject_Events
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

            NewsStatusEvent eventObserver = new NewsStatusEvent(path);
            //два подписчика
            MerloSubscriber subscriber1 = new MerloSubscriber("Petrov");
            MerloSubscriber subscriber2 = new MerloSubscriber("Ivanov");
            //подписка
            eventObserver.NewsArticle += subscriber1.ItIsSubscriber;
            eventObserver.NewsArticle += subscriber2.ItIsSubscriber;

            Console.ReadKey();

            Console.WriteLine("-- Отписка Ivanov-а от сообщений --");
            eventObserver.NewsArticle -= subscriber2.ItIsSubscriber;

            Console.ReadKey();
        }
    }
}
