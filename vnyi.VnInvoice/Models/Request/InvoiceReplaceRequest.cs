using Newtonsoft.Json;
using vnyi.VnInvoice.Models.DataModel;

namespace vnyi.VnInvoice.Models.Request
{
    public class InvoiceReplaceRequest : InvoiceCreateRequest
    {
        public InvoiceReplaceRequest(InvoiceReplaceModel model) : base(model)
        {
            ReferenceId = model.ReferenceId;
            RecordNo = model.RecordNo;
            RecordDate = model.RecordDate.ConvertToString();
            Reason = model.Reason;
            FileNameOfRecord = model.FileNameOfRecord;
            FileOfRecord = model.FileOfRecord;
        }

        /// <summary>
        ///     Id bản ghi hóa đơn bị thay thế
        /// </summary>
        [JsonProperty(PropertyName = "idReference")]
        public string ReferenceId { get; set; }

        /// <summary>
        ///     Số biên bản
        /// </summary>
        [JsonProperty(PropertyName = "recordNo")]
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày thay thế
        /// </summary>
        [JsonProperty(PropertyName = "recordDate")]
        public string RecordDate { get; set; }

        /// <summary>
        ///     Lý do thay thế
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        ///     Tên file biên bản
        /// </summary>
        [JsonProperty(PropertyName = "fileNameOfRecord")]
        public string FileNameOfRecord { get; set; }

        /// <summary>
        ///     Nội dung file biên bản base64
        /// </summary>
        [JsonProperty(PropertyName = "fileOfRecord")]
        public string FileOfRecord { get; set; }
    }
}
