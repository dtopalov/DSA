// This code is distributed under MIT license. Copyright (c) 2013 George Mamaladze
// See license.txt or http://opensource.org/licenses/mit-license.php

namespace WordFinder.Trie
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class ConcurrentTrieNode<TValue> : TrieNodeBase<TValue>
    {
        private readonly ConcurrentDictionary<char, ConcurrentTrieNode<TValue>> m_Children;
        private readonly ConcurrentQueue<TValue> m_Values;

        public ConcurrentTrieNode()
        {
            this.m_Children = new ConcurrentDictionary<char, ConcurrentTrieNode<TValue>>();
            this.m_Values = new ConcurrentQueue<TValue>();
        }


        protected override int KeyLength
        {
            get { return 1; }
        }

        protected override IEnumerable<TValue> Values()
        {
            return this.m_Values;
        }

        protected override IEnumerable<TrieNodeBase<TValue>> Children()
        {
            return this.m_Children.Values;
        }

        protected override void AddValue(TValue value)
        {
            this.m_Values.Enqueue(value);
        }

        protected override TrieNodeBase<TValue> GetOrCreateChild(char key)
        {
            return this.m_Children.GetOrAdd(key, new ConcurrentTrieNode<TValue>());
        }

        protected override TrieNodeBase<TValue> GetChildOrNull(string query, int position)
        {
            if (query == null) throw new ArgumentNullException("query");
            ConcurrentTrieNode<TValue> childNode;
            return
                this.m_Children.TryGetValue(query[position], out childNode)
                    ? childNode
                    : null;
        }
    }
}