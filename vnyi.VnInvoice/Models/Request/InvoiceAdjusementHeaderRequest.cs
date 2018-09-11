using Newtonsoft.Json;
using vnyi.VnInvoice.Models.DataModel;

namespace vnyi.VnInvoice.Models.Request
{
    public class InvoiceAdjusementHeaderRequest
    {
        public InvoiceAdjusementHeaderRequest()
        {
        }

        public InvoiceAdjusementHeaderRequest(InvoiceAdjusementHeaderModel model) : this()
        {
            if(model != null)
            {
                Id = model.Id;
                RecordNo = model.RecordNo;
                RecordDate = model.RecordDate.ConvertToString();
                Reason = model.Reason;
                FileNameOfRecord = model.FileNameOfRecord;
                FileOfRecord = model.FileOfRecord;
            }
        }

        /// <summary>
        ///     ID hóa đơn cần điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Số biên bản điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "recordNo")]
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày biên bản điều chỉnh
        /// </summary>
        [JsonProperty(PropertyName = "recordDate")]
        public string RecordDate { get; set; }

        /// <summary>
        ///     Lý do điều chỉnh
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
