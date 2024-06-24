﻿namespace Simple.Coinos;

using Simple.API;
using System;
using System.Threading.Tasks;
using static Simple.Coinos.CoinosClient;

/// <summary>
/// Coinos API
/// https://coinos.io/docs
/// https://github.com/coinos/coinos-server
/// </summary>
public class CoinosClient
{
    public enum Network
    {
        lightning,
        bitcoin,
        liquid,
        @internal,
    }

    private ClientInfo client;
    public ClientInfo InternalClient => client;
    public bool Authenticated { get; private set; } = false;

    public CoinosClient()
    {
        client = new ClientInfo("https://coinos.io/api/");
    }

    /* User Handling */

    // "null user" errror
    internal async Task Register(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));
        }

        var r = await client.PostAsync<string>("register", new
        {
            user = new
            {
                username,
                password
            }
        });

        r.EnsureSuccessStatusCode<string>();

    }

    public async Task<Models.UserInfo> Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));
        }

        var r = await client.PostAsync<Models.UserLogin>("login", new
        {
            username,
            password
        });

        r.EnsureSuccessStatusCode<string>();
        client.SetAuthorizationBearer(r.Data.token);
        Authenticated = true;
        return r.Data.user;
    }

    public async Task<Models.UserInfo> Me()
    {
        if (!Authenticated) throw new Exception("You must logon first");

        var r = await client.GetAsync<Models.UserInfo>("me");
        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }

    public async Task Balances()
    {
        if (!Authenticated) throw new Exception("You must logon first");

        var r = await client.GetAsync<string>("balances");
        r.EnsureSuccessStatusCode<string>();
        //return r.Data;
    }

    /* Invoices */
    public async Task<Models.InvoiceDetalis> CreateInvoice(Network network, string currency, ulong? valueSat = null, decimal? valueFiat = null, string? memo = null, string? webhook = null)
    {
        if (!Authenticated) throw new Exception("You must logon first");

        if (string.IsNullOrEmpty(currency))
        {
            throw new ArgumentException($"'{nameof(currency)}' cannot be null or empty.", nameof(currency));
        }

        if (valueSat == null && valueFiat == null)
        {
            throw new ArgumentException($"'{nameof(valueSat)}' and '{nameof(valueFiat)}' cannot be both null.");
        }
        if (valueSat != null && valueFiat != null)
        {
            throw new ArgumentException($"'{nameof(valueSat)}' and '{nameof(valueFiat)}' cannot be both non-null.");
        }

        if (!string.IsNullOrEmpty(memo) && memo.Length > 200)
        {
            throw new ArgumentException($"'{nameof(memo)}' memo should not exceed 200 chars.", nameof(memo));
        }

        var r = await client.PostAsync<Models.InvoiceDetalis>("invoice", new
        {
            invoice = new
            {
                amount = valueSat,
                fiat = valueFiat,
                type = network.ToString(),
                currency,
                memo,
                webhook,
            }
        });

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }

    /// <summary>
    /// Get any invoice (allow unauthenticated)
    /// </summary>
    public async Task<Models.InvoiceDetalis> GetInvoice(string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
        {
            throw new ArgumentException($"'{nameof(hash)}' cannot be null or whitespace.", nameof(hash));
        }
        var r = await client.GetAsync<Models.InvoiceDetalis>($"invoice/{hash}");

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }

    /* Payments */
    public async Task ListPayments(DateTime startUTC, DateTime endUTC, int limit, int? offset = null)
    {
        if (!Authenticated) throw new Exception("You must logon first");

        var r = await client.GetAsync<string>($"payments?start={epoch(startUTC)}&end={epoch(endUTC)}&limit={limit}&offset={offset ?? 0}");
        r = r;
        r.EnsureSuccessStatusCode<string>();
    }

    public async Task Payment_Lightning(string invoice)
    {
        if (!Authenticated) throw new Exception("You must logon first");

        if (string.IsNullOrWhiteSpace(invoice))
        {
            throw new ArgumentException($"'{nameof(invoice)}' cannot be null or whitespace.", nameof(invoice));
        }

        var r = await client.PostAsync<string>("payments", new
        {
            payreq = invoice,
        });
        r = r;
        r.EnsureSuccessStatusCode<string>();
    }

    private long epoch(DateTime dt)
    {
        return (long)(dt - DateTime.UnixEpoch).TotalSeconds;
    }
}