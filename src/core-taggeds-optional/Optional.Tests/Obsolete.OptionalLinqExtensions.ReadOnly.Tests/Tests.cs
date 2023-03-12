using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

[Obsolete("These cases test obsolete public ReadOnly-based methods of the Optional Linq.")]
public sealed partial class ObsoleteReadOnlyOptionalLinqExtensionsTests
{
    private static IReadOnlyList<T> CreateReadOnlyList<T>(
        params T[] items)
        =>
        new StubReadOnlyList<T>(items);

    private static SomeException CreateSomeException()
        =>
        new();
}
