namespace Core.Web.Common
{
    using Microsoft.AspNetCore.Authorization;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public const string AdministratorRoleName = "Administrator";

        public AuthorizeAdministratorAttribute() => this.Roles = AdministratorRoleName;
    }
}
