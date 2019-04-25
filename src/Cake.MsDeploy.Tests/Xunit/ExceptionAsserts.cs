using System;
using Cake.Core;

namespace Xunit
{
    public static class AssertEx
    {
        public static void IsArgumentNullException(Exception exception, string parameterName)
        {
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal(parameterName, ((ArgumentNullException)exception).ParamName);
        }

        public static void IsArgumentException(Exception exception, string parameterName, string message)
        {
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal(parameterName, ((ArgumentException)exception).ParamName);
            Assert.Equal(new ArgumentException(message, parameterName).Message, exception.Message);
        }

        public static void IsCakeException(Exception exception, string message)
        {
            IsExceptionWithMessage<CakeException>(exception, message);
        }

        public static void IsExceptionWithMessage<T>(Exception exception, string message)
            where T : Exception
        {
            Assert.IsType<T>(exception);
            Assert.Equal(message, exception.Message);
        }
    }
}