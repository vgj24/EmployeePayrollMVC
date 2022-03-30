using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeePayrollMVCController : Controller
    {
        IUserBL userBL;
        public EmployeePayrollMVCController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        /// <summary>
        /// Creates the specified employee model post.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                userBL.AddEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        } //view added

        /// <summary>
        /// Creates this instance get.
        /// </summary>
        /// <returns></returns>
       [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees = this.userBL.EmployeeList().ToList();
            return View(employees);
        } //view added

        /// <summary>
        /// UpdateEmployee -Edit get.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = userBL.GetEmployeeData(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        /// <summary>
        /// Edits the specified emp post.
        /// </summary>
        /// <param name="emp">The emp.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit([Bind] EmployeeModel emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userBL.UpdateEmployee(emp);
                    return RedirectToAction("Index");
                }
                return View(emp);
            }
            catch (Exception)
            {

                throw;
            }
        } //view added

        /// <summary>
        /// Deletes the Employee by id get.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = userBL.GetEmployeeData(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        /// <summary>
        /// Deletes the confirmed post.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id) //view added
        {
            userBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Detailses -get employee detail by id Get .
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Details(int? id) //view added
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = userBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
    }
}
