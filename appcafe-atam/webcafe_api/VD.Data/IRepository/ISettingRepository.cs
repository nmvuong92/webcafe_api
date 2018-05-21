using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Data.Base;
using VD.Data.Entity;

namespace VD.Data.IRepository
{
    public interface ISettingRepository:IRepository<Setting>
    {
        Setting GetSetting();
    }
}
