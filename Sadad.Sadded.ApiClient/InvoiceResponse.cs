using Newtonsoft.Json;
using System.ComponentModel;

namespace Sadad.Sadded.ApiClient
{
    /// <summary>
    /// Model of the response received from the server
    /// </summary>
    public class InvoiceResponse
    {
        [DefaultValue(null)]
        [JsonProperty("transaction-reference", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string TransactionReference { get; set; }

        [DefaultValue(null)]
        [JsonProperty("payment-url", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string PaymentUrl { get; set; }

        [DefaultValue(-1)]
        [JsonProperty("notification-mode", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int NotificationMode { get; set; }

        [DefaultValue(-1)]
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Status { get; set; }

        [DefaultValue(-1)]
        [JsonProperty("error-code", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ErrorCode { get; set; }

        [DefaultValue(null)]
        [JsonProperty("error-message", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ErrorMessage { get; set; }

    }
}
