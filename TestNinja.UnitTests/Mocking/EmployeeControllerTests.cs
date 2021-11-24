using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _mockEmployeeStorage;
        private EmployeeController _employeeController;

        [SetUp]
        public void SetUp()
        {
            
            _mockEmployeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_mockEmployeeStorage.Object);
        }

        [Test]
        public void DeleteEmployee_EmployeeExists_RemoveFromDatabase()
        {
            _employeeController.DeleteEmployee(1);

            // as this method mock.RemoveEmployee() touch an external resource (database) in this case
            // we test only the interaction between controller method and database method and if the controller method is passing the correct parameter value
            // to the database method.
            // if the database method would return a boolean or id after performed operation on database for example, we could then unit test this return.
            // Or we could use integration test approuch to test this external resource method mock.RemoveEmploee().
            _mockEmployeeStorage.Verify(mock => mock.RemoveEmployee(1));
        }

        [Test]
        public void DeleteEmployee_MethodExecutedWithoutError_RedirectsToEmployeesPage()
        {
            var result = _employeeController.DeleteEmployee(1);

            Assert.That(result, Is.InstanceOf<RedirectResult>());
        }

    }
}
