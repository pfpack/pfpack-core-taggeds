#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Filter(in Func<T, bool> predicate)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return (box is null || predicate.Invoke(box)) switch
            {
                true => this,
                _ => default
            };
        }
    }
}
