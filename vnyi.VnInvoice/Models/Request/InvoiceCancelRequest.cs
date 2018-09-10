using Newtonsoft.Json;
using vnyi.VnInvoice.Models.DataModel;

namespace vnyi.VnInvoice.Models.Request
{
    public class InvoiceCancelRequest
    {
        public InvoiceCancelRequest()
        {
        }

        public InvoiceCancelRequest(InvoiceCancelModel model) : this()
        {
            Id = model.Id;
        }

        /// <summary>
        ///     Id hóa đơn trên hệ thống
        /// </summary>
        [JsonProperty(PropertyName = "idInvoice")]
        public string Id { get; set; }
    }
}
