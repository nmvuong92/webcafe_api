using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VD.Data.Entity.Logging
{
    
    public class LogType
    {
        public LogType()
        {

        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Log> Logs { get; set; }

        public static LogType[] seed()
        {
            return new LogType[]
            {
                new LogType() {Id = 1, Name = "Info"},
                new LogType() {Id = 2, Name = "Warning"},
                new LogType() {Id = 3, Name = "Error"},
            };
        }
    }
}
