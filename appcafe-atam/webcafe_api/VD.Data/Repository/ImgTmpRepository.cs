using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.IRepository;

namespace VD.Data.Repository
{
    public  class ImgTmpRepository:RepositoryBase<ImgTmp>,IImgTmpRepository
    {
        public ImgTmpRepository(IUnitOfWork UOW)
            : base(UOW){}
        //


        public int Create()
        {
            var c = base._dbContext.Set<ImgTmp>().Add(new ImgTmp());
            base._dbContext.SaveChanges();
            return c.Id;
        }
    }
}
