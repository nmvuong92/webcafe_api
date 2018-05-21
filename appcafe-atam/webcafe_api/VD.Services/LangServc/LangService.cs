using VD.Data.IRepository;

namespace VD.Services.LangServc
{
    public class LangService:ILangService
    {
        private readonly ILangRepository _repo;
        public LangService(ILangRepository _repo)
        {
            this._repo = _repo;
        }
    }
}
