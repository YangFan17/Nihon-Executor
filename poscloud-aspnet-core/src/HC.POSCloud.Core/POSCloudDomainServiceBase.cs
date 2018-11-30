

using Abp.Domain.Services;

namespace HC.POSCloud
{
	public abstract class POSCloudDomainServiceBase : DomainService
	{
		/* Add your common members for all your domain services. */
		/*在领域服务中添加你的自定义公共方法*/





		protected POSCloudDomainServiceBase()
		{
			LocalizationSourceName = POSCloudConsts.LocalizationSourceName;
		}
	}
}
