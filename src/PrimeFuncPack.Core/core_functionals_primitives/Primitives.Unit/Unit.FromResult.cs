#nullable enable

namespace System
{
    partial struct Unit
    {
        public static Unit FromResult<TResult>(in TResult result)
            =>
            result switch { _ => default };
    }
}
