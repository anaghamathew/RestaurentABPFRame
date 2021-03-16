using Abp.Authorization;
using RestaurentProject.Authorization.Roles;
using RestaurentProject.Authorization.Users;

namespace RestaurentProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
