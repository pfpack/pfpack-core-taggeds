#nullable enable

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static InvalidOperationException InnerCreateMoreThanOneElementException()
            =>
            new("The collection contains more than one element.");

        private static InvalidOperationException InnerCreateMoreThanOneMatchException()
            =>
            new("The collection contains more than one element matching to the predicate.");
    }
}
