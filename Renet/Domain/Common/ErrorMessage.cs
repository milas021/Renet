﻿using System;
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
    }
}