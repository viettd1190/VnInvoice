using System;

namespace vnyi.VnInvoice.Models.DataModel
{
    public class InvoiceReplaceModel : InvoiceCreateModel
    {
        /// <summary>
        ///     Id bản ghi hóa đơn bị thay thế
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        ///     Số biên bản
        /// </summary>
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày thay thế
        /// </summary>
        public DateTime RecordDate { get; set; }

        /// <summary>
        ///     Lý do thay thế
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
