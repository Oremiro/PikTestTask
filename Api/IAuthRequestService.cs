using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Api.Models;

namespace Api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAuthRequestService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "auth/get")]
        string Get();
        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "auth/post", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        HttpResponseAuthModel Post(AuthRequestModel model);

        /// <summary>
        /// Ugly trick to avoid cors errors
        /// </summary>
        [OperationContract]
        [WebInvoke(Method="OPTIONS", UriTemplate="auth/post")]
        void Option();
    }

    public class AuthRequestModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
