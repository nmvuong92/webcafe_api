using VD.Data.Base;
using VD.Data.Repository;
using VD.Data.Entity;

using VD.Data.IRepository;
namespace VD.Data.Repository
{
    public class PermissionRepository:  RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(IUnitOfWork uOW) : base(uOW) { }
    }
}
