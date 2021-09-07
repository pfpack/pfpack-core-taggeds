#nullable enable

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static int InnerShortenIndex(this long index) => unchecked((int)index);
    }
}
