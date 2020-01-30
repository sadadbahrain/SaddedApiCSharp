using Sadad.Sadded.ApiClient;
using System.ComponentModel.DataAnnotations;

namespace Sadad.Sadded.WebsiteExample.Models
{
    public abstract class BaseModel
    {
        /// <summary>
        /// ApiKey of the vendor, set in Web.config
        /// </summary>
        [Display(Name ="API Key")]
        public string ApiKey { get; set; }

        /// <summary>
        /// VendorId of the vendor, set in Web.config
        /// </summary>
        [Display(Name = "Vendor Id")]
        public int VendorId { get; set; }

        /// <summary>
        /// BranchId of the vendor, set in Web.config
        /// </summary>
        [Display(Name = "Branch Id")]
        public int BranchId { get; set; }

        /// <summary>
        /// TerminalId of the vendor, set in Web.config
        /// </summary>
        [Display(Name = "Terminal Id")]
        public int TerminalId { get; set; }

        /// <summary>
        /// Base URL for the invoice creation/status APIs
        /// </summary>
        [Display(Name = "Base URL")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Server's response
        /// </summary>
        public InvoiceResponse Response { get; set; }
    }
}