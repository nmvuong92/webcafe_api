using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml.FormulaParsing.Utilities;
using VD.Data.IRepository;
using VD.Data.Temp;

using VD.Lib;
using System.Text;
using VD.Lib.DTO;
using System.Web.Routing;


namespace Web.Security
{
    [SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes",
Justification = "Unsealed so that subclassed types can set properties in the default constructor or override our behavior.")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class myAuthEmployees : FilterAttribute, IAuthorizationFilter
    {
        
        private IEmployeeRepository _empRepo;
        private IConfigRepository _configRepo;
        public myAuthEmployees()
        {
            this.RedirectMessageOnly = true;
        }
        public int ServiceId { get; set; }
        public bool IsUseHutingService { get; set; }

        private string _roles; //quền
        private string[] _rolesSplit = new string[0]; //mảng quền


        private string _quyens; //quền
        private string[] _quyensSplit = new string[0]; //mảng quền


        private string _users; //người dùng
        private string[] _usersSplit = new string[0]; //mảng người dùng

      
        public bool RedirectMessageOnly { get; set; }
        public string Message { get; set; }

        public string Quyens
        {
            get{return _quyens ?? String.Empty;}
            set { _quyens = value; _quyensSplit = SplitString(value); }
        }
        public string Roles
        {
            get { return _roles ?? String.Empty; }
            set { _roles = value; _rolesSplit = SplitString(value); }
        }

        public string Users
        {
            get{return _users ?? String.Empty;}
            set{_users = value;_usersSplit = SplitString(value);}
        }
      
        // This method must be thread-safe since it is called by the thread-safe OnCacheAuthorization() method.
        /*
         Phương thức này phải được thread-safe  vì nó được gọi bởi các phương thức Authorization cache thread-safe ()
         cái đích của phương thức này là kiểm tra xem user đó đăng nhập đúng hay ko, có quền hay ko có quề
         * true: có quền
         * false: không có quên - > simple that!
         * 
         */
      

        protected virtual bool AuthorizeCore(HttpContextBase httpContext)
        {

            this._empRepo = DependencyResolver.Current.GetService<IEmployeeRepository>();
            this._configRepo = DependencyResolver.Current.GetService<IConfigRepository>();
            try
            {
                if (httpContext == null)
                {
                    throw new ArgumentNullException("httpContext");
                }
                //Auth1. kiểm tra login cơ bản????
                if (!_empRepo.SSisLogin())
                {
                    //trường hợp remember me?
                    var getRemember = _empRepo.GetCookieRememberMeEmployees();
                    if (getRemember.IsRememberMe)
                    {
                        var log = _empRepo.GetEntry(getRemember.EmployeeId);
                        _empRepo.SSLogin(new CustomerLoginVM(log));
                    }
                    else //nếu chưa đăng nhập mà cũng remember thì out
                    {
                        return false;
                    }
                }
                //auth2: ServiceId
                if (IsUseHutingService)
                {
                    return VD.Data.MySsAuthCustomers.GetAuth().IsUseHuntingService;
                }

                /*
                var user_login = _empRepo.SSgetEmployeeLoged();
                if (ServiceId==1||ServiceId==2)
                {
                    if (user_login.EmployeeServiceId != ServiceId)
                    {
                        return false;
                    }
                }*/
                /*
                //Auth2. kiểm tra quền hạn theo username
              
                if (_usersSplit.Length > 0 &&
                    !_usersSplit.Contains(user_login.Username, StringComparer.OrdinalIgnoreCase))
                {
                    return false;
                }

                if (_rolesSplit.Length > 0 && !_rolesSplit.Contains(user_login.RoleId.ToString()))
                {
                 
                    return false;
                }
                
                //Auth3. Kiểm tra quền hạn theo access role
                if (user_login.Username != "admin")
                {
                    if (_quyensSplit.Length > 0 && !IsInRole(user_login.ne_quyenIntArrStr, _quyensSplit))
                    {
                        return false;
                    }
                }*/

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool IsAnonymousAction(AuthorizationContext filterContext)
        {
            return filterContext.ActionDescriptor
                                 .GetCustomAttributes(inherit: true)
                                 .OfType<AllowAnonymousAttribute>()
                //or any attr. you want
                                 .Any();
        }


        //private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        //{
        //    validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
        //}
       
        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            this._empRepo = DependencyResolver.Current.GetService<IEmployeeRepository>();
            this._configRepo = DependencyResolver.Current.GetService<IConfigRepository>();
            var __config = _configRepo.GetConfigCache();
            //nếu mà allowAnonymous thì bỏ qua 
            if (this.IsAnonymousAction(filterContext))
            {
                return;
            }
            var rd = filterContext.RequestContext.RouteData;
            string currentAction = rd.GetRequiredString("action");
            string currentController = rd.GetRequiredString("controller");
            string currentArea = rd.Values["area"] as string;
            var area= HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"];
            var currentRequestReturnUrl = rd.Values["ReturnUrl"];
            string _returnUrl = filterContext.HttpContext.Request.Url.AbsoluteUri;
            if (currentRequestReturnUrl != null)
            {
                if (!string.IsNullOrWhiteSpace(currentRequestReturnUrl as string))
                {
                    _returnUrl = currentRequestReturnUrl as string;
                }

            }
            _returnUrl = myBase64EncodeDecode.EncodeBase64(_returnUrl);
    


         

           
            
            
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                string _err_msg = __config.conf_val_login_employees;
                TempDataDictionary tempdata = filterContext.Controller.TempData;
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;

                    filterContext.Result = new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        ContentType = "application/json",
                        ContentEncoding = Encoding.UTF8,
                        Data = rs.Err(401, _err_msg)
                    };
                    /*
                    filterContext.HttpContext.Response.ContentType = "application/json";
                    filterContext.Result = new HttpUnauthorizedResult(_err_msg);*/
                }
                else
                {

                    //here we will need to pass to the access denied
                    if (!string.IsNullOrWhiteSpace(Message))
                    {
                        _err_msg = Message;
                    }
                    if (!tempdata.ContainsKey("message"))
                    {
                        tempdata.Add("message", _err_msg);
                    }
                    filterContext.Result =
                        new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            action = "Login",
                            controller = "Candidates",
                            area = currentArea,
                            relog = "c",
                            returnUrl = _returnUrl
                        }));

                }
                //filterContext.Result = new RedirectResult(loginUrl);
                // FilterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "SSLogin",area="" })); 
                // New HttpUnauthorizedResult();
            }
            else
            {
                // ** IMPORTANT **
                // Since we're performing authorization at the action level, the authorization code runs
                // After the output caching module. In the worst case this could allow an authorized user
                // To cause the page to be cached, then an unauthorized user would later be served the
                // Cached page. We work around this by telling proxies not to cache the sensitive page,
                // Then we hook our custom authorization code into the caching mechanism so that we have
                // The final say on whether a page should be served from the cache.
                //HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
                //cachePolicy.SetProxyMaxAge(new TimeSpan(0));
                //cachePolicy.AddValidationCallback(CacheValidateHandler, null /* data */);
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

        #region[utils]
        ////phương thức cắt danh sách chuỗi ngăn cách nhau bằng dấu phẩy thành 1 mảng chuỗi string
        private string[] SplitString(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return new string[0];
            }

            //cái: piece
            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;
            return split.ToArray();
        }

        private bool IsInRole(string [] chils_roles,string[] parent_roles)
        {
            //đếm những node con nằm trong node cha
            int d1 = chils_roles.Count(s => parent_roles.Contains(s));
            int d2 = parent_roles.Length;
            
            
            return  d1 >= d2;
        }
        #endregion

    }
}