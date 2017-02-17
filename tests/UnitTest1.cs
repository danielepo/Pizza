using System;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void APizzaIsAGrid()
        {
            var pizza = new Pizza(10, 30);
            Assert.That(pizza.R, Is.EqualTo(10));
            Assert.That(pizza.C, Is.EqualTo(30));
        }
        [TestCase(-1, 2)]
        [TestCase(-1, -2)]
        [TestCase(1, -2)]
        public void APizzaDoesntHaveNegativePositions(int r, int c)
        {
            var pizza = new Pizza(10, 30);
            Assert.Throws<IndexOutOfRangeException>(() => pizza.GetCell(r, c));
        }
        [TestCase(10, 9)]
        [TestCase(9, 10)]
        [TestCase(10, 10)]
        public void APizzaDoesntGoesOutsideOfBouds(int r, int c)
        {
            var pizza = new Pizza(10, 10);
            Assert.Throws<IndexOutOfRangeException>(() => pizza.GetCell(r, c));
        }
        [TestCase(9, 8)]
        [TestCase(5, 5)]
        [TestCase(0, 0)]
        public void CanGetAPizzaInASpecificPosition(int r, int c)
        {
            var pizza = new Pizza(10, 10);
            var cell = pizza.GetCell(r, c);
            Assert.That(cell.R, Is.EqualTo(r));
            Assert.That(cell.C, Is.EqualTo(c));
        }
        [Test]
        public void ACellHasRowAndColumn()
        {
            var cell = new Cell(0, 0);
            Assert.That(cell.R, Is.EqualTo(0));
            Assert.That(cell.C, Is.EqualTo(0));
        }
    }

    public class Pizza
    {
        public int R { get; }
        public int C { get; }

        public Pizza(int r, int c)
        {
            R = r;
            C = c;
        }

        public Cell GetCell(int r, int c)
        {
            if (r < 0 || c < 0 || r >= R || c >= C)
                throw new IndexOutOfRangeException();

            return new Cell(r,c);
        }
    }

    public class Cell
    {
        public int R { get; }
        public int C { get; }

        public Cell(int r, int c)
        {
            R = r;
            C = c;
        }
    }
}
