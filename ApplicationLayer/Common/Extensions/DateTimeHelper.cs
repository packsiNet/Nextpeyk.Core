﻿using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace ApplicationLayer.Common.Extensions;

public static class DateTimeHelper
{
    public static DateTime GetDate(this HttpRequest Request, string key)
    {
        return Convert.ToDateTime(Request.Form.FirstOrDefault(k => k.Key == key).Value);
    }

    public static DateTime GetMiladiDate(string shamsiDate)
    {
        PersianCalendar pc = new();
        var shamsiInfo = shamsiDate.Split('/');
        int year = int.Parse(shamsiInfo[0]);
        int month = int.Parse(shamsiInfo[1]);
        int day = int.Parse(shamsiInfo[2]);
        DateTime dt = new DateTime(year, month, day, pc);
        return dt;
    }

    public static string GetMiladiDateString(string shamsiDate)
    {
        PersianCalendar pc = new();
        var shamsiInfo = shamsiDate.Split('/');
        int year = int.Parse(shamsiInfo[0]);
        int month = int.Parse(shamsiInfo[1]);
        int day = int.Parse(shamsiInfo[2]);

        var newDateTime = new DateTime(year, month, day, new PersianCalendar());
        return $"{newDateTime.Year}-{newDateTime.Month}-{newDateTime.Day}";
    }

    public static string GetShamsiDateWithoutSlash(this DateTime? miladi)
    {
        if (miladi.HasValue && miladi != null)
        {
            DateTime param = Convert.ToDateTime(miladi);
            System.Globalization.PersianCalendar Persian = new System.Globalization.PersianCalendar();
            string Year = Persian.GetYear(param).ToString();
            string Month = Persian.GetMonth(param).ToString();
            string Day = Persian.GetDayOfMonth(param).ToString();
            if (Month.Length == 1)
                Month = "0" + Month;
            if (Day.Length == 1)
                Day = "0" + Day;
            return Year + "" + Month + "" + Day;
        }
        return String.Empty;
    }

    public static int GetDayOfWeek(int day)
    {
        if ((int)DayOfWeek.Friday == day)
        {
            return 6;
        }
        else if ((int)DayOfWeek.Thursday == day)
        {
            return 5;
        }
        else if ((int)DayOfWeek.Wednesday == day)
        {
            return 4;
        }
        else if ((int)DayOfWeek.Tuesday == day)
        {
            return 3;
        }
        else if ((int)DayOfWeek.Monday == day)
        {
            return 2;
        }
        else if ((int)DayOfWeek.Sunday == day)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public static string GetPersianDate(this DateTime? miladi)
    {
        if (miladi.HasValue && miladi != null)
        {
            DateTime param = Convert.ToDateTime(miladi);
            PersianCalendar Persian = new();
            string Year = Persian.GetYear(param).ToString();
            string Month = Persian.GetMonth(param).ToString();
            string Day = Persian.GetDayOfMonth(param).ToString();
            if (Month.Length == 1)
                Month = "0" + Month;
            if (Day.Length == 1)
                Day = "0" + Day;
            return Year + Month + Day;
        }
        return String.Empty;
    }

    public static string GetPersianDateOnly(this DateTime? miladi)
    {
        if (miladi.HasValue && miladi != null)
        {
            DateTime param = Convert.ToDateTime(miladi);
            PersianCalendar Persian = new();
            string Year = Persian.GetYear(param).ToString();
            string Month = Persian.GetMonth(param).ToString();
            string Day = Persian.GetDayOfMonth(param).ToString();
            if (Month.Length == 1)
                Month = "0" + Month;
            if (Day.Length == 1)
                Day = "0" + Day;
            return Year + "/" + Month + "/" + Day;
        }
        return String.Empty;
    }

    public static string GetDetDayOfWeek(string culture, DayOfWeek dayOfWeek)
    {
        Dictionary<string, string[]> DayOfWeeks = new Dictionary<string, string[]>();
        DayOfWeeks.Add("en", new string[] { "Saturday", "Sunday", "Monday", "Tuesday", "Thursday", "Wednesday", "Friday" });
        //  DayOfWeeks.Add("fa", new string[] { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" });
        DayOfWeeks.Add("fa", new string[] { "جمعه", "پنج شنبه", "چهار شنبه", "سه شنبه", "دو شنبه", "یک شنبه", "شنبه" });
        var list = new List<string>() { "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه" };

        return /*DayOfWeeks[culture]*/ list[(int)dayOfWeek];
    }

    public static string GetMonthShamsi(int currentMonth)
    {
        var list = new List<string>() { "فروردین", "اردبیهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        return list[currentMonth - 1];
    }

    public static (string Fa, string En) GetTimeAgo(DateTime dateTime)
    {
        var now = DateTime.UtcNow;
        var ts = now - dateTime.ToUniversalTime();

        if (ts.TotalMinutes < 1)
            return ("لحظاتی پیش", "just now");

        if (ts.TotalMinutes < 60)
        {
            var minutes = (int)ts.TotalMinutes;
            return ($"{minutes} دقیقه پیش", $"{minutes} minute{(minutes > 1 ? "s" : "")} ago");
        }

        if (ts.TotalHours < 24)
        {
            var hours = (int)ts.TotalHours;
            return ($"{hours} ساعت پیش", $"{hours} hour{(hours > 1 ? "s" : "")} ago");
        }

        if (ts.TotalDays < 30)
        {
            var days = (int)ts.TotalDays;
            return ($"{days} روز پیش", $"{days} day{(days > 1 ? "s" : "")} ago");
        }

        if (ts.TotalDays < 365)
        {
            var months = (int)(ts.TotalDays / 30);
            return ($"{months} ماه پیش", $"{months} month{(months > 1 ? "s" : "")} ago");
        }

        var years = (int)(ts.TotalDays / 365);
        return ($"{years} سال پیش", $"{years} year{(years > 1 ? "s" : "")} ago");
    }
}