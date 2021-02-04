#nullable enable

using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitTests
    {
        [Test]
        public void ToResult_ExpectIsObsolete()
        {
            var toResultMethodInfo = typeof(Unit).GetMethod(
                nameof(Unit.ToResult),
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
