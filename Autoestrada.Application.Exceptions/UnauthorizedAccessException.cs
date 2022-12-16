using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;


namespace Autoestrada.Application.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class UnauthorizedException : BusinessException
    {
        public UnauthorizedException() 
        {
        }

        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected UnauthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
