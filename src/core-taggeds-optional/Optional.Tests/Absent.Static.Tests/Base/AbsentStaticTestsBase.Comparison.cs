using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class AbsentStaticTestsBase<T>
{
    [Test]
    public void Comparison_Compare_OfAndDefault_ExpectTrue()
    {
        var actual = Absent.Compare(Absent.Of<T>(), default(Absent<T>));
        Assert.That(actual, Is.Zero);
    }

    [Test]
    public void Comparison_Compare_OfAndNew_ExpectTrue()
    {
        var actual = Absent.Compare(new Absent<T>(), default(Absent<T>));
        Assert.That(actual, Is.Zero);
    }
}
