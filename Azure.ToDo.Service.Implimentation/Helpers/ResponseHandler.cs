using Azure.ToDo.Infrastructure.Exception;

namespace Azure.ToDo.Service.Implimentation.Helpers
{
    public static class ResponseHandler
    {
        public static void BadRequest(string message)
        {
            throw new ManagedException(message);
        }

        public static void NotFound(string message)
        {
            throw new NotFoundException(message);
        }

        public static ResponseMessage OkResult(string message, object content, int total)
        {
            return new ResponseMessage(message, content, total);
        }

        public static ResponseMessage OkResult(string message, object content)
        {
            return new ResponseMessage(message, content);
        }

        public static ResponseMessage OkResult(string message)
        {
            return new ResponseMessage(message);
        }
    }
}