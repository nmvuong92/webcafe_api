using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data.Entity.MF
{
    public class Article : BaseEntity
    {
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

        public static Article[] seed()
        {
            List<Article> l = new List<Article>();
            //about us
            for (int i = 1; i <= 3; i++)
            {
                bool ismain = i == 1;
                l.Add(new Article()
                {
                    Id = i,
                    Title = "ABOUT US" + i,
                    CategoryId = 1,
                    Description = "CÔNG TY TNHH NHỰA MING FENG VIỆT NAM",
                    Content = "<h1>CÔNG TY TNHH NHỰA MING FENG VIỆT NAM</h1><br/>Past 40 years, Di Chun insists the spirit of “Quality to be the must and customer must to be the first; do the right thing; seeking the truth and finding the cause",
                    SEOTitle = "cong-ty-abc",
                    ImageThumbnail = "https://static1.squarespace.com/static/53f54afbe4b095875281dfea/t/59987d137131a51239a91316/1503165726863/aboutus.jpg",
                    LuotXem = i,
                });
            }


            //news
            for (int i = 4; i <= 25; i++)
            {
                l.Add(new Article()
                {
                    Id = i,
                    Title = "NEWS " + i,
                    CategoryId = 2,
                    Description = "CÔNG TY TNHH NHỰA MING FENG VIỆT NAM",
                    Content = "<h1>CÔNG TY TNHH NHỰA MING FENG VIỆT NAM</h1><br/>Past 40 years, Di Chun insists the spirit of “Quality to be the must and customer must to be the first; do the right thing; seeking the truth and finding the cause",
                    SEOTitle = "cong-ty-abc",
                    ImageThumbnail = "http://s3.amazonaws.com/digitaltrends-uploads-prod/2016/01/News-Apps-Header.jpg",
                    LuotXem = i,
                });
            }
            for (int i = 26; i <= 29; i++)
            {
                l.Add(new Article()
                {
                    Id = i,
                    Title = "NEWS " + i,
                    CategoryId = 3,
                    Description = "Hướng dẫn mua hàng",
                    Content = "<h1>CÔNG TY TNHH NHỰA MING FENG VIỆT NAM</h1><br/>Past 40 years, Di Chun insists the spirit of “Quality to be the must and customer must to be the first; do the right thing; seeking the truth and finding the cause",
                    SEOTitle = "cong-ty-abc",
                    ImageThumbnail = "http://s3.amazonaws.com/digitaltrends-uploads-prod/2016/01/News-Apps-Header.jpg",
                    LuotXem = i,
                    FontAwesomeIcon = "fa fa-tasks"
                });
            }

            return l.ToArray();
        }
    }
}
