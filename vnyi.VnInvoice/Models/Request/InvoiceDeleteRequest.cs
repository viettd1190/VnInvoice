using Newtonsoft.Json;
using vnyi.VnInvoice.Models.DataModel;

namespace vnyi.VnInvoice.Models.Request
{
    public class InvoiceDeleteRequest
    {
        public InvoiceDeleteRequest()
        {
        }

        public InvoiceDeleteRequest(InvoiceDeleteModel model) : this()
        {
            Id = model.Id;
            RecordNo = model.RecordNo;
            RecordDate = model.RecordDate.ConvertToString();
            Reason = model.Reason;
            FileNameOfRecord = model.FileNameOfRecord;
            FileOfRecord = model.FileOfRecord;
        }

        /// <summary>
        ///     Id hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "idInvoice")]
        public string Id { get; set; }

        /// <summary>
        ///     Số biên bản
        /// </summary>
        [JsonProperty(PropertyName = "recordNo")]
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày biên bản
        /// </summary>
        [JsonProperty(PropertyName = "recordDate")]
        public string RecordDate { get; set; }

        /// <summary>
        ///     Lý do xóa bỏ
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        ///     Tên file biên bản
        /// </summary>
        [JsonProperty(PropertyName = "fileNameOfRecord")]
        public string FileNameOfRecord { get; set; }

        /// <summary>
        ///     Nội dung file biên bản convert sang base64
        /// </summary>
        [JsonProperty(PropertyName = "fileOfRecord")]
        public string FileOfRecord { get; set; }
    }
}
