using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Http
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// 扩展获取绝对URL
        /// </summary>
        public static string GetAbsoluteUri(this HttpRequest request)
        {
            return new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host)
                .Append(request.PathBase)
                .Append(request.Path)
                //.Append(request.QueryString)
                .ToString();
        }
    }
}
