﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting
{
   public class Tools
    {
        public static void CheckDate(DevExpress.XtraEditors.TextEdit textBox)
        {
            var splited = textBox.Text.Split('/');
            var year = splited[0].Replace("_", "");
            var month = splited[1].Replace("_", "");
            var day = splited[2].Replace("_", "");

            PersianCalendar pc = new PersianCalendar();


            if (year.Length < 4)
            {
                year = pc.GetYear(DateTime.Now).ToString();
            }

            if (month.Length < 1 || (month.Length > 0 && int.Parse(month) == 0) || (month.Length > 0 && int.Parse(month) > 12))
            {
                month = pc.GetMonth(DateTime.Now).ToString();
            }

            if (day.Length < 1 || (day.Length > 0 && int.Parse(day) == 0) || (day.Length > 0 && int.Parse(month) <= 6 && int.Parse(day) > 31)

                || (day.Length > 0 && int.Parse(month) > 6 && int.Parse(day) > 30))
            {
                day = pc.GetDayOfMonth(DateTime.Now).ToString();

            }

            textBox.Text = $"{year}/{month}/{day}";
        }
    }
}