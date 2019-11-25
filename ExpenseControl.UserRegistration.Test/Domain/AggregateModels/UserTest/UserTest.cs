using ExpenseControl.UserRegistration.Domain.AggregateModels.RegisterAggregate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseControl.UserRegistration.Test.Domain.AggregateModels.UserTest
{
    [TestFixture]
    public class UserTest
    {
        private const string VALID_EMAIL = "email@gmail.com";
        private const string VALID_PASSWORD = "ASA458484";
        
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Should_returnSuccess_When_UserCreatedWithInputValid()
        {
            var sut = User.Create(VALID_EMAIL, VALID_PASSWORD);

            Assert.IsTrue(sut.IsSuccess);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("email@@teste.com.br")]
        [TestCase("email.com.br")]
        [TestCase("email")]
        public void Should_returnMessageFail_when_EmailIsInvalid(string invalidEmailInput)
        {
            var sut = User.Create(invalidEmailInput, VALID_PASSWORD);

            Assert.IsTrue(sut.IsFailure);
            Assert.IsTrue(sut.Messages.Count > 0);
        }


        [TestCase(null)]
        [TestCase("")]        
        public void Should_returnMessageFail_when_PasswordIsInvalid(string invalidPasswordInput)
        {
            var sut = User.Create(VALID_EMAIL, invalidPasswordInput);

            Assert.IsTrue(sut.IsFailure);
            Assert.IsTrue(sut.Messages.Count > 0);
        }
    }
}
