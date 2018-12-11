
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using HC.POSCloud.Members.Dtos;
using HC.POSCloud.Members;

namespace HC.POSCloud.Members
{
    /// <summary>
    /// Member应用层服务的接口方法
    ///</summary>
    public interface IMemberAppService : IApplicationService
    {
        /// <summary>
		/// 获取Member的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<MemberListDto>> GetPaged(GetMembersInput input);


		/// <summary>
		/// 通过指定id获取MemberListDto信息
		/// </summary>
		Task<MemberListDto> GetById(EntityDto<Guid> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetMemberForEditOutput> GetForEdit(NullableIdDto<Guid> input);


        /// <summary>
        /// 添加或者修改Member的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateMemberInput input);


        /// <summary>
        /// 删除Member信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<Guid> input);


        /// <summary>
        /// 批量删除Member
        /// </summary>
        Task BatchDelete(List<Guid> input);


		/// <summary>
        /// 导出Member为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
