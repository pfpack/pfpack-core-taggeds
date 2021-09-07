#nullable enable

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static int InnerShortenIndex(long index) => unchecked((int)index);
    }
}
