#nullable enable

using PrimeFuncPack.Linq.Collections.Tests.Stubs;
using System.Collections.Generic;

namespace PrimeFuncPack.Linq.Collections.Tests
{
    public sealed partial class CollectionsExtensionsTest
    {
        private static IReadOnlyList<T> CreateReadOnlyList<T>(
            params T[] items)
            =>
            new StubReadOnlyList<T>(items);

        private static IList<T> CreateList<T>(
            params T[] items)
            =>
            new StubList<T>(items);

        private static IEnumerable<T> CreateCollection<T>(
            params T[] items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}
