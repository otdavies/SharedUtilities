using System;
using UnityEngine;

namespace Psyfer.Patterns
{
    public interface Responsbility<T>
    {
        bool CanHandle(T value);
        T Handle(T value);
    }

    public abstract class Handler<T>
    {
        protected Handler<T> successor;
        protected Responsbility<T> responsibility;

        public Handler(Responsbility<T> responsability)
        {
            this.responsibility = responsability;
        }

        public void SetSuccessor(Handler<T> successor)
        {
            this.successor = successor;
        }

        public virtual T HandleRequest(T request)
        {
            if (responsibility.CanHandle(request))
            {
                return responsibility.Handle(request);
            }
            else if (successor != null)
            {
                return successor.HandleRequest(request);
            }

            throw new Exception("No handler found");
        }
    }
}
