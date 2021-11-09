using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        //[TestMethod]
        //public void MethodName_Scenario_ExpectedBehavior()
        //{
        //    //Arrange
            
        //    //Act

        //    //Assert
        //}

        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancalledBy_SameUserCancelling_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation() { MadeBy = user};

            var result =  reservation.CanBeCancelledBy(user);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_NonAutorizedUserCancelling_ReturnsFalse()
        {
            var autorizedUser = new User();
            var notAutorizedUser = new User();

            var reservation = new Reservation() { MadeBy = autorizedUser };

            var result = reservation.CanBeCancelledBy(notAutorizedUser);

            Assert.That(result, Is.False);
        }

    }
}
