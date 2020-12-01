#nullable enable

using Moq;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
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
                .Setup(d => d.TryGetValue(It.IsAny<TKey>(), out returnedValue))
                .Returns(tryGetValueResult);

            return mock;
        }

        private static Mock<IDictionary<TKey, TValue>> CreateMockDictionary<TKey, TValue>(
            bool tryGetValueResult,
            TValue returnedValue)
        {
            var mock = new Mock<IDictionary<TKey, TValue>>();

            _ = mock
                .Setup(d => d.TryGetValue(It.IsAny<TKey>(), out returnedValue))
                .Returns(tryGetValueResult);

            return mock;
        }
    }
}
