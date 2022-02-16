using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WorldClockApp.Models;
using TimeZoneInfo = WorldClockApp.Models.TimeZoneInfo;

namespace WorldClockApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            FormModel model = new FormModel();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> SearchAsync(FormModel model)
        {
            model.message = String.Empty;
            client.DefaultRequestHeaders.Accept.Clear();
            string citynametoquery = model.CityName;
            citynametoquery = citynametoquery.Replace(" ", "_");
            string continentnametoquery = model.ContinentName;
            try
            {
                var stringTask = client.GetStringAsync("http://worldtimeapi.org/api/timezone/" + continentnametoquery + "/" + citynametoquery);

                var msg = await stringTask;
                var data = JsonConvert.DeserializeObject<TimeZoneInfo>(msg);
                FormModel mymodel = new FormModel();
                if (data != null)
                {
                    mymodel.abbreviation = (string)data.Abbreviation;
                    mymodel.client_ip = (string)data.ClientIp;
                    mymodel.Dst = (bool)data.Dst;
                    //mymodel.DstFrom = data.DstFrom.Tostring();
                    //mymodel.DstUntil = data.DstUntil.ToString();
                    mymodel.timezone = (string)data.Timezone;
                    mymodel.Unixtime = (long)data.Unixtime;
                    mymodel.Utc_Datetime = data.UtcDatetime.ToString();
                    mymodel.timezone = (string)data.Timezone;
                    mymodel.Datetime = data.Datetime.ToString();

                    return View("~/Views/Home/Index.cshtml", mymodel);
                }
                else
                {
                    model.message = "No results returned, please try again";
                    return View("~/Views/Home/Index.cshtml", mymodel);
                }
            }
            catch (Exception e)
            {
                model.message = "No results returned, please try again";
                FormModel mymodel = new FormModel();
                return View("~/Views/Home/Index.cshtml", mymodel);
            }
        }
    }
}