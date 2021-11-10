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

    }
}
