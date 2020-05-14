using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Contacts.Utils;

namespace Contacts.Tests.Utils
{
    public class ErrorUtilsTests
    {
        private ErrorUtils _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Contacts.Utils.ErrorUtils();
        }
        [Test]
        public void FormatErrorMessage_GivenException_ReturnsFormattedString()
        {
            var ex = new Exception("Broken");
            var expected = "Message: Broken\r\nInnerException: \r\nStackTrace: ";
            var actual = _sut.FormatErrorMessage(ex);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FormatErrorMessage_GivenNestedException_ReturnsFormattedStringWithInnerException()
        {
            var ex = new Exception("Broken", new Exception("Really Broken"));
            var expected = "Message: Broken\r\nInnerException: Really Broken\r\nStackTrace: ";

            var actual = _sut.FormatErrorMessage(ex);

            Assert.AreEqual(expected, actual);
        }
    }
}