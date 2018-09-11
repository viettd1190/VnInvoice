using System;

namespace vnyi.VnInvoice.Models.DataModel
{
    public class EconomicInvoiceUpdateModel : EconomicInvoiceCreateModel
    {
        /// <summary>
        ///     Id hóa đơn gốc
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        ///     Số biên bản
        /// </summary>
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày lập biên bản
        /// </summary>
        public DateTime RecordDate { get; set; }

        /// <summary>
        ///     Lý do biên bản
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        ///     Tên file biên bản
        /// </summary>
        public string FileNameOfRecord { get; set; }

        /// <summary>
        ///     Nội dung file biên bản base64
        /// </summary>
        public string FileOfRecord { get; set; }
    }
}
