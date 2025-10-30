namespace Simple.Coinos;

using Simple.API;
using System;
using System.Threading.Tasks;

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
    public string? CurrentAuthToken { get; private set; }

    public Models.UserInfo? LastUserInfo { get; private set; }

    public CoinosClient()
    {
        client = new ClientInfo("https://coinos.io/api/");
    }

    /* User Handling */

    public async Task<Models.UserInfo> Register(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));
        }

        var r = await client.PostAsync<Models.UserInfo>("register", new
        {
            user = new
            {
                username,
                password
            }
        });

        r.EnsureSuccessStatusCode<string>();
        LastUserInfo = r.Data;
        return r.Data;
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
        CurrentAuthToken = r.Data.token;
        Authenticated = true;

        LastUserInfo = r.Data.user;
        return r.Data.user;
    }
    public void AuthenticateWithStoredToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentException($"'{nameof(token)}' cannot be null or whitespace.", nameof(token));
        }

        client.SetAuthorizationBearer(token);
        CurrentAuthToken = token;
        Authenticated = true;
    }

    /// <summary>
    /// Gets a ReadOnly token for the authenticated user
    /// </summary>
    /// <returns>A JWT Token with read-only permission</returns>
    public async Task<string> GetReadOnlyToken()
    {
        if (!Authenticated) throw new Exception("You must logon first");

        var r = await client.GetAsync<string>("ro");
        r.EnsureSuccessStatusCode<string>();

        return r.Data;
    }

    public async Task<Models.UserInfo> Me()
    {
        if (!Authenticated) throw new Exception("You must logon first");

        var r = await client.GetAsync<Models.UserInfo>("me");
        r.EnsureSuccessStatusCode<string>();

        LastUserInfo = r.Data;
        return r.Data;
    }
    public async Task<Models.NodeInfoModel> NodeInfo()
    {
        if (!Authenticated) throw new Exception("You must logon first");

        var r = await client.GetAsync<Models.NodeInfoModel>("info");
        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }

    [Obsolete("Use `Me()` instead", false)]
    public async Task<string> Balances()
    {
        if (!Authenticated) throw new Exception("You must logon first");

        var r = await client.GetAsync<string>("balances");
        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }

    public async Task<Models.ContactsModel> GetContacts()
    {
        if (!Authenticated) throw new Exception("You must logon first");

        var r = await client.GetAsync<Models.ContactsModel>("contacts");
        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }

    /* Invoices */
    public async Task<Models.InvoiceDetalis> CreateInvoice(Network network, string currency, ulong? valueSat = null, decimal? valueFiat = null, int? expiry = null, string? memo = null, string? webhook = null)
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
                expiry,
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

    /// <summary>
    /// Request an invoice to pay any Coinos user (allow unauthenticated)
    /// </summary>
    /// <param name="userName">Username to generate invoice to</param>
    /// <param name="valueSat">Invoice amount in sats</param>
    /// <returns>Two stage object containing both Pyament data and Invoice data</returns>
    public async Task<Models.PayUserModel> PayUserGenerateInvoice(string userName, ulong valueSat)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentException($"'{nameof(userName)}' cannot be null or whitespace.", nameof(userName));
        }
        if (valueSat <= 0)
        {
            throw new ArgumentException($"'{nameof(valueSat)}' must be positive.", nameof(valueSat));
        }

        var rPayment = await client.GetAsync<Models.PayUserModel.PayUserPayment>($"pay/{userName}/{valueSat}");
        rPayment.EnsureSuccessStatusCode();

        var paymentId = rPayment.Data.callback.Split('/')[^1];
        var rInvoice = await client.GetAsync<Models.PayUserModel.PayUserInvoice>($"lnurl/{paymentId}");

        var data = new Models.PayUserModel
        {
            Payment = rPayment.Data,
            Invoice = rInvoice.Data,
        };

        return data;
    }

    /* Payments */
    public async Task<Models.Payments> ListPayments(DateTime startUTC, DateTime endUTC, int limit, int? offset = null)
    {
        if (!Authenticated) throw new Exception("You must logon first");

        var r = await client.GetAsync<Models.Payments>($"payments?start={epoch(startUTC)}&end={epoch(endUTC)}&limit={limit}&offset={offset ?? 0}");
        r.EnsureSuccessStatusCode<string>();

        return r.Data;
    }

    public async Task<Models.Payment> Payment_ToInvoice(string invoice)
    {
        if (!Authenticated) throw new Exception("You must logon first");

        if (string.IsNullOrWhiteSpace(invoice))
            throw new ArgumentException($"'{nameof(invoice)}' cannot be null or whitespace.", nameof(invoice));

        var r = await client.PostAsync<Models.Payment>("payments", new
        {
            payreq = invoice,
        });

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }

    [Obsolete("Use `Payment_ToLNAddress()` instead", false)]
    public async Task Payment_ToAddress(string ln_address, int amount_sat, int max_fee = 500)
        => await Payment_ToLNAddress(ln_address, amount_sat, max_fee);
    public async Task<Models.Payment> Payment_ToLNAddress(string ln_address, int amount_sat, int max_fee = 500)
    {
        if (!Authenticated) throw new Exception("You must logon first");

        if (string.IsNullOrWhiteSpace(ln_address))
            throw new ArgumentException($"'{nameof(ln_address)}' cannot be null or whitespace.", nameof(ln_address));

        var r = await client.PostAsync<Models.Payment>($"send/{ln_address}/{amount_sat}?maxfee={max_fee}", null);

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }

    /// <summary>
    /// Simulates a transaction to calculate fees
    /// </summary>
    public async Task<Models.BitcoinFee> GetBitcoinFee(string address, int amount_sat)
    {
        var r = await client.PostAsync<Models.BitcoinFee>("bitcoin/fee", new
        {
            address,
            amount = amount_sat,
        });

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }
    /// <summary>
    /// Sends a OnChain transaction
    /// </summary>
    /// <param name="address">Bitcoin address to pay to</param>
    /// <param name="amount_sat">Amount in sats</param>
    /// <param name="fee_rate">Fee, 0: Automatic</param>
    /// <returns></returns>
    public async Task<Models.Payment> Payment_ToOnChainAddress(string address, int amount_sat, int fee_rate)
    {
        var r = await client.PostAsync<Models.Payment>("bitcoin/send", new
        {
            address,
            amount = amount_sat,
            rate = fee_rate,
        });

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }


    /* Funds */
    public async Task<Models.FundModel> GetFund(string fund_id)
    {
        var r = await client.GetAsync<Models.FundModel>($"fund/{fund_id}");
        r.EnsureSuccessStatusCode();
        return r.Data;
    }
    public async Task<Models.FundManagerUserModel[]> GeFundManager(string fund_id)
    {
        var r = await client.GetAsync<Models.FundManagerUserModel[]>($"fund/{fund_id}/managers");
        r.EnsureSuccessStatusCode();

        return r.Data;
    }

    public async Task<Models.Payment> Payment_ToCoinosFund(string fund_id, int amount_sat)
    {
        if (!Authenticated) throw new Exception("You must logon first");

        var r = await client.PostAsync<Models.Payment>("payments", new
        {
            fund = fund_id,
            amount = amount_sat,
        });

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }


    /* Misc */
    /// <summary>
    /// Get rates in USD (allow unauthenticated)
    /// </summary>
    public async Task<Models.RatesModels> Rates_USD()
    {
        var r = await client.GetAsync<Models.RatesModels>("fx"); // rate forex

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }
    /// <summary>
    /// Get BTC/USD (allow unauthenticated)
    /// </summary>
    public async Task<decimal> Rates_BTCUSD()
    {
        var r = await client.GetAsync<decimal>("rate");

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }
    /// <summary>
    /// Get CoinosMap pins (allow unauthenticated)
    /// </summary>
    public async Task<Models.LocationsModel> Locations()
    {
        var r = await client.GetAsync<Models.LocationsModel>("locations");

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }
    /// <summary>
    /// Coinos internal Credit system
    /// </summary>
    public async Task<Models.CreditsModel> GetCredits()
    {
        var r = await client.GetAsync<Models.CreditsModel>("credits");

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }
    /// <summary>
    /// Decodes an LN invoice
    /// </summary>
    public async Task<Models.DecodedInvoice> Decode(string invoice)
    {
        var r = await client.GetAsync<Models.DecodedInvoice>("decode/" + invoice);

        r.EnsureSuccessStatusCode<string>();
        return r.Data;
    }

    private long epoch(DateTime dt)
    {
        return (long)(dt - DateTime.UnixEpoch).TotalMilliseconds;
    }

}
