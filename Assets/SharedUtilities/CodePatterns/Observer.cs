using System;
using System.Collections.Generic;

namespace Psyfer.Patterns
{
    public interface IListen<T>
    {
        void Subscribe(IObserve<T> observer);
        void Unsubscribe(IObserve<T> observer);
    }

    public interface INotify<T>
    {
        void Notify(T value);
    }

    public interface IObserve<T>
    {
        void OnChange(T value);
    }

    public abstract class Observable<T> : IListen<T>, INotify<T>
    {
        protected readonly List<IObserve<T>> observers = new();

        public virtual void Subscribe(IObserve<T> observer)
        {
            observers.Add(observer);
        }

        public virtual void Unsubscribe(IObserve<T> observer)
        {
            observers.Remove(observer);
        }

        public virtual void Notify(T value)
        {
            foreach (var observer in observers)
            {
                observer.OnChange(value);
            }
        }
    }

    public class Observer<T> : IObserve<T>
    {
        private readonly Action<T> onChange;

        public Observer(Action<T> onChange)
        {
            this.onChange = onChange;
        }

        public void OnChange(T value)
        {
            onChange(value);
        }
    }
}
