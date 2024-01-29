namespace ZedUtils.Utility
{
    public class ListenableProperty<T> where T : notnull
    {
        public delegate void ValueChangedEvent(T value);

        /// <summary>
        /// Event fired when the value changes, including null values
        /// </summary>
        public event ValueChangedEvent? ValueChanged;

        public ListenableProperty(T value)
        {
            _value = value;
        }
        private T _value;

        /// <summary>
        /// Value of this ListenableProperty
        /// </summary>
        public T Value
        {
            get => _value;
            set
            {
                if(value == null) return;
                if(value.Equals(_value))
                {
                    ValueChanged?.Invoke(value);
                    _value = value;
                }
            }
        }

        public static implicit operator T (ListenableProperty<T> current) => current.Value;
        public static implicit operator ListenableProperty<T>(T current) => new(current);
    }

    /// <summary>
    /// Nullable variant of the <c>ListenableProperty&lt;T&gt;</c>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NullableListenableProperty<T>
    {
        public delegate void ValueChangedEvent(T? value);

        /// <summary>
        /// Event fired when the value changes, including null values
        /// </summary>
        public event ValueChangedEvent? ValueChanged;

        public NullableListenableProperty(T? value)
        {
            _value = value;
        }
        private T? _value;

        /// <summary>
        /// Value of this ListenableProperty
        /// </summary>
        public T? Value
        {
            get => _value;
            set
            {
                if(value == null && _value == null) return;
                if(_value == null && value != null)
                {
                    ValueChanged?.Invoke(value);
                    _value = value;
                }
                else if(_value != null && _value.Equals(value)) return;
                else
                {
                    ValueChanged?.Invoke(value);
                    _value = value;
                }
            }
        }

        public static implicit operator T? (NullableListenableProperty<T> current) => current.Value;
        public static implicit operator NullableListenableProperty<T>(T? current) => new(current);
    }
}