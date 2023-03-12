using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void Equality_Static_Equals_NewAndDefault_ExpectTrue()
    {
        var actual = Absent<T>.Equals(new Absent<T>(), default);
        Assert.True(actual);
    }

    [Test]
    public void Equality_Static_Equals_ValueAndDefault_ExpectTrue()
    {
        var actual = Absent<T>.Equals(Absent<T>.Value, default);
        Assert.True(actual);
    }

    [Test]
    public void Equality_Static_EqualityOperator_NewAndDefault_ExpectTrue()
    {
        var actual = new Absent<T>() == default;
        Assert.True(actual);
    }

    [Test]
    public void Equality_Static_EqualityOperator_ValueAndDefault_ExpectTrue()
    {
        var actual = Absent<T>.Value == default;
        Assert.True(actual);
    }

    [Test]
    public void Equality_Static_InequalityOperator_NewAndDefault_ExpectFalse()
    {
        var actual = new Absent<T>() != default;
        Assert.False(actual);
    }

    [Test]
    public void Equality_Static_InequalityOperator_ValueAndDefault_ExpectFalse()
    {
        var actual = Absent<T>.Value != default;
        Assert.False(actual);
    }
}
