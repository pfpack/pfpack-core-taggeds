#nullable enable

namespace System
{
    partial struct Unit
    {
        public static TResult ToResult<TResult>(Unit unit, TResult result)
            =>
            unit switch { _ => result };
    }
}
