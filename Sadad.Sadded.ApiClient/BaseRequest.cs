using Newtonsoft.Json;
namespace Sadad.Sadded.ApiClient
{        
    public abstract class BaseRequest
    {
        /// <summary>
        /// ApiKey of the vendor
        /// </summary>
        [JsonProperty("api-key")]
        public string ApiKey { get; set; }

        /// <summary>
        /// vendor's VendorId
        /// </summary>
        [JsonProperty("vendor-id")]
        public long VendorId { get; set; }

        /// <summary>
        /// vendor's BranchId
        /// </summary>
        [JsonProperty("branch-id")]
        public long BranchId { get; set; }

        /// <summary>
        /// vendor's TerminalId
        /// </summary>
        [JsonProperty("terminal-id")]
        public long TerminalId { get; set; }
    }
}
