using System;
using System.IO;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using HC.WeChat.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HC.POSCloud.Web.Host.Controllers
{
    public class PosCloudController : AbpController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public PosCloudController(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 商品图片上传
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fileName"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [RequestFormSizeLimit(valueCountLimit: 2147483647)]
        [HttpPost]
        public async Task<IActionResult> ProductPhotoPost(IFormFile[] image, string fileName, Guid name)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var imageName = "";
            foreach (var formFile in image)
            {
                if (formFile.Length > 0)
                {
                    string fileExt = Path.GetExtension(formFile.FileName); //文件扩展名，不含“.”
                    long fileSize = formFile.Length; //获得文件大小，以字节为单位
                    name = name == Guid.Empty ? Guid.NewGuid() : name;
                    string newName = name + fileExt; //新的文件名
                    var fileDire = webRootPath + string.Format("/product/{0}/", fileName);
                    if (!Directory.Exists(fileDire))
                    {
                        Directory.CreateDirectory(fileDire);
                    }

                    var filePath = fileDire + newName;

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    imageName = filePath.Substring(webRootPath.Length);
                }
            }

            return Ok(new { imageName });
        }
    }
}