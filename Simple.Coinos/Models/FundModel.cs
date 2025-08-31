namespace Simple.Coinos.Models;

using System;

public class FundModel
{
    public int amount { get; set; }
    public FundPayment[] payments { get; set; }

    public class FundPayment : Payment
    {
        public FundManagerUserModel user { get; set; }
    }


}
public class FundManagerUserModel
{
    public string currency { get; set; }
    public string display { get; set; }
    public string id { get; set; }
    public string picture { get; set; }
    public bool prompt { get; set; }
    public string pubkey { get; set; }
    public string username { get; set; }
}