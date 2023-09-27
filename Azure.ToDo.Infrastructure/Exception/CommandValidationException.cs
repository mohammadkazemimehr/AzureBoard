using System.Runtime.Serialization;

namespace Azure.ToDo.Infrastructure.Exception
{
    [Serializable]
    public class CommandValidationException : System.Exception
    {
        public CommandValidationException()
        {
        }

        public CommandValidationException(string message) : base(message)
        {
        }

        public CommandValidationException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected CommandValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
