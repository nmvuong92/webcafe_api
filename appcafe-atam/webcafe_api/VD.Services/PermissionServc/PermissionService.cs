using VD.Data;
using VD.Data.IRepository;

namespace VD.Services.PermissionServc
{
    public class PermissionService:IPermissionService
    {
        private readonly IPermissionRepository _repo;

        public PermissionService(IPermissionRepository _repo)
        {
            this._repo = _repo;
        }
    }
}
