namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static int InnerShorten(this long index) => unchecked((int)index);
    }
}
