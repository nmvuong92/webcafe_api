using System.Collections.Generic;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Lib.DTO;

namespace VD.Data.Paging
{
    public class AboutUs_filter : smartpaging
    {

    }
    public class FeeService_filter : smartpaging
    {

    }
    public class User_filter : smartpaging
    {
        public int roleid { get; set; }
        public bool isvip { get; set; }

    }
    public class SalaryWage_filter : smartpaging
    {

    }

    public class JobIndustry_filter : smartpaging
    {
        public int base_job_industry_id { get; set; }
    }

    public class City_filter : smartpaging
    {
        
    }
    public class JobLevel_filter : smartpaging
    {

    }
    public class JobFunction_filter : smartpaging
    {

    }
    public class Conf_filter : smartpaging
    {

    }
    public class Degrees_filter : smartpaging
    {

    }
    public class JobWorkType_filter : smartpaging
    {

    }
    public class YearExperience_filter : smartpaging
    {

    }
    public class IndustryFocus_filter : smartpaging
    {
        public int IndustryFocusCatId { get; set; }
    }
    public class IndustryFocusCat_filter : smartpaging
    {

    }
    public class TipForEmployee_filter : smartpaging
    {

    }
    public class OurService_filter : smartpaging
    {

    }
    public class TipForCandidates_filter : smartpaging
    {

    }
    public class OurClientCat_filter : smartpaging
    {

    }
    public class OurClient_filter : smartpaging
    {
        public int OurClientCatId { get; set; }

    }
    public class Candidate_filter : smartpaging
    {
        public bool is_active { get; set; }
    }
    public class Employee_filter : smartpaging
    {

        public bool is_active { get; set; }
    }
    public class EmployeePointHistory_filter : smartpaging
    {

        public bool is_active { get; set; }
    }
    public class CV_filter : smartpaging
    {

    }
    public class Job_filter : smartpaging
    {
        public int jobstatusid { get; set; }
    }
    public class Contact_filter : smartpaging
    {
        public int contactstatusid { get; set; }
    }
}
