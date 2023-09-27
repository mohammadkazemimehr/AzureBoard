namespace Azure.ToDo.Service.Implimentation.Helpers
{
    /// <summary>
    /// Exception Extentions :)
    /// </summary>
    public static class ValidateExtentions
    {
        public static void CheckShouldThrowNotFoundException(this object obj, string message)
        {
            if (obj is null)
            {
                ResponseHandler.NotFound(message);
            }
        }

        public static void CheckShouldThrowNotFoundException(this IEnumerable<object> obj, string message)
        {
            if (obj.Count() == 0)
            {
                ResponseHandler.NotFound(message);
            }
        }
    }
}
