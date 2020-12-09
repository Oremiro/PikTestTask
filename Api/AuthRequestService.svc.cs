using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Api.EntityServices;

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
            return "Hello";
        }

        public string Post(AuthRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
