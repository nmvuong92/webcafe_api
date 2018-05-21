
using System;
using System.Data;
using System.Data.Entity;
using VD.Data.Base;
namespace VD.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDatabaseFactory _databaseFactory;
        private DbContext _dbContext;
  

        public UnitOfWork(IDatabaseFactory databaseFatory)
        {
            this._databaseFactory = databaseFatory;

        }
        public DbContext dbContext
        {
            get { return _dbContext ?? (_dbContext = _databaseFactory.Get()); }
        }
        public DbContextTransaction transaction
        {
            get { return dbContext.Database.BeginTransaction(); }
        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
