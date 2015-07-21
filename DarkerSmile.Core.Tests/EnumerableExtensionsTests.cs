using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DarkerSmile.Core.Tests
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void Given_List_When_ButFirst_Then_ReturnsListShortFirstElement()
        {
            const string a = "a";
            const string b = "b";
            const string c = "c";

            var l = new List<string> {a, b, c};

            var result = l.ButFirst().ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(b, result[0]);
            Assert.AreEqual(c, result[1]);
        }

        [Test]
        public void Given_List_When_ButLast_Then_ReturnsListShortLastElement()
        {
            const string a = "a";
            const string b = "b";
            const string c = "c";

            var l = new List<string> {a, b, c};

            var result = l.ButLast().ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(a, result[0]);
            Assert.AreEqual(b, result[1]);
        }

        [Test]
        public void Given_SingleElementList_When_ButFirst_Then_ReturnsEmptyList()
        {
            const string a = "a";
            var l = new List<string> {a};

            var result = l.ButFirst().ToList();
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void Given_ValidList_When_ToDisplayString_ReturnsString()
        {
            const string result = "[a, b, c]";
            var a = new List<string> {"a", "b", "c"};
            Assert.AreEqual(result, a.ToDisplayString());
        }

        [Test]
        public void Given_EmptyList_When_ToDisplayString_ReturnsEmptyBoxString()
        {
            const string result = "[]";
            var a = new List<string>();
            Assert.AreEqual(result, a.ToDisplayString());
        }

        [Test]
        public void Given_NullList_When_ToDisplayString_ReturnsNullString()
        {
            const string result = "null";
            List<string> a = null;
            Assert.AreEqual(result, a.ToDisplayString());
        }

        [Test]
        public void Given_ValidList_When_RandomOne_ReturnOne()
        {
            const string a = "a";
            const string b = "b";
            const string c = "c";
            var l = new List<string> {a, b, c};
            List<string> nl = null;
            var rand = "";
            Assert.DoesNotThrow(() => rand = l.GetRandomOne());
            Assert.Contains(rand, l);
        }

        [Test]
        public void Given_ValidList_When_RandomX_ReturnX()
        {
            const string a = "a";
            const string b = "b";
            const string c = "c";
            var l = new List<string> {a, b, c};
            IEnumerable<string> rand = new List<string>();
            Assert.DoesNotThrow(() => rand = l.GetRandomX(4));
            Assert.AreEqual(4, rand.Count());
        }

        [Test]
        public void Given_EmptyList_When_RandomOne_ReturnDefault()
        {
            var l = new List<string>();
            var rand = "";
            Assert.DoesNotThrow(() => rand = l.GetRandomOne());
            Assert.IsNull(rand);
        }

        [Test]
        public void Given_EmptyList_When_RandomX_ReturnEmptyList()
        {
            var l = new List<string>();
            IEnumerable<string> rand = new List<string>();
            Assert.DoesNotThrow(() => rand = l.GetRandomX(4));
            Assert.AreEqual(0, rand.Count());
        }

        [Test]
        public void Given_SingleItemList_When_RandomOne_ReturnSingle()
        {
            var l = new List<string> {"a"};
            var rand = "";
            Assert.DoesNotThrow(() => rand = l.GetRandomOne());
            Assert.AreEqual("a", rand);
        }

        [Test]
        public void Given_SingleItemList_When_RandomX_ReturnSingle()
        {
            var l = new List<string> {"a"};
            IList<string> rand = new List<string>();
            Assert.DoesNotThrow(() => rand = l.GetRandomX(4).ToList());
            Assert.AreEqual(4, rand.Count);
            for (var i = 0; i < 4; i++)
            {
                Assert.AreEqual("a", rand[i]);
            }
        }

        [Test]
        public void Given_ValidList_When_RandomXMinusAmount_ThrowsOutOfRange()
        {
            const string a = "a";
            const string b = "b";
            const string c = "c";
            var l = new List<string> {a, b, c};
            IEnumerable<string> rand = new List<string>();
            Assert.Throws<ArgumentOutOfRangeException>(() => rand = l.GetRandomX(-4));
        }

        [Test]
        public void Given_NullList_When_RandomX_ThrowsArgumentNull()
        {
            List<string> l = null;
            IEnumerable<string> rand = new List<string>();
            Assert.Throws<ArgumentNullException>(() => rand = l.GetRandomX(3));
        }

        [Test]
        public void Given_StringList_When_MaxByLength_ReturnsLongestWord()
        {
            const string a = "sup";
            const string b = "my";
            const string c = "world";
            var l = new List<string> {a, b, c};

            var result = l.MaxBy(x => x.Length).ToList();

            Assert.AreEqual(c, result);
        }

        [Test]
        public void Given_StringList_When_MinByLength_ReturnsShortestWord()
        {
            const string a = "sup";
            const string b = "my";
            const string c = "world";
            var l = new List<string> {a, b, c};

            var result = l.MinBy(x => x.Length).ToList();

            Assert.AreEqual(b, result);
        }

        [Test]
        public void Given_ObjectList_When_FilterByType_ReturnsCorrentCount()
        {
            var lst = new List<object>
            {
                new Dog {Name = "Scruffy"},
                new Dog {Name = "Poodle"},
                new Dog {Name = "Barky"},
                new Cat {Name = "SnowBall"},
                new Dog {Name = "Floofy"}
            };

            var dogs = lst.FilterByType<object, Dog>();
            var cats = lst.FilterByType<object, Cat>();
            var pets = lst.FilterByType<object, IPet>();

            Assert.AreEqual(4, dogs.Count());
            Assert.AreEqual(1, cats.Count());
            Assert.AreEqual(5, pets.Count());
        }

        [Test]
        public void Given_ValidList_When_ShiftLeft_Then_ElementsReordered()
        {
            string a = "a", b = "b", c = "c";
            var l = new List<string> {a, b, c};

            l = l.AsShiftedLeft().ToList();

            Assert.AreEqual(b, l[0]);
            Assert.AreEqual(c, l[1]);
            Assert.AreEqual(a, l[2]);

            l = l.AsShiftedLeft().ToList();

            Assert.AreEqual(c, l[0]);
            Assert.AreEqual(a, l[1]);
            Assert.AreEqual(b, l[2]);
        }

        [Test]
        public void Given_ValidList_When_ShiftRight_Then_ElementsReordered()
        {
            string a = "a", b = "b", c = "c";
            var l = new List<string> {a, b, c};

            l = l.AsShiftedRight().ToList();

            Assert.AreEqual(c, l[0]);
            Assert.AreEqual(a, l[1]);
            Assert.AreEqual(b, l[2]);

            l = l.AsShiftedRight().ToList();

            Assert.AreEqual(b, l[0]);
            Assert.AreEqual(c, l[1]);
            Assert.AreEqual(a, l[2]);
        }

        [Test]
        public void Given_ValidEnumeration_When_ToListShuffled_ReturnsShuffled()
        {
            IEnumerable<string> lst = new List<string> {"a", "b", "c", "d"};
            var newList = lst.ToListShuffled();
            Assert.AreEqual(4, newList.Count);
            Assert.AreNotEqual(newList, new List<string> {"a", "b", "c", "d"});
        }

        [Test]
        public void Given_NullEnumeration_When_ToListShuffled_ReturnEmptyList()
        {
            IEnumerable<string> lst = null;
            IList<string> newList = null;
            Assert.DoesNotThrow(() => { newList = lst.ToListShuffled(); });
            Assert.NotNull(newList);
            Assert.AreEqual(0, newList.Count);
        }

        [Test]
        public void Given_UniqueList_When_AllElementsAreUnique_ReturnsTrue()
        {
            var lst = new List<string> {"a", "b", "c", "d", "e"};
            Assert.True(lst.AllElementsAreUnique());
        }

        [Test]
        public void Given_NotUniqueList_When_AllElementsAreUnique_ReturnsTrue()
        {
            var lst = new List<string> {"a", "a", "c", "d", "e"};
            Assert.False(lst.AllElementsAreUnique());
        }

        [Test]
        public void Given_NullList_When_AllElementsAreUnique_ReturnsFalse()
        {
            List<string> lst = null;
            Assert.False(lst.AllElementsAreUnique());
        }

        [Test]
        public void Given_EmptyList_When_AllElementsAreUnique_ReturnsFalse()
        {
            var lst = new List<string>();
            Assert.False(lst.AllElementsAreUnique());
        }

        [Test]
        public void Given_ValidList_When_NoNullElements_ReturnTrue()
        {
            var s = new List<string> {"a", "b", "c"};
            Assert.IsTrue(s.NoNullElements());
        }

        [Test]
        public void Given_ListWithNull_When_NoNullElements_ReturnFalse()
        {
            var s = new List<string> {"a", "b", null, "c"};
            Assert.IsFalse(s.NoNullElements());
        }

        public class Dog : IPet
        {
            public string Name;
        }

        public class Cat : IPet
        {
            public string Name;
        }

        public interface IPet
        {
        }
    }
}