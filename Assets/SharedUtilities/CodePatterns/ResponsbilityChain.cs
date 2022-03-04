using System;
using UnityEngine;

namespace Psyfer.Patterns
{
    public interface Responsbility<T>
    {
        void CanHandle(T value);
        void Handle(T value);
    }

    public abstract class Handler<T>
    {
        protected Handler<T> successor;
        protected Responsbility<T> responsibility;

        public Handler(Responsbility<T> responsability)
        {
            this.responsibility = responsability;
        }

        public virtual SetSuccessor(Handler<T> successor)
        {
            this.next = successor;
        }

        public virtual void HandleRequest(Responsbility<T> request)
        {
            if (responsibility.CanHandle(request))
            {
                responsibility.Handle(request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}
