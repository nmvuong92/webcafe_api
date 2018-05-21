using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Web.Schedule
{
    /// <summary>
    /// Summary description for ScheduleService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ScheduleService : System.Web.Services.WebService
    {


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello world";
        }

        [WebMethod]
        public string SendMail()
        {
            var task = new TaskJob();
            return task.SendMail();
        }
    }
}
