using System;
using System.Linq.Expressions;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.Paging;
using VD.Lib.DTO;

namespace VD.Data.IRepository
{
    public interface IContactRepository : IRepository<Contact>
    {
        PG<Contact> GetQueryPaging(Contact_filter paging = null, Expression<Func<Contact, bool>> where = null);
        rs SendEmail(sendMailObj obj, bool is_robot = false, bool is_send_to_adm = false);
    }
}
