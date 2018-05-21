using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VD.Lib;

namespace VD.Data.Entity
{
 
    public class Lang
    {
        public Lang()
        {
            Order = myNumbers.LaySoNgauNhienTuDen(1, 100);
        }
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Flag { get; set; }

        [Required]
        public int Order { get; set; }


        public static Lang[] seed()
        {
            return new Lang[]
            {
                new Lang()
                {
                    Id = 1,
                    Code = "en-US",
                    Name = "English - United States",
                    Flag =
                        "/Content/hht/images/flag/us.png",
                    Order = 1,
                },
                new Lang()
                {
                    Id = 2,
                    Code = "vi-VN",
                    Name = "Vietnamese - Vietnam ",
                    Flag = "/Content/hht/images/flag/vi.png",
                    Order = 2,

                },
                new Lang()
                {
                    Id = 3,
                    Code = "ko-KR",
                    Name = "Korean - Korea ",
                    Flag = "/Content/hht/images/flag/kr.png",
                    Order = 3,
                },
            };
        }
    }
}
