using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace VD.Lib
{
    public class myDatetimes
    {
        //tất cả ngày trong tháng
        public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }
        //tất cả ngày từ đến
        public static IEnumerable<DateTime> AllDatesInFromTo(DateTime f, DateTime t)
        {//đã cộng giá trị t truyên
            for (DateTime date = f; date < t; date = date.AddDays(1))
                yield return date;
        }
        //tất cả ngày tháng từ đến +1
        public static IEnumerable<DateTime> AllDatesInFromToPlusOne(DateTime f, DateTime t)
        {//đã cộng giá trị t truyên
            for (DateTime date = f.Date; date <= t.Date; date = date.AddDays(1))
                yield return date;
        }
        //nằm trong ds ngày
        public static bool isNamTrongDSNgay(List<DateTime> lst, DateTime d)
        {
            return lst.Any(ngay => ngay.Date == d.Date);
        }

    }

    public static class MyDatetimesExtMethod
    {
        //parse chuỗi thành kiểu timespane
        public static TimeSpan ToTimeSpan(this object value)
        {
            return TimeSpan.ParseExact(value.ToString(), @"h\:m", CultureInfo.InvariantCulture);
        }
        //tostring timespan
        public static string ToChuoiTimeSpan(this System.TimeSpan value)
        {
            return value.ToString(@"hh\:mm");
        }
        //parse chuỗi thành kiểu ngày tháng năm
        public static DateTime toDate(this string value)
        {
            return DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }

        //thay đổi thời gian: giờ, phút, giây, miligiay
        public static DateTime ThayDoiThoiGian(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }

        //thay đổi thời gian (phần timespan)
        public static DateTime ThayDoiThoiGian(this DateTime dateTime, TimeSpan timeSpan)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                timeSpan.Hours,
                timeSpan.Minutes,
                timeSpan.Seconds,
                timeSpan.Milliseconds,
                dateTime.Kind);
        }
        //hien tai
        public static DateTime ThayDoiThoiGianHienTai(this DateTime dateTime)
        {
            return ThayDoiThoiGian(dateTime, DateTime.Now.TimeOfDay);
        }
        //xuất chuỗi datetime
        public static string XuatDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm");
        }

        //xuất chuỗi datetime
        public static string XuatDateTime(this DateTime? dateTime)
        {
            return dateTime != null ? dateTime.Value.ToString() : "";
        }
        //xuất chuỗi time
        public static string XuatTime(this DateTime? dateTime)
        {
            return dateTime != null ? dateTime.Value.ToString("hh:mm:ss tt") : "";
        }
        //xuất chuỗi date
        public static string XuatDate(this DateTime dateTime)
        {
            return dateTime.ToShortDateString();
        }
        public static string XuatDate(this DateTime? dateTime)
        {

            return dateTime != null ? dateTime.Value.ToString("dd/MM/yyyy") : "";
        }
        public static string TimeAgo(this DateTime? dateTime)
        {
           
            if (dateTime != null)
            {
                DateTime d = dateTime.Value;
               // 1.
	                // Get time span elapsed since the date.
	                TimeSpan s = DateTime.Now.Subtract(d);

	                // 2.
	                // Get total number of days elapsed.
	                int dayDiff = (int)s.TotalDays;

	                // 3.
	                // Get total number of seconds elapsed.
	                int secDiff = (int)s.TotalSeconds;

	                // 4.
	                // Don't allow out of range values.
	                if (dayDiff < 0 || dayDiff >= 31)
	                {
	                    return null;
	                }

	                // 5.
	                // Handle same-day times.
	                if (dayDiff == 0)
	                {
	                    // A.
	                    // Less than one minute ago.
	                    if (secDiff < 60)
	                    {
		                return "just now";
	                    }
	                    // B.
	                    // Less than 2 minutes ago.
	                    if (secDiff < 120)
	                    {
		                return "1 minute ago";
	                    }
	                    // C.
	                    // Less than one hour ago.
	                    if (secDiff < 3600)
	                    {
		                return string.Format("{0} minutes ago",
		                    Math.Floor((double)secDiff / 60));
	                    }
	                    // D.
	                    // Less than 2 hours ago.
	                    if (secDiff < 7200)
	                    {
		                return "1 hour ago";
	                    }
	                    // E.
	                    // Less than one day ago.
	                    if (secDiff < 86400)
	                    {
		                return string.Format("{0} hours ago",
		                    Math.Floor((double)secDiff / 3600));
	                    }
	                }
	                // 6.
	                // Handle previous days.
	                if (dayDiff == 1)
	                {
	                    return "yesterday";
	                }
	                if (dayDiff < 7)
	                {
	                    return string.Format("{0} days ago",
		                dayDiff);
	                }
	                if (dayDiff < 31)
	                {
	                    return string.Format("{0} weeks ago",
		                Math.Ceiling((double)dayDiff / 7));
	                }
	                return null;
                   
               
            }
            return "-";
          

        }
        public static string TimeAgo(this DateTime dateTime)
        {

            if (dateTime != null)
            {
                DateTime d = dateTime;
                // 1.
                // Get time span elapsed since the date.
                TimeSpan s = DateTime.Now.Subtract(d);

                // 2.
                // Get total number of days elapsed.
                int dayDiff = (int)s.TotalDays;

                // 3.
                // Get total number of seconds elapsed.
                int secDiff = (int)s.TotalSeconds;

                // 4.
                // Don't allow out of range values.
                if (dayDiff < 0 || dayDiff >= 31)
                {
                    return "-";
                }

                // 5.
                // Handle same-day times.
                if (dayDiff == 0)
                {
                    // A.
                    // Less than one minute ago.
                    if (secDiff < 60)
                    {
                        return "Vừa xong";
                    }
                    // B.
                    // Less than 2 minutes ago.
                    if (secDiff < 120)
                    {
                        return "1 phút trước";
                    }
                    // C.
                    // Less than one hour ago.
                    if (secDiff < 3600)
                    {
                        return string.Format("{0} phút trước",
                            Math.Floor((double)secDiff / 60));
                    }
                    // D.
                    // Less than 2 hours ago.
                    if (secDiff < 7200)
                    {
                        return "1 giờ trước";
                    }
                    // E.
                    // Less than one day ago.
                    if (secDiff < 86400)
                    {
                        return string.Format("{0} giờ trước",
                            Math.Floor((double)secDiff / 3600));
                    }
                }
                // 6.
                // Handle previous days.
                if (dayDiff == 1)
                {
                    return "Hôm qua";
                }
                if (dayDiff < 7)
                {
                    return string.Format("{0} ngày trước",
                    dayDiff);
                }
                return dateTime.XuatDateTime();
            }
            return "-";
        }
        //chuyển c# datetme format tới jquery datetime picker format

        /// <summary>
        /// Gets the javascript short date pattern.
        /// </summary>
        /// <param name="dateTimeFormat">The date time format.</param>
        /// <returns></returns>
        /// 
    }

    public class JQEXT
    {
        public static string GetJavascriptShortDatePattern(DateTimeFormatInfo dateTimeFormat)
        {
            return dateTimeFormat.ShortDatePattern
                .Replace("M", "m")
                .Replace("yy", "y");
        }
    }
}
