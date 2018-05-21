using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.MF
{
    public class Contact : BaseEntity
    {
        public Contact()
        {
            this.ContactStatusId = 1;//chua doc
        }
        [Required]
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Required]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Tên công ty")]
        public string CompanyName { get; set; }

        //
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [Display(Name = "Gửi email thành công?")]
        public bool KetQuaGuiMail { get; set; }
        [Display(Name = "Lỗi gửi email")]
        public string LoiGuiMail { get; set; }

        //
        [Display(Name = "Trạng thái")]
        public int ContactStatusId { get; set; }
        [ForeignKey("ContactStatusId")]
        public virtual ContactStatus ContactStatus { get; set; }



    }
    public class ContactStatus
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Html { get; set; }
        [NotMapped]
        public string NameHtml
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.Html) && this.Html.Contains("{0}"))
                {
                    return string.Format(this.Html, this.Name);
                }
                else
                {
                    return this.Name;
                }
            }
        }
        public static ContactStatus[] seed()
        {
            return new ContactStatus[]{
                new ContactStatus{Id=1,Name="Chưa đọc",Html="<span class='label label-warning'>{0}</i>"},
                new ContactStatus{Id=2,Name="Đã đọc",Html="<span class='label label-success'>{0}</i>"},
                new ContactStatus{Id=3,Name="Đã phản hồi",Html="<span class='label label-success'>{0} <i class='fa fa-reply'></i></i>"},
                new ContactStatus{Id=4,Name="Spam",Html="<span class='label label-danger'>{0}</i>"},
            };
        }
    }
}
