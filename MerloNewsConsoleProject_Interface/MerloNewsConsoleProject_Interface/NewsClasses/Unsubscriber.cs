using System;
using System.Collections.Generic;
using System.Text;

namespace MerloNewsConsoleProject_Interface.NewsClasses
{
    public class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<string>> _observers; //список наблюдателей
        private readonly IObserver<string> _observer; //наблюдатель

        public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            //если наблюдатель не ноль и он есть в списке наблюдателей, то освобождаем память
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
