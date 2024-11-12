using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.Models;
using System.Linq;
using System.Collections.Generic;
namespace webapp.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly HrDatabaseContext _context;

        // Constructor with dependency injection for HrDatabaseContext
        public EmployeeController(HrDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult EmployeeList()
        {
            List<Employee> employees = _context.Employees.Include(x => x.Department).ToList();
            employees.ForEach(x =>
            {
                x.DapartmentName = x.Department?.Name ?? "No Department";  // Null check for Department
            });
            //List<Employee> employees = GetEmployees();

            return View(employees);
        }

    
        [HttpGet]
        public IActionResult Create()
        {
          ViewBag.DeptList = _context.Departments.ToList(); // Populate departments
           return View(new Employee()); // Pass an empty Employee object to the view

        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            ModelState.Remove("EmployeeId");
          
            ModelState.Remove("Department");
            ModelState.Remove("DapartmentName");

            if (ModelState.IsValid)
            {
                if (emp.DepartmentId != 0)
                {
                    try
                    {

                        _context.Employees.Add(emp);
                        _context.SaveChanges();
                        return RedirectToAction("EmployeeList");

                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("DepartmentId", "Please select a department.");
            }
                ViewBag.DeptList = this._context.Departments.ToList();
            return View(emp);

        }
               
           
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee Data = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (Data == null)
            {
                return NotFound();  // It's better to handle the case where the employee is not found
            }

            ViewBag.DeptList = _context.Departments.ToList();
            return View(Data);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            ModelState.Remove("EmployeeId");

            ModelState.Remove("Department");
            ModelState.Remove("DapartmentName");  // Typo - should be "DepartmentName"

      
            if (ModelState.IsValid == true)
                if (emp.DepartmentId != 0)
                {


                    try
                    {
                        _context.Employees.Update(emp);
                        _context.SaveChanges();
                        return RedirectToAction("EmployeeList");

                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message);
                    }

                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "Please select a department.");
                }



            ViewBag.DeptList =_context.Departments.ToList();
            return View(emp);
        }

            public IActionResult Delete(int id)
        {
            Employee Data = this._context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            if (Data != null)
            {
                _context.Employees.Remove(Data);
                _context.SaveChanges();
            }
            return RedirectToAction("EmployeeList");
        }

    }
}
