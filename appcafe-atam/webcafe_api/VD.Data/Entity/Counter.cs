using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VD.Data.Entity
{
    
    public class Counter
    {
        [Key, Required]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }

    [NotMapped]
    public class Statistic
    {
        public Statistic()
        {
            HomNay = HomQua = TuanNay = TuanTruoc = ThangNay = ThangTruoc = TatCa = 0;
        }
        public int HomNay { get; set; }
        public int HomQua { get; set; }
        public int TuanNay { get; set; }
        public int TuanTruoc { get; set; }
        public int ThangNay { get; set; }
        public int ThangTruoc { get; set; }
        public int TatCa { get; set; }
    }
}
