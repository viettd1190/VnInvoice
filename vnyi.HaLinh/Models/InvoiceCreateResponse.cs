using Newtonsoft.Json;

namespace vnyi.HaLinh.Models
{
    public class InvoiceCreateResponse
    {
        /// <summary>
        ///     Id bản ghi
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Id hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "idErp")]
        public string ErpId { get; set; }

        /// <summary>
        ///     Mã giao dịch
        /// </summary>
        [JsonProperty(PropertyName = "idTransaction")]
        public string TransactionId { get; set; }

        /// <summary>
        ///     Số hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "invoiceNo")]
        public string InvoiceNo { get; set; }

        /// <summary>
        ///     Trạng thái hóa đơn
        /// </summary>
        [JsonProperty(PropertyName = "invoiceStatus")]
        public string InvoiceStatus { get; set; }

        /// <summary>
        ///     Trạng thái ký
        /// </summary>
        [JsonProperty(PropertyName = "signStatus")]
        public string SignStatus { get; set; }
    }
}
