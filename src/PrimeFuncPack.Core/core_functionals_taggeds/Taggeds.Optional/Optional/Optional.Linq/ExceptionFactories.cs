#nullable enable

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        private static InvalidOperationException CreateMoreThanOneElementException()
            =>
            new InvalidOperationException("The collection contains more than one element.");

        private static InvalidOperationException CreateMoreThanOneMatchException()
            =>
            new InvalidOperationException("The collection contains more than one element matching to the predicate.");
    }
}
