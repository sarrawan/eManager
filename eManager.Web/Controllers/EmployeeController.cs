using eManager.Domain;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    [Authorize(Roles = "Admin")] // user has to be logged in to site to get into this action 
    public class EmployeeController : Controller
    {
        private readonly IDepartmentDataSource _db;

        public EmployeeController(IDepartmentDataSource db)
        {
            _db = db;
        }

        // means it will automatically look in the query string for the
        // depID value and pass it in 
        [HttpGet]
        public ActionResult Create(int departmentId)
        {
            var model = new CreateEmployeeViewModel();
            model.DepartmentId = departmentId;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // look in hidden input that will be in form and compare
        public ActionResult Create(CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // want to save info
                var department = _db.Departments.Single(d => d.id == viewModel.DepartmentId);
                var employee = new Employee();
                employee.Name = viewModel.Name;
                employee.HireDate = viewModel.HireDate;
                department.Employees.Add(employee);

                _db.Save();
                return RedirectToAction("detail", "department", new { id = viewModel.DepartmentId });
            }
            // return that view again so they can fix
            return View(viewModel);
        }
    }
}