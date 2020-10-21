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
            {
                IReadOnlyList<StructType> source = null!;

                var ex = Assert.Throws<ArgumentNullException>(() => source.ForEach((int index, StructType _) => { }));
                Assert.AreEqual("source", ex.ParamName);
            }

            {
                IEnumerable<StructType> source = null!;

                var ex = Assert.Throws<ArgumentNullException>(() => source.ForEach((int index, StructType _) => { }));
                Assert.AreEqual("source", ex.ParamName);
            }
        }

        [Test]
        public void ForEachIndex_ActionIsNull_ExpectArgumentNullException()
        {
            {
                IReadOnlyList<RefType> source = CreateReadOnlyList(PlusFifteenIdRefType);
                Action<int, RefType> action = null!;

                var ex = Assert.Throws<ArgumentNullException>(() => source.ForEach(action));
                Assert.AreEqual("action", ex.ParamName);
            }

            {
                IEnumerable<RefType> source = CreateReadOnlyList(PlusFifteenIdRefType);
                Action<int, RefType> action = null!;

                var ex = Assert.Throws<ArgumentNullException>(() => source.ForEach(action));
                Assert.AreEqual("action", ex.ParamName);
            }
        }

        [Test]
        public void ForEachIndex_SourceIsEmpty_ExpectNeverCallAction()
        {
            {
                IReadOnlyList<RefType?> source = CreateReadOnlyList<RefType?>();
                var mockAction = MockActionFactory.CreateMockAction<int, RefType?>();

                source.ForEach(mockAction.Object.Invoke);
                mockAction.Verify(a => a.Invoke(It.IsAny<int>(), It.IsAny<RefType?>()), Times.Never);
            }

            {
                IEnumerable<RefType?> source = CreateReadOnlyList<RefType?>();
                var mockAction = MockActionFactory.CreateMockAction<int, RefType?>();

                source.ForEach(mockAction.Object.Invoke);
                mockAction.Verify(a => a.Invoke(It.IsAny<int>(), It.IsAny<RefType?>()), Times.Never);
            }
        }

        [Test]
        public void ForEachIndex_SourceCountIsTwo_ExpectCallActionTwoTimes()
        {
            {
                IReadOnlyList<StructType> source = CreateReadOnlyList(SomeTextStructType, NullTextStructType);
                var mockAction = MockActionFactory.CreateMockAction<int, StructType>();

                source.ForEach(mockAction.Object.Invoke);

                mockAction.Verify(a => a.Invoke(0, source[0]), Times.Once);
                mockAction.Verify(a => a.Invoke(1, source[1]), Times.Once);
            }

            {
                IReadOnlyList<StructType> source = CreateReadOnlyList(SomeTextStructType, NullTextStructType);
                var mockAction = MockActionFactory.CreateMockAction<int, StructType>();

                ((IEnumerable<StructType>)source).ForEach(mockAction.Object.Invoke);

                mockAction.Verify(a => a.Invoke(0, source[0]), Times.Once);
                mockAction.Verify(a => a.Invoke(1, source[1]), Times.Once);
            }
        }

        [Test]
        public void ForEachIndex_SourceListIsEmpty_ExpectNeverCallAction()
        {
            IList<RefType> source = CreateList<RefType>();
            var mockAction = MockActionFactory.CreateMockAction<int, RefType>();

            source.ForEach(mockAction.Object.Invoke);
            mockAction.Verify(a => a.Invoke(It.IsAny<int>(), It.IsAny<RefType>()), Times.Never);
        }

        [Test]
        public void ForEachIndex_SourceListCountIsTwo_ExpectCallActionTwoTimes()
        {
            IList<StructType> source = CreateList(SomeTextStructType, NullTextStructType);
            var mockAction = MockActionFactory.CreateMockAction<int, StructType>();

            ((IEnumerable<StructType>)source).ForEach(mockAction.Object.Invoke);

            mockAction.Verify(a => a.Invoke(0, source[0]), Times.Once);
            mockAction.Verify(a => a.Invoke(1, source[1]), Times.Once);
        }

        [Test]
        public void ForEachIndex_SourceCollectionIsEmpty_ExpectNeverCallAction()
        {
            IEnumerable<RefType?> source = CreateCollection<RefType?>();
            var mockAction = MockActionFactory.CreateMockAction<int, RefType?>();

            source.ForEach(mockAction.Object.Invoke);
            mockAction.Verify(a => a.Invoke(It.IsAny<int>(), It.IsAny<RefType?>()), Times.Never);
        }

        [Test]
        public void ForEachIndex_SourceCollectionContainsTwoItems_ExpectCallActionTwoTimes()
        {
            IList<StructType> source = CreateList(SomeTextStructType, default);
            var mockAction = MockActionFactory.CreateMockAction<int, StructType>();

            ((IEnumerable<StructType>)source).ForEach(mockAction.Object.Invoke);

            mockAction.Verify(a => a.Invoke(0, source[0]), Times.Once);
            mockAction.Verify(a => a.Invoke(1, source[1]), Times.Once);
        }
    }
}
