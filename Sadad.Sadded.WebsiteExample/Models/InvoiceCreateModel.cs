using System;
using System.ComponentModel.DataAnnotations;

namespace Sadad.Sadded.WebsiteExample.Models
{
    /// <summary>
    /// Model to render CreateInvoice view
    /// </summary>
    public class InvoiceCreateModel : BaseModel
    {
        /// <summary>
        /// Customer's phone number
        /// </summary>
        [Display(Name = "Phone Number")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Customer's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Customer's name
        /// </summary>
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Invoice's amount
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Description for invoice
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// invoice's creation request date
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// external references 
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string ExternalReference { get; set; }

        /// <summary>
        /// invoice's notification mode, can be either 200 (Email), 100 (SMS) or 300 (Online)
        /// </summary>
        [Required]
        [Display(Name = "Notification Mode")]
        public int NotificationMode { get; set; }

        /// <summary>
        /// url to redirect in case of successful payment
        /// </summary>
        [Display(Name = "Success Url")]
        public string SuccessUrl { get; set; }

        /// <summary>
        /// url to redirect in case of unsuccessful payment
        /// </summary>
        [Display(Name = "Error Url")]
        public string ErrorUrl { get; set; }
    }
}