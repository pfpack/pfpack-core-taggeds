using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

public abstract class AbsentTestBase<T>
{
    // Factory

    [Test]
    public void Factory_New_ExpectDefault()
    {
        Assert.AreEqual(default(Absent<T>), new Absent<T>());
    }

    [Test]
    public void Factory_Value_ExpectDefault()
    {
        Assert.AreEqual(default(Absent<T>), Absent<T>.Value);
    }

    // Equality

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

    // Comparison

    [Test]
    public void Comparison_CompareTo_NewAndDefault_ExpectZero()
    {
        var actual = new Absent<T>().CompareTo(default);
        Assert.Zero(actual);
    }

    [Test]
    public void Comparison_CompareTo_ValueAndDefault_ExpectZero()
    {
        var actual = Absent<T>.Value.CompareTo(default);
        Assert.Zero(actual);
    }

    [Test]
    public void Comparison_CompareToObj_NewAndNull_ExpectOne()
    {
        var actual = new Absent<T>().CompareTo(null);
        Assert.Positive(actual);
        Assert.AreEqual(1, actual);
    }

    [Test]
    public void Comparison_CompareToObj_ValueAndNull_ExpectOne()
    {
        var actual = Absent<T>.Value.CompareTo(null);
        Assert.Positive(actual);
        Assert.AreEqual(1, actual);
    }

    [Test]
    public void Comparison_CompareToObj_NewAndDefault_ExpectZero()
    {
        var actual = new Absent<T>().CompareTo((object?)default(Absent<T>));
        Assert.Zero(actual);
    }

    [Test]
    public void Comparison_CompareToObj_ValueAndDefault_ExpectZero()
    {
        var actual = Absent<T>.Value.CompareTo((object?)new Absent<T>());
        Assert.Zero(actual);
    }

    [Test]
    public void Comparison_CompareToObj_NewAndAnotherType_ExpectZero()
    {
        Assert.Throws<ArgumentException>(() => _ = new Absent<T>().CompareTo(new object()));
    }

    [Test]
    public void Comparison_CompareToObj_ValueAndAnotherType_ExpectZero()
    {
        Assert.Throws<ArgumentException>(() => _ = Absent<T>.Value.CompareTo(new object()));
    }
}
