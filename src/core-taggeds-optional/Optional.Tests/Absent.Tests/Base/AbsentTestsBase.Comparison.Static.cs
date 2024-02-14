using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void Comparison_Compare_NewAndDefault_ExpectZero()
    {
        var actual = Absent<T>.Compare(new Absent<T>(), default);
        Assert.That(actual, Is.Zero);
    }

    [Test]
    public void Comparison_Compare_ValueAndDefault_ExpectZero()
    {
        var actual = Absent<T>.Compare(Absent<T>.Value, default);
        Assert.That(actual, Is.Zero);
    }

    [Test]
    public void Comparison_LessThanOrEqualToOperator_NewAndDefault_ExpectTrue()
    {
        var actual = new Absent<T>() <= default(Absent<T>);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Comparison_LessThanOrEqualToOperator_ValueAndDefault_ExpectTrue()
    {
        var actual = Absent<T>.Value <= default(Absent<T>);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Comparison_GreaterThanOrEqualToOperator_NewAndDefault_ExpectTrue()
    {
        var actual = new Absent<T>() >= default(Absent<T>);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Comparison_GreaterThanOrEqualToOperator_ValueAndDefault_ExpectTrue()
    {
        var actual = Absent<T>.Value >= default(Absent<T>);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Comparison_LessThanOperator_NewAndDefault_ExpectFalse()
    {
        var actual = new Absent<T>() < default(Absent<T>);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Comparison_LessThanOperator_ValueAndDefault_ExpectFalse()
    {
        var actual = Absent<T>.Value < default(Absent<T>);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Comparison_GreaterThanOperator_NewAndDefault_ExpectFalse()
    {
        var actual = new Absent<T>() > default(Absent<T>);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Comparison_GreaterThanOperator_ValueAndDefault_ExpectFalse()
    {
        var actual = Absent<T>.Value > default(Absent<T>);
        Assert.That(actual, Is.False);
    }
}
