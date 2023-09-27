namespace Azure.ToDo.Repository.Interface
{
    public interface IExceptionLogger
    {
        Task SetLog(string exception, string stackTrace);
    }
}
