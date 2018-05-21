namespace VD.Data
{
    public class SysConfigVM
    {
        public string conf_website { get; set; }
        public string conf_email { get; set; }
        public string conf_description { get; set; }
        public string conf_copyright { get; set; }
        public string conf_address { get; set; }
        public string conf_tel { get; set; }
        public string conf_fax { get; set; }
        public string conf_designby { get; set; }
        public string conf_google_map { get; set; }
        public string conf_err_401 { get; set; }
        //validation
        public string conf_val_login_isvalid { get; set; }

        public string conf_val_login_candidates { get; set; }
        public string conf_val_login_employees { get; set; }
        //txt
        public string txt_headhunting_service_fee { get; set; }
        public string txt_headhunting_submit_job_description { get; set; }

        public string txt_employee_vip_post_a_job { get; set; }
        public string txt_employees_clients { get; set; }
        //
        public string website_logo { get; set; }
        public string website_logo2 { get; set; }
        public string msg_scores_empty { get; set; }

        //social network
        public string link_facebook { get; set; }
        public string link_linkedin { get; set; }

        //
        public string conf_website_link { get; set; }
        public string conf_hotline { get; set; }
        public string conf_company_name { get; set; }

    }
}
