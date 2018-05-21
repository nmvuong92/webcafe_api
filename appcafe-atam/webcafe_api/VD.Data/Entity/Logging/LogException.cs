using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.Logging
{
 
    public class LogException
    {
        [Key]
        [ForeignKey("Log")]
        public int Id { get; set; }
        public string ExceptionMsg { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionURL { get; set; }
        public DateTime Logdate { get; set; }
        public virtual Log Log { get; set; }
    }
}
