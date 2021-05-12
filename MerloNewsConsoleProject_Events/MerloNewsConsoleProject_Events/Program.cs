using MerloNewsConsoleProject_Event.NewsClasses;
using System;
using System.IO;

namespace MerloNewsConsoleProject_Events
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

            var eventObserver = new NewsStatusEvent(path);

            var subscriber1 = new MerloSubscriber("Petrov");
            var subscriber2 = new MerloSubscriber("Ivanov");

            eventObserver.NewsArticle += subscriber1.ItIsSecondSubscriber;
            eventObserver.NewsArticle += subscriber2.ItIsSecondSubscriber;

            Console.ReadKey();

            Console.WriteLine("-- Отписка от сообщений --");
            eventObserver.NewsArticle -= subscriber2.ItIsSecondSubscriber;

            Console.ReadKey();
        }
    }
}
