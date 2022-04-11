using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApiCrud.Models;

namespace WebApiCrud.Controllers
{
    public class CrudApiController : ApiController
    {
        ApiLearningEntities1 db = new ApiLearningEntities1();


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeesDetails()
        {
            List<EmployeeDetail> obj = db.EmployeeDetails.ToList();
            return Ok(obj);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeesByID(int id)
        {
            var emp = db.EmployeeDetails.Where(model=>model.Id  == id).FirstOrDefault();
            return Ok(emp);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertEmployees(EmployeeDetail e)
        {
            db.EmployeeDetails.Add(e);
            db.SaveChanges();
            return Ok();
        }
    }
}
