using System;

namespace PlayersWebAPI.Core.Exceptions
{
    public enum UnvalidCode
    {
        MissingFields,
        DataFormat,
        RangeFormat
    }

    public class UnvalidException : Exception
    {
        public UnvalidCode Code { get; set; }

        public UnvalidException(UnvalidCode code)
            : base()
        {
            Code = code;
        }

        public UnvalidException(UnvalidCode code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}
