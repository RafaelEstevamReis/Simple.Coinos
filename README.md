# Simple.Coinos

A simple-to-use [Coinos.io](https://coinos.io) C# API implementation

NuGet [link](https://www.nuget.org/packages/Simple.Coinos/):
~~~
PM> NuGet\Install-Package Simple.Coinos
~~~

## Usage

1. Import NuGet library
2. Authenticate with Coinos either by Login/Password or Token
3. Automate your process

First, create a new CoinosClient object:
~~~C#
var coinos = new Simple.Coinos.CoinosClient();
~~~

Then you authenticate by:

User and Password:
~~~C#
var userInfo = await coinos.Login("username", "password");
// userInfo has all account details
~~~
Or with a Token
~~~C#
coinos.AuthenticateWithStoredToken(token);
// call await coinos.Me(); for account details
~~~

Once authenticated:

To create a new invoice (receive):
~~~C#
// Value in Fiat
var invoiceCreated = await coinos.CreateInvoice(Network, FiatCurrency, valueFiat: FiatValue, memo: Memo);
// Value in Sats
var invoiceCreated = await coinos.CreateInvoice(Network, FiatCurrency, valueSat: SatsValue, memo: Memo);
~~~

To check an Invoice:
~~~C#
// This endpoint supports non-authenticated requests
var invoiceDetails = await coinos.GetInvoice("lnbc...");
~~~

To Check payment history:
~~~C#
var payments = await c.ListPayments(startDate, endDate, limit, offset);
~~~
