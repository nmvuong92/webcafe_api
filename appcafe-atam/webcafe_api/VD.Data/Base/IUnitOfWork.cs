
using System.Data.Entity;

namespace VD.Data.Base
{
    public interface IUnitOfWork
    {
        void Commit();
        void Save();
        DbContext dbContext { get; }
    }
}
