using System;
using UnityEngine;

namespace Psyfer.Patterns
{
    public interface IResponsible<T>
    {
        bool IsResponsible(T value);
        T Handle(T value);
    }

    public class ResponsibilityChain<T>
    {
        protected ResponsibilityChain<T> successor;
        protected IResponsible<T> responsibility;

        public ResponsibilityChain(IResponsible<T> responsability)
        {
            this.responsibility = responsability;
        }

        public virtual void SetSuccessor(ResponsibilityChain<T> successor)
        {
            this.successor = successor;
        }

        public virtual T Handle(T request)
        {
            if (responsibility.IsResponsible(request))
            {
                return responsibility.Handle(request);
            }
            else if (successor != null)
            {
                return successor.Handle(request);
            }

            throw new Exception("No handler found");
        }
    }
}
