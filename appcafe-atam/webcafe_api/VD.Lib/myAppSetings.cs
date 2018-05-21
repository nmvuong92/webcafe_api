using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace VD.Lib
{
    public class myAppSetings
    {       
        #region[ROBOT EMAIL]
        public static string robot_email1
        {
            get
            {
                return Setting<string>("robot_email1");
            }
        }
        public static string robot_email1_pw
        {
            get
            {
                return Setting<string>("robot_email1_pw");
            }
        }
        public static string robot_email2
        {
            get
            {
                return Setting<string>("robot_email2");
            }
        }
        public static string robot_email2_pw
        {
            get
            {
                return Setting<string>("robot_email2_pw");
            }
        }
        #endregion

        #region[email setings]
        public static int email_port
        {
            get
            {
                return Setting<int>("email_port");
            }
        }
        public static string email_host
        {
            get
            {
                return Setting<string>("email_host");
            }
        }
        public static bool email_EnableSsl
        {
            get
            {
                return Setting<bool>("email_EnableSsl");
            }
        }
        #endregion
        public static string currency
        {
            get
            {
                return Setting<string>("currency");
            }
        }
        public static List<int> row_per_page
        {
            get
            {
                var rs = Setting<string>("row_per_page");
                return rs.Split(',').Select(int.Parse).ToList();
            }
        }
        public static int admin_pg_size
        {
            get
            {
               return Setting<int>("admin_pg_size");
            }
        }
        
        //core get settings
        public static T Setting<T>(string name)
        {
           
            string value = ConfigurationManager.AppSettings[name];

            if (value == null)
            {
                throw new Exception(String.Format("Could not find setting '{0}',", name));
            }
            return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
    }
}
