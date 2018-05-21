using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data.Entity.MF
{
    public class HinhThucMuaHang
    {
        [Key]
        //[DatabaseGenerated(databaseGeneratedOption:DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Ten { get; set; }

        public static HinhThucMuaHang[] seed()
        {
            return new HinhThucMuaHang[]
            {
                new HinhThucMuaHang()
                {
                    Id = 1,
                    Ten = "Tại quán",
                    
                }, 
                new HinhThucMuaHang()
                {
                    Id=2,
                    Ten = "Mang đi",
                }, 
                new HinhThucMuaHang()
                {
                    Id=3,
                    Ten = "Giao hàng tận nơi",
                }, 
            };
        }
    }
}
