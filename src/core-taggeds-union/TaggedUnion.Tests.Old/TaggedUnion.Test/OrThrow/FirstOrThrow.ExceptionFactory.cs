﻿using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedUnionTest
{
    [Test]
    public void FirstOrThrowWithFactory_ExceptionFactoryIsNull_ExpectArgumentNullException()
    {
        var source = TaggedUnion<StructType, RefType>.First(SomeTextStructType);

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.FirstOrThrow(null!));
        ClassicAssert.AreEqual("exceptionFactory", ex!.ParamName);
    }

    [Test]
    public void FirstOrThrowWithFactory_SourceIsFirst_ExpectSourceValue()
    {
        var sourceValue = SomeTextStructType;
        TaggedUnion<StructType, RefType> source = sourceValue;

        var resultException = new SomeException();

        var actual = source.FirstOrThrow(() => resultException);
        ClassicAssert.AreEqual(sourceValue, actual);
    }

    [Test]
    public void FirstOrThrowWithFactory_SourceIsSecond_ExpectCreatedException()
    {
        var source = TaggedUnion<StructType, object?>.Second(new object());
        var resultException = new SomeException();

        var actualException = Assert.Throws<SomeException>(
            () => _ = source.FirstOrThrow(() => resultException));

        ClassicAssert.AreSame(resultException, actualException);
    }

    [Test]
    public void FirstOrThrowWithFactory_SourceIsDefault_ExpectInvalidOperationException()
    {
        var source = default(TaggedUnion<int, RefType?>);
        var resultException = new SomeException();

        var actualException = Assert.Throws<SomeException>(
            () => _ = source.FirstOrThrow(() => resultException));

        ClassicAssert.AreSame(resultException, actualException);
    }
}
