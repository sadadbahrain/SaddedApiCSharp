using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sadad.Sadded.WebsiteExample.Models
{
    /// <summary>
    /// Model to render GatewayResponse view
    /// </summary>
    public class PaymentResponseModel
    {
        /// <summary>
        /// Result code of the invoice transaction
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// Result message of the invoice transaction
        /// </summary>
        public string ResultMessage { get; set; }

        /// <summary>
        /// Transaction Reference number of the invoice transaction
        /// </summary>
        public string TransactionIdentifier { get; set; }
    }
}