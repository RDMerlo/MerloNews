using System;
using System.Collections.Generic;
using System.Text;

namespace MerloNewsConsoleProject.NewsClasses
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
                    _name = "User";
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
    }
}
