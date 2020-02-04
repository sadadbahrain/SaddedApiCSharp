using Sadad.Sadded.ApiClient;
using Sadad.Sadded.WebsiteExample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace Sadad.Sadded.WebsiteExample.Controllers
{
    public class InvoiceController : Controller
    {
        private string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        private int branchId = Convert.ToInt32(ConfigurationManager.AppSettings["BranchId"]);
        private int terminalId = Convert.ToInt32(ConfigurationManager.AppSettings["TerminalId"]);
        private int vendorId = Convert.ToInt32(ConfigurationManager.AppSettings["VendorId"]);
        private const string paymentGatewayResponsePage = "{0}Invoice/GatewayResponse";

        /// <summary>
        /// Get method for CreateInvoice page, passing base configurations to be displayed on page
        /// </summary>
        /// <returns>CreateInvoice view</returns>
        public ActionResult CreateInvoice()
        {            
            InvoiceCreateModel invoiceCreateModel = new InvoiceCreateModel();
            SetBaseConfigurations(invoiceCreateModel);
            AddNotificationModesInBag();
            SetDefaultSuccessErrorUrl(invoiceCreateModel, Request.Url.ToString());
            return View(invoiceCreateModel);
        }

        /// <summary>
        /// This controller will display response from payment gateway after making payment.
        /// </summary>
        /// <returns>GatewayResponse view</returns>
        [HttpPost]
        public ActionResult GatewayResponse()
        {
            string resultCode = Request.Params["ResultCode"];
            string resultMessage = Request.Params["ResultMessage"];
            string transactionIdentifier = Request.Params["TransactionIdentifier"];

            PaymentResponseModel model = new PaymentResponseModel()
            {
                ResultCode = resultCode,
                ResultMessage = resultMessage,
                TransactionIdentifier = transactionIdentifier
            };
            return View(model);
        }

        /// <summary>
        /// Post method for CreateInvoice page, This function returns an invoice link based on the given parameters as an invoice from the website
        /// </summary>
        /// <param name="invoiceCreateModel">Contains paramters that are related to invoice</param>
        /// <returns>CreateInvoice view with server's response</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInvoice(InvoiceCreateModel invoiceCreateModel)
        {
            SetBaseConfigurations(invoiceCreateModel);
            if (ModelState.IsValid)
            {
                SaddedClient client = new SaddedClient(invoiceCreateModel.BaseUrl,
                    invoiceCreateModel.ApiKey,
                    invoiceCreateModel.VendorId,
                    invoiceCreateModel.BranchId,
                    invoiceCreateModel.TerminalId);

                DateTime invoiceDate = invoiceCreateModel.Date != null ?
                    invoiceCreateModel.Date.Value : DateTime.Now;

                SetDefaultSuccessErrorUrl(invoiceCreateModel, Request.Url.ToString());

                CreateInvoiceRequest request = new CreateInvoiceRequest()
                {
                    Amount = invoiceCreateModel.Amount,
                    CustomerName = invoiceCreateModel.CustomerName,
                    Date = invoiceDate,
                    Description = invoiceCreateModel.Description,
                    ExternalReference = invoiceCreateModel.ExternalReference,
                    SuccessUrl = invoiceCreateModel.SuccessUrl,
                    ErrorUrl = invoiceCreateModel.ErrorUrl,
                    Msisdn = invoiceCreateModel.Msisdn,
                    Email = invoiceCreateModel.Email,
                    NotificationMode = invoiceCreateModel.NotificationMode
                };

                invoiceCreateModel.Response = client.createInvoiceLink(request);
            }
            AddNotificationModesInBag();            
            return View(invoiceCreateModel);
        }

        /// <summary>
        /// Get method for CreateInvoice page, passing base configurations to be displayed on page
        /// </summary>
        public ActionResult CheckStatus()
        {
            InvoiceStatusModel invoiceStatusModel = new InvoiceStatusModel();
            SetBaseConfigurations(invoiceStatusModel);
            return View(invoiceStatusModel);
        }

        /// <summary>
        /// Post method for CheckStatus page, This function returns status of invoice based on the given 'transaction-reference'
        /// </summary>
        /// <param name="invoiceStatusModel">Contains paramters that are related to check status of invoice</param>
        /// <returns>CheckStatus view with server's response</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckStatus(InvoiceStatusModel invoiceStatusModel)
        {
            SetBaseConfigurations(invoiceStatusModel);
            if (ModelState.IsValid)
            {
                SaddedClient client = new SaddedClient(invoiceStatusModel.BaseUrl,
                    invoiceStatusModel.ApiKey,
                    invoiceStatusModel.VendorId,
                    invoiceStatusModel.BranchId,
                    invoiceStatusModel.TerminalId);

                invoiceStatusModel.Response = client.checkTransactionStatus(invoiceStatusModel.TransactionReference);
            }            
            return View(invoiceStatusModel);
        }

        /// <summary>
        /// This method sets NotificationModes in ViewBag, that will be used in CreateInvoice view
        /// </summary>
        /// <returns>void</returns>
        [NonAction]
        private void AddNotificationModesInBag()
        {
            Dictionary<string, int> notificationModes = new Dictionary<string, int>();
            notificationModes.Add("Online", 300);
            notificationModes.Add("SMS", 100);
            notificationModes.Add("Email", 200);
            ViewBag.NotificationModes = notificationModes;
        }

        /// <summary>
        /// This method sets default success and error urls path to Invoice/GatewayResponse
        /// </summary>
        /// <returns>void</returns>
        [NonAction]
        private void SetDefaultSuccessErrorUrl(InvoiceCreateModel model, string websiteBaseUrl)
        {
            model.SuccessUrl = model.SuccessUrl ?? string.Format(paymentGatewayResponsePage, websiteBaseUrl);
            model.ErrorUrl = model.ErrorUrl ?? string.Format(paymentGatewayResponsePage, websiteBaseUrl);
        }

        /// <summary>
        /// This method sets base configurations for the view
        /// </summary>
        /// <returns>void</returns>
        [NonAction]
        private void SetBaseConfigurations(BaseModel baseModel)
        {
            baseModel.BaseUrl = baseUrl;
            baseModel.ApiKey = apiKey;
            baseModel.BranchId = branchId;
            baseModel.TerminalId = terminalId;
            baseModel.VendorId = vendorId;
        }

    }
}