using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MerloNewsConsoleProject_Interface.NewsClasses
{
    public class MerloPublisher
    {
        private string _filepath;
        private XmlDocument xDoc;
        private XmlElement xRoot;

        public int ColNews;
        public MerloPublisher(string filename)
        {
            _filepath = filename;
            ColNews = 0;
        }

        public bool OpenNewsDocument()
        {
            try
            {
                xDoc = new XmlDocument();
                xDoc.Load(_filepath);
                // получим корневой элемент
                xRoot = xDoc.DocumentElement;
                ColNews = xRoot.SelectNodes("article").Count;
                return true;
            }
            catch
            {
                Console.WriteLine("Error Open File!\n");
                return false;
            }
        }

        public List<string> NewNews()
        {
            List<string> result = new List<string>();

            xDoc.Load(_filepath);
            // получим корневой элемент
            xRoot = xDoc.DocumentElement;

            int colNews = xRoot.SelectNodes("article").Count;

            if (colNews > ColNews)
            {
                XmlElement root = xDoc.DocumentElement;
                XmlNodeList elemList = root.GetElementsByTagName("article");

                for (int i = ColNews; i < colNews; i++)
                {
                    result.Add(elemList[i].InnerText);
                }

                ColNews = colNews;
            }

            return result; //возвращаем новые новости
        }
    }
}
