using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.Logging
{

    public class Log
    {
        [Key]
        public int Id { get; set; }
       
        public string Message { get; set; }
        public int LogTypeId { get; set; }

        [ForeignKey("LogTypeId")]
        public virtual LogType LogType { get; set; }

        public virtual LogException LogException { get; set; }
    }
}
