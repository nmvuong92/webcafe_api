using System;
using System.Globalization;

namespace JWT
{
    /// <summary>
    /// Provider for UTC DateTime.
    /// </summary>
    public sealed class UtcDateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// Retuns the current time (UTC).
        /// </summary>
        /// <returns></returns>
        public DateTime GetNow()
        {
            return DateTime.UtcNow;
        }
            
    }

    public static class JwtDatetimeEtx
    {
        public static string toJWTString(this DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static DateTime getJWTDatetime(this string value)
        {
            return DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss",CultureInfo.InvariantCulture);
        }
    }
   
    
}