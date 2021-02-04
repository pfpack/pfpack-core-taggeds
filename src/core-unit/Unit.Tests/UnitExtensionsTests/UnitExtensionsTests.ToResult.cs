#nullable enable

using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitExtensionsTests
    {
        [Test]
        public void ToResult_ExpectIsObsolete()
        {
            var toResultMethodInfo = typeof(UnitExtensions).GetMethod(
                nameof(UnitExtensions.ToResult),
                bindingAttr: BindingFlags.Public | BindingFlags.Static);

            Assert.IsNotNull(toResultMethodInfo);

            Assert.IsTrue(
                toResultMethodInfo!.CustomAttributes.Any(
                    data =>
                    data.AttributeType == typeof(ObsoleteAttribute) &&
                    data.ConstructorArguments.Count == 2 &&
                    data.ConstructorArguments[1].ArgumentType == typeof(bool) &&
                    data.ConstructorArguments[1].Value is true));

            Assert.IsTrue(
                toResultMethodInfo!.CustomAttributes.Any(
                    data => data.AttributeType == typeof(DoesNotReturnAttribute)));
        }
    }
}
