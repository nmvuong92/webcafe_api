
using VD.Data.Base;
using VD.Data.Entity;

namespace VD.Data.IRepository
{
    public interface ICounterRepository:IRepository<Counter>
    {
        void SetCounter();
        Statistic GetCounter();
    }
}
