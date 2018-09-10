using Newtonsoft.Json;

namespace vnyi.VnInvoice.Models.Response
{
    public class InvoiceCancelResponse
    {
        /// <summary>
        ///     Id bản ghi
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Id phiên giao dịch
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
