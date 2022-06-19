using System;

namespace PlayersWebAPI.Core.Exceptions
{
    public enum InternalErrorCode
    {
        Players = 1
    }

    public class InternalErrorException : Exception
    {
        public InternalErrorCode Code { get; set; }

        public InternalErrorException(InternalErrorCode code, string message, Exception innerException)
            : base (message, innerException)
        {
            Code = code;
        }

        public InternalErrorException(InternalErrorCode code, Exception innerException)
            : base(innerException?.Message, innerException)
        {
            Code = code;
        }

        public InternalErrorException(InternalErrorCode code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}
