using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.MF
{
    public class ImgTmp : BaseEntity
    {
        public virtual ICollection<ImgTmpDetail> ImgTmpDetails { get; set; }

        public static ImgTmp[] seed()
        {
            return new ImgTmp[]
            {
                new ImgTmp()
                {
                    Id=1
                }, 
            };
        }
    }

    public class ImgTmpDetail : BaseEntity
    {
        [Display(Name = "Ảnh đầy đủ")]
        public string FullImage { get; set; }
        [Display(Name = "Ảnh thumbs")]
        public string Thumbnail { get; set; }
        [Display(Name = "Là ảnh chính?")]
        public bool IsMain { get; set; }

        public int ImgTmpId { get; set; }
        [ForeignKey("ImgTmpId")]
        public virtual ImgTmp ImgTmp { get; set; }

        public static ImgTmpDetail[] seed()
        {
            int id = 1;
            return new ImgTmpDetail[]
            {
                new ImgTmpDetail()
                {
                    Id=++id,
                    FullImage = "https://cdn.vox-cdn.com/thumbor/Su22ufw0Nw7BlUtOg5F3e9G-9Hk=/0x0:1717x1044/1200x800/filters:focal(722x385:996x659)/cdn.vox-cdn.com/uploads/chorus_image/image/56671365/vdhnbCX.0.png",
                    Thumbnail ="https://cdn.vox-cdn.com/thumbor/Su22ufw0Nw7BlUtOg5F3e9G-9Hk=/0x0:1717x1044/1200x800/filters:focal(722x385:996x659)/cdn.vox-cdn.com/uploads/chorus_image/image/56671365/vdhnbCX.0.png",
                    ImgTmpId = 1,
                    IsMain = true,
                }, 
                   new ImgTmpDetail()
                {
                    Id=++id,
                    FullImage = "https://cnet2.cbsistatic.com/img/SVArV0NpzrZzcyVYNgybsAB_5e8=/770x433/2017/09/12/61096602-8e41-41d5-a63d-0ed945435e49/iphonexfl.jpg",
                    Thumbnail ="https://cnet2.cbsistatic.com/img/SVArV0NpzrZzcyVYNgybsAB_5e8=/770x433/2017/09/12/61096602-8e41-41d5-a63d-0ed945435e49/iphonexfl.jpg",
                    ImgTmpId = 1,
                    IsMain = false,
                }, 
                  new ImgTmpDetail()
                {
                    Id=++id,
                    FullImage = "http://cdn.newsapi.com.au/image/v1/90c942375cfe0fe484b9ad0a82c62d14?width=650",
                    Thumbnail ="http://cdn.newsapi.com.au/image/v1/90c942375cfe0fe484b9ad0a82c62d14?width=650",
                    ImgTmpId = 1,
                    IsMain = false,
                }, 
            };
        }

    }
}
