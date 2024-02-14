using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalLinqExtensionsTests
{
    [Test]
    public void TryGetValueOrAbsent_ExpectIsObsolete()
    {
        const string expectedObsoleteMessage = "This method is not intended for use. Call GetValueOrAbsent instead.";

        IReadOnlyCollection<MethodInfo> methods = typeof(OptionalLinqExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(method => method.Name == nameof(OptionalLinqExtensions.TryGetValueOrAbsent))
            .ToArray();

        Assert.That(
             methods.Count(
                method =>
                method.CustomAttributes.Any(
                    attr
                    =>
                    attr.AttributeType == typeof(DoesNotReturnAttribute)) &&
                method.CustomAttributes.Any(
                    attr
                    =>
                    attr.AttributeType == typeof(ObsoleteAttribute) &&
                    attr.ConstructorArguments.Count == 2 &&
                    attr.ConstructorArguments[0].ArgumentType == typeof(string) &&
                    attr.ConstructorArguments[0].Value is expectedObsoleteMessage &&
                    attr.ConstructorArguments[1].ArgumentType == typeof(bool) &&
                    attr.ConstructorArguments[1].Value is true)),
             Is.EqualTo(1));
    }
}
