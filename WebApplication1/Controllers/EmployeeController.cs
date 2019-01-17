using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Business;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        FBusiness fEmployees = new FBusiness();
        List<Employee> ieEmployees = new List<Employee>();

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            await GetEmployees();

            return View(ieEmployees);
        }

        private async Task GetEmployees()
        {
            IEnumerable<object> oEmployees = await fEmployees.GetEmployees();
            foreach (var employee in oEmployees)
            {
                Employee pEmployee = JsonConvert.DeserializeObject<Employee>(employee.ToString());

                if (pEmployee.ContractTypeName == "HourlySalaryEmployee")
                {
                    pEmployee.Salary = 120 * pEmployee.HourlySalary * 12;
                }
                else
                {
                    pEmployee.Salary = pEmployee.MonthlySalary * 12;
                }


                ieEmployees.Add(pEmployee);
            }
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int id)
        {
            await GetEmployees();
            Employee employee = new Employee();
            employee = ieEmployees.FirstOrDefault<Employee>(x => x.Id == id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            await GetEmployees();
            Employee employee = new Employee();
            employee = ieEmployees.FirstOrDefault<Employee>(x => x.Id == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await GetEmployees();
            Employee employee = new Employee();
            employee = ieEmployees.FirstOrDefault<Employee>(x => x.Id == id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
