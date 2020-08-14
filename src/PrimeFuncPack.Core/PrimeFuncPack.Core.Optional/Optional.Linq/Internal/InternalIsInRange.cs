#nullable enable

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        private static bool InternalIsInRange(in int index, in int count) => index >= 0 && index < count;
    }
}
