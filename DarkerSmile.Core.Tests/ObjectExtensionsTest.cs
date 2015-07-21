using NUnit.Framework;
namespace DarkerSmile.Core.Tests
{
    [TestFixture]
    public class ObjectExtensionsTest
    {
        /// <summary>
        /// Given NullObject When NullOrDefault Then Returns true
        /// </summary>
        [Test]
        public void Given_Null_When_NullOrDefault_ReturnTrue()
        {
            object o = null;
            Assert.IsTrue(o.NullOrDefault());
        }

        [Test]
        public void Given_Value_When_NullOrDefault_ReturnFalse()
        {
            var obj = new object();
            Assert.IsFalse(obj.NullOrDefault());
        }
    }
}
