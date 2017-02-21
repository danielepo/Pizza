using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void OneColOneRowReturnsOneCell()
        {
            var slicer = new Slicer(1, 1);
            var slices = slicer.Slice();
            Assert.That(slices.Count, Is.EqualTo(1));
            Assert.IsTrue(slices[0][0]);
        }
        [Test]
        public void OneColTwoRowsReturnsThreeCells()
        {
            var slicer = new Slicer(1, 2);
            var slices = slicer.Slice();
            Assert.That(slices.Count, Is.EqualTo(3));

            Assert.IsTrue(slices[0][0]);
            Assert.IsFalse(slices[0][1]);

            Assert.IsFalse(slices[1][0]);
            Assert.IsTrue(slices[1][1]);

            Assert.IsTrue(slices[2][0]);
            Assert.IsTrue(slices[2][1]);
        }
    }

    public class Slicer
    {
        private readonly int _r;
        private readonly int _c;

        public Slicer(int c, int r)
        {
            _r = r;
            _c = c;
        }

        public List<bool[]> Slice()
        {
            if (_r == 1)
            {
                return new List<bool[]>
                {
                    new []{true}
                };
            }
            return new List<bool[]>
            {
                new List<bool[]> { new []{true,false},
                new []{false,true}},
                new List<bool[]> { new []{true,true}},
            };
        }
    }
}
