using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace MerloNewsConsoleProject_Event.NewsClasses
{
    public class NewsStatusEvent: IDisposable
    {
        /// <summary>
        /// Наши события
        /// </summary>
        public EventHandler<string> NewsArticle;

        private readonly Timer _timer;

        private readonly MerloPublisher _merloPublisher; //отслеживание новостей

        private void CheckNewNews(Object sourse, ElapsedEventArgs e)
        {
            foreach (var news in _merloPublisher.NewNews()) //DeletedFiles
            {
                var handler = NewsArticle;
                handler?.Invoke(this, news);
            }
        }

        public NewsStatusEvent(string filename)
        {
            _merloPublisher = new MerloPublisher(filename);

            //StartMonitoring
            if (_merloPublisher.OpenNewsDocument())
            {
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
