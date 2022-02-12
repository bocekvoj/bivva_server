using bivaa_server_main.Utils;
using bivva_ser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace bivva_ser.Services
{
    public class CommonService : ICommonService
    {
        public HttpResponseMessage GetResponse()
        {
            var result = GetBaseResponse("OK");

            result.ApplyJsonContentType();

            return result;
        }

        public HttpResponseMessage GetResponse(string content)
        {
            var result = GetBaseResponse(content);
            result.ApplyJsonContentType();

            return result;
        }

        private HttpResponseMessage GetBaseResponse(string content)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(content)
            };
        }
    }
}