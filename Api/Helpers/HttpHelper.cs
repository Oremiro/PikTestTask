using System;
using System.Net;
using System.ServiceModel.Web;

namespace Api.Helpers
{
    public class HttpHelper
    {
        public static void SetResponseHttpStatus(HttpStatusCode statusCode)
        {
            var context = WebOperationContext.Current;
            // I'm doing it to get more control of workflow - maybe i'll change it in future
            if (context == null)
            {
                throw new NullReferenceException();
            }
            context.OutgoingResponse.StatusCode = statusCode;
        }

    }
}