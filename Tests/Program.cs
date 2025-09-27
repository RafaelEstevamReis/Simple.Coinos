using System;
using System.IO;

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("user.txt");
var pair = lines[0].Split(',');

string? token = null;
if(lines.Length > 1 && lines[1].StartsWith("ey"))
{
    token = lines[1];
}

var c = new Simple.Coinos.CoinosClient();

//await c.Register(pair[0], pair[1]);
Simple.Coinos.Models.UserInfo userInfo;
if (token != null)
{
    c.AuthenticateWithStoredToken(token);
    userInfo = await c.Me();
}
else
{
    userInfo = await c.Login(pair[0], pair[1]);
}

// var roToken = await c.GetReadOnlyToken();
// // Auth as ReadOnly
// //c.AuthenticateWithStoredToken(roToken);

//var fund = await c.GetFund("021-fund_id");
//var p2f = await c.Payment_ToCoinosFund("021-fund_id", 21);
//await c.GeFundManager("021-fund_id");

//var friends = await c.GetContacts();
//var maplocations = await c.Locations();
//var payment = await c.PayUserGenerateInvoice("adam", 21);
//var invoiceCreated = await c.CreateInvoice(Simple.Coinos.CoinosClient.Network.lightning, "BRL", valueFiat: 0.15M, memo: "test");
//var invoiceDetails = await c.GetInvoice("lnbc...");
//var lst = await c.ListPayments(DateTime.UtcNow.AddDays(-7), DateTime.UtcNow, 100);
//var payment = await c.Payment_ToInvoice("lnbc...");

//var estimateFee = await c.GetBitcoinFee("bc1q...", 1000);
//var payBtc = await c.Payment_ToOnChainAddress("bc1q...", 1000, 0);

//var rates = await c.Rates_USD();
//var rate = await c.Rates_BTCUSD();
//var credits = await c.GetCredits();

c = c;

