using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.ViewModels.Form
{
    public class FrmJobDescriptionView:BaseInput
    {
        [Required]
        public string CompanyName { get; set; }
        public string Location { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email isvalid!")]
        public string CompanyEmail { get; set; }
        [Required]
        public string CompanyPhone { get; set; }
        public string Adrress { get; set; }
        [Required]
        public string JobTitle { get; set; }


        public int CityId { get; set; }
        public IEnumerable<SelectListItem> ddlCity { get; set; }
        //JobIndustryId
        public int JobIndustryId { get; set; }
        public IEnumerable<SelectListItem> ddlJobIndustry { get; set; }

        //JobLevelId
        public int JobLevelId { get; set; }
        public IEnumerable<SelectListItem> ddlJobLevel { get; set; }

        //JobWorkTypeId
        public int JobWorkTypeId { get; set; }
        public IEnumerable<SelectListItem> ddlJobWorkType { get; set; }

        //SalaryWageId
        public int SalaryWageId { get; set; }
        public IEnumerable<SelectListItem> ddlSalaryWage { get; set; }

        //public int EmployeeId { get; set; }

        public string Description { get; set; }
        public string ContactPerson { get; set; }
    }
}