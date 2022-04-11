using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiCrud.Models;

namespace WebApiCrud.Controllers
{
    public class CrudMvcController : Controller
    {
        
        // GET: CrudMvc
        HttpClient clients = new HttpClient();
        public ActionResult Index()
        {
            List<EmployeeDetail> emplist = new List<EmployeeDetail>();
            clients.BaseAddress = new Uri("https://localhost:44304/api/CrudApi");
            var response = clients.GetAsync("CrudApi");
            response.Wait();

            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<EmployeeDetail>>();
                display.Wait();
                emplist = display.Result;
            }

            return View(emplist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeDetail emp)
        {
            clients.BaseAddress = new Uri("https://localhost:44304/api/CrudApi");
            var response = clients.PostAsJsonAsync<EmployeeDetail>("CrudApi",emp);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        public ActionResult Details(int id)
        {
            EmployeeDetail e = null;
            clients.BaseAddress = new Uri("https://localhost:44304/api/CrudApi");
            var response = clients.GetAsync("CrudApi?id"+id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<EmployeeDetail>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        public ActionResult Edit(int id)
        {
            EmployeeDetail e = null;
            clients.BaseAddress = new Uri("https://localhost:44304/api/CrudApi");
            var response = clients.GetAsync("CrudApi?id" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<EmployeeDetail>();
                display.Wait();
                e= display.Result;
            }

            return View(e);
        }
    }
}