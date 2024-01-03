using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            if(employee.Id == 0)
                   _context.Employees.Add(employee);
            else
            {
                var employeeInDb = _context.Employees.Single(c => c.Id == employee.Id);

                employeeInDb.Name = employee.Name;
                employeeInDb.Age = employee.Age;
                employeeInDb.Description = employee.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }

        

        public ActionResult EmployeeForm()
        {
            

            return View();
        }
        public ActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == id);

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employee == null)
                return HttpNotFound();

            return View("EmployeeForm", employee);
        }
    }
}