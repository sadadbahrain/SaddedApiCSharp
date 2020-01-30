# SaddedAPIC#

This project provides ways to create Sadded Invoice. 
The project also provides method to check status of an already created invoice.

Invoice can be created using three different ways i.e. Email, Sms and Online.

### How to use

After clonning, build the project. Go to following path to get dll 

```
[Your local directory]\Sadad.Sadded\Sadad.Sadded.ApiClient\bin\Debug\Sadad.Sadded.ApiClient.dll
```

Now you will need to add reference of this dll file to your project.

To create invoice or to check status of an already created invoice, you will need an instance of **SaddedClient** class.
Its constructor takes following five arguments
* BaseUrl
* ApiKey
* VendorId
* BranchId
* TerminalId

Once the instance is created, you can finally use it to create invoice and check status of invoice.

```
SaddedClient client = new SaddedClient([API_BASE_URL],
	[API_KEY],
	[VENDOR_ID],
	[BRANCH_ID],
	[TERMINAL_ID]);
```

## Sample code to create invoice

To create invoice, you will need to create an instance of **CreateInvoiceRequest** class and set values.
```
CreateInvoiceRequest request = 	new CreateInvoiceRequest()
{
	Amount = <decimal value, required>, // e.g. 10.50
	CustomerName = <string value, required>, // e.g. "John Smith"
	Date = <DateTime object, optional>, // e.g. DateTime.Now
	Description = <string value, optional>, // e.g. "Invoice of 10.50 created for John Smith"
	ExternalReference = <string value, optional>,
	SuccessUrl = <string value, required>, // e.g. "https://mywebsite.com/successpage"
	ErrorUrl =  <string value, required>, // e.g. "https://mywebsite.com/errorpage"
	Msisdn = <string value, required>, // e.g. "97312345678"
	Email = <string value, required>, // e.g. "example@gmail.com"
	NotificationMode = <int value, required> // e.g. 100 (SMS), 200 (Email), 300 (Online)
};
```

Now, call **createInvoiceLink** method from **SaddedClient** instance that you created earlier.
```
InvoiceResponse response = client.createInvoiceLink(request);
```

## Sample code to check invoice status

To check invoice status, call **checkTransactionStatus** method from **SaddedClient** instance that you created earlier.
```
InvoiceResponse response = client.checkTransactionStatus([TRANSACTION_REFERENCE]);
```
