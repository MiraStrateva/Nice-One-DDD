namespace Core.Application.Identity
{
    using Common.Application;
    using Core.Application.Identity.Commands;
    using Core.Application.Identity.Commands.ChangePassword;
    using Core.Application.Identity.Commands.LoginUser;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(LoginInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
