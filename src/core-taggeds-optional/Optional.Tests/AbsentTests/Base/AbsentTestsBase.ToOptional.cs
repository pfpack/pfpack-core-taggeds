using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentTestsBase<T>
{
    [Test]
    public void ToOptionalExplicit_FromDefault_ExpectAbsent()
    {
        var optional = default(Absent<T>).ToOptional();

        Assert.IsTrue(optional.IsAbsent);
    }
    [Test]
    public void ToOptionalImplicit_FromDefault_ExpectAbsent()
    {
        Optional<T> optional = default(Absent<T>);

        Assert.IsTrue(optional.IsAbsent);
    }

    [Test]
    public void ToOptionalExplicit_FromNew_ExpectAbsent()
    {
        var optional = new Absent<T>().ToOptional();

        Assert.IsTrue(optional.IsAbsent);
    }
    [Test]
    public void ToOptionalImplicit_FromNew_ExpectAbsent()
    {
        Optional<T> optional = new Absent<T>();

        Assert.IsTrue(optional.IsAbsent);
    }

    [Test]
    public void ToOptionalExplicit_FromValue_ExpectAbsent()
    {
        var optional = Absent<T>.Value.ToOptional();

        Assert.IsTrue(optional.IsAbsent);
    }
    [Test]
    public void ToOptionalImplicit_FromValue_ExpectAbsent()
    {
        Optional<T> optional = Absent<T>.Value;

        Assert.IsTrue(optional.IsAbsent);
    }
}
