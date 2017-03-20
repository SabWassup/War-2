using System;
using System.Runtime.Serialization;

namespace _2lab
{
    [Serializable]
    internal class PowerException : Exception
    {
        public PowerException()
        {
        }

        public PowerException(string message) : base(message)
        {
        }

        public PowerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PowerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}