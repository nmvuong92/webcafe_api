using System;
using System.Linq;
using System.Linq.Expressions;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Paging;

namespace VD.Data.IRepository
{
    public interface IConfigRepository : IRepository<Conf>
    {
        SysConfigVM GetConfigCache();
        string GetContentCulture(string key, int __idlang);
        Conf GetEntry(string key);
        string GetContent(string key);
        void Delete(string key);

        PG<Conf> GetQueryPaging(Conf_filter paging = null,Expression<Func<Conf, bool>> where = null);
    }
}
