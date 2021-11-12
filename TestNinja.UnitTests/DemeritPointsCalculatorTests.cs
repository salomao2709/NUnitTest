using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPoint;
        [SetUp]
        public void SetUp()
        {
            _demeritPoint = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsNegativeOrHigherThanMaxSpeedLimit_ThrowAnException(int speed)
        {
            // because CalculateDemeritPoints method throws and exception it is necessary to wrap it in a lambda expression to get the method return.
            Assert.That(() => _demeritPoint.CalculateDemeritPoints(speed), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(30, 0)]
        [TestCase(65, 0)]
        public void CalculateDemeritPoints_SpeedIsLowerOrEqualSpeedLimit_ReturnsZero(int speed, int expectedResult)
        {
            int result = _demeritPoint.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(68, 0)]
        public void CalculateDemeritPoints_SpeedIsHigherThanSpeedLimitButNotEnoughtToGetDemeriPoints_ReturnsZero(int speed, int expectedResult)
        {
            int result = _demeritPoint.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_SpeedIsHigherThanSpeedLimit_ReturnsDemeritPoints(int speed, int expetedResult)
        {
            int result = _demeritPoint.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expetedResult));
        }

    }
}
