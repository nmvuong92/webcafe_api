using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;
using VD.Data;
using VD.Data.IRepository;
using VD.Data.Temp;

using VD.Lib;
using VD.Lib.DTO;


namespace Web.Security
{
    public class myAuthApi : System.Web.Http.AuthorizeAttribute
    {
        private IUserRepository _userServ;


  

        private string _roles; //quền
        private string[] _rolesSplit = new string[0]; //mảng quền

        private string _users; //người dùng
        private string[] _usersSplit = new string[0]; //mảng người dùng

      
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.GetValues("jwt") != null)
                {
                    // get value from header
                    string authenticationToken = Convert.ToString(
                        actionContext.Request.Headers.GetValues("jwt").FirstOrDefault());
                    //authenticationTokenPersistant
                    // it is saved in some data store
                    // i will compare the authenticationToken sent by client with
                    // authenticationToken persist in database against specific user, and act accordingly


                    rs rsdecode = EncodeDecodeJWT.Decode(authenticationToken);
                    return (rsdecode.r && rsdecode.v != null);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
           // base.OnAuthorization(actionContext);
          
            if (!IsAuthorized(actionContext))
            {
                HttpContext.Current.Response.StatusCode = 404;
            }
            else
            {
                HttpContext.Current.Response.AddHeader("AuthenticationStatus", "SUCCESS");
            }
        }
    }
  
    // This method must be thread-safe since it is called by the caching module.
    //protected virtual HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
    //{
    //    if (httpContext == null)
    //    {
    //        throw new ArgumentNullException("httpContext");
    //    }

    //    bool isAuthorized = AuthorizeCore(httpContext);
    //    return (isAuthorized) ? HttpValidationStatus.Valid : HttpValidationStatus.IgnoreThisRequest;
    //}


}
