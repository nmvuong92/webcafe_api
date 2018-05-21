using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VD.Data.Entity.MF;

namespace Web.Models.ThuanHanhMobileApp.VM
{
    public class ArticleVM
    {
        public int Id { get; set; }
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề SEO")]
        public string SEOTitle { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Ảnh")]
        public string ImageThumbnail { get; set; }
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "Lượt xem")]
        public int LuotXem { get; set; }
        [Display(Name = "Biểu tượng font-awesome")]
        public string FontAwesomeIcon { get; set; }


        public static ArticleVM map(Article item)
        {
            return new ArticleVM()
            {
                Id=item.Id,
                Title = item.Title,
                SEOTitle = item.SEOTitle,
                Content = item.Content,
                Description = item.Description,
                CategoryId = item.CategoryId,
                ImageThumbnail = Utils.site + item.ImageThumbnail,
            };
        }

        public static IEnumerable<ArticleVM> map(IEnumerable<Article> data)
        {
            List<ArticleVM> rs = new List<ArticleVM>();
            foreach (var item in data)
            {
                rs.Add(map(item));
            }
            return rs;
        } 
    }
}