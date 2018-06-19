using System;
using System.Collections.Generic;
using System.Linq;

namespace Types
{
    struct NullableExample<T> where T : struct
    {
        private bool hasValue; private T value;

        public NullableExample(T value)
        {
            this.hasValue = true;
            this.value = value;
        }

        public bool HasValue
        {
            get
            {
                return this.hasValue;
            }
        }

        public T Value
        {
            get
            {
                if (!this.HasValue)
                    throw new ArgumentException();
                return this.value;
            }
        }

        public T GetValueOrDefault()
        {
            return this.value;
        }
    }
}
