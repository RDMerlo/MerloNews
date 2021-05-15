using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace MerloNewsConsoleProject_Interface.NewsClasses
{
    public class NewsStatusEventObservable: IObservable<string>, IDisposable
    {
        private readonly List<IObserver<string>> _observers; //подписчики

        private readonly Timer _timer;

        private readonly MerloPublisher _merloPublisher; //отслеживание новостей

        private void CheckNewNews(Object sourse, ElapsedEventArgs e)
        {
            //получаем список новых новостей
            foreach (var news in _merloPublisher.NewNews())
            {
                foreach (var observer in _observers)
                {
                    observer.OnNext(news); //отправляем подписчикам новость
                }
            }
        }

        public NewsStatusEventObservable(string filename)
        {
            _observers = new List<IObserver<string>>();
            _merloPublisher = new MerloPublisher(filename);

            //запуск таймера для мониторинга за новыми новостями
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
        //добавление нового подписчика
        public IDisposable Subscribe(IObserver<string> observer)
        {
            //если такого подписчика нет, то добавляем его
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer); //возвращаем объект типа IDisposable от класса Unsubscriber
        }
    }
}
