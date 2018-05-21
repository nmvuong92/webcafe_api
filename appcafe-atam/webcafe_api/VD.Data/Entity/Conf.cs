using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity
{

    public class Conf : BaseEntity
    {
        public Conf()
        {
            this.IsHtmlEditor = false;
            this.IsPublic = true;
            this.IsImg = false;
        }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(254)]
        [Index(IsUnique = true)]
        public string Key { get; set; }
        public string Description { get; set; }
        public bool IsHtmlEditor { get; set; }
        public bool IsImg { get; set; }
        public bool IsPublic { get; set; }

        public string Content { get; set; }

        
        public static Conf[] seed()
        {
            int genid = 0;
            return new Conf[]
            {
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_website",
                    Description = "Website name",
                    Content = "Thuận Hành",
                },
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_website_link",
                    Description = "Website link",
                    Content = "Thuận Hành",
                },
                 new Conf
                {
                    Id = ++genid,
                    Key = "conf_hotline",
                    Description = "Hotline",
                    Content = "19001570",
                }, //
                   new Conf
                {
                    Id = ++genid,
                    Key = "conf_company_name",
                    Description = "Company name",
                    Content = "Thuận Hành",
                },
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_email",
                    Description = "Email footer",
                    Content = "thuanhanh168@yahoo.com.hk"
                },
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_description",
                    Description = "Website description",

                },
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_copyright",
                    Description = "Website copyright",
                    Content = "Thiết kế vườn đào"
                },
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_address",
                    Description = "Address",
                    Content = "47A kênh Tân Hóa, P. Tân Thới Hòa, Q. Tân Phú, Tp. Hồ Chí Minh"
                },
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_tel",
                    Description = "Telephone",
                    Content = "(84-028) 3961 3373"
                },
                    new Conf
                {
                    Id = ++genid,
                    Key = "conf_fax",
                    Description = "Fax",
                    Content = "(84-028) 3961 3373"
                },
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_designby",
                    Description = "Website design by",
                    Content = "Thiết kế vườn đào"
                },
                new Conf
                {
                    Id = ++genid,
                    Description = "Google map code contact",
                    Key = "conf_google_map",
                    IsHtmlEditor = true,
                    Content =
                        "<iframe src='https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d3920.070286382373!2d106.72136411525055!3d10.729062362998908!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1svi!2s!4v1479718891280' style='border:0' allowfullscreen='' width='100%' height='300' frameborder='0'></iframe>",
                },
                new Conf()
                {
                    Id = ++genid,
                    Description = "Status 401 login",
                    Key = "conf_err_401",
                    Content = "Vui lòng đăng nhập"
                },
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_val_login_isvalid",
                    Description = "Account incorrect password",
                },
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_val_login_candidates",
                    Description = "Login for candidates",
                },
                new Conf
                {
                    Id = ++genid,
                    Key = "conf_val_login_employees",
                    Description = "Login for employees",
                },
                new Conf
                {
                    Id = ++genid,
                    Key = "txt_headhunting_service_fee",
                    Description = "TEXT FOR HEADHUNTING SERVICE FEE",
                    IsHtmlEditor = true,
                },

                new Conf
                {
                    Id = ++genid,
                    Key = "txt_headhunting_submit_job_description",
                    Description = "hunting submit job description",
                    IsHtmlEditor = true

                },
                new Conf
                {
                    Id = ++genid,
                    Key = "txt_employee_vip_post_a_job",
                    Description = "Post a job description",

                },
                new Conf
                {
                    Id = ++genid,
                    Key = "txt_employees_clients",
                    Description = "Employees clients description",
                    IsHtmlEditor = true

                },
                new Conf
                {
                    Id = ++genid,
                    Key = "website_logo",
                    Description = "Logo website",
                    IsImg = true,
                    Content = "/content/dccd/assets/img/dienchanlieuphap.jpg",

                },
                new Conf
                {
                    Id = ++genid,
                    Key = "msg_scores_empty",
                    Description = "Message when score is zero",
                    IsHtmlEditor = true
                },
            };
        }
    }

}
