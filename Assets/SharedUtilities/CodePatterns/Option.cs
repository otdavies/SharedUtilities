namespace Psyfer.Patterns
{
    /// Rustlike Type: Option<T>
    /// Used in situations where you want to return a value or not.
    public struct Option<T>
    {
        // Error state (panic)
        private static readonly System.Exception panic = new("Option is none");

        // Internal value
        private readonly T value;

        // If we have Some or none
        public bool Some { get { return value != null; } }
        public bool None { get { return value == null; } }

        /// <summary>
        /// Used when we want to unwrap a value once we know it's Some.
        /// </summary>
        public T Unwrap()
        {
            if (value == null)
            {
                throw panic;
            }
            return value;
        }

        public Option(T value)
        {
            this.value = value;
        }

        public static implicit operator Option<T>(T value)
        {
            return new Option<T>(value);
        }

        public static implicit operator T(Option<T> option)
        {
            if (option.Some) return option.value;
            else throw panic;
        }

        public static implicit operator bool(Option<T> option)
        {
            return option.Some;
        }
    }
}
