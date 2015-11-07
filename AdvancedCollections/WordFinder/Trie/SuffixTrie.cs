// This code is distributed under MIT license. Copyright (c) 2013 George Mamaladze
// See license.txt or http://opensource.org/licenses/mit-license.php

namespace WordFinder.Trie
{
    using System.Collections.Generic;
    using System.Linq;

    using WordFinder.PatriciaTree;

    public class SuffixTrie<T> : ITrie<T>
    {
        private readonly Trie<T> m_InnerTrie;
        private readonly int m_MinSuffixLength;

        public SuffixTrie(int minSuffixLength)
            : this(new Trie<T>(), minSuffixLength)
        {
        }

        private SuffixTrie(Trie<T> innerTrie, int minSuffixLength)
        {
            this.m_InnerTrie = innerTrie;
            this.m_MinSuffixLength = minSuffixLength;
        }

        public IEnumerable<T> Retrieve(string query)
        {
            return
                this.m_InnerTrie
                    .Retrieve(query)
                    .Distinct();
        }

        public void Add(string key, T value)
        {
            foreach (string suffix in GetAllSuffixes(this.m_MinSuffixLength, key))
            {
                this.m_InnerTrie.Add(suffix, value);
            }
        }

        private static IEnumerable<string> GetAllSuffixes(int minSuffixLength, string word)
        {
            for (int i = word.Length - minSuffixLength; i >= 0; i--)
            {
                var partition = new StringPartition(word, i);
                yield return partition.ToString();
            }
        }
    }
}