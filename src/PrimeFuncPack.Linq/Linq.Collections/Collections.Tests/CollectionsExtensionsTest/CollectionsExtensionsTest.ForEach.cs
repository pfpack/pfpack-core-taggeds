#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Linq.Collections.Tests
{
    partial class CollectionsExtensionsTest
    {
        [Test]
        public void ForEach_SourceIsNull_ExpectArgumentNullException()
        {
            IEnumerable<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => source.ForEach(_ => { }));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void ForEach_ActionIsNull_ExpectArgumentNullException()
        {
            {
                var source = CreateReadOnlyList(PlusFifteenIdRefType);
                Action<RefType> action = null!;

                var ex = Assert.Throws<ArgumentNullException>(() => source.ForEach(action));
                Assert.AreEqual("action", ex.ParamName);
            }

            {
                IEnumerable<RefType> source = CreateReadOnlyList(PlusFifteenIdRefType);
                Action<RefType> action = null!;

                var ex = Assert.Throws<ArgumentNullException>(() => source.ForEach(action));
                Assert.AreEqual("action", ex.ParamName);
            }
        }

        [Test]
        public void ForEach_SourceReadOnlyListIsEmpty_ExpectNeverCallAction()
        {
            {
                var source = CreateReadOnlyList<StructType>();
                var mockAction = MockActionFactory.CreateMockAction<StructType>();

                source.ForEach(mockAction.Object.Invoke);
                mockAction.Verify(a => a.Invoke(It.IsAny<StructType>()), Times.Never);
            }

            {
                IEnumerable<StructType> source = CreateReadOnlyList<StructType>();
                var mockAction = MockActionFactory.CreateMockAction<StructType>();

                source.ForEach(mockAction.Object.Invoke);
                mockAction.Verify(a => a.Invoke(It.IsAny<StructType>()), Times.Never);
            }
        }

        [Test]
        public void ForEach_SourceListIsEmpty_ExpectNeverCallAction()
        {
            var source = CreateList<RefType>();
            var mockAction = MockActionFactory.CreateMockAction<RefType>();

            source.ForEach(mockAction.Object.Invoke);
            mockAction.Verify(a => a.Invoke(It.IsAny<RefType>()), Times.Never);
        }

        [Test]
        public void ForEach_SourceListCountIsTwo_ExpectCallActionTwoTimes()
        {
            var source = CreateList(ZeroIdRefType, MinusFifteenIdRefType);
            var mockAction = MockActionFactory.CreateMockAction<RefType>();

            source.ForEach(mockAction.Object.Invoke);

            mockAction.Verify(a => a.Invoke(source[0]), Times.Once);
            mockAction.Verify(a => a.Invoke(source[1]), Times.Once);
        }

        [Test]
        public void ForEach_SourceCollectionIsEmpty_ExpectNeverCallAction()
        {
            var source = CreateCollection<StructType>();
            var mockAction = MockActionFactory.CreateMockAction<StructType>();

            source.ForEach(mockAction.Object.Invoke);
            mockAction.Verify(a => a.Invoke(It.IsAny<StructType>()), Times.Never);
        }

        [Test]
        public void ForEach_SourceCollectionContainsThreeItems_ExpectCallActionThreeTimes()
        {
            var source = CreateList<StructType?>(SomeTextStructType, null, default(StructType));
            var mockAction = MockActionFactory.CreateMockAction<StructType?>();

            source.ForEach(mockAction.Object.Invoke);

            mockAction.Verify(a => a.Invoke(source[0]), Times.Once);
            mockAction.Verify(a => a.Invoke(source[1]), Times.Once);
            mockAction.Verify(a => a.Invoke(source[2]), Times.Once);
        }
    }
}
