using System;

namespace PlayersWebAPI.Core.Exceptions
{
    public enum NotFoundExceptionCode
    {
        PlayerNotFound = 1
    }

    public class NotFoundException : Exception
    {
        public NotFoundExceptionCode Code { get; set; }
        public NotFoundException(NotFoundExceptionCode code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}
