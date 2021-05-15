using System;
using System.IO;
using System.Xml;

namespace AddNewsToXMLConsoleApp
{
    class Program
    {
        static bool CreateDirectory(ref string folderPath)
        {
            try
            {
                //получаем путь к Документам
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                folderPath += "\\MerloNews";
                //если папки нет, то пытаемся создать
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                return true;
            }
            catch
            {
                Console.WriteLine("Не удалось создать папку.");
                Console.ReadKey();
                return false;
            }      
        }

        static bool CreateXMLDoc(ref XmlDocument doc, string filePath)
        {
            try
            {
                /*<?xml version="1.0" encoding="utf-8" ?> */
                //создание объявления (декларации) документа
                //добавляем в документ
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);

                XmlElement xRoot = doc.CreateElement("news");
                //добавляем в документ
                doc.AppendChild(xRoot);
                doc.Save(filePath);
                return true;
            }
            catch
            {
                Console.WriteLine("Не удалось создать файл.");
                Console.ReadKey();
                return false;
            }
        }

        static void Main(string[] args)
        {
            XmlDocument Doc = new XmlDocument();
            
            string folderPath = "";
            string filePath;

            //Создание папки, если её нет
            if (!CreateDirectory(ref folderPath))
                return;

            filePath = folderPath + "\\" + "NewsFile.xml";

            //Если файла нет, то пытаемся создать
            if (!System.IO.File.Exists(filePath))
                if (!CreateXMLDoc(ref Doc, filePath))
                    return;

            Doc.Load(filePath);
            //Console.WriteLine("Количество узлов: {0}", Doc.SelectNodes("news/article").Count);
            // получим корневой элемент
            XmlElement xRoot = Doc.DocumentElement;
            // обход всех узлов в корневом элементе
            string textMessage;

            Console.WriteLine("Нажмите enter, чтобы выйти.");
            do
            {
                try
                {
                    Console.Write("Введите сообщение: ");
                    textMessage = Console.ReadLine();

                    if (textMessage != "")
                    {
                        XmlElement companyElem = Doc.CreateElement("article");
                        XmlText companyText = Doc.CreateTextNode(textMessage);

                        companyElem.AppendChild(companyText);
                        xRoot.AppendChild(companyElem);
                        Doc.Save(filePath);
                    }
                    else
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произршла непредвиденная ошибка!\n{ex.Message}\n\nНажмите enter чтобы продолжить.");
                    Console.ReadKey();
                }
            }
            while (true);
        }
    }
}
