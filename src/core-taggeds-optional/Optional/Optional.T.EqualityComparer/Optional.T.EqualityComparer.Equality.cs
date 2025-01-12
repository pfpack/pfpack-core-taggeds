namespace System;

partial struct Optional<T>
{
    partial class EqualityComparer
    {
        public bool Equals(Optional<T> x, Optional<T> y)
        {
            if (x.hasValue != y.hasValue)
            {
                return false;
            }

            if (x.hasValue)
            {
                return comparer.Equals(x.value, y.value);
            }

            return true;
        }

        public int GetHashCode(Optional<T> obj)
        {
            if (obj.hasValue)
            {
                return HashCode.Combine(
                    obj.value is null ? default : comparer.GetHashCode(obj.value));
            }

            return default;
        }
    }
}
