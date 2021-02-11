using Airport.Web.DataTransferObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Airport.Web.Controllers
{
    public class AirplanesTypesController : Controller
    {
        string Baseurl = "https://localhost:44366/";
        // GET: AirplanesTypes
        public async Task<ActionResult> Index()
        {
            List<AirplanesTypesDto> airplanesTypes = new List<AirplanesTypesDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/AirplanesTypes/GetAllAirplanesTypes");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    dynamic AirResponse = Res.Content.ReadAsStringAsync().Result;

                    dynamic airplanesT = JObject.Parse(AirResponse);

                    dynamic a = JsonConvert.DeserializeObject(AirResponse);

                    //Deserializing the response recieved from web api and storing into the AirplanesTypesDto list  
                    var j = JsonConvert.DeserializeObject<TransactionDto<List<AirplanesTypesDto>>>(AirResponse);

                }
            }
            return View(airplanesTypes);
        }
    }
}