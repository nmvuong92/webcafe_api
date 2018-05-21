using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Entity.MF;

namespace VD.Data.IRepository
{
    public interface IImgTmpRepository : IRepository<ImgTmp>
    {
        int Create();
       
    }
}
