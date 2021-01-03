#nullable enable

namespace System.Linq
{
    partial class InternalOptionalLinqExtensions
    {
        private static int InternalShortenIndex(long index) => unchecked((int)index);
    }
}
