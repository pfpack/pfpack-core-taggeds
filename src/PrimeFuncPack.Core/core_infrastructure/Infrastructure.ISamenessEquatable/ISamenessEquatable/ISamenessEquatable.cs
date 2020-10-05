#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    public interface ISamenessEquatable<T>
    {
        bool Same([AllowNull] T other);

        int GetSamenessHashCode();
    }
}
