#nullable enable

using PrimeFuncPack.UnitTest.Data;
using System.Text.RegularExpressions;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class DataGeneratorTests
    {
        private const string UrlTemplate = @"^((http|ftp|https):\/\/)?([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:\/~+#-]*[\w@?^=%&\/~+#-])?";
        private const string EmailTemplate = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        [Fact]
        public void GenerateUrl_ExpectSomeUrl()
        {
            var actual = DataGenerator.GenerateUrl();
            var isUrl = Regex.IsMatch(actual, UrlTemplate);

            Assert.True(isUrl);
        }

        [Fact]
        public void GenerateEmail_ExpectSomeEmail()
        {
            var actual = DataGenerator.GenerateEmail();
            var isEmail = Regex.IsMatch(actual, EmailTemplate);

            Assert.True(isEmail);
        }
    }
}
