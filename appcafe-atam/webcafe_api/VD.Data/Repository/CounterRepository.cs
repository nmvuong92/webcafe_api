using System;
using System.Linq;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.IRepository;

namespace VD.Data.Repository
{
    public class CounterRepository:RepositoryBase<Counter>,ICounterRepository
    {
        public CounterRepository(IUnitOfWork UOW):base(UOW) { }
        public void SetCounter()
        {
            var now = DateTime.Now.Date;
            var item = GetList(i => i.Date.Equals(now)).Take(1).SingleOrDefault();
            if (item == null)
            {
                item = new Counter();
                item.Date = DateTime.Now.Date;
                item.Value = 1;
                Insert(item);
                Save();
            }
            else
            {
                item.Value += 1;
                Update(item);
                Save();
            }
        }


        public Statistic GetCounter()
        {
            var cul = System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString();
            var list = GetList();

            var item = new Statistic();

            //hôm nay
            var dateToday = DateTime.Now.Date;
            item.HomNay = list.Where(i => i.Date.Equals(dateToday)).Sum(i => (int?)i.Value) ?? 0;

            //hôm qua
            var dateYesterday = dateToday.AddDays(-1).Date;
            item.HomQua = list.Where(i => i.Date.Equals(dateYesterday)).Sum(i => (int?)i.Value) ?? 0;

            //tuần này
            var startWeek = dateToday.AddDays(DayOfWeek.Monday - dateToday.DayOfWeek).Date;
            item.TuanNay = list.Where(i => i.Date >= startWeek).Sum(i => (int?)i.Value) ?? 0;

            //tuần trước
            var lastWeek = startWeek.AddDays(-7).Date;
            item.TuanTruoc = list.Where(i => i.Date >= lastWeek && i.Date < startWeek).Sum(i => (int?)i.Value) ?? 0;

            //Tháng này
            var startOfMonth = new DateTime(dateToday.Year, dateToday.Month, 1).Date;
            item.ThangNay = list.Where(i => i.Date >= startOfMonth).Sum(i => (int?)i.Value) ?? 0;


            //Tháng trước
            var lastOfMonth = startOfMonth.AddMonths(-1).Date;
            item.ThangTruoc = list.Where(i => i.Date >= lastOfMonth && i.Date < startOfMonth).Sum(i => (int?)i.Value) ?? 0;

            //Tất cả
            item.TatCa = list.Sum(i => (int?)i.Value) ?? 0;

            return item;
        }
    }
}
