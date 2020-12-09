using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Api.EntityServices;
using Api.Models;

namespace Api
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class AuthRequestService : IAuthRequestService
    {
        private IAuthService _service { get; set; }
        public AuthRequestService()
        {
            _service = new AuthService();
        }

        public string Get()
        {
            Helpers.HttpHelper.SetResponseHttpStatus(HttpStatusCode.OK);
            return "Test, get method.";
        }

        public HttpResponseAuthModel Post(AuthRequestModel model)
        {
            var username = model.Username;
            var password = model.Password;
            if (username == null || password == null)
            {
                Helpers.HttpHelper.SetResponseHttpStatus(HttpStatusCode.NotAcceptable);       
            }

            var user = _service.GetUserByUsernameAndPassword(username, password);
            if (user == null)
            {
                Helpers.HttpHelper.SetResponseHttpStatus(HttpStatusCode.NotFound);
            }

            var httpResponse = new HttpResponseAuthModel {User = user, StatusCode = HttpStatusCode.OK};
            Helpers.HttpHelper.SetResponseHttpStatus(HttpStatusCode.OK);
            return httpResponse;
        }
    }
}
