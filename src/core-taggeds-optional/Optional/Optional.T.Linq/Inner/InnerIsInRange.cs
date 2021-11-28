namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static bool InnerIsInRange(this int index, int count) => index >= 0 && index < count;
    }
}
