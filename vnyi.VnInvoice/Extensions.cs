using System;
using Newtonsoft.Json;
using vnyi.VnInvoice.Enums;
using vnyi.VnInvoice.Models;

namespace vnyi.VnInvoice
{
    public static class Extensions
    {
        public static string DATE_PARAM_FORMAT = "{0:yyyy-MM-dd}";

        public static string ToJson(this object input)
        {
            return JsonConvert.SerializeObject(input,
                                               Formatting.None);
        }

        public static T ToObject<T>(this string input)
                where T : class
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public static void CannotLogin(this MessageResult result)
        {
            result.Data = null;
            result.Code = Constants.CAN_NOT_LOGIN;
            result.Succeeded = false;
        }

        public static void ErrorApi(this MessageResult result)
        {
            result.Data = null;
            result.Code = Constants.API_ERR;
            result.Succeeded = false;
        }

        public static string ConvertToString(this DateTime date)
        {
            return string.Format(DATE_PARAM_FORMAT,
                                 date);
        }

        public static string ConvertToString(this PaymentMethodType paymentMethodType)
        {
            switch (paymentMethodType)
            {
                case PaymentMethodType.TM: return "TM";
                case PaymentMethodType.CK: return "CK";
                case PaymentMethodType.TM_CK: return "TM/CK";
            }

            return string.Empty;
        }

        public static string ConvertToString(this VatPercentType vatPercentType)
        {
            switch (vatPercentType)
            {
                case VatPercentType.KHONG_CHIU_THUE: return "Không chịu thuế";
                case VatPercentType.KHONG_KE_KHAI: return "Không kê khai";
                case VatPercentType.THUE_0: return "0%";
                case VatPercentType.THUE_5: return "5%";
                case VatPercentType.THUE_10: return "10%";
            }

            return string.Empty;
        }

        public static double CalcTax(this double amount,
                                     VatPercentType vatPercent)
        {
            switch (vatPercent)
            {
                case VatPercentType.KHONG_CHIU_THUE:
                case VatPercentType.KHONG_KE_KHAI:
                case VatPercentType.THUE_0:
                    return 0;
                case VatPercentType.THUE_5: return amount * 5 / 100;
                case VatPercentType.THUE_10: return amount * 10 / 100;
            }

            return 0;
        }
    }
}
