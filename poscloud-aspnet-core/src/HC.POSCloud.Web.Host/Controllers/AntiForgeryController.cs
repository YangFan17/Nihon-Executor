using Microsoft.AspNetCore.Antiforgery;
using HC.POSCloud.Controllers;

namespace HC.POSCloud.Web.Host.Controllers
{
    public class AntiForgeryController : POSCloudControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
