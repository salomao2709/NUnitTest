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
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            //NotFound object
            Assert.That(result, Is.TypeOf<NotFound>());

            //NotFound object or one of its derivatives
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        public void GetCustomer_IdIsNotZero_RetornOk()
        {
        }
    }
}
