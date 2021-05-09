using MerloNewsConsoleProject_Event.NewsClasses;
using System;

namespace MerloNewsConsoleProject_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "F://vevit//OneDrive//Study//Practics//Coursework//DesignPattern//MerloNews//NewsFiles//NewsFile.xml";

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
