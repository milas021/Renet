using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extentions
{
  public static  class DateTimeExtention
    {
        public static string ToPersianDate(this DateTime dateTime) {
            var pc = new PersianCalendar();
            var result = $"{pc.GetYear(dateTime)}-{pc.GetMonth(dateTime)}-{pc.GetDayOfMonth(dateTime)}";
            return result ;
        }
    }
}
