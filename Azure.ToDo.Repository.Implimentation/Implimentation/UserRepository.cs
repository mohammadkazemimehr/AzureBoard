using Azure.ToDo.Repository.Implimation;

namespace Azure.ToDo.Repository.Implimentation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Guid> CreateUser(string firstName, string lastName, string email, string userName, string password)
        {
            var user = new User
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
