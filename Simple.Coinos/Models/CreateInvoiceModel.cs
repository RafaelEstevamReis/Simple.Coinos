namespace Simple.Coinos.Models;

public record CreateInvoiceModel
{

    public InvoiceModel invoice { get; set; } = default!;
    public UserModel? user { get; set; }

    public record InvoiceModel
    {
        public ulong? amount { get; internal set; }
        public decimal? fiat { get; internal set; }
        public string type { get; internal set; }
        public string currency { get; internal set; }
        public int? expiry { get; internal set; }
        public string? memo { get; internal set; }
        public string? webhook { get; internal set; }
    }
    public record UserModel
    {
        public string username { get; set; } = default!;
    }

}
