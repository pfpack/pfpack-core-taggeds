#nullable enable

using System;

namespace PrimeFuncPack.Extensions.System.Linq.Internal
{
    partial class InternalCollectionsExtensions
    {
        private static Exception CreateMoreThanOneElementException()
            =>
            new InvalidOperationException("The collection contains more than one element.");

        private static Exception CreateMoreThanOneMatchException()
            =>
            new InvalidOperationException("The collection contains more than one element matching the predicate.");
    }
}
