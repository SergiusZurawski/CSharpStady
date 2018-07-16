using System;
using System.Collections;
using System.Collections.Generic;
// https://mycodingplace.wordpress.com/2017/07/19/csharp-behind-the-scenes-yield/					
public class YealdImplementation
{
	public static void Example()
	{
      
		
	}

    public IEnumerable<int> ExampleEnumerableOriginal()
    {
        var arr = new int[] { 1, 2, 3 };
        foreach (var i in arr)
        {
            yield return i;
        }
    }

    //Is compliled to this: 
    public IEnumerable<int> ExampleEnumerable()
    {
        YealdImplementation.YeildGeneratedCode yeildExample = new YealdImplementation.YeildGeneratedCode(-2);
        yeildExample._this = this;
        return (IEnumerable<int>)yeildExample;
    }

    class YeildGeneratedCode : IEnumerable<int>, IEnumerable, IEnumerator<int>, IDisposable, IEnumerator
    {
        private int _state; // The state of the enumerator. see explanation later. 
        private int _current; // The current item
        private readonly int _initialThreadId; // For thread safety. see GetEnumerator later.
        public YealdImplementation _this; // This is the variable that saving the instance of the original code. In this case its Yield object and not YeildGeneratedCode object
        private int[] _collection; //The collection with items to enumerate
        private int _index; // Index of the current enumeration

        int IEnumerator<int>.Current => _current; // Return the current item (last item the has set in the last MoveNext call)

        object IEnumerator.Current => (object)_current;

        public YeildGeneratedCode(int state)
        {
            // Initialize a new Enumerable. The state set to -2, meaning the
            // enumerator hasn't create yet and set the thread id for thread safety
            _state = state;
            _initialThreadId = Environment.CurrentManagedThreadId;
        }

        void IDisposable.Dispose()
        {
            // Use if needed
        }

        bool IEnumerator.MoveNext()
        {
            switch (_state)
            {
                case 0: // Initialized. Change to running and initialize the collection and the index
                    _state = -1;
                    _collection = new int[] { 1, 2, 3 };
                    _index = 0;
                    break;
                case 1: // Suspend. Change to running and increase the index
                    _state = -1;
                    _index++;
                    break;
                default: // Other states
                    return false;
            }
            if (_index < _collection.Length)
            {
                // If there is a items, set current and change state to suspend
                _current = _collection[_index];
                _state = 1;
                return true;
            }
            _collection = null;
            return false;
        }

        void IEnumerator.Reset()
        {
            // This is not the real implementation, 
            // I just show you an example of what you can do here. 
            // The regular implementation is to throw NotSupported exception
            _state = 0;
            _index = 0;
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            YeildGeneratedCode yeildGeneratedCode;
            if (_state == -2 && _initialThreadId == Environment.CurrentManagedThreadId)
            {
                // If the enumerator yet not created and the the 
                // original thread is same as the current calling thread, 
                // change the state to initialized and return this
                _state = 0;
                yeildGeneratedCode = this;
            }
            else
            {
                // In other case, return a new Enumerator
                yeildGeneratedCode = new YeildGeneratedCode(0);
                yeildGeneratedCode._this = _this;
            }
            return yeildGeneratedCode;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>)this).GetEnumerator();
        }
    }

}
