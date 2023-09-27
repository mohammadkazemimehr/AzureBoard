using System.Runtime.Serialization;

namespace Azure.ToDo.Infrastructure.Exception
{
    [Serializable]
    public class ManagedException : System.Exception
    {
        public ManagedException()
        {
        }

        public ManagedException(string message) : base(message)
        {
        }

        public ManagedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ManagedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
