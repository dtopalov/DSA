// This code is distributed under MIT license. Copyright (c) 2013 George Mamaladze
// See license.txt or http://opensource.org/licenses/mit-license.php

namespace WordFinder.PatriciaTree
{
    using System.Diagnostics;

    [DebuggerDisplay("Head: '{CommonHead}', This: '{ThisRest}', Other: '{OtherRest}', Kind: {MatchKind}")]
    public struct ZipResult
    {
        private readonly StringPartition m_CommonHead;
        private readonly StringPartition m_OtherRest;
        private readonly StringPartition m_ThisRest;

        public ZipResult(StringPartition commonHead, StringPartition thisRest, StringPartition otherRest)
        {
            this.m_CommonHead = commonHead;
            this.m_ThisRest = thisRest;
            this.m_OtherRest = otherRest;
        }

        public MatchKind MatchKind
        {
            get
            {
                return this.m_ThisRest.Length == 0
                    ? (this.m_OtherRest.Length == 0
                        ? MatchKind.ExactMatch
                        : MatchKind.IsContained)
                    : (this.m_OtherRest.Length == 0
                        ? MatchKind.Contains
                        : MatchKind.Partial);
            }
        }

        public StringPartition OtherRest
        {
            get { return this.m_OtherRest; }
        }

        public StringPartition ThisRest
        {
            get { return this.m_ThisRest; }
        }

        public StringPartition CommonHead
        {
            get { return this.m_CommonHead; }
        }


        public bool Equals(ZipResult other)
        {
            return 
                this.m_CommonHead == other.m_CommonHead && 
                this.m_OtherRest == other.m_OtherRest &&
                this.m_ThisRest == other.m_ThisRest;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ZipResult && this.Equals((ZipResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.m_CommonHead.GetHashCode();
                hashCode = (hashCode*397) ^ this.m_OtherRest.GetHashCode();
                hashCode = (hashCode*397) ^ this.m_ThisRest.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ZipResult left, ZipResult right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ZipResult left, ZipResult right)
        {
            return !(left == right);
        }
    }
}