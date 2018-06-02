using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using APISample;

namespace APISample.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.useapi.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("Authorization", "Bearer WH8S3gJJEwlkYhixKmydCR_Qu7eKJ5Lf2i5ZcDfUHMGgfPRcelBH3BFawYNSgT6trnqB8-127R8kFPD0bn5L3ewUSPGW1t2Q98NB0sfQjD7eCtCd3gO-Hf1xdmrWqjoFfnmsvd-S9s_hYhoXmbhPexqelQ6vu4DMNJT4xbD2buMlITe8qlUsPCAYPoPMYEj3QeWdH-MTpnVcCiV6VLncKms1-V_4EgsfpRGcL1c86-1YhEMqw94BdF9uPNtn0qzQs9fLEsszHqEVuyehZYP8t6jXlSfCw2Z8L2aQIbus3ivfDanvU9jkudyb5ScUHj8x");

            Task<HttpResponseMessage> response = client.GetAsync("api/data/accessall");

            var jsonString = await response.Result.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<User[]>(jsonString);

            return View(users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}