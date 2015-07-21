using NUnit.Framework;

namespace DarkerSmile.Core.Tests
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
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

        [Test]
        public void Given_Null_When_Exists_ReturnFalse()
        {
            object o = null;
            Assert.IsFalse(o.Exists());
        }

        [Test]
        public void Given_Value_When_Exists_ReturnTrue()
        {
            var obj = new object();
            Assert.IsTrue(obj.Exists());
        }

        [Test]
        public void Given_Null_When_DoesNotExist_ReturnTrue()
        {
            object o = null;
            Assert.IsTrue(o.DoesNotExist());
        }

        [Test]
        public void Given_Value_When_DoesNotExist_ReturnFalse()
        {
            var obj = new object();
            Assert.IsFalse(obj.DoesNotExist());
        }

    }
}