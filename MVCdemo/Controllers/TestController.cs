using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCdemo.Models;

namespace MVCdemo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            using (DBEntities5 db = new DBEntities5())
            {
                List<Employee> employees = db.Employees.ToList();
                List<Department> departments = db.Departments.ToList();

                //var result = from dept in departments
                //                     join emp in employees on dept.DeptId equals emp.DeptId into table1
                //                     select new ViewModel
                //                     {
                //                         department = dept,
                //                     };


                var result = from emp in employees
                             join dept in departments on emp.DeptId equals dept.DeptId into table1
                             select new ViewModel
                             {
                                 //department = dept,
                                 employee = emp,
                             };
                return View(result);
            }
        }
    }
}