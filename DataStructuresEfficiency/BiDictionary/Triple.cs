namespace BiDictionary
{
    using System;

    public class Triple<T1, T2, T3> : IComparable<Triple<T1, T2, T3>>
        where T3 : IComparable
    {
        public Triple(T1 x, T2 y, T3 z)
        {
            this.FirstKey = x;
            this.SecondKey = y;
            this.Value = z;
        }

        public T1 FirstKey { get; set; }

        public T2 SecondKey { get; set; }

        public T3 Value { get; set; }

        public int CompareTo(Triple<T1, T2, T3> other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
