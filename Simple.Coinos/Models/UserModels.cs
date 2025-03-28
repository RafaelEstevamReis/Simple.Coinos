namespace Simple.Coinos.Models;

using System;

public class UserLogin
{
    public UserInfo user { get; set; }
    public string token { get; set; }
}

public class UserInfo
{
    public int balance { get; set; }
    public string[] currencies { get; set; }
    public string currency { get; set; }
    public bool fiat { get; set; }
    public string id { get; set; }
    public int locktime { get; set; }
    public string npub { get; set; }
    public string nsec { get; set; }
    public string nwc { get; set; }
    public string pubkey { get; set; }
    public string sk { get; set; }
    public string token { get; set; }
    public string username { get; set; }
}

