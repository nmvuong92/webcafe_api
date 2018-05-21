using System;
using System.Linq;
using System.Web.Mvc;
using VD.Data;
using VD.Data.Entity;
using VD.Data.IRepository;
using VD.Data.Temp;
using VD.Lib;
using VD.Lib.DTO;
using Web.Fitters;
using Web.Models;
using Web.Security;

namespace Web.Controllers
{
    [Localization]
    public class BaseController : Controller
    {

        private ISettingRepository _settingServ;
        private IConfigRepository _confServ;
        private ILangRepository _langServ;
        private IUserRepository _userServ;
        private ICounterRepository _counterRepo;
        public int __langid { get; set; }
        public Setting __setting { get; set; }
        public SysConfigVM __config { get; set; }

        public BaseController()
        {
            this._confServ = DependencyResolver.Current.GetService<IConfigRepository>();
            this._langServ = DependencyResolver.Current.GetService<ILangRepository>();
            this._userServ = DependencyResolver.Current.GetService<IUserRepository>();
            this._counterRepo = DependencyResolver.Current.GetService<ICounterRepository>();
            this._settingServ = DependencyResolver.Current.GetService<ISettingRepository>();
        }


        /// <summary>
        /// Set metadata
        /// </summary>
        /// <param name="title"></param>
        /// <param name="keyword"></param>
        /// <param name="description"></param>
        /// <param name="path"></param>
        public void SetMetaData(string title = "", string keyword = "", string description = "", string path = "")
        {
            ViewBag.Title = _confServ.GetConfigCache().conf_website;
            ViewBag.Keywords = _confServ.GetConfigCache().conf_email;
            ViewBag.Description = _confServ.GetConfigCache().conf_description;

            if (!string.IsNullOrEmpty(title))
            {
                ViewBag.Title = title + (string.IsNullOrEmpty(ViewBag.Title) ? "" : (" - " + ViewBag.Title));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                ViewBag.Keywords = keyword + ", " + ViewBag.Title;
            }

            if (!string.IsNullOrEmpty(description))
            {
                ViewBag.Description = description;
            }

            if (!string.IsNullOrEmpty(path))
            {
                ViewBag.Path = path;
            }
        }
        private void HitCounter()
        {
            var cook_lock = myCookies.Get("hit_counter");
            if (string.IsNullOrWhiteSpace(cook_lock)) //neu chua ton tai cookie
            {
                myCookies.Set("hit_counter", "1", DateTime.Now.AddMinutes(1));
                _counterRepo.SetCounter();
            }
        }


        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {

            loginVM logvm = MySsAuthUsers.GetAuth();
            if (logvm == null)
            {
                var jsonnn = myCookies.Get("auth");
                if (!string.IsNullOrWhiteSpace(jsonnn))
                {
                    try
                    {
                        rs rsdecode = EncodeDecodeJWT.Decode(jsonnn);
                        if (rsdecode.r && rsdecode.v != null)
                        {
                            JwtLoginModel user_cook = (JwtLoginModel)rsdecode.v;
                            var log = _userServ.GetEntry(user_cook.uid);
                            var quanids = log.UserQuans.Select(s => s.QuanID).ToList();
                            if (log.QuanDefaultId == null)
                            {
                                requestContext.HttpContext.Response.Clear();
                                requestContext.HttpContext.Response.Redirect(Url.Action("ChonQuan", "Quan",new{area="Admin"}));
                                requestContext.HttpContext.Response.End();
                            }
                            logvm = new loginVM(log);
                            MySsAuthUsers.setLogin(logvm);
                        }
                    }
                    catch (Exception ex)
                    {
                       //_userServ.SSLogOut();
                    }
                }
            }
           
            __langid = myCookies.GetLangKey();
            __setting = _settingServ.GetSetting();
            __config = _confServ.GetConfigCache();
            HitCounter();
            ViewBag.__config = __config;
            ViewBag.__setting = __setting;
            VIEWSETTING __viewsetting = new VIEWSETTING();
            __viewsetting.__config = __config;
            __viewsetting.__setting = __setting;
            __viewsetting.__login = MySsAuthUsers.GetAuth();
            ViewBag.__viewsetting = __viewsetting; //VIEWSETTING __vs = ViewBag.__viewsetting;
            base.Initialize(requestContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);
        }

    }
}