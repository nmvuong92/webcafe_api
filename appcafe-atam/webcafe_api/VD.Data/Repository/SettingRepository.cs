using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.IRepository;

namespace VD.Data.Repository
{
    public class SettingRepository:RepositoryBase<Setting>,ISettingRepository
    {
        public SettingRepository(IUnitOfWork UOW):base(UOW){}

        public Setting GetSetting()
        {

            return CacheServ.GetOrSet<Setting>(constCacheKey.vd_setting, () =>
                {
                    try
                    {
                        return _dbContext.Set<Setting>().Find(1);
                    }
                    catch
                    {
                        return null;
                    }
                });
        }
    }
}
