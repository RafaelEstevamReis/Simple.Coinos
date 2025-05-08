namespace Simple.Coinos.Models;

using System.Collections.Generic;

public class ContactsModel
{
    public Contact[] Contacts { get; set; }

    public class Contact
    {
        public string id { get; set; }
        public string picture { get; set; }
        public string username { get; set; }
    }
}

public class RatesModels
{
    public Dictionary<string, decimal> fx { get; set; }
}

public class CreditsModel
{
    public long bitcoin { get; set; }
    public long lightning { get; set; }
    public long liquid { get; set; }
}
public class BitcoinFee
{
    public long feeRate { get; set; }
    public long ourfee { get; set; }
    public long fee { get; set; }
    public Fees fees { get; set; }
    public string hex { get; set; }
    public Input[] inputs { get; set; }

    public class Fees
    {
        public int fastestFee { get; set; }
        public int halfHourFee { get; set; }
        public int hourFee { get; set; }
        public int economyFee { get; set; }
        public int minimumFee { get; set; }
    }

    public class Input
    {
        public Witnessutxo witnessUtxo { get; set; }
        public string path { get; set; }
    }

    public class Witnessutxo
    {
        public long amount { get; set; }
        public string script { get; set; }
    }
}

public class DecodedInvoice
{
    public string type { get; set; }
    public string currency { get; set; }
    public int created_at { get; set; }
    public int expiry { get; set; }
    public string payee { get; set; }
    public int amount_msat { get; set; }
    public string description_hash { get; set; }
    public int min_final_cltv_expiry { get; set; }
    public string payment_secret { get; set; }
    public string features { get; set; }
    public Route[][] routes { get; set; }
    public string payment_hash { get; set; }
    public string signature { get; set; }
    public bool valid { get; set; }
    public string offer_id { get; set; }
    public string offer_description { get; set; }
    public string offer_issuer_id { get; set; }
    public class Route
    {
        public string pubkey { get; set; }
        public string short_channel_id { get; set; }
        public int fee_base_msat { get; set; }
        public int fee_proportional_millionths { get; set; }
        public int cltv_expiry_delta { get; set; }
    }
}