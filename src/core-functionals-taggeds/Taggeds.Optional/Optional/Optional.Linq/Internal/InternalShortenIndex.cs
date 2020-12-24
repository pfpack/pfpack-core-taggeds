#nullable enable

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        private static int InternalShortenIndex(long index) => unchecked((int)index);
    }
}
