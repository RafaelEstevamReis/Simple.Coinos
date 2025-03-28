namespace Simple.Coinos.Models;

using System;

public class LocationsModel
{
    public Location[] locations { get; set; }

    public class Location
    {
        public string id { get; set; }
        public Osm_Json osm_json { get; set; }
        public Tags1 tags { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string deleted_at { get; set; }
    }

    public class Osm_Json
    {
        public string type { get; set; }
        public long id { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public DateTime timestamp { get; set; }
        public int version { get; set; }
        public int changeset { get; set; }
        public string user { get; set; }
        public int uid { get; set; }
        public Tags tags { get; set; }
        public Bounds bounds { get; set; }
        public long[] nodes { get; set; }
        public Geometry[] geometry { get; set; }
    }

    public class Tags
    {
        public string addrcity { get; set; }
        public string addrhousenumber { get; set; }
        public string addrpostcode { get; set; }
        public string addrstreet { get; set; }
        public string addrsuburb { get; set; }
        public string currencyXBT { get; set; }
        public string leisure { get; set; }
        public string name { get; set; }
        public string paymentcoinos { get; set; }
        public string paymentlightning_contactless { get; set; }
        public string paymentonchain { get; set; }
        public string reflinzaddress_id { get; set; }
        public string sport { get; set; }
        public string surveydate { get; set; }
        public string addrprovince { get; set; }
        public string amenity { get; set; }
        public string contactphone { get; set; }
        public string cuisine { get; set; }
        public string currencyCAD { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string layer { get; set; }
        public string paymentlightning { get; set; }
        public string twitter { get; set; }
        public string website { get; set; }
        public string check_datecurrencyXBT { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string craft { get; set; }
        public string currencyUSD { get; set; }
        public string description { get; set; }
        public string opening_hours { get; set; }
        public string _operator { get; set; }
        public string paymentbitcoin { get; set; }
        public string paymentcash { get; set; }
        public string bitcoin { get; set; }
        public string office { get; set; }
        public string contactwhatsapp { get; set; }
        public string check_date { get; set; }
        public string contactinstagram { get; set; }
        public string shop { get; set; }
        public string addrunit { get; set; }
        public string wheelchair { get; set; }
        public User user { get; set; }
        public string building { get; set; }
        public string buildinglevels { get; set; }
        public string currencyothers { get; set; }
        public string addrdoor { get; set; }
        public string delivery { get; set; }
        public string disusedamenity { get; set; }
        public string fhrsid { get; set; }
        public string old_fhrsid { get; set; }
        public string old_name { get; set; }
        public string takeaway { get; set; }
        public string dietvegan { get; set; }
        public string websitemenu { get; set; }
        public string hairdresser { get; set; }
        public string addrdistrict { get; set; }
        public string paymentcredit_cards { get; set; }
        public string paymentdebit_cards { get; set; }
        public string addrcountry { get; set; }
        public string contactwebsite { get; set; }
        public string note { get; set; }
        public string company { get; set; }
        public string source { get; set; }
        public string sourcedate { get; set; }
        public string male { get; set; }
        public string unisex { get; set; }
        public string internet_access { get; set; }
        public string internet_accessfee { get; set; }
        public string tourism { get; set; }
        public string product { get; set; }
        public string addrfloor { get; set; }
        public string level { get; set; }
        public string female { get; set; }
        public string healthcare { get; set; }
        public string healthcarespeciality { get; set; }
        public string servicebicyclebicycle { get; set; }
        public string servicebicyclebike { get; set; }
        public string servicebicyclecleaning { get; set; }
        public string servicebicycleclothing { get; set; }
        public string servicebicycleebike { get; set; }
        public string servicebicyclemtb { get; set; }
        public string servicebicycleparts { get; set; }
        public string servicebicyclerepair { get; set; }
        public string servicebicyclesales { get; set; }
        public string servicebicyclescrewdriver { get; set; }
        public string servicebicycleservice { get; set; }
        public string servicebicycletools { get; set; }
        public string image { get; set; }
        public string air_conditioning { get; set; }
        public string resort { get; set; }
        public string dietmeat { get; set; }
        public string opening_hourssigned { get; set; }
        public string microbrewery { get; set; }
        public string addrplace { get; set; }
        public string currencyEUR { get; set; }
        public string contactemail { get; set; }
        public string contactfacebook { get; set; }
        public string paymentliquid { get; set; }
        public string dietfruitarian { get; set; }
        public string paymentfinancing { get; set; }
        public string paymentinterac { get; set; }
        public string man_made { get; set; }
        public string drive_through { get; set; }
        public string paymentcontactless { get; set; }
        public string currencyBRL { get; set; }
        public string paymentcryptocurrencies { get; set; }
        public string mobile { get; set; }
        public string buildingmaterial { get; set; }
        public string outdoor_seating { get; set; }
        public string paymentsats { get; set; }
        public string musical_instrument { get; set; }
        public string check_datesmoking { get; set; }
        public string indoor_seating { get; set; }
        public string smoking { get; set; }
        public string paymentvisa { get; set; }
        public string paymentmastercard { get; set; }
        public string servicevehiclebody_repair { get; set; }
        public string city { get; set; }
        public string fee { get; set; }
        public string addrstate { get; set; }
        public string addrhousename { get; set; }
        public string studio { get; set; }
        public string last_checked { get; set; }
        public string beauty { get; set; }
        public string currencyMXN { get; set; }
        public string paymentcards { get; set; }
        public string government { get; set; }
        public string dietlocal { get; set; }
        public string dispensing { get; set; }
        public string height { get; set; }
        public string currencyUSDT { get; set; }
        public string taxi_vehicle { get; set; }
        public string paymentpix { get; set; }
        public string capacity { get; set; }
        public string descriptionen { get; set; }
        public string dietvegetarian { get; set; }
        public string dietgluten_free { get; set; }
        public string club { get; set; }
        public string bar { get; set; }
        public string paymentcoins { get; set; }
        public string renovations { get; set; }
        public string operatortype { get; set; }
        public string clothes { get; set; }
        public string country { get; set; }
        public string ele { get; set; }
        public string surface { get; set; }
        public string lit { get; set; }
        public string information { get; set; }
        public string addrbeach { get; set; }
        public string paymentmaestro { get; set; }
        public string stroller { get; set; }
        public string brandwikipedia { get; set; }
        public string brand { get; set; }
        public string brandwikidata { get; set; }
        public string guest_house { get; set; }
        public string refCNES { get; set; }
        public string refvatin { get; set; }
        public string emergency { get; set; }
        public string public_transport { get; set; }
        public string highway { get; set; }
        public string bus { get; set; }
        public string contacttwitter { get; set; }
        public string currencyBTC { get; set; }
        public string currencyLBTC { get; set; }
        public string start_date { get; set; }
        public string paymentliquidbtc { get; set; }
        public string rooms { get; set; }
        public string paymentinterac_etransfer { get; set; }
        public string organic { get; set; }
        public string namees { get; set; }
        public string nameen { get; set; }
        public string paymentMAVEN { get; set; }
        public string paymentpaypal { get; set; }
        public string paymentblink { get; set; }
        public string currencyUSDP { get; set; }
        public string shoes { get; set; }
        public string automated { get; set; }
        public string self_service { get; set; }
        public string attraction { get; set; }
        public string namept { get; set; }
        public string phonemobile { get; set; }
        public string min_age { get; set; }
        public string brewery { get; set; }
        public string nohousenumber { get; set; }
        public string group_only { get; set; }
        public string check_datedietvegetarian { get; set; }
        public string lastcheck { get; set; }
        public string surreydate { get; set; }
        public string sourceaddr { get; set; }
        public string surreyaddrid { get; set; }
        public string addrfull { get; set; }
        public string parkingfee { get; set; }
        public string paymentvisa_contactless { get; set; }
        public string addrmilestone { get; set; }
        public string telecom { get; set; }
        public string generatoroutputelectricity { get; set; }
        public string power { get; set; }
        public string generatortype { get; set; }
        public string generatormethod { get; set; }
        public string generatorsource { get; set; }
        public string languageen { get; set; }
        public string languageit { get; set; }
        public string languageja { get; set; }
        public string languagefr { get; set; }
        public string languagees { get; set; }
        public string languagept { get; set; }
    }

    public record User
    {
        public string currency { get; set; }
        public string id { get; set; }
        public string picture { get; set; }
        public string pubkey { get; set; }
        public string username { get; set; }
        public string about { get; set; }
        public object banner { get; set; }
        public string display { get; set; }
    }

    public record Bounds
    {
        public float minlon { get; set; }
        public float maxlon { get; set; }
        public float minlat { get; set; }
        public float maxlat { get; set; }
    }

    public record Geometry
    {
        public float lat { get; set; }
        public float lon { get; set; }
    }

    public record Tags1
    {
        public string category { get; set; }
        public string iconandroid { get; set; }
        public Issue[] issues { get; set; }
        public Area[] areas { get; set; }
        public string paymentcoinos { get; set; }
        public object boostexpires { get; set; }
        public string foo { get; set; }
    }

    public record Issue
    {
        public string type { get; set; }
        public int severity { get; set; }
        public string description { get; set; }
    }

    public record Area
    {
        public int id { get; set; }
        public string url_alias { get; set; }
    }
}