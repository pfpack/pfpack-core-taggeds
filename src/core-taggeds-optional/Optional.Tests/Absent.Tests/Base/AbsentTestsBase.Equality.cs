using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void Equality_Equals_NewAndDefault_ExpectTrue()
    {
        var actual = new Absent<T>().Equals(default);
        Assert.True(actual);
    }

    [Test]
    public void Equality_Equals_ValueAndDefault_ExpectTrue()
    {
        var actual = Absent<T>.Value.Equals(default);
        Assert.True(actual);
    }
}
