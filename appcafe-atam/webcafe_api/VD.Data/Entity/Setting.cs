using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data.Entity
{

    public class Setting
    {
        public Setting()
        {
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string sys_email { get; set; }
        public string sys_email_robot { get; set; }
        public string sys_email_robot_pw { get; set; }


        #region SMTP

        public int smpt_port { get; set; } /*587*/
        public string smpt_host { get; set; } /*smtp.gmail.com*/
        public bool smpt_enable_ssl { get; set; }  /*false*/
        public bool smpt_use_default_credentials { get; set; } /*false*/

        #endregion

        public string ddl_row_per_page { get; set; } /*row_per_page*/
       
      


        #region[rpp]
        public int row_per_page { get; set; }
        #endregion


        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }



        #region email_emplate_contact
        public bool is_reply_contact { get; set; }
        public string etmp_reply_contact { get; set; }
        public string etmp_reply_contact_title { get; set; }
        #endregion

        #region email_thong_bao_dat_hang
        public string etmp_thong_bao_dat_hang { get; set; }
        public string etmp_thong_bao_dat_hang_title { get; set; }
        #endregion

        #region giaodich
        public int menh_gia_the_cao_mua_thanh_vien_vip1 { get; set; }

        #endregion


       
        public int? AboutUsMainId { get; set; }

        public static Setting seed()
        {
            return new Setting
            {
                Id = 1,
                sys_email = "nmvuong92@gmail.com",
                sys_email_robot = "nmvuong2@gmail.com",
                sys_email_robot_pw = "104255020101247154213024095114123176100126129011",
                smpt_port = 587,
                smpt_host = "smtp.gmail.com",
                smpt_enable_ssl = false,
                smpt_use_default_credentials = false,
                row_per_page = 20,
                ddl_row_per_page = "1,5,10,20,30,50,-1",
                
                etmp_reply_contact = "hello {full_name} thanks for contact us",
                etmp_reply_contact_title = "hello {full_name} thanks for contact us",
                is_reply_contact = true,
                menh_gia_the_cao_mua_thanh_vien_vip1 = 500000
            };
        }
    }

}
