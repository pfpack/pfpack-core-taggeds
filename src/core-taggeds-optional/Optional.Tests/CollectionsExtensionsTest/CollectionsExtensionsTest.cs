#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Taggeds.Tests
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

        private static Mock<IFunc<T, bool>> CreateMockPredicate<T>(
            Func<T, bool> valueFunction)
        {
            var mock = new Mock<IFunc<T, bool>>();

            _ = mock
                .Setup(p => p.Invoke(It.IsAny<T>()))
                .Returns(valueFunction);

            return mock;
        }

        private static SomeException CreateSomeException()
            => new SomeException();
    }
}
