﻿#nullable enable

using NUnit.Framework;
using System;
using System.Collections.Generic;
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
            IReadOnlyCollection<MethodInfo> methods = typeof(Unit)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == nameof(Unit.ToResult))
                .ToArray();

            Assert.AreEqual(1, methods.Count);

            Assert.IsTrue(
                methods.All(
                    method => method.CustomAttributes.Any(
                        attr
                        =>
                        attr.AttributeType == typeof(ObsoleteAttribute) &&
                        attr.ConstructorArguments.Count == 2 &&
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