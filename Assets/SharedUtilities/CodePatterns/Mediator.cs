using System;
using System.Collections.Generic;

namespace Psyfer.Patterns
{
    public interface IMediate<P, T>
    {
        void Register(P participantKey, IMediatable<T> participant);
        void Unregister(P participantKey);
        void Send(P to, IMediatable<T> from, T message);
    }

    public interface IMediatable<T>
    {
        void Receive(IMediatable<T> from, T message);
    }

    public class Mediator<P, T> : IMediate<P, T>
    {
        protected readonly Dictionary<P, IMediatable<T>> participants = new();

        public virtual void Register(P participantKey, IMediatable<T> participant)
        {
            if (!participants.ContainsKey(participantKey))
            {
                participants.Add(participantKey, participant);
            }
        }

        public virtual void Unregister(P participantKey)
        {
            if (participants.ContainsKey(participantKey))
            {
                participants.Remove(participantKey);
            }
        }

        public virtual void Send(P to, IMediatable<T> from, T message)
        {
            if (participants.ContainsKey(to))
            {
                participants[to].Receive(from, message);
            }
        }
    }
}
