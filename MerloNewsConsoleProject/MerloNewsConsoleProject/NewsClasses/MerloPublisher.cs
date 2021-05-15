using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MerloNewsConsoleProject.NewsClasses
{
    public class MerloPublisher
    {
        /// Путь до документа XML
        private string _filepath; // Путь до документа XML

        private XmlDocument xDoc; //Объект для работы с XML документом
        private XmlElement xRoot; //Объект, для работы с корневым узлом XML документа

        private int ColNews; // количество статей до загрузки новых статей

        /// Конструктор
        public MerloPublisher(string filename)
        {
            _filepath = filename;
            ColNews = 0;
        }

        /// Открытие документа
        public bool OpenNewsDocument()
        {
            try
            {
                xDoc = new XmlDocument();
                xDoc.Load(_filepath); //открытие документа
                // получим корневой элемент
                xRoot = xDoc.DocumentElement;

                return true;
            }
            catch
            {
                Console.WriteLine("Error Open File!\n");
                return false;
            }
        }

        /// Загрузить и вернуть новые статьи из документа
        public List<string> NewNews()
        {
            List<string> result = new List<string>();

            xDoc.Load(_filepath); //открываем документ
            // получим корневой элемент
            xRoot = xDoc.DocumentElement;

            int colNews = xRoot.SelectNodes("article").Count; //получаем количество узлов article в документе
            //если в документе стало больше статей, то загружаем новые
            if (colNews > ColNews)
            {
                //вернуть список всех узлов article
                XmlNodeList elemList = xRoot.GetElementsByTagName("article");

                for (int i = ColNews; i < colNews; i++)
                {
                    //загружаем новые статьи
                    result.Add(elemList[i].InnerText);
                }

                ColNews = colNews; //изменяем количество статей после загрузки данных
            }
            return result; //возвращаем новые статьи
        }
    }
}
