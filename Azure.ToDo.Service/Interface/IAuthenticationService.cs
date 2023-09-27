namespace Azure.ToDo.Service.Interface
{
    public interface IAuthenticationService
    {
        Task<ResponseMessage> Login(LoginCommand command);
        Task<ResponseMessage> SignUp(SignUpCommand command);
    }
}
