#nullable enable

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        private static int InternalShortenIndex(in long index) => unchecked((int)index);
    }
}
