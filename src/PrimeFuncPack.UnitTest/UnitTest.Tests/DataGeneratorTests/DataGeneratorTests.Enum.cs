#nullable enable

using PrimeFuncPack.UnitTest.Data;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class DataGeneratorTests
    {
        [Fact]
        public void GenerateEnum_TypeIsSingletonEnum_ExpectSingleOnlyValue()
        {
            for (var i = 0; i < 100; i++)
            {
                var actual = DataGenerator.GenerateEnum<SingletonEnum>();
                Assert.Equal(SingletonEnum.Single, actual);
            }
        }

        [Fact]
        public void GenerateEnum_TypeIsNumberEnum_ExpectOneOrTwoOrThree()
        {
            for (var i = 0; i < 100; i++)
            {
                var actual = DataGenerator.GenerateEnum<NumberEnum>();
                Assert.True((actual == NumberEnum.One) || (actual == NumberEnum.Two) || (actual == NumberEnum.Three));
            }
        }

        private enum SingletonEnum
        {
            Single
        }

        private enum NumberEnum
        {
            One,
            Two,
            Three
        }
    }
}
