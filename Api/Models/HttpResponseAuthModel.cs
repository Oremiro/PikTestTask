using System.Net;
using Api.DTO;
using Api.Entities;

namespace Api.Models
{
    public class HttpResponseAuthModel
    {
        public UserSafeDTO User { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}