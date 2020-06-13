#nullable enable

namespace System
{
    partial struct Unit
    {
        public static Unit FromResult<TResult>(in TResult result) => default;
    }
}
