using System.Collections.Generic;
using System.Linq;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncTestCaseSources
{
    private static IEnumerable<object?[]> InnerBuildSource<T>(this IEnumerable<T> source)
        =>
        source.Select(item => new object?[] { item });
}
