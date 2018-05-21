using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data.Entity.MF
{
    public class TrangThaiGiaoHang
    {
        [Key]
        //[DatabaseGenerated(databaseGeneratedOption:DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string CssLabel { get; set; }

        public static TrangThaiGiaoHang[] seed()
        {
            return new TrangThaiGiaoHang[]
            {
                new TrangThaiGiaoHang()
                {
                    Id = 1,
                    Ten = "Chưa giao hàng",
                    CssLabel = "label label-default"
                }, 
                new TrangThaiGiaoHang()
                {
                    Id=2,
                    Ten = "Đã giao hàng",
                    CssLabel = "label label-success"
                }
            };
        }
    }
}
