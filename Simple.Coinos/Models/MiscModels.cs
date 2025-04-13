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