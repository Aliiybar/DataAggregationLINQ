using DataAggreagation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataAggreagation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var d1 = LoadJson1();
            var d2 = LoadJson2();

            var t1 = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            var dt = from dt1 in d1
                     from dt2 in d2
                     where dt1.id == dt2.id
                     select  new ItemTotal(dt1.id, dt1.first_name, dt1.last_name, dt1.email, dt2.gender, dt2.ip_address);

       

            ViewBag.testData = dt.ToList();
            var t2 = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            ViewBag.time1 = t1;
            ViewBag.time2 = t2;

            return View();
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


        private List<Item1> LoadJson1()
        {
            List<Item1> items = new List<Item1>();

            using (StreamReader r = new StreamReader(@"C:\Users\aiybar\source\Test\data1.json"))
            {
                string json = r.ReadToEnd();
                 items = JsonConvert.DeserializeObject<List<Item1>>(json);
            }
            return items;
        }

        private List<Item2> LoadJson2()
        {
            List<Item2> items = new List<Item2>();

            using (StreamReader r = new StreamReader(@"C:\Users\aiybar\source\Test\data2.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Item2>>(json);
            }
            return items;
        }



    }
}
