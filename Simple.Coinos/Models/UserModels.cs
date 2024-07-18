namespace Simple.Coinos.Models;

using System;

public class UserLogin
{
    public UserInfo user { get; set; }
    public string token { get; set; }
}

public class UserInfo
{
    public string[] currencies { get; set; }
    public string currency { get; set; }
    public bool fiat { get; set; }
    public string id { get; set; }
    public int locktime { get; set; }
    public string username { get; set; }
}

