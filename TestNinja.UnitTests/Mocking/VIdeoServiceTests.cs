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
    public class VIdeoServiceTests
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var service = new VideoService();

            // example of unit test mock object dependecy injection as method parameter
            var result = service.ReadVideoTitle(new MockFileReader());

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

    }
}
