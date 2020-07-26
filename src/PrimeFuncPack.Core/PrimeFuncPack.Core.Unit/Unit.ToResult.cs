#nullable enable

namespace System
{
    partial struct Unit
    {
        public static TResult ToResult<TResult>(in Unit unit, in TResult result) => result;
    }
}
