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
    public  class SliderRepository:RepositoryBase<Slider>,ISliderRepository
    {
        public SliderRepository(IUnitOfWork UOW)
            : base(UOW){}
        //

    }
}
