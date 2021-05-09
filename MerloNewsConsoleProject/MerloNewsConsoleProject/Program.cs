using MerloNewsConsoleProject.NewsClasses;
using System;

namespace MerloNewsConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "F://vevit//OneDrive//Study//Practics//Coursework//DesignPattern//MerloNews//NewsFiles//NewsFile.xml";
            var newsStatusDelegate = new NewsStatusDelegate(path, new MerloSubscriber(String.Empty).ItIsSubscriber);
            Console.ReadKey();
        }
    }
}
