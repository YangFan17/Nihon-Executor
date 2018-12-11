
using AutoMapper;
using HC.POSCloud.Members;
using HC.POSCloud.Members.Dtos;

namespace HC.POSCloud.Members.Mapper
{

	/// <summary>
    /// 配置Member的AutoMapper
    /// </summary>
	internal static class MemberMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Member,MemberListDto>();
            configuration.CreateMap <MemberListDto,Member>();

            configuration.CreateMap <MemberEditDto,Member>();
            configuration.CreateMap <Member,MemberEditDto>();

        }
	}
}
