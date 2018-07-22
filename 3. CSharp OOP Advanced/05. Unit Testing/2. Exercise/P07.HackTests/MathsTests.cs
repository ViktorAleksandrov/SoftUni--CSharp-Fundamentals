using System;
using NUnit.Framework;
using P07.Hack;

namespace P07.HackTests
{
    public class MathsTests
    {
        Maths math;

        [SetUp]
        public void MathsInit()
        {
            this.math = new Maths();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(2.7)]
        public void MathsAbs(double value)
        {
            Assert.That(this.math.Abs(value), Is.EqualTo(Math.Abs(value)));
        }

        [Test]
        [TestCase(-1.6)]
        [TestCase(-1.4)]
        [TestCase(0)]
        [TestCase(1.4)]
        [TestCase(1.6)]
        public void MathsFloor(double value)
        {
            Assert.That(this.math.Floor(value), Is.EqualTo(Math.Floor(value)));
        }
    }
}
