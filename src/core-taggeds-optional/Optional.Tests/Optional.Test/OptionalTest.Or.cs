using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Or_OtherFactoryIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.Or(null!));
        Assert.AreEqual("otherFactory", ex!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Or_SourceIsPresent_ExpectSourceValue(
        object? sourceValue)
    {
        var source = Optional<object?>.Present(sourceValue);
        var other = Optional<object?>.Absent;

        var actual = source.Or(() => other);
        Assert.AreEqual(source, actual);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void Or_SourceIsAbsent_ExpectOtherValue(
        bool isOtherPresent)
    {
        var source = Optional<RefType>.Absent;
        var other = isOtherPresent ? Optional<RefType>.Present(MinusFifteenIdRefType) : default;

        var actual = source.Or(() => other);
        Assert.AreEqual(other, actual);
    }

    [Test]
    public void OrAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await source.OrAsync(null!));
        Assert.AreEqual("otherFactoryAsync", ex!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public async Task OrAsync_SourceIsPresent_ExpectSourceValue(
        object? sourceValue)
    {
        var source = Optional<object?>.Present(sourceValue);
        var other = Optional<object?>.Absent;

        var actual = await source.OrAsync(() => Task.FromResult(other));
        Assert.AreEqual(source, actual);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task OrAsync_SourceIsAbsent_ExpectOtherValue(
        bool isOtherPresent)
    {
        var source = Optional<RefType?>.Absent;
        var other = isOtherPresent ? Optional<RefType?>.Present(MinusFifteenIdRefType) : default;

        var actual = await source.OrAsync(() => Task.FromResult(other));
        Assert.AreEqual(other, actual);
    }

    [Test]
    public void OrValueAsync_OtherFactoryAsyncIsNull_ExpectArgumentNullException()
    {
        var source = Optional<StructType>.Present(SomeTextStructType);

        var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await source.OrValueAsync(null!));
        Assert.AreEqual("otherFactoryAsync", ex!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public async Task OrValueAsync_SourceIsPresent_ExpectSourceValue(
        object? sourceValue)
    {
        var source = Optional<object?>.Present(sourceValue);
        var other = Optional<object?>.Absent;

        var actual = await source.OrValueAsync(() => ValueTask.FromResult(other));
        Assert.AreEqual(source, actual);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task OrValueAsync_SourceIsAbsent_ExpectOtherValue(
        bool isOtherPresent)
    {
        var source = Optional<string>.Absent;
        var other = isOtherPresent ? Optional<string>.Present(SomeString) : Optional<string>.Absent;

        var actual = await source.OrValueAsync(() => ValueTask.FromResult(other));
        Assert.AreEqual(other, actual);
    }
}
