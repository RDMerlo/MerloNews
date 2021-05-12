using MerloNewsConsoleProject_Interface.NewsClasses;
using System;

namespace MerloNewsConsoleProject_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "F://vevit//OneDrive//Study//Practics//Coursework//DesignPattern//MerloNews//NewsFiles//NewsFile.xml";

            var provider = new NewsStatusEventObservable(path);
            var observer = new Observer();

            observer.Subscribe(provider);

            Console.ReadKey();
        }
    }
}
