#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    public interface ISamenessEquatable<T>
    {
        bool Same([AllowNull] in T other);

        int GetSamenessHashCode();
    }
}
