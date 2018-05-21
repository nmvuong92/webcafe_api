using System.Data.Entity;
using VD.Data.Base;
using VD.Data.Entity;


namespace VD.Data
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {

        private DbContext dataContext;
        public DbContext Get()
        {
            return dataContext ?? (dataContext = new vuong_cms_context());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
    public class DatabaseFactory2 : Disposable, IDatabaseFactory
    {

        private DbContext dataContext2;
        public DbContext Get()
        {
            if (dataContext2 == null)
            {
                dataContext2 = new vuong_cms_context();
            }
            dataContext2.Configuration.LazyLoadingEnabled = false;
            dataContext2.Configuration.ProxyCreationEnabled = false;

            return dataContext2;

        }
        protected override void DisposeCore()
        {
            if (dataContext2 != null)
                dataContext2.Dispose();
        }
    }
}
