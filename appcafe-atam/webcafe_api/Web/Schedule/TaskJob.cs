using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using VD.Data.IRepository;
using VD.Lib;
using VD.Lib.DTO;

namespace Web.Schedule
{
    public class TaskJob
    {

     
        private ISettingRepository _settingRepository;

        public TaskJob()
        {
          
            _settingRepository = DependencyResolver.Current.GetService<ISettingRepository>();
        }

        public string SendMail()
        {
            return "ok";
        }

    }
}