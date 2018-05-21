using System;
using System.Linq.Expressions;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.Paging;
using VD.Lib.DTO;

namespace VD.Data.IRepository
{
    public interface IDonHangRepository : IRepository<DonHang>
    {
        PG<DonHang> GetQueryPaging(donhang_sp paging = null, Expression<Func<DonHang, bool>> where = null);
    }
}
