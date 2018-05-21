using VD.Data.IRepository;
namespace VD.Services.ConfigServc
{
    public class ConfigService:IConfigService
    {
        private readonly IConfigRepository _repo;
        public ConfigService(IConfigRepository _repo)
        {
            this._repo = _repo;
        }
    }
}
