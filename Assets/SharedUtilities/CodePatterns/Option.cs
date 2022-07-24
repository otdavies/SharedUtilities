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
        private readonly bool isSome;

        // If we have Some or none
        public bool Some { get { return isSome; } }

        /// <summary>
        /// Used when we want to unwrap a value once we know it's Some.
        /// </summary>
        public T Unwrap()
        {
            if (!isSome)
            {
                throw panic;
            }
            return value;
        }

        // Constructor
        public Option(T value)
        {
            if (value == null)
            {
                this.value = default;
                this.isSome = false;
                return;
            }

            this.value = value;
            this.isSome = true;
        }

        // Implicit conversion from T to Option<T>
        public static implicit operator Option<T>(T value)
        {
            return new Option<T>(value);
        }

        // Implicit conversion from Option<T> to T
        public static implicit operator T(Option<T> option)
        {
            if (option.Some) return option.value;
            else throw panic;
        }

        // Implicit conversion from Option<T> to bool
        public static implicit operator bool(Option<T> option)
        {
            return option.Some;
        }
    }
}
