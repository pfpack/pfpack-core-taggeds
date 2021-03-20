#nullable enable

namespace System.Linq
{
    partial class InternalOptionalLinqExtensions
    {
        private static bool InternalIsInRange(int index, int count) => index >= 0 && index < count;
    }
}
