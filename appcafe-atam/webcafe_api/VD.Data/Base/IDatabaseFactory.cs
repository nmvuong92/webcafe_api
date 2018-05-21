using System;
using System.Data.Entity;

namespace VD.Data.Base
{
    public interface IDatabaseFactory: IDisposable
    {
        DbContext Get();
    }
}
