using VD.Data;
using VD.Data.IRepository;

namespace VD.Services.RoleServc
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repo;

        public RoleService(IRoleRepository _repo)
        {
            this._repo = _repo;
        }
    }
}