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
    public class ErrorLorggerTests
    {
        ErrorLogger _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            _logger = new ErrorLogger();

            _logger.Log("a");

            Assert.That(_logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            //_logger.Log(error);
            Assert.That(() => _logger.Log(error), Throws.ArgumentNullException);

            //another example to check the type of the exception throwed
            //Assert.That(() => _logger.Log(error), Throws.TypeOf<DivideByZeroException>);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            //it will receive the id of the error
            var id = Guid.Empty;

            //sender is the source of the event
            //args is the event arguments

            //if the event is raised, the { id = args } block will be executed and so id will have no longer be Guid.empty, but will be receive the id of the event (args)
            //to test a class method that raise an event - we have to subscribe to that event before call the class method
            _logger.ErrorLogged += (sender, args) => { id = args; };

            _logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
            
        }

    }
}
