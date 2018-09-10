using Newtonsoft.Json;

namespace vnyi.VnInvoice.Models.Response
{
    public class BaseResponse<T>
    {
        /// <summary>
        ///     thành công hay không
        /// </summary>
        [JsonProperty(PropertyName = "succeeded")]
        public bool Succeeded { get; set; }

        /// <summary>
        ///     mã lỗi
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        /// <summary>
        ///     dữ liệu trả về
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }
    }
}
