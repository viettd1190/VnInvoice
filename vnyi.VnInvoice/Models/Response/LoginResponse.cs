using System;
using Newtonsoft.Json;

namespace vnyi.VnInvoice.Models.Response
{
    public class LoginResponse
    {
        /// <summary>
        ///     token
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        /// <summary>
        ///     thời điểm hết hạn
        /// </summary>
        [JsonProperty(PropertyName = "expiredOn")]
        public DateTime ExpiredOn { get; set; }

        /// <summary>
        ///     số phút khả dụng của token
        /// </summary>
        [JsonProperty(PropertyName = "validFor")]
        public int ValidFor { get; set; }
    }
}
