using System.ComponentModel.DataAnnotations;
using PagedList;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Lib;

namespace Web.Areas.Admin.ViewModels
{
    public class SliderView
    {
        public IPagedList<Slider> Rows { get; set; }
    }
    public class SliderCrud:Input
    {
        public SliderCrud()
        {
            this.Order = myNumbers.LaySoNgauNhienTuDen(1, 100);
        }

        public string Url { get; set; }

        [Display(ResourceType = typeof(mui.mui), Name = "image")]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(mui.mui))]
        public string Image { get; set; }
        [Display(ResourceType = typeof(mui.mui), Name = "order")]
        public int Order { get; set; }
    }
}