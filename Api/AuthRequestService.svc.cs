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
using Api.DTO;
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
            var httpResponse = new HttpResponseAuthModel();
            if (model == null)
            {
                Helpers.HttpHelper.SetResponseHttpStatus(HttpStatusCode.NotAcceptable);
                httpResponse.StatusCode = HttpStatusCode.NotAcceptable;
                return httpResponse;
            }
            var username = model.Username;
            var password = model.Password;
            var user = _service.GetUserDTOByUsernameAndPassword(username, password);
            httpResponse.User = user;
            if (user == null)
            {
                Helpers.HttpHelper.SetResponseHttpStatus(HttpStatusCode.NotFound);
                
                httpResponse.StatusCode = HttpStatusCode.NotFound;
                return httpResponse;
            }

            httpResponse.StatusCode = HttpStatusCode.OK;
            Helpers.HttpHelper.SetResponseHttpStatus(HttpStatusCode.OK);
            return httpResponse;
        }

        public void Option()
        { 
            Helpers.HttpHelper.SetResponseHttpStatus(HttpStatusCode.OK);
        }
    }
}
