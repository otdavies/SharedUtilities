using System;
using System.Collections.Generic;

namespace Psyfer.Patterns
{
    public interface IMediate<P, T>
    {
        void Register(P participant, Action<P, T> receive);
        void Send(P from, P to, T message);
    }

    public abstract class Mediator<P, T> : IMediate<P, T>
    {
        protected readonly Dictionary<P, Action<P, T>> participants = new();

        public virtual void Register(P participant, Action<P, T> receive)
        {
            if (!participants.ContainsKey(participant))
            {
                participants.Add(participant, receive);
            }
        }

        public virtual void Send(P from, P to, T message)
        {
            if (participants.ContainsKey(from) && participants.ContainsKey(to))
            {
                participants[to].Invoke(from, message);
            }
        }
    }
}
