using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Sadad.Sadded.ApiClient
{
    /// <summary>
    /// Model of the request to create invoices
    /// </summary>
    public class CreateInvoiceRequest : BaseRequest
    {
        /// <summary>
        /// Customer's phone number
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("msisdn", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Msisdn { get; set; }

        /// <summary>
        /// Customer's email address
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("email", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Email { get; set; }

        /// <summary>
        /// Customer's name
        /// </summary>
        [JsonProperty("customer-name")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Invoice's amount
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Description for invoice
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Description { get; set; }

        /// <summary>
        /// invoice's creation request date
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// external references 
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("external-reference", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ExternalReference { get; set; }

        /// <summary>
        /// invoice's notification mode, can be either 200 (Email), 100 (SMS) or 300 (Online)
        /// </summary>
        [JsonProperty("notification-mode", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int NotificationMode { get; set; }

        /// <summary>
        /// url to redirect in case of successful payment
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("success-url", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string SuccessUrl { get; set; }

        /// <summary>
        /// url to redirect in case of unsuccessful payment
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("error-url", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ErrorUrl { get; set; }
    }
}
