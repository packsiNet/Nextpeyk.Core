﻿namespace ApplicationLayer.Common.Extensions;

public static class PhoneNumberHelper
{
    /// <summary>
    /// ترکیب کد کشور و شماره موبایل به شکل استاندارد. مانند: +989123456789
    /// </summary>
    public static string NormalizePhoneNumber(string phonePrefix, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phonePrefix))
            throw new ArgumentException("Country code is required.");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number is required.");

        // حذف فاصله‌ها یا کاراکترهای اضافی
        phonePrefix = phonePrefix.Trim().Replace(" ", "");
        phoneNumber = phoneNumber.Trim().Replace(" ", "").Replace("-", "");

        if (phonePrefix.StartsWith("00"))
            phonePrefix = phonePrefix.Trim().Replace("00", "");

        // اطمینان از اینکه کد کشور با "+" شروع می‌شود
        if (!phonePrefix.StartsWith("+"))
            phonePrefix = "+" + phonePrefix;

        // حذف صفر ابتدایی از شماره موبایل (مثلاً 0912 → 912)
        if (phoneNumber.StartsWith("0"))
            phoneNumber = phoneNumber.Substring(1);

        return phonePrefix + phoneNumber;
    }

    /// <summary>
    /// حذف صفر ابتدایی از شماره موبایل (اگر وجود داشته باشد)
    /// </summary>
    public static string RemoveLeadingZero(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number is required.");

        phoneNumber = phoneNumber.Trim().Replace(" ", "").Replace("-", "");

        if (phoneNumber.StartsWith("0"))
            return phoneNumber.Substring(1);

        return phoneNumber;
    }

    /// <summary>
    /// دریافت شماره موبایل و حذف کد کشور (+XX یا 00XX)
    /// فقط شماره داخلی بدون کد کشور خروجی داده می‌شود
    /// </summary>
    public static string RemoveCountryCode(string phoneNumber, string defaultCountryCode = null)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number is required.");

        phoneNumber = phoneNumber.Trim().Replace(" ", "").Replace("-", "");

        // اگر شماره با + شروع شد → حذف کد کشور
        if (phoneNumber.StartsWith("+"))
        {
            // اولین کاراکتر '+' را حذف کن
            phoneNumber = phoneNumber.Substring(1);

            // حذف کد کشور تا جایی که شماره به 0 برسد یا طول استاندارد داشته باشد
            // مثلا +98... → 9...
            if (phoneNumber.Length > 10)
            {
                // فرض می‌کنیم کد کشور 1 تا 3 رقم است
                phoneNumber = phoneNumber.Substring(phoneNumber.Length - 10);
            }
        }
        // اگر با 00 شروع شد → حذف کد کشور
        else if (phoneNumber.StartsWith("00"))
        {
            phoneNumber = phoneNumber.Substring(2);
            if (phoneNumber.Length > 10)
            {
                phoneNumber = phoneNumber.Substring(phoneNumber.Length - 10);
            }
        }

        // اگر defaultCountryCode داده شده بود و شماره هنوز طولانی بود
        if (!string.IsNullOrEmpty(defaultCountryCode) && phoneNumber.StartsWith(defaultCountryCode))
        {
            phoneNumber = phoneNumber.Substring(defaultCountryCode.Length);
        }

        return phoneNumber;
    }

    /// <summary>
    /// دریافت شماره کامل و برگرداندن کد کشور
    /// مثلا +19136547890 → +1
    /// </summary>
    public static string ExtractCountryCode(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number is required.");

        phoneNumber = phoneNumber.Trim().Replace(" ", "").Replace("-", "");

        if (!phoneNumber.StartsWith("+"))
            throw new ArgumentException("Phone number must start with '+' for extracting country code.");

        // کد کشور بین + و اولین رقم شماره داخلی (که معمولا 10 رقم است)
        // یعنی طول شماره داخلی معمولا 10 رقم → پس بقیه‌اش کد کشور است
        if (phoneNumber.Length <= 11) // حداقل باید 1 رقم کد + 10 رقم شماره داشته باشه
            throw new ArgumentException("Invalid phone number format.");

        int countryCodeLength = phoneNumber.Length - 10;
        return phoneNumber.Substring(0, countryCodeLength);
    }

    /// <summary>
    /// دریافت شماره کامل و برگرداندن فقط شماره موبایل بدون کد کشور
    /// مثلا +19136547890 → 9136547890
    /// </summary>
    public static string ExtractPhoneParts(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number is required.");

        // پاک‌سازی
        phoneNumber = phoneNumber.Trim()
                                 .Replace(" ", "")
                                 .Replace("-", "")
                                 .Replace("(", "")
                                 .Replace(")", "");

        // اگر با 00 شروع شد → تبدیل به +
        if (phoneNumber.StartsWith("00"))
            phoneNumber = "+" + phoneNumber.Substring(2);

        if (phoneNumber.Length < 10)
            throw new ArgumentException("Invalid phone number length.");

        string countryCode = "";
        string localNumber = "";

        if (phoneNumber.StartsWith("+"))
        {
            if (phoneNumber.Length <= 11)
                throw new ArgumentException("Invalid international phone number format.");

            // آخرین ۱۰ رقم شماره داخلی
            localNumber = phoneNumber.Substring(phoneNumber.Length - 10);

            // کد کشور = از ابتدای + تا قبل از ۱۰ رقم آخر
            countryCode = phoneNumber.Substring(0, phoneNumber.Length - 10);
        }
        else
        {
            // شماره داخلی بدون کد کشور
            localNumber = phoneNumber.Substring(phoneNumber.Length - 10);
            countryCode = ""; // نامشخص
        }

        return localNumber;
    }
}