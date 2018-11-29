using Abp.Authorization;
using HC.POSCloud.Authorization.Roles;
using HC.POSCloud.Authorization.Users;

namespace HC.POSCloud.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
