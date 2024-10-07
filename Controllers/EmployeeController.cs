using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppEmpCrud.Context; 

namespace WebAppEmpCrud.Controllers
{
    public class EmployeeController : Controller
    {
        EmpGCEntities _dbContext;

        public EmployeeController() 
        {
            _dbContext = new EmpGCEntities(); 
        }

        // GET: Employee
        public ActionResult Index()
        {

            var empList = _dbContext.EmpGCs.ToList();

            if (empList == null)
                return HttpNotFound();

            return View(empList);
        }


        [HttpGet]
        public ActionResult AddEmployee(EmpGC emp) // Get
        {
            if (emp.Id > 0)
                return View(emp);
            else
            {
                ModelState.Clear();
                ViewBag.NoData = 0;
                return View();
            }
        }


        [HttpPost]
        public ActionResult CreateEmployee(EmpGC emp)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (emp.Id <= 0)
                {
                    _dbContext.EmpGCs.Add(emp);
                    _dbContext.SaveChanges();

                }
                else
                {
                    _dbContext.Entry(emp).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                }

                return RedirectToAction("Index");

            }

            return View("AddEmployee");

        }


        public ActionResult Delete(int Id)
        {
            var data = _dbContext.EmpGCs.Where(x => x.Id == Id).First();
            _dbContext.EmpGCs.Remove(data);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}