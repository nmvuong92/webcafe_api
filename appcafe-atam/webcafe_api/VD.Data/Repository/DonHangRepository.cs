using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Lib.DTO;
using VD.Lib.Encode;

namespace VD.Data.Repository
{
    public class DonHangRepository : RepositoryBase<DonHang>, IDonHangRepository
    {
        public DonHangRepository(IUnitOfWork UOW) : base(UOW) { }

        public PG<DonHang> GetQueryPaging(donhang_sp paging = null, Expression<Func<DonHang, bool>> where = null)
        {
            IQueryable<DonHang> query;
            //PHÂN QUYỀN ĐỒ
            query = GetList(where);
            if (paging.quanid != -1)
            {
                query = query.Where(w => w.QuanId == paging.quanid);
            }
            if (paging.trangthaigiaohangid != -1)
            {
                query = query.Where(w => w.TrangThaiGiaoHangId == paging.trangthaigiaohangid);
            }
            if (paging.trangthaithanhtoanid != -1)
            {
                query = query.Where(w => w.TrangThaiThanhToanId == paging.trangthaithanhtoanid);
            }
            if (paging.ban != -1)
            {
                query = query.Where(w => w.Ban==paging.ban);
            }
            if (paging.loctg)
            {
                query = query.Where(e => EntityFunctions.TruncateTime(e.CreatedDate) >= paging.tu
                                         &&
                                         EntityFunctions.TruncateTime(e.CreatedDate) <=
                                         EntityFunctions.TruncateTime(paging.den));
            }
         
         
            //SORTING
            query = query.OrderByField(paging.tentruongsort, paging.giatrisort == "asc");
            //FILTERING
            if (paging.bolocs != null)
            {
                foreach (var loc in paging.bolocs)
                {
                    if (loc.tentruongloc.Equals("full_text_search"))
                    {
                     
                        boloc loc1 = loc;
                        int id_loc = -1;
                        if (int.TryParse(loc1.giatriloc, out id_loc))
                        {
                            query = query.Where(q => q.Id == id_loc);
                        }
                    }
                }
            }
            PG<DonHang> vmpg = null;
            //TOTAL RECORDS
            int tongdong = query.Count();
            decimal tongtien = query.Sum(s => (decimal?)s.TongTienHang) ?? 0;
            //PAGING INFORMATION
            if (paging.tongdongmottrang != -1)
            {
                query = query.Skip(paging.numSkip).Take(paging.tongdongmottrang);
            }

            vmpg = new PG<DonHang>(tongdong, paging.tranghientai, paging.tongdongmottrang, paging.fnjs);
            vmpg.L = query.ToList();
            vmpg.TongTien = tongtien;
            return vmpg;
        }
    }
}
