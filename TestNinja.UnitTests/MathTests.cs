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

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //1) more general
            //Assert.That(result, Is.Not.Empty);

            //2) a little more specifically
            //Assert.That(result.Count(), Is.EqualTo(3));

            //3)
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

            //4) better way to assert an array/collection in this case
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);
        }

    }
}