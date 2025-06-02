using System;
using System.Collections.Generic;
using System.Dynamic;

namespace VSSystem
{
    public class TComparer
    {
        public static IEqualityComparer<T> Create<T>(Func<T, T, bool> equalityFunc)
        {
            if (equalityFunc == null)
                throw new NotImplementedException();
            return new PEqualityComparer<T>(equalityFunc, null);
        }
        public static IEqualityComparer<T> Create<T>(Func<T, T, bool> equalityFunc, Func<T, int> getHashCodeFunc)
        {
            if (equalityFunc == null)
                throw new NotImplementedException();
            return new PEqualityComparer<T>(equalityFunc, getHashCodeFunc);
        }
        public static IComparer<T> Create<T>(Func<T, T, int> compareFunc)
        {
            if (compareFunc == null)
                throw new NotImplementedException();
            return new PComparer<T>(compareFunc);
        }
        class PEqualityComparer<T> : IEqualityComparer<T>
        {
            readonly Func<T, int> _getHashCodeFunc;
            readonly Func<T, T, bool> _equalityFunc;
            public PEqualityComparer(Func<T, T, bool> equalityFunc, Func<T, int> getHashCodeFunc)
            {
                _equalityFunc = equalityFunc;
                _getHashCodeFunc = getHashCodeFunc;
            }
            public bool Equals(T x, T y)
            {
                return _equalityFunc.Invoke(x, y);
            }

            public int GetHashCode(T obj)
            {
                if (_getHashCodeFunc == null)
                    return base.GetHashCode();
                return _getHashCodeFunc.Invoke(obj);
            }
        }
        class PComparer<T> : IComparer<T>
        {
            readonly Func<T, T, int> _compareFunc;
            public int Compare(T x, T y)
            {
                return _compareFunc.Invoke(x, y);
            }
            public PComparer(Func<T, T, int> compareFunc)
            {
                _compareFunc = compareFunc;
            }
        }
    }
}
