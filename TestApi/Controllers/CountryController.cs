using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace TestApi.Controllers
{

    [Route("api/Country/GetCountryByName")]
    [Produces("application/json")]
    public class CountryController : Controller
    {
        
     
        // GET apiCountry/GetCountryByName/{name}
        [HttpPost]
        public async Task<string> GetCountryByName(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://restcountries.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                
           

                // HTTP POST
                HttpResponseMessage response = await client.PostAsJsonAsync("/v2/name/", name);
                return await response.Content.ReadAsStringAsync();
                //if (response.IsSuccessStatusCode)
                //{
                //    var result = 
                //}

                //return response.Content.ReadFromJsonAsync<Country>();
                //if (response.IsSuccessStatusCode)
                //{
                //    Uri gizmoUrl = response.Headers.Location;

                //    // HTTP PUT
                //    gizmo.Price = 80;   // Update price
                //    response = await client.PutAsJsonAsync(gizmoUrl, name);

                //    // HTTP DELETE
                //    response = await client.DeleteAsync(gizmoUrl);
                //}
            }

        }

    }
}

