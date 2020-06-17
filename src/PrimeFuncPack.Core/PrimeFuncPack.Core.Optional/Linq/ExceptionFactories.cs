#nullable enable

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        private static Func<Exception> GetMoreThanOneElementExceptionFactory()
            =>
            () => new InvalidOperationException("The collection contains more than one element.");

        private static Func<Exception> GetMoreThanOneMatchExceptionFactory()
            =>
            () => new InvalidOperationException("The collection contains more than one element matching to the predicate.");
    }
}
