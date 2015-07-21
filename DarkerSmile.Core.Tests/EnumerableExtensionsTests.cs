using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DarkerSmile.Core.Tests
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        public class Dog : IPet { public string Name; }
        public class Cat : IPet { public string Name; }
        public interface IPet {}

        [Test]
        public void Given_DifferentLists_When_AddUnique_Then_ListContainsUniqueElements()
        {
            var a = new List<string> { "a", "b", "c" };
            var b = new List<string> { "c", "d", "e" };

            a.AddUnique(b);
            Assert.AreEqual(5, a.Count);
            Assert.AreEqual(a,new List<string>{"a","b","c","d","e"});
        }

        [Test]
        public void Given_MatchingLists_When_AddUnique_Then_ListContainsIdenticalElements()
        {
            var a = new List<string> { "a", "b", "c" };
            var b = new List<string> { "a", "b", "c" };

            a.AddUnique(b);
            Assert.AreEqual(3, a.Count);
            Assert.AreEqual(a, new List<string> { "a", "b", "c" });
        }

        [Test]
        public void Given_ListAndNullEnumerable_When_AddUnique_Then_ReturnsOriginalList()
        {
            var a = new List<string> { "a", "b", "c" };
            a.AddUnique(null);
            Assert.AreEqual(3, a.Count);
            Assert.AreEqual(a, new List<string> { "a", "b", "c" });
        }



        [Test]
        public void Given_List_When_ButFirst_Then_ReturnsListShortFirstElement()
        {
            const string a = "a";
            const string b = "b";
            const string c = "c";

            var l = new List<string> { a, b, c };

            var result = l.ButFirst().ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(b, result[0]);
            Assert.AreEqual(c, result[1]);
        }

        [Test]
        public void Given_SingleElementList_When_ButFirst_Then_ReturnsEmptyList()
        {
            const string a = "a";
            var l = new List<string> { a };

            var result = l.ButFirst().ToList();
            Assert.AreEqual(0, result.Count());
        }



    }
}
