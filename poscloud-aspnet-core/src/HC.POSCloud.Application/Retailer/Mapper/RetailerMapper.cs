
using AutoMapper;
using HC.POSCloud.Retailers;
using HC.POSCloud.Retailers.Dtos;

namespace HC.POSCloud.Retailers.Mapper
{

	/// <summary>
    /// 配置Retailer的AutoMapper
    /// </summary>
	internal static class RetailerMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Retailer,RetailerListDto>();
            configuration.CreateMap <RetailerListDto,Retailer>();

            configuration.CreateMap <RetailerEditDto,Retailer>();
            configuration.CreateMap <Retailer,RetailerEditDto>();

        }
	}
}
