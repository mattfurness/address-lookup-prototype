namespace AddressLookup.Api.Address
{
    public class AddressDetail
    {
        public string address_detail_pid { get; set; }
        public string full_address_line { get; set; }
        public string building_name { get; set; }
        public string lot_number_prefix { get; set; }
        public string lot_number { get; set; }
        public string lot_number_suffix { get; set; }
        public string flat_type_code { get; set; }
        public string flat_number_prefix { get; set; }
        public int? flat_number { get; set; }
        public string flat_number_suffix { get; set; }
        public string level_type_code { get; set; }
        public string level_number_prefix { get; set; }
        public int? level_number { get; set; }
        public string level_number_suffix { get; set; }
        public string number_first_prefix { get; set; }
        public int? number_first { get; set; }
        public string number_first_suffix { get; set; }
        public string number_last_prefix { get; set; }
        public int? number_last { get; set; }
        public string number_last_suffix { get; set; }
        public string location_description { get; set; }
        public string alias_principal { get; set; }
        public string postcode { get; set; }
        public string private_street { get; set; }
        public string legal_parcel_id { get; set; }
        public int? confidence { get; set; }
        public int? level_geocoded_code { get; set; }
        public string property_pid { get; set; }
        public string gnaf_property_pid { get; set; }
        public string primary_secondary { get; set; }
        public string m2_mb_2011_code { get; set; }
        public string amb2_mb_match_code { get; set; }
        public string sl_street_class_code { get; set; }
        public string sl_street_name { get; set; }
        public string sl_street_type_code { get; set; }
        public string sl_street_suffix_code { get; set; }
        public string sl_gnaf_street_pid { get; set; }
        public int? sl_gnaf_street_confidence { get; set; }
        public int? sl_gnaf_reliability_code { get; set; }
        public string l_locality_name { get; set; }
        public string l_primary_postcode { get; set; }
        public string l_locality_class_code { get; set; }
        public string l_gnaf_locality_pid { get; set; }
        public int? l_gnaf_reliability_code { get; set; }
        public string s_state_abbreviation { get; set; }
        public string lp_planimetric_accuracy { get; set; }
        public decimal? lp_longitude { get; set; }
        public decimal? lp_latitude { get; set; }
        public string as_address_type { get; set; }
        public string as_address_site_name { get; set; }
        public string adg_geocode_type_code { get; set; }
        public decimal? adg_longitude { get; set; }
        public decimal? adg_latitude { get; set; }
        public int? slp_boundary_extent { get; set; }
        public string slp_planimetric_accuracy { get; set; }
        public decimal? slp_longitude { get; set; }
        public decimal? slp_latitude { get; set; }
    }

    public class AddressResult
    {
        public string address_detail_pid { get; set; }
        public string full_address_line { get; set; }
        public string legal_parcel_id { get; set; }
        public string postcode { get; set; }
        public AddressDetail address_detail { get; set; }
    }
}