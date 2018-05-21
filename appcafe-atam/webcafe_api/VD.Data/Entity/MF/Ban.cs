using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.MF
{
    public class Ban:BaseEntity
    {
        [Display(Name = "Mã bàn")]
        [MaxLength(100)]
        public string MaBan { get; set; }


        [Display(Name = "Tên bàn")]
        [Required]
        [MaxLength(200)]
        public string TenBan { get; set; }



        [Display(Name="STT")]
        public int STT { get; set; }



        //bàn thuộc quán nào
        [Display(Name = "Quán")]
        public int QuanId { get; set; }
        [ForeignKey("QuanId")]
        public virtual Quan Quan { get; set; }

        public static Ban[] seed()
        {
            List<Ban> lst = new List<Ban>();
            for (int j = 1; j <= 3; j++)
            {
                  for (var i = 0; i < 5; i++)
                    {
                        lst.Add(new Ban()
                        {
                            MaBan = "Ban"+i,
                            TenBan = "Bàn "+i,
                            QuanId = j,
                        });
                    }
            }

            return lst.ToArray();
        }
    }
}
