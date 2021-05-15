using System;
using System.Collections.Generic;
using System.Text;

namespace MerloNewsConsoleProject_Event.NewsClasses
{
    public class MerloSubscriber
    {
        private string _name;
        /// Имя
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

        public void ItIsSubscriber(object sender, string Message)
        {
            Console.WriteLine("-----");
            Console.WriteLine($"New news {sender}: \n{Name}: {Message}\n");
            Console.WriteLine("-----");
        }
    }
}
