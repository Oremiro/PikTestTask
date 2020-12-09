using System.Net;
using Api.Entities;

namespace Api.Models
{
    public class HttpResponseAuthModel
    {
        public User User { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}