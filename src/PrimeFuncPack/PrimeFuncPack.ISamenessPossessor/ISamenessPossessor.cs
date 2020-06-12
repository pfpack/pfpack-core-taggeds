#nullable enable

namespace PrimeFuncPack
{
    public interface ISamenessPossessor<T>
    {
        bool Same(in T other);

        int SamenessHashCode();
    }
}
