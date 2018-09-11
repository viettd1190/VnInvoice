using System;
using Newtonsoft.Json;

namespace vnyi.VnInvoice.Models.DataModel
{
    public class InvoiceAdjusementHeaderModel
    {
        /// <summary>
        ///     ID hóa đơn cần điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Số biên bản điều chỉnh
        /// </summary>
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày biên bản điều chỉnh
        /// </summary>
        public DateTime RecordDate { get; set; }

        /// <summary>
        ///     Lý do điều chỉnh
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
