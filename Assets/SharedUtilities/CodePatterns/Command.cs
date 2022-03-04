using System;
namespace Psyfer.Patterns
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class Command<T> : ICommand
    {
        protected readonly Action<T> execute;
        protected readonly Action<T> undo;
        protected T state;

        public Command(T state)
        {
            this.state = state;
        }

        public virtual void Execute()
        {
            execute(state);
        }

        public virtual void Undo()
        {
            undo(state);
        }

        public T State
        {
            get => state;
            private set => state = value;
        }
    }
}
