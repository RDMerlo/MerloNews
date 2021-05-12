using System;
using System.Collections.Generic;
using System.Text;

namespace MerloNewsConsoleProject_Interface.NewsClasses
{
    class Observer : IObserver<string>
    {
        private IDisposable _unsubscriber;
        public virtual void Subscribe(IObservable<string> provider)
        {
            if (provider != null)
            {
                _unsubscriber = provider.Subscribe(this);
            }
        }

        public virtual void Unsubscriber()
        {
            _unsubscriber.Dispose(); //отписка
        }

        public void OnCompleted()
        {
            Unsubscriber();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"An error was occured: {error.Message}");
        }

        public void OnNext(string value)
        {
            Console.WriteLine($"News: {value}");
        }
    }
}
