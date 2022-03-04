using System;
using System.Collections.Generic;

namespace Psyfer.Patterns
{
    public interface IListen<T>
    {
        void Subscribe(Action<T> observer);
        void Unsubscribe(Action<T> observer);
    }

    public interface INotify<T>
    {
        void Notify(T value);
    }

    public abstract class Observable<T> : IListen<T>, INotify<T>
    {
        protected readonly List<Action<T>> observers = new();

        public void Subscribe(Action<T> observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(Action<T> observer)
        {
            observers.Remove(observer);
        }

        public void Notify(T value)
        {
            foreach (var observer in observers)
            {
                observer(value);
            }
        }
    }
}
