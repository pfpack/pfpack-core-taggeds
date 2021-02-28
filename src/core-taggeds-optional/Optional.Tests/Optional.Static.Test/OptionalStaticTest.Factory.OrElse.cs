#nullable enable

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace PrimeFuncPack.Core.Tests
{
    partial class OptionalStaticTest
    {
        [Test]
        public void PresentOrElse_ExpectIsObsolete()
        {
            const string expectedObsoleteMessage
                = "This method is not intended for use. Call Present and then FilterNotNull or FilterNotNullThenMap instead.";

            IReadOnlyCollection<MethodInfo> methods = typeof(Optional)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == nameof(Optional.PresentOrElse))
                .ToArray();

            Assert.AreEqual(2, methods.Count);

            Assert.IsTrue(
                methods.All(
                    method => method.CustomAttributes.Any(
                        attr
                        =>
                        attr.AttributeType == typeof(ObsoleteAttribute) &&
                        attr.ConstructorArguments.Count == 2 &&
                        attr.ConstructorArguments[0].ArgumentType == typeof(string) &&
                        attr.ConstructorArguments[0].Value is expectedObsoleteMessage &&
                        attr.ConstructorArguments[1].ArgumentType == typeof(bool) &&
                        attr.ConstructorArguments[1].Value is true)));

            Assert.IsTrue(
                methods.All(
                    method => method.CustomAttributes.Any(
                        attr
                        =>
                        attr.AttributeType == typeof(DoesNotReturnAttribute))));
        }
    }
}
