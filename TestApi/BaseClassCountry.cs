using System;
using Newtonsoft.Json;

namespace TestApi
{
    public class BaseClassCountry
    {

        [JsonProperty("name")]
        public string? Name { get; set; }
       
        [JsonProperty("alpha2Code")]
        public string? Alpha2Code { get; set; }

        [JsonProperty("capital")]
        public string? Capital { get; set; }

        [JsonProperty("callingCodes")]
        public string[]? CallingCodes { get; set; }

        [JsonProperty("flag")]
        public Uri? Flag { get; set; }

        [JsonProperty("timezones")]
        public string[]? Timezones { get; set; }

        [JsonProperty("region")]
        public string? Region { get; set; }


    }



}

