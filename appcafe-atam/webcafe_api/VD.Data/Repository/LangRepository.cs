using VD.Data.Base;
using VD.Data.Repository;
using VD.Data.Entity;

using VD.Data.IRepository;
namespace VD.Data.Repository
{
    public class LangRepository : RepositoryBase<VD.Data.Entity.Lang>, ILangRepository
    {
        public LangRepository(IUnitOfWork uOW) : base(uOW) { }
        
    }
}
