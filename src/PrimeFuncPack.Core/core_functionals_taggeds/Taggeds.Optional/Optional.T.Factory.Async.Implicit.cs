#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public static implicit operator Task<Optional<T>>(in Optional<T> optional)
            =>
            optional.ThisAsync();

        public static implicit operator ValueTask<Optional<T>>(in Optional<T> optional)
            =>
            optional.ThisValueAsync();
    }
}
