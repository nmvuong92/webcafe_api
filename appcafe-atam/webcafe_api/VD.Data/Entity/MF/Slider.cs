using System.ComponentModel.DataAnnotations;
using VD.Lib;

namespace VD.Data.Entity.MF
{
    public class Slider : BaseEntity
    {
        public Slider()
        {
            this.Order = myNumbers.LaySoNgauNhienTuDen(1, 100);
            this.Active = true;
        }
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Alt { get; set; }
        [Display(Name = "Thứ tự")]
        public int Order { get; set; } //auto seed
        public bool Active { get; set; }

        public static Slider[] seed()
        {
            return new Slider[]
            {
                new Slider()
                {
                    Id = 1,
                    Image = "/content/dccd/assets/img/slide1.jpg",
                    Alt = string.Empty,
                    Url = string.Empty,
                    Order = 1,
                }, 
                 new Slider()
                {
                    Id = 2,
                    Image =  "/content/dccd/assets/img/slide2.jpg",
                     Alt = string.Empty,
                    Url = string.Empty,
                    Order = 2,
                }, 
                   new Slider()
                {
                    Id = 3,
                    Image =  "/content/dccd/assets/img/slide3.jpg",
                     Alt = string.Empty,
                    Url = string.Empty,
                    Order = 3,
                }, 
                new Slider()
                {
                    Id = 4,
                    Image =  "/content/dccd/assets/img/slide4.jpg",
                     Alt = string.Empty,
                    Url = string.Empty,
                    Order = 4,
                }, 
            };
        }
    }
}
