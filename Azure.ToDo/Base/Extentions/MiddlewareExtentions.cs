namespace Azure.ToDo.Base.Extentions
{
    public static class MiddlewareExtentions
    {
        public static void UseCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandllerMiddleware>();
        }
    }
}
