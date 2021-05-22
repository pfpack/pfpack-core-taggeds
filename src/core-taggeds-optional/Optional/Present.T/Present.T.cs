#nullable enable

namespace System
{
    public partial struct Present<T> : IEquatable<Present<T>>
    {
        private readonly T value;
    }
}
