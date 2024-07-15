namespace Simple.Coinos.Models;

using System.Collections.Generic;

public class Payments
{
    public Payment[] payments { get; set; } = [];
    public int count { get; set; }
    public Dictionary<string, CurrencyTotals> totals { get; set; } = [];

    public class CurrencyTotals
    {
        public int tips { get; set; }
        public string fiatTips { get; set; } = string.Empty;
        public long sats { get; set; }
        public string fiat { get; set; } = string.Empty;
    }

    public class Payment
    {
        public string id { get; set; } = string.Empty;
        public long amount { get; set; }
        public long fee { get; set; }
        public string hash { get; set; } = string.Empty;
        public long ourfee { get; set; }
        public string uid { get; set; } = string.Empty;
        public bool confirmed { get; set; }
        public decimal rate { get; set; }
        public string currency { get; set; } = string.Empty;
        public string type { get; set; }
        public object? _ref { get; set; }
        public decimal? tip { get; set; }
        public long created { get; set; }
        public string? iid { get; set; }
        public string? memo { get; set; }
    }
}