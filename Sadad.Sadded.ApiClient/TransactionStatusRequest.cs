using Newtonsoft.Json;

namespace Sadad.Sadded.ApiClient
{
    class TransactionStatusRequest : BaseRequest
    {
        /// <summary>
        /// Transaction Reference number of the invoice to check status
        /// </summary>
        [JsonProperty("transaction-reference")]
        public string TransactionReference { get; set; }
    }
}
