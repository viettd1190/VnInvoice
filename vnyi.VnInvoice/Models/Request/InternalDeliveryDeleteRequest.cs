using Newtonsoft.Json;
using vnyi.VnInvoice.Models.DataModel;

namespace vnyi.VnInvoice.Models.Request
{
    public class InternalDeliveryDeleteRequest
    {
        public InternalDeliveryDeleteRequest()
        {
        }

        public InternalDeliveryDeleteRequest(InternalDeliveryDeleteModel model) : this()
        {
            RecordNo = model.RecordNo;
            RecordDate = model.RecordDate.ConvertToString();
            Reason = model.Reason;
            FileOfRecord = model.FileOfRecord;
            FileNameOfRecord = model.FileNameOfRecord;
        }

        /// <summary>
        ///     Số biên bản
        /// </summary>
        [JsonProperty(PropertyName = "recordNo")]
        public string RecordNo { get; set; }

        /// <summary>
        ///     Ngày lập biên bản
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
        ///     Nội dung biên bản
        /// </summary>
        [JsonProperty(PropertyName = "fileOfRecord")]
        public string FileOfRecord { get; set; }
    }
}
