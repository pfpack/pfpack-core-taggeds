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
        public void ForEachIndex_SourceIsNull_ExpectArgumentNullException()
        {
            IReadOnlyList<StructType> source = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => source.ForEach((int index, StructType _) => { }));
            Assert.AreEqual("source", ex.ParamName);
        }

        [Test]
        public void ForEachIndex_ActionIsNull_ExpectArgumentNullException()
        {
            var source = CreateReadOnlyList(PlusFifteenIdRefType);
            Action<int, RefType> action = null!;

            var ex = Assert.Throws<ArgumentNullException>(() => source.ForEach(action));
            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void ForEachIndex_SourceIsEmpty_ExpectNeverCallAction()
        {
            var source = CreateReadOnlyList<RefType?>();
            var mockAction = MockActionFactory.CreateMockAction<int, RefType?>();

            source.ForEach(mockAction.Object.Invoke);
            mockAction.Verify(a => a.Invoke(It.IsAny<int>(), It.IsAny<RefType?>()), Times.Never);
        }

        [Test]
        public void ForEachIndex_SourceCountIsTwo_ExpectCallActionTwoTimes()
        {
            var source = CreateReadOnlyList(SomeTextStructType, NullTextStructType);
            var mockAction = MockActionFactory.CreateMockAction<int, StructType>();

            source.ForEach(mockAction.Object.Invoke);

            mockAction.Verify(a => a.Invoke(0, source[0]), Times.Once);
            mockAction.Verify(a => a.Invoke(1, source[1]), Times.Once);
        }

        [Test]
        public void ForEachIndex_SourceListIsEmpty_ExpectNeverCallAction()
        {
            var source = CreateList<RefType>();
            var mockAction = MockActionFactory.CreateMockAction<int, RefType>();

            source.ForEach(mockAction.Object.Invoke);
            mockAction.Verify(a => a.Invoke(It.IsAny<int>(), It.IsAny<RefType>()), Times.Never);
        }

        [Test]
        public void ForEachIndex_SourceListCountIsTwo_ExpectCallActionTwoTimes()
        {
            var source = CreateList(SomeTextStructType, NullTextStructType);
            var mockAction = MockActionFactory.CreateMockAction<int, StructType>();

            source.ForEach(mockAction.Object.Invoke);

            mockAction.Verify(a => a.Invoke(0, source[0]), Times.Once);
            mockAction.Verify(a => a.Invoke(1, source[1]), Times.Once);
        }

        [Test]
        public void ForEachIndex_SourceCollectionIsEmpty_ExpectNeverCallAction()
        {
            var source = CreateCollection<RefType?>();
            var mockAction = MockActionFactory.CreateMockAction<int, RefType?>();

            source.ForEach(mockAction.Object.Invoke);
            mockAction.Verify(a => a.Invoke(It.IsAny<int>(), It.IsAny<RefType?>()), Times.Never);
        }

        [Test]
        public void ForEachIndex_SourceCollectionContainsTwoItems_ExpectCallActionTwoTimes()
        {
            var source = CreateList(SomeTextStructType, default);
            var mockAction = MockActionFactory.CreateMockAction<int, StructType>();

            source.ForEach(mockAction.Object.Invoke);

            mockAction.Verify(a => a.Invoke(0, source[0]), Times.Once);
            mockAction.Verify(a => a.Invoke(1, source[1]), Times.Once);
        }
    }
}
