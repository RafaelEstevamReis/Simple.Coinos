// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, World!");

var pair = File.ReadAllLines("user.txt")[0].Split(',');

var c = new Simple.Coinos.CoinosClient();

//await c.Register(pair[0], pair[1]);
//var userInfo = await c.Login(pair[0], pair[1]);
//var me = await c.Me();
//await c.Balances();
//var invoiceCreated = await c.CreateInvoice(Simple.Coinos.CoinosClient.Network.lightning, "BRL", valueFiat: 0.15M, memo: "test");
//var invoiceDetails = await c.GetInvoice("lnbc...");
//await c.ListPayments(DateTime.UtcNow.AddDays(-7), DateTime.UtcNow, 100);
//await c.Payment_Lightning("lnbc...");

c = c;

