
using AutoMapper;
using HC.POSCloud.ProductTags;
using HC.POSCloud.ProductTags.Dtos;

namespace HC.POSCloud.ProductTags.Mapper
{

	/// <summary>
    /// 配置ProductTag的AutoMapper
    /// </summary>
	internal static class ProductTagMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <ProductTag,ProductTagListDto>();
            configuration.CreateMap <ProductTagListDto,ProductTag>();

            configuration.CreateMap <ProductTagEditDto,ProductTag>();
            configuration.CreateMap <ProductTag,ProductTagEditDto>();

        }
	}
}
