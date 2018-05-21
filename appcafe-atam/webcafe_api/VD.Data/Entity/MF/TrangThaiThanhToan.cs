using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data.Entity.MF
{
    public class TrangThaiThanhToan
    {
        [Key]
        //[DatabaseGenerated(databaseGeneratedOption:DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string CssLabel { get; set; }

        public static TrangThaiThanhToan[] seed()
        {
            return new TrangThaiThanhToan[]
            {
                new TrangThaiThanhToan()
                {
                    Id = 1,
                    Ten = "Chưa thanh toán",
                    CssLabel = "label label-default"
                    
                }, 
                new TrangThaiThanhToan()
                {
                    Id=2,
                    Ten = "Đã thanh toán",
                    CssLabel = "label label-success"
                }, 
                new TrangThaiThanhToan()
                {
                    Id=3,
                    Ten = "Hủy bỏ",
                    CssLabel = "label label-danger"
                }, 
            };
        }
    }
}
