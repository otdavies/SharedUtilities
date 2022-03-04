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

        public Command(T state, Action<T> execute, Action<T> undo)
        {
            this.state = state;
            this.execute = execute;
            this.undo = undo;
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
