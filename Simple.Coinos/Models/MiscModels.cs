namespace Simple.Coinos.Models;

using System;

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