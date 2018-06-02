using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Net;
using System.Net.Http;

namespace APISample
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        private string Role { get; set; }
        public AuthorizeAttribute(string role = null)
        {
            this.Role = role;
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (base.IsAuthorized(actionContext))
            {
                if (string.IsNullOrEmpty(Role))
                    return true;

                var user = HttpContext.Current.User;
                if (user.IsInRole(Role))
                {
                    return true;
                }
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(
                HttpContext.Current.User.Identity.IsAuthenticated ? HttpStatusCode.Unauthorized : HttpStatusCode.Forbidden);
        }
    }
}