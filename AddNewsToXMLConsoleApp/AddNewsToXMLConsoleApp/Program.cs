using System;
using System.Xml;

namespace AddNewsToXMLConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepatch;
            //filepatch = Console.ReadLine();
            filepatch = "F://vevit//OneDrive//Study//Practics//Coursework//DesignPattern//MerloNews//NewsFiles//NewsFile.xml";

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filepatch);

            Console.WriteLine("Количество узлов: {0}", xDoc.SelectNodes("news/article").Count);


            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе

            //foreach (XmlNode xnode in xRoot)
            //{
            //    // если узел - article
            //    if (xnode.Name == "article")
            //    {
            //        Console.WriteLine($"Сообщение: {xnode.InnerText}");
            //    }
            //}

            XmlElement root = xDoc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName("article");

            for (int i = 0; i < xDoc.SelectNodes("news/article").Count; i++)
            {
                Console.WriteLine(elemList[i].InnerText);
            }
        }
    }
}
