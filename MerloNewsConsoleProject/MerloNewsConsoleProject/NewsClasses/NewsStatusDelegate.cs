using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace MerloNewsConsoleProject.NewsClasses
{
    public class NewsStatusDelegate: IDisposable
    {
        /// Наш делегат
        private readonly Action<string> _subscriber;

        private readonly Timer _timer; //таймер

        private readonly MerloPublisher _merloPublisher; //отслеживание новостей

        private void CheckNewNews(Object sourse, ElapsedEventArgs e)
        {
            foreach (var news in _merloPublisher.NewNews()) //DeletedFiles
            {
                _subscriber(news);
            }
        }

        public NewsStatusDelegate(string filename, Action<string> subscriber)
        {
            _subscriber = subscriber;
            _merloPublisher = new MerloPublisher(filename);

            //если документ открылся
            if (_merloPublisher.OpenNewsDocument())
            {
                //создаём таймер и передаём метод для проверки новых статей
                _timer = new Timer(1000);
                _timer.Elapsed += CheckNewNews;
                _timer.Start();
            }
            else
            {
                Console.WriteLine("Sorry. Error.");
                Dispose();
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
