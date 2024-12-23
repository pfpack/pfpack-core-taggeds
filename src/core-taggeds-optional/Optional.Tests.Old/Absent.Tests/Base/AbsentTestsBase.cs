using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

public abstract partial class AbsentTestsBase<T>
{

    private static IEnumerable<Absent<T>> AbsentCaseSource
    {
        get
        {
            yield return default;
            yield return new();
            yield return Absent<T>.Value;
        }
    }
}
