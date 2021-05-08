using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ReportTesting.Controllers
{
    public class TestController : ApiController
    {
        public HttpResponseMessage Get(string fileName)
        {
            string bookName = "sample." + "pdf".ToLower();
            //converting Pdf file into bytes array  
            var dataBytes = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/PDF/" + fileName + ".pdf"));
            //adding bytes to memory stream   
            var dataStream = new MemoryStream(dataBytes);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = bookName;
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }

    }
}
