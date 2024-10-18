using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ErrorMessage
    {

        public static readonly string InvalidCategoryName = "نام دسته بندی معتبر نیست";
        public static readonly string DuplicateCategoryName = "نام دسته بندی تکراری است";
        public static readonly string UnkonwError = "خطایی در سامانه رخ داد";
        public static readonly string InvalidCategoryIconOrImage = "تصاویر دسته بندی نا معتبر است";
        public static readonly string DuplicatedColorName = "نام رنگ نمیتواند تکراری باشد .";
        public static readonly string UserExist = "کاربر وجود دارد";
        public static readonly string UserNotExist = "کاربر وجود ندارد";
        public static readonly string InvalidProductName = "نام محصول نا معتبر است";
    }
}
