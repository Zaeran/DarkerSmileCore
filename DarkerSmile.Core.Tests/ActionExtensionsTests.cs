using System;
using NUnit.Framework;
namespace DarkerSmile.Core.Tests
{
    [TestFixture]
    public class ActionExtensionsTests
    {
        [Test]
        public void Given_Null_When_Fire_Then_DoesNotThrow()
        {
            Action ar = null;
            Assert.DoesNotThrow(ar.Fire);
        }

        [Test]
        public void Given_Null_When_FireWithParam_Then_DoesNotThrow()
        {
            Action<string> ar = null;
            Assert.DoesNotThrow(() => ar.Fire("lol"));
        }

        [Test]
        public void Given_Value_When_Fire_Then_Fires()
        {
            var fired = false;
            Action ar = () => fired = true;
            Assert.DoesNotThrow(ar.Fire);
            Assert.IsTrue(fired);
        }

        [Test]
        public void Given_Value_When_FireWithParam_Then_Fires()
        {
            var vm = "";
            Action<string> ar = s => vm = s;
            ar.Fire("ABC");
            Assert.AreEqual("ABC", vm);
        }



        [Test]
        public void Given_Null_WhenFuncFire_Then_DoesNotThrow()
        {
            Func<string> ar = null;
            Assert.DoesNotThrow(() => ar.Fire());
        }

        [Test]
        public void Given_Value_WhenFuncFire_Then_Fires()
        {
            var vm = "";
            Func<string> ar = () => "ABC";
            vm = ar.Fire();
            Assert.AreEqual("ABC", vm);
        }

        [Test]
        public void Given_Null_WhenFuncWithParamFire_Then_DoesNotThrow()
        {
            Func<string, string> ar = null;
            Assert.DoesNotThrow(() => ar.Fire("Blah"));
        }

        [Test]
        public void Given_Value_WhenFuncWithParamFire_Then_Fires()
        {
            var vm = "";
            Func<string, string> ar = a => "ABC" + a;
            vm = ar.Fire("DEF");
            Assert.AreEqual("ABCDEF", vm);
        }
    }
}
