using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Autoestrada.Application.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ServiceUnavailableException : BusinessException
    {
        public ServiceUnavailableException()
        {
        }

        public ServiceUnavailableException(string message) : base(message)
        {
        }

        public ServiceUnavailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected ServiceUnavailableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}