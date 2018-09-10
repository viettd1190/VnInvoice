using System;

namespace vnyi.VnInvoice.Models.DataModel
{
    public class InvoiceDeleteModel
    {
        /// <summary>
        ///     Id hóa đơn
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Số biên bản
        /// </summary>
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày biên bản
        /// </summary>
        public DateTime RecordDate { get; set; }

        /// <summary>
        ///     Lý do xóa bỏ
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        ///     Tên file biên bản
        /// </summary>
        public string FileNameOfRecord { get; set; }

        /// <summary>
        ///     Nội dung file biên bản convert sang base64
        /// </summary>
        public string FileOfRecord { get; set; }
    }
}
