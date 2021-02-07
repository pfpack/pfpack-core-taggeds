#nullable enable

using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitExtensionsObsoleteTests
    {
        [Test]
        [TestCase("System.InvokeThenToUnitActionExtensions")]
        [TestCase("System.InvokeThenToUnitFuncAsyncExtensions")]
        [TestCase("System.InvokeThenToUnitValueAsyncExtensions")]
        public void ExtensionsClass_ExpectIsObsolete(string fullName)
        {
            var type = typeof(Unit).Assembly.GetType(
                fullName,
                throwOnError: false,
                ignoreCase: false);

            Assert.IsNotNull(type);
            Assert.IsTrue(type!.Attributes.HasFlag(TypeAttributes.Public));
            Assert.IsTrue(type!.Attributes.HasFlag(TypeAttributes.Sealed));
            Assert.IsEmpty(type.GetConstructors());

            Assert.IsTrue(
                type.CustomAttributes.Any(
                    attr
                    =>
                    attr.AttributeType == typeof(ObsoleteAttribute) &&
                    attr.ConstructorArguments.Count == 2 &&
                    attr.ConstructorArguments[0].ArgumentType == typeof(string) &&
                    attr.ConstructorArguments[1].ArgumentType == typeof(bool) &&
                    attr.ConstructorArguments[1].Value is true));
        }
    }
}
