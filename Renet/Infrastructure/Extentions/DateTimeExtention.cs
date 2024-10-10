using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extentions {
    public static class DateTimeExtention {
        public static string ToPersianDate(this DateTime dateTime) {
            var pc = new PersianCalendar();
            var result = $"{pc.GetYear(dateTime)}-{pc.GetMonth(dateTime)}-{pc.GetDayOfMonth(dateTime)}";
            return result;
        }

        public static string ToTime(this DateTime dateTime) {
            var result = $"{dateTime.Hour.ToString("00")}:{dateTime.Minute.ToString("00")}";
            return result;
        }
    }


}
