using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Globalization;
using System.IO;
using System.Collections;

namespace Demo
{
    public class ExceptionTests
    {
        #region ThrowsException
        [Fact]
        public void ThrowsException()
        {
            Assert.Throws<Exception>(() => ThrowException(new Exception()));
            Assert.Throws<Exception>(() => ThrowException(new Exception("some random exception")));
            Assert.Throws<ArgumentNullException>(() => ThrowException(new ArgumentNullException("some random exception")));

            // fails because Exception != ArgumentNullException
            //Assert.Throws<Exception>(() => ThrowException(new ArgumentNullException("some random exception")));

            // fails because ArgumentNullException != Exception
            //Assert.Throws<ArgumentNullException>(() => ThrowException(new Exception("some random exception")));
        }

        private static void ThrowException(Exception exception) => throw exception;
        #endregion

        #region ThrowsExceptionAsync
        [Fact]
        public void ThrowsExceptionAsync()
        {
            Assert.ThrowsAsync<Exception>(() => ThrowExceptionAsync(new Exception()));
            Assert.ThrowsAsync<Exception>(() => ThrowExceptionAsync(new Exception("some random exception")));
            Assert.ThrowsAsync<ArgumentNullException>(() => ThrowExceptionAsync(new ArgumentNullException("some random exception")));

            // works but not recommended
            //Assert.ThrowsAsync<Exception>(() => ThrowExceptionAsync(new ArgumentNullException("some random exception")));
        }

        private static async Task ThrowExceptionAsync(Exception exception) => throw exception;
        #endregion
    }
}
