﻿namespace Simple.Coinos.Models;

using System;
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