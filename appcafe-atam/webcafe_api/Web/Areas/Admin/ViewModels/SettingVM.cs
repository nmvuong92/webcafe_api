

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Web.Areas.Admin.ViewModels
{
    public class SettingRppVM
    {
        [MuiSys("setting_row_per_page")]
        public int row_per_page { get; set; }

    }

    public class GiaVipVM
    {
        [Display(Name="Mệnh giá thẻ cào mua thành viên VIP")]
        public int menh_gia_the_cao_mua_thanh_vien_vip1 { get; set; }
    }
    public class SettingSmtpVM
    {
        [MuiSys("setting_smpt_port")]
        public int smpt_port { get; set; } /*587*/
        [MuiSys("setting_smpt_host")]

        public string smpt_host { get; set; } /*smtp.gmail.com*/
        [MuiSys("setting_smpt_enable_ssl")]

        public bool smpt_enable_ssl { get; set; }  /*false*/
        [MuiSys("setting_smpt_use_default_credentials")]

        public bool smpt_use_default_credentials { get; set; } /*false*/
    }

    public class SettingEmailRobotVM
    {

        [MuiSys("setting_sys_email")]
        public string sys_email { get; set; }

        [MuiSys("setting_sys_email_robot")]
        public string sys_email_robot { get; set; }

        [MuiSys("setting_sys_email_robot_pw")]
        public string sys_email_robot_pw { get; set; }
    }


    public class SettingThongBaoDatHangVM
    {
        [Display(Name = "Nội dung")]
        public string etmp_thong_bao_dat_hang { get; set; }
        [Display(Name="Tiêu đề")]
        public string etmp_thong_bao_dat_hang_title { get; set; }

    }
    public class SettingEmailContactVM
    {
        [Display(Name = "Auto reply contact")]
        public bool is_reply_contact { get; set; }
        [Display(Name = "Content template")]
        [AllowHtml]
        public string etmp_reply_contact { get; set; }
        [Display(Name = "Title template")]
        public string etmp_reply_contact_title { get; set; }

    }
    public class SettingFeeScoreVM
    {
        [Display(Name = "Post recruitment")]
        public int fee_score_post_recruitment { get; set; }
        [Display(Name = "Post filter profile")]
        public int fee_score_filter_profile { get; set; }
  


        [Display(Name = "Urgent")]
        public int fee_score_label_urgent { get; set; }
        [Display(Name = "Hot")]
        public int fee_score_label_hot { get; set; }
        [Display(Name = "New")]
        public int fee_score_label_new { get; set; }
        [Display(Name = "Top")]
        public int fee_score_label_top { get; set; }

    }


    public class SettingEmployerRegisterVM
    {
        [Display(Name = "Content template")]
        [AllowHtml]
        public string etmp_reply_employer_register_content { get; set; }
        [Display(Name = "Title template")]
        public string etmp_reply_employer_register_title { get; set; }

    }
    public class SettingEmployerRegisterSendAdminVM
    {
        [Display(Name = "Content template")]
        [AllowHtml]
        public string etmp_reply_employer_register_content_send_admin { get; set; }
        [Display(Name = "Title template")]
        public string etmp_reply_employer_register_title_send_admin { get; set; }

    }
    public class SettingCadidateRegisterVM
    {
        [Display(Name = "Content template")]
        [AllowHtml]
        public string etmp_reply_cadidate_register_content { get; set; }
        [Display(Name = "Title template")]
        public string etmp_reply_cadidate_register_title { get; set; }

    }
    public class SettingCadidateRegisterSendAdminVM
    {
        [Display(Name = "Content template")]
        [AllowHtml]
        public string etmp_reply_cadidate_register_content_send_admin { get; set; }
        [Display(Name = "Title template")]
        public string etmp_reply_cadidate_register_title_send_admin { get; set; }

    }


    public class SettingPurchaseWalletVM
    {
        [Display(Name = "Content template")]
        [AllowHtml]
        public string etmp_reply_purchase_wallet_content { get; set; }
        [Display(Name = "Title template")]
        public string etmp_reply_purchase_wallet_title { get; set; }

    }

    public class SettingStatisticsJobsAndCVVM
    {
        [Display(Name = "Content template")]
        [AllowHtml]
        public string etmp_statis_job_cs_content { get; set; }
        [Display(Name = "Title template")]
        public string etmp_statis_job_cs_title { get; set; }

    }
}