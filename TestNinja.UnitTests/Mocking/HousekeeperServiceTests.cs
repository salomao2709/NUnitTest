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
    public class HousekeeperServiceTests
    {
        Housekeeper _housekeeper;
        HousekeeperService _housekeeperService;
        Mock<IUnitOfWork> mockUnitOfWork;
        Mock<IStatementRegistration>  mockStatementRegistration;
        Mock<IEmailFileSender> mockEmailFileSender;
        Mock<IXtraMessageBox> mockMessageBox;
        DateTime _statementDate = new DateTime(2021, 11, 30);
        private string _statementFileName;

        [SetUp]
        public void SetUp()
        {
            _housekeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };
            
            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>()
            {
                _housekeeper
            }.AsQueryable);

            _statementFileName = "fileNanme";
            mockStatementRegistration = new Mock<IStatementRegistration>();
            mockStatementRegistration.
            Setup(mockStatement => mockStatement
                .SaveStatement(_housekeeper.Oid, _housekeeper.FullName, (_statementDate)))
                .Returns(() => _statementFileName);   //lambda expression used here in order to Returns() method accepts null as return parameter in a test methods bellow.

            mockEmailFileSender = new Mock<IEmailFileSender>();
            mockMessageBox = new Mock<IXtraMessageBox>();

            _housekeeperService = new HousekeeperService(
                mockUnitOfWork.Object,
                mockStatementRegistration.Object,
                mockEmailFileSender.Object,
                mockMessageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            _housekeeperService.SendStatementEmails(_statementDate);

            mockStatementRegistration.Verify(mockStatement => 
                mockStatement.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate));
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsNUll_ShouldNotGenerateStatement(string email)
        {
            _housekeeper.Email = email;

            _housekeeperService.SendStatementEmails(_statementDate);

            //second argument checks how many times this method should be called.
            mockStatementRegistration.Verify(mockStatement =>
                mockStatement.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, (_statementDate)), Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_ShouldWemailTheStatement()
        {
            _housekeeperService.SendStatementEmails(_statementDate);

            VerifyEmailSent();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [Test]
        public void SendStatementEmails_StatementFileNameIsNullOrEmptyString_ShouldNotEmailTheStatement(string statementFilename)
        {
            _statementFileName = statementFilename;

            _housekeeperService.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox(string statementFilename)
        {
            mockEmailFileSender.Setup(es => es.EmailFile(
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>() ))
                .Throws<Exception>();

            _housekeeperService.SendStatementEmails(_statementDate);

            mockMessageBox.Verify(mb => mb.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
        }

        // helper method to let the test method cleaner
        private void VerifyEmailNotSent()
        {
            mockEmailFileSender.Verify(em => em.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);
        }
        private void VerifyEmailSent()
        {
            mockEmailFileSender.Verify(em => em.EmailFile(
                _housekeeper.Email,
                _housekeeper.StatementEmailBody,
                _statementFileName,
                It.IsAny<string>()));
        }

    }
}
