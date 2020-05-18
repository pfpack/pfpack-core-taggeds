#nullable enable

namespace PrimeFuncPack.Extensions.Primitives
{
    public interface ISamenessPossessor<T>
    {
        bool Same(in T other);

        int SamenessHashCode();
    }
}
