namespace Simple.Coinos.Models;

public class NodeInfoModel
{
    public string id { get; set; }
    public string alias { get; set; }
    public string color { get; set; }
    public int num_peers { get; set; }
    public int num_pending_channels { get; set; }
    public int num_active_channels { get; set; }
    public int num_inactive_channels { get; set; }
    public Address[] address { get; set; }
    public Binding[] binding { get; set; }
    public string version { get; set; }
    public int blockheight { get; set; }
    public string network { get; set; }
    public long fees_collected_msat { get; set; }
    public string lightningdir { get; set; }
    public Our_Features our_features { get; set; }

    public class Our_Features
    {
        public string init { get; set; }
        public string node { get; set; }
        public string channel { get; set; }
        public string invoice { get; set; }
    }

    public class Address
    {
        public string type { get; set; }
        public string address { get; set; }
        public int port { get; set; }
    }

    public class Binding
    {
        public string type { get; set; }
        public string address { get; set; }
        public int port { get; set; }
    }
}
