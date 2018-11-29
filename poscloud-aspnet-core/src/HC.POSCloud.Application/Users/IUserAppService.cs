using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HC.POSCloud.Roles.Dto;
using HC.POSCloud.Users.Dto;

namespace HC.POSCloud.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password">新密码</param>
        /// <returns></returns>
        Task UpdatePassword(string password);

        /// <summary>
        /// 检查输入的原密码与数据库中密码是否相等
        /// </summary>
        /// <returns></returns>
        Task<bool> CheckOldPassword(string oldPassword);
    }
}
