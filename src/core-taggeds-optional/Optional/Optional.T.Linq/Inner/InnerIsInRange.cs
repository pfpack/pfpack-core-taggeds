#nullable enable

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static bool InnerIsInRange(int index, int count) => index >= 0 && index < count;
    }
}
