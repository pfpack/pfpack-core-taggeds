#nullable enable

namespace System
{
    public interface ISamenessPossessor<T>
    {
        bool Same(in T other);

        int SamenessHashCode();
    }
}
