using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;


namespace Autoestrada.Application.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ForbiddenException : BusinessException
    {
        public ForbiddenException()
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }

        public ForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected ForbiddenException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
