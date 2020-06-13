#nullable enable

namespace System
{
    public interface ISamenessEquatable<T>
    {
        bool Same(in T other);

        int GetSamenessHashCode();
    }
}
