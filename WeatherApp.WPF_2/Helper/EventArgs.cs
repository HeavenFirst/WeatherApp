using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.WPF_2.Helper
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }
}
