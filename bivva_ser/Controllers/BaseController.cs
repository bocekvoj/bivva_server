using bivva_ser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace bivva_ser.Controllers
{
    public class BaseController : ApiController
    {
        public ICommonService commonService;
        public BaseController(ICommonService commonService)
        {
            this.commonService = commonService;
        }
            
    }
}