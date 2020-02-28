using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPICRUD.Models;

namespace WebAPIConsume.Controllers
{
    public class WebAPIController : Controller
    {
        // GET: WebAPI
        public ActionResult Index()
        {
            List<Person> persons = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhosthttp:55396/Api/Persons");
                var responseTask = client.GetAsync("GetAllpersons");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Person>>();
                    readTask.Wait();
                    persons = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

                return View(persons);
            }

        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Person Pobj)
        {

            return View("index");
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult GetCountries()
        {
            return View();
        }
       

    }
}