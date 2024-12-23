using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    [TestCaseSource(nameof(AbsentCaseSource))]
    public void GetHashCode_ExpectCombineEqualityContract(Absent<T> absent)
    {
        var actual = absent.GetHashCode();
        var expected = HashCode.Combine(EqualityComparer<Type>.Default.GetHashCode(typeof(Absent<T>)));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
