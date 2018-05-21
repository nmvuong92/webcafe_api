using System.Web.Mvc;
using Web.Schedule;

namespace Web.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            return Content("Schedule Task Send Mail");
        }

        public ActionResult SendMail()
        {

            var task = new TaskJob();
            return Content(task.SendMail());
        }
    }
}