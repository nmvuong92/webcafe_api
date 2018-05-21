using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Lib.DTO;
using Web.Models.ThuanHanhMobileApp.VM;

namespace Web.Apis
{
    public class QuanController : ApiController
    {
        vuong_cms_context __db = new vuong_cms_context();
        [HttpGet]
        [AcceptVerbs("OPTIONS")]
        public rs get_by_id(int id)
        {

            rs r;
            Quan quan = null;
            var data = __db.Quan.FirstOrDefault(f=>f.Id==id);
            if (data != null)
            {
                quan = new Quan()
                {
                    Id = data.Id,
                    MaQuan = data.MaQuan,
                    TenQuan = data.TenQuan,
                    DiaChi = data.DiaChi,
                    DienThoai = data.DienThoai,
                    ImageThumbnail = Utils.site + data.ImageThumbnail + "?v=2",
                    /*Ban = data.Ban.ToList().Select(s=>new Ban()
                    {
                        Id=s.Id,
                        TenBan = s.TenBan,
                        MaBan = s.MaBan,
                    }).ToList()*/
                };
                r = rs.T("Ok", quan);
            }
            else
            {
                r = rs.F("Không tìm thấy quán");
            }
            return r;
        }
    }
}