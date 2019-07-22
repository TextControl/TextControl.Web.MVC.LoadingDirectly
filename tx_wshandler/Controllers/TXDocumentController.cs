using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TXTextControl.Web;

namespace tx_wshandler.Controllers
{
    public class TXDocumentController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage LoadDocument(string ConnectionID, string DocumentName)
        {
            // connect the WebSocketHandler with the ConnectionID
            WebSocketHandler wsHandler = WebSocketHandler.GetInstance(ConnectionID);

            // the document directly server-side
            wsHandler.LoadText(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/" + DocumentName),
                StreamType.WordprocessingML);

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage SaveDocument(string ConnectionID, string DocumentName)
        {
            // connect the WebSocketHandler with the ConnectionID
            WebSocketHandler wsHandler = WebSocketHandler.GetInstance(ConnectionID);

            // save the document directly server-side
            wsHandler.SaveText(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/" + DocumentName),
                StreamType.WordprocessingML);

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
