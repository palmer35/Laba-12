using System.Collections;
using laba_10;
namespace Laba_12
{
    public class MyCollection<T> : IEnumerable<T>, IEnumerator<T> where T : Transport
    {
        private readonly List<T> myList;
        private int position = -1;

        public MyCollection()
        {
            myList = new List<T>();
        }

        public MyCollection(MyCollection<T> collection)
        {
            myList = new List<T>();
            foreach (var item in collection)
            {
                myList.AddLast(item);
            }
        }

        public void Add(T item)
        {
            myList.AddLast(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (var item in items)
            {
                myList.AddLast(item);
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < myList.Count)
            {
                myList.RemoveAt(index);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }
        }

        public MyCollection<T> ShallowCopy()
        {
            return new MyCollection<T>(this);
        }

        public void Clear()
        {
            myList.Clear();
        }

        public void PrintListCollection()
        {
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }

        public T Current
        {
            get
            {
                if (position < 0 || position >= myList.Count)
                {
                    throw new InvalidOperationException("Enumerator is not started or ended");
                }
                return myList.Get(position);
            }
        }

        object IEnumerator.Current => Current;
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            position++;
            return position < myList.Count;
        }

        public void Reset()
        {
            position = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
