using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void Comparison_CompareTo_NewAndDefault_ExpectZero()
    {
        var actual = new Absent<T>().CompareTo(default);
        Assert.That(actual, Is.Zero);
    }

    [Test]
    public void Comparison_CompareTo_ValueAndDefault_ExpectZero()
    {
        var actual = Absent<T>.Value.CompareTo(default);
        Assert.That(actual, Is.Zero);
    }
}
