namespace BiDictionary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class BiDictionary<T1, T2, T3> : IEnumerable<KeyValuePair<T1, ICollection<Triple<T1, T2, T3>>>>
        where T3 : IComparable
    {
        private readonly MultiDictionary<T1, Triple<T1, T2, T3>> firstKeyValueMultiDictionary;
        private readonly MultiDictionary<T2, Triple<T1, T2, T3>> secondKeyValueMultiDictionary;
        private readonly MultiDictionary<CompositeKey<T1, T2>, Triple<T1, T2, T3>> compositeKeyValueMultiDictionary; 

        public BiDictionary(MultiDictionary<T1, Triple<T1, T2, T3>> firstKeyValueMultiDictionary, MultiDictionary<T2, Triple<T1, T2, T3>> secondKeyValueMultiDictionary, MultiDictionary<CompositeKey<T1, T2>, Triple<T1, T2, T3>> compositeKeyValueMultiDictionary)
        {
            this.firstKeyValueMultiDictionary = firstKeyValueMultiDictionary ?? new MultiDictionary<T1, Triple<T1, T2, T3>>(true);
            this.secondKeyValueMultiDictionary = secondKeyValueMultiDictionary ?? new MultiDictionary<T2, Triple<T1, T2, T3>>(true);
            this.compositeKeyValueMultiDictionary = compositeKeyValueMultiDictionary ?? new MultiDictionary<CompositeKey<T1, T2>, Triple<T1, T2, T3>>(true);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.firstKeyValueMultiDictionary.GetEnumerator();
        }

        public void AddByFirstKey(KeyValuePair<T1, Triple<T1, T2, T3>> item)
        {
            this.firstKeyValueMultiDictionary.Add(item.Key, item.Value);
            this.secondKeyValueMultiDictionary.Add(item.Value.SecondKey, item.Value);
            this.compositeKeyValueMultiDictionary.Add(
                new CompositeKey<T1, T2>(
                    item.Key, item.Value.SecondKey),
                    item.Value);
        }

        public void AddBySecondKey(KeyValuePair<T2, Triple<T1, T2, T3>> item)
        {
            this.firstKeyValueMultiDictionary.Add(item.Value.FirstKey, item.Value);
            this.secondKeyValueMultiDictionary.Add(item.Key, item.Value);
            this.compositeKeyValueMultiDictionary.Add(
                new CompositeKey<T1, T2>(
                    item.Value.FirstKey, item.Key),
                    item.Value);
        }

        public void AddByCompositeKey(KeyValuePair<CompositeKey<T1, T2>, Triple<T1, T2, T3>> item)
        {
            this.firstKeyValueMultiDictionary.Add(item.Value.FirstKey, item.Value);
            this.secondKeyValueMultiDictionary.Add(item.Value.SecondKey, item.Value);
            this.compositeKeyValueMultiDictionary.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            this.firstKeyValueMultiDictionary.Clear();
            this.secondKeyValueMultiDictionary.Clear();
            this.compositeKeyValueMultiDictionary.Clear();
        }

        public bool ContainsByFirstKey(KeyValuePair<T1, Triple<T1, T2, T3>> item)
        {
            return this.firstKeyValueMultiDictionary.Contains(item.Key, item.Value);
        }

        public bool ContainsBySecondKey(KeyValuePair<T2, Triple<T1, T2, T3>> item)
        {
            return this.secondKeyValueMultiDictionary.Contains(item.Key, item.Value);
        }

        public bool ContainsByCompositeKey(KeyValuePair<CompositeKey<T1, T2>, Triple<T1, T2, T3>> item)
        {
            return this.compositeKeyValueMultiDictionary.Contains(item.Key, item.Value);
        }

        public bool RemoveByFirstKey(KeyValuePair<T1, Triple<T1, T2, T3>> item)
        {
            this.secondKeyValueMultiDictionary.Remove(item.Value.SecondKey, item.Value);
            this.compositeKeyValueMultiDictionary.Remove(new CompositeKey<T1, T2>(item.Key, item.Value.SecondKey), item.Value);
            return this.firstKeyValueMultiDictionary.Remove(item.Key, item.Value);
        }

        public bool RemoveBySecondKey(KeyValuePair<T2, Triple<T1, T2, T3>> item)
        {
            this.firstKeyValueMultiDictionary.Remove(item.Value.FirstKey, item.Value);
            this.compositeKeyValueMultiDictionary.Remove(new CompositeKey<T1, T2>(item.Value.FirstKey, item.Key), item.Value);
            return this.secondKeyValueMultiDictionary.Remove(item.Key, item.Value);
        }

        public bool RemoveByCompositeKey(KeyValuePair<CompositeKey<T1, T2>, Triple<T1, T2, T3>> item)
        {
            this.secondKeyValueMultiDictionary.Remove(item.Value.SecondKey, item.Value);
            this.compositeKeyValueMultiDictionary.Remove(item.Key, item.Value);
            return this.firstKeyValueMultiDictionary.Remove(item.Value.FirstKey, item.Value);
        }

        public int Count
        {
            get
            {
                return this.firstKeyValueMultiDictionary.Count;
            }
        }

        public bool ContainsFirstKey(T1 key)
        {
            return this.firstKeyValueMultiDictionary.ContainsKey(key);
        }

        public bool ContainsSecondKey(T2 key)
        {
            return this.secondKeyValueMultiDictionary.ContainsKey(key);
        }

        public bool ContainsCompositeKey(CompositeKey<T1, T2> key)
        {
            return this.compositeKeyValueMultiDictionary.ContainsKey(key);
        }

        public void AddByFirstKey(T1 key, Triple<T1, T2, T3> value)
        {
            this.firstKeyValueMultiDictionary.Add(key, value);
            this.secondKeyValueMultiDictionary.Add(value.SecondKey, value);
            this.compositeKeyValueMultiDictionary.Add(new CompositeKey<T1, T2>(key, value.SecondKey), value);
        }

        public void AddBySecondKey(T2 key, Triple<T1, T2, T3> value)
        {
            this.firstKeyValueMultiDictionary.Add(value.FirstKey, value);
            this.secondKeyValueMultiDictionary.Add(key, value);
            this.compositeKeyValueMultiDictionary.Add(new CompositeKey<T1, T2>(value.FirstKey, key), value);
        }

        public void AddByCompositeKey(CompositeKey<T1, T2> key, Triple<T1, T2, T3> value)
        {
            this.firstKeyValueMultiDictionary.Add(key.FirstKey, value);
            this.secondKeyValueMultiDictionary.Add(key.SecondKey, value);
            this.compositeKeyValueMultiDictionary.Add(key, value);
        }

        IEnumerator<KeyValuePair<T1, ICollection<Triple<T1, T2, T3>>>> IEnumerable<KeyValuePair<T1, ICollection<Triple<T1, T2, T3>>>>.GetEnumerator()
        {
            return this.firstKeyValueMultiDictionary.GetEnumerator();
        }

        public ICollection<Triple<T1, T2, T3>> this[T1 key]
        {
            get
            {
                return this.firstKeyValueMultiDictionary[key];
            }
            set
            {
                this.firstKeyValueMultiDictionary[key] = value;
            }
        }

        public ICollection<T1> KeysT1
        {
            get
            {
                return this.firstKeyValueMultiDictionary.Keys;
            }
        }

        public ICollection<T2> KeysT2
        {
            get
            {
                return this.secondKeyValueMultiDictionary.Keys;
            }
        }

        public ICollection<CompositeKey<T1, T2>> KeysComposite
        {
            get
            {
                return this.compositeKeyValueMultiDictionary.Keys;
            }
        }

        public ICollection<Triple<T1, T2, T3>> Values
        {
            get
            {
                return this.firstKeyValueMultiDictionary.Values;
            }
        }
    }
}
