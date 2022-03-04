using System;
namespace Psyfer.Patterns
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class Command<T> : ICommand where T : class
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
    }

    /// The situations where we would use this are pretty limited, it is here for completeness.
    public class CommandByValue<T> : ICommand where T : struct
    {
        protected readonly Func<T, T> execute;
        protected readonly Func<T, T> undo;
        protected T value;

        public CommandByValue(T value, Func<T, T> execute, Func<T, T> undo)
        {
            this.value = value;
            this.execute = execute;
            this.undo = undo;
        }

        public virtual void Execute()
        {
            value = execute(value);
        }

        public virtual void Undo()
        {
            value = undo(value);
        }

        public virtual T Value()
        {
            return value;
        }
    }
}
