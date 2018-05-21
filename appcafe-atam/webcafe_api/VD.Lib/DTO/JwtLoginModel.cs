using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Lib.DTO
{
    public class JwtLoginModel
    {
        public int uid { get; set; }
        public string exp { get; set; }
    }
}
