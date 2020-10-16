namespace Core.Application.Identity.Commands.LoginUser
{
    public class LoginInputModel
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
