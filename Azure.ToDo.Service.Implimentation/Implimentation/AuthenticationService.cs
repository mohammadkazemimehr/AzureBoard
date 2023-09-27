using Microsoft.Extensions.Configuration;
namespace Azure.ToDo.Service.Implimentation.Implimentation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public AuthenticationService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<ResponseMessage> Login(LoginCommand command)
        {
            var user = await _unitOfWork.UserRepository.FirstOrDefaultAsync(u => u.UserName == command.UserName && u.IsActive);
            if (user is null || user.Password != command.Password)
                ResponseHandler.BadRequest("The username or password is incorrect.");

            var token = JWTHelper.GenerateEncodedToken(_configuration, user.Id, user.UserName);
            return ResponseHandler.OkResult($"{user.FirstName + " " + user.LastName} welcome.", token);
        }

        public async Task<ResponseMessage> SignUp(SignUpCommand command)
        {
            var userNameCheck = await _unitOfWork.UserRepository.AnyAsync(c => c.UserName == command.UserName && c.IsActive);
            if (userNameCheck)
                ResponseHandler.BadRequest("The username is duplicated.");

            var userId = await _unitOfWork.UserRepository.CreateUser(command.FirstName, command.LastName, command.Email, command.UserName, command.Password);

            return ResponseHandler.OkResult("User created successfully.", userId);
        }
    }
}
