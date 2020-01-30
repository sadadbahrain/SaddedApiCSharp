using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Sadad.Sadded.WebsiteExample.Models
{
    /// <summary>
    /// Model to render CheckStatus view
    /// </summary>
    public class InvoiceStatusModel : BaseModel
    {
        /// <summary>
        /// Transaction Reference number of the invoice to check status
        /// </summary>
        [Required]
        [Display(Name ="Transaction Reference")]
        public string TransactionReference { get; set; }
    }
}