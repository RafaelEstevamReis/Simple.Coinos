namespace Simple.Coinos.Models;

using System;

public class InvoiceDetalis
{
    public int amount { get; set; }
    public long created { get; set; }
    public string currency { get; set; }
    public string hash { get; set; }
    public string id { get; set; }
    public object[] items { get; set; }
    public string memo { get; set; }
    public float rate { get; set; }
    public int pending { get; set; }
    public int received { get; set; }
    public string text { get; set; }
    public object tip { get; set; }
    public string type { get; set; }
    public string uid { get; set; }
}

