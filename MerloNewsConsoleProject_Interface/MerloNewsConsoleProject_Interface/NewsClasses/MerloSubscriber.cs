using System;
using System.Collections.Generic;
using System.Text;

namespace MerloNewsConsoleProject_Interface.NewsClasses
{
    /// <summary>
    /// Класс подписчика
    /// </summary>
    public class MerloSubscriber
    {
        /// <summary>
        /// Имя подписчика
        /// </summary>
        private string _name;
        /// <summary>
        /// Имя
        /// </summary>
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 0)
                    _name = value;
                else
                    _name = "Null";
            }
        }

        public MerloSubscriber(string name)
        {
            Name = name;
        }

        public void ItIsSubscriber(string text)
        {
            Console.WriteLine($"New news: \n{text}\n");
        }

        public void ItIsSubscriber(object sender, string Message)
        {
            Console.WriteLine($"New news: \n{Name}: {Message}\n");
        }

        public void ItIsSecondSubscriber(object sender, string Message)
        {
            Console.WriteLine("-----");
            Console.WriteLine($"New news: \n{Name}: {Message}\n");
            Console.WriteLine("-----");
        }
    }
}
