using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Fundamentals.Math _math;

        [SetUp]
        public void SetUp()
        {
            //arrange
            _math = new Fundamentals.Math();
        }

        [Test]
        [Ignore("Ignoring this method for test another ones")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //act
            var result = _math.Add(1, 2);

            //assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Add_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            //act
            var result = _math.Max(a, b);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
