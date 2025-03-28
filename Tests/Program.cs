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

//await c.Balances();
//var friends = await c.GetContacts();
//var maplocations = await c.Locations();
//var invoiceCreated = await c.CreateInvoice(Simple.Coinos.CoinosClient.Network.lightning, "BRL", valueFiat: 0.15M, memo: "test");
//var invoiceDetails = await c.GetInvoice("lnbc...");
//var lst = await c.ListPayments(DateTime.UtcNow.AddDays(-7), DateTime.UtcNow, 100);
//await c.Payment_Lightning("lnbc...");

//var rates = await c.Rates_USD();
//var rate = await c.Rates_BTCUSD();

c = c;

