using VD.Data.Base;
using VD.Data.Repository;
using VD.Data.Entity;

using VD.Data.IRepository;
namespace VD.Data.Repository
{
    public  class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork uOW) : base(uOW) { }
    }
}
