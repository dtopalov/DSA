namespace BiDictionary
{
    using System;
    public class CompositeKey<T1, T2> : IComparable<CompositeKey<T1, T2>>
    {
        public CompositeKey(T1 firstKey, T2 secondKey)
        {
            this.FirstKey = firstKey;
            this.SecondKey = secondKey;
        }

        public T1 FirstKey { get; set; }

        public T2 SecondKey { get; set; }

        public int CompareTo(CompositeKey<T1, T2> other)
        {
            if (this.FirstKey.Equals(other.FirstKey) && this.SecondKey.Equals(other.SecondKey))
            {
                return 0;
            }

            return 1;
        }

        public override string ToString()
        {
            return string.Format("(First: {0}, Second: {1})", this.FirstKey, this.SecondKey);
        }
    }
}
