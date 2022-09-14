using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CountryController : Controller
    {
        
        // POST apiCountry/GetCountryByName/{name}
        [HttpPost]
        [Route("api/Country/GetCountryByName")]
        public async Task<Country> GetCountryByName(string countryName)
        {
            using (var client = new HttpClient())
            {

                var url = "https://restcountries.com/v2/name/" + countryName;
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var resString = await response.Content.ReadAsStringAsync();
                   
                    var dynamicObject = JsonConvert.DeserializeObject<List<BaseClassCountry>>(resString)!;


                    var obj = dynamicObject.First();
                    //Country country = new Country()
                    //{
                    //    Name = obj.Name,
                    //    Alpha2Code = obj.Alpha2Code,
                    //    CallingCodes = int.Parse(obj.CallingCodes.First<string>()),
                    //    Capital = obj.Capital,
                    //    FlagUrl = obj.Flag.ToString(),
                    //    Timezones = obj.Timezones.First<string>()

                    //};

                    return new Country(
                        obj.Name,
                        obj.Alpha2Code,
                        obj.Capital,
                        int.Parse(obj?.CallingCodes.First<string>()),
                        obj?.Flag.ToString(),
                        obj?.Timezones.First<string>()
                      );

                }
                else
                {
                    return null;
                }
            }
  
        }

        // POST apiCountry/GetCountryByArea/{area}
        [HttpPost]
        [Route("api/Country/GetCountryByArea")]
        public async Task<List<Country>> GetCountryByArea(string term)
        {
            using (var client = new HttpClient())
            {
                var url = "https://restcountries.com/v2/all";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var resString = await response.Content.ReadAsStringAsync();

                    var dynamicObjects = JsonConvert.DeserializeObject<List<BaseClassCountry>>(resString)!;

                    List<Country> countries = new List<Country>();

                    dynamicObjects.Where(x =>
                    x.Region.ToUpper() == term.ToUpper() || x.Timezones.Contains(term))
                    .ToList()
                    .ForEach((country) => countries.Add(
                      new Country(
                        country.Name,
                        country.Alpha2Code,
                        country.Capital,
                        int.Parse(country.CallingCodes.First<string>().Replace(" ", "")),
                        country.Flag.ToString(),
                        country.Timezones.First<string>()
                     )
                    ));

                    return countries;
                }
                else
                {
                    return new List<Country>();
                }
            }

        }
    }
}

