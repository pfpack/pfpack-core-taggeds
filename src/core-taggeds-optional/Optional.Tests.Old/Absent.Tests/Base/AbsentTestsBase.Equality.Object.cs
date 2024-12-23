using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void Equality_EqualsObject_OtherIsAbsent_NewAndDefault_ExpectTrue()
    {
        var actual = new Absent<T>().Equals((object?)default(Absent<T>));
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Equality_EqualsObject_OtherIsAbsent_ValueAndDefault_ExpectTrue()
    {
        var actual = Absent<T>.Value.Equals((object?)default(Absent<T>));
        Assert.That(actual, Is.True);
    }

    [Test]
    [TestCaseSource(nameof(Equality_EqualsObject_OtherIsRefType_ExpectFalse_CaseSource))]
    public void Equality_EqualsObject_OtherIsRefType_NewAndDefault_ExpectFalse(object? other)
    {
        var actual = new Absent<T>().Equals(other);
        Assert.That(actual, Is.False);
    }

    [Test]
    [TestCaseSource(nameof(Equality_EqualsObject_OtherIsRefType_ExpectFalse_CaseSource))]
    public void Equality_EqualsObject_OtherIsRefType_ValueAndDefault_ExpectFalse(object? other)
    {
        var actual = Absent<T>.Value.Equals(other);
        Assert.That(actual, Is.False);
    }

    private static IEnumerable<object?> Equality_EqualsObject_OtherIsRefType_ExpectFalse_CaseSource
    {
        get
        {
            yield return null;
            yield return new object();
            yield return "";
            yield return "SomeString";
        }
    }
}
