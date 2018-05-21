using System;
using System.Linq;
using VD.Data.Base;
using VD.Data.Repository;
using VD.Data.Entity;

using VD.Lib;
using VD.Lib.DTO;
using VD.Data.IRepository;
using VD.Data.Paging;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace VD.Data.Repository
{
    public class ConfigRepository : RepositoryBase<Conf>, IConfigRepository
    {
        public ConfigRepository(IUnitOfWork uOW) : base(uOW) { }

        public override Conf GetEntry(int id)
        {
            var item = base.GetEntry(id);
            return item;
        }

        /// <summary>
        /// Get entry
        /// </summary>
        /// <param name="key"></param>
        /// <param name="site"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public virtual Conf GetEntry(string key)
        {
            var item = base.GetList(i => i.Key.Equals(key)).Take(1).SingleOrDefault();
            return item;
        }
        /// <summary>
        /// lấy nội dung
        /// </summary>
        /// 
        public virtual SysConfigVM GetConfigCache()
        {
            var __idlang = myCookies.GetLangKey();

            return CacheServ.GetOrSet<SysConfigVM>(constCacheKey.vd_sys_configs +"_"+ __idlang,
                () =>
                {
                    try
                    {
                        SysConfigVM vm = new SysConfigVM();
                        foreach (var prop in vm.GetType().GetProperties())
                        {
                            prop.SetValue(vm, GetContentCulture(prop.Name, __idlang), null);
                        }
                        return vm;
                    }
                    catch
                    {
                        return new SysConfigVM();
                    }
                });
        }
        public virtual string GetContentCulture(string key, int __idlang)
        {
            return CacheServ.GetOrSet<string>(key + "_" + __idlang,
                () =>
                {
                    try
                    {
                        var get = _dbContext.Set<Conf>().FirstOrDefault(i => i.Key.Equals(key));
                        if (get == null)
                        {
                            return "-empty-";
                        }

                     
                        return get.Content;
                       
                           
                    }
                    catch
                    {
                        return "-not-found-";
                    }
                });
        }


        /// <returns></returns>
        public virtual string GetContent(string key)
        {
            var __idlang = myCookies.GetLangKey();
            return CacheServ.GetOrSet<string>(key + "_" + __idlang,
                () =>
                {
                    try
                    {
                        var get = _dbContext.Set<Conf>().FirstOrDefault(i => i.Key.Equals(key));

                        if (get != null)
                        {
                            return get.Content;
                        }
                        return "-not-found-";
                    }
                    catch
                    {
                        return "-not-found-";
                    }
                });
        }
     
        public virtual void Delete(string key)
        {
            base.Delete(i => i.Key.Equals(key));
        }


        public PG<Conf> GetQueryPaging(Conf_filter paging = null, Expression<Func<VD.Data.Entity.Conf, bool>> where = null)
        {
            IQueryable<Conf> query;
            //PHÂN QUYỀN ĐỒ
            query = GetList(where);
       

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
                        query = query.FullTextSearch(loc1.giatriloc, true);
                    }
                    else
                    {
                        if (loc.tentruongloc.Equals("Key"))
                        {
                            boloc loc1 = loc;
                            query = query.Where(q => q.Key.Contains(loc1.giatriloc));
                        }
                        
                    }
                }
            }
            return (new PGQuery<Conf>(query)).GetPG(paging);
        }


    }
  
}