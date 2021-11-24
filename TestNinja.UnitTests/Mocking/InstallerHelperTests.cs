using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private InstallerHelper _installerHelper;
        private Mock<IFileDownloader> _fileDownloader;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnTrue()
        {
            // because the this example mock method does not return anything, it is not necessary to Setup it
            // _fileDownloader.Setup(fd => fd.DownloadFile("John", "Visual Studio"));

            var result = _installerHelper.DownloadInstaller("John", "Visual Studio");

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void DownloadInstaller_DownloadSucceed_ReturnFalse()
        {
            // When a the mock method Setup() is used with Throws<WebException>() as return, the parameter have to be the same used in the implementation of the production code (real class),
            // in this case if we can see the parameter value used in the implementation code we can use it like:
            // _fileDownloader.Setup(fd => fd.DownloadFile("http://example.com/customer/installer", null)).Throws<WebException>();

            // If we cant see it, so we can use the simpler way: It.IsAny<string>(),
            _fileDownloader.Setup(fd => 
                fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result =_installerHelper.DownloadInstaller("", "");

            Assert.That(result, Is.False);
        }

    }
}
