namespace Azure.ToDo.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<Guid> CreateUser(string firstName, string lastName, string email, string userName, string password);
    }
}
