namespace vnyi.VnInvoice.Enums
{
    public enum VatPercentType
    {
        /// <summary>
        ///     Không kê khai thuế
        /// </summary>
        KHONG_KE_KHAI = -2,

        /// <summary>
        ///     Không phải chịu thuế
        /// </summary>
        KHONG_CHIU_THUE = -1,

        /// <summary>
        ///     Thuế 0%
        /// </summary>
        THUE_0 = 0,

        /// <summary>
        ///     Thuế 5%
        /// </summary>
        THUE_5 = 5,

        /// <summary>
        ///     Thuế 10%
        /// </summary>
        THUE_10 = 10
    }
}
