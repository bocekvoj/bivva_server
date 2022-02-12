using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace bivva_ser.Core
{
    public interface ICommonService
    {
        HttpResponseMessage GetResponse();
        HttpResponseMessage GetResponse(string content);

   
    }
}
