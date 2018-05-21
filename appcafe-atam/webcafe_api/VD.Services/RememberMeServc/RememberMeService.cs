using VD.Data.IRepository;
using VD.Services.Role;

namespace VD.Services.RememberMeServc
{
    public class RememberMeService:IRememberMeService
    {
        private readonly IRememberMeRepository _repo;
        public RememberMeService(IRememberMeRepository _repo)
        {
            this._repo = _repo;
        }
    }
}