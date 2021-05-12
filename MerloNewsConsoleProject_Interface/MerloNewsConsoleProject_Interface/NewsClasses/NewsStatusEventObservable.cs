using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace MerloNewsConsoleProject_Interface.NewsClasses
{
    public class NewsStatusEventObservable: IObservable<string>, IDisposable
    {
        /// <summary>
        /// Наши события
        /// </summary>
        private readonly List<IObserver<string>> _observers;

        private readonly Timer _timer;

        private readonly MerloPublisher _merloPublisher; //отслеживание новостей

        private void CheckNewNews(Object sourse, ElapsedEventArgs e)
        {
            foreach (var news in _merloPublisher.NewNews()) //DeletedFiles
            {
                foreach (var observer in _observers)
                {
                    observer.OnNext(news);
                }
            }
        }

        public NewsStatusEventObservable(string filename)
        {
            _observers = new List<IObserver<string>>();
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

        public IDisposable Subscribe(IObserver<string> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }
    }
}
