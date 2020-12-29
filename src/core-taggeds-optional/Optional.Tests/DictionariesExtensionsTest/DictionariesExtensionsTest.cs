#nullable enable

using Moq;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Taggeds.Tests
{
    public sealed partial class DictionariesExtensionsTest
    {
        private static IEnumerable<KeyValuePair<TKey, TValue>> CreatePairsCollection<TKey, TValue>(
            params KeyValuePair<TKey, TValue>[] pairs)
        {
            foreach (var pair in pairs)
            {
                yield return pair;
            }
        }

        private static Mock<IReadOnlyDictionary<TKey, TValue>> CreateMockReadOnlyDictionary<TKey, TValue>(
            bool tryGetValueResult,
            TValue returnedValue)
        {
            var mock = new Mock<IReadOnlyDictionary<TKey, TValue>>();

            _ = mock
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                .Setup(d => d.TryGetValue(It.IsAny<TKey>(), out returnedValue))
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                .Returns(tryGetValueResult);

            return mock;
        }

        private static Mock<IDictionary<TKey, TValue>> CreateMockDictionary<TKey, TValue>(
            bool tryGetValueResult,
            TValue returnedValue)
        {
            var mock = new Mock<IDictionary<TKey, TValue>>();

            _ = mock
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                .Setup(d => d.TryGetValue(It.IsAny<TKey>(), out returnedValue))
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                .Returns(tryGetValueResult);

            return mock;
        }
    }
}
