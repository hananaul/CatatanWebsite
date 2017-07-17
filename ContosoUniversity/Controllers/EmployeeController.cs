using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using ContosoUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class EmployeeController : Controller
    {
         private SchoolContext db = new SchoolContext();
        // GET: Employee
        public ActionResult Index()
        {
            var employee = from e in db.Employees
                           select e;
            return View(employee);
        }
        //ambil Skill
        public object CreateAjax(EmployeeDto dto)
        {
            var employee = new Employee();

            employee.FirstName = dto.firstname;
            employee.NameLast = dto.namelast;
            employee.DateOfBirth = dto.dateofbirth;
            employee.PlaceOfBirth = dto.placeofbirth;
            employee.Gender = dto.gender;
            employee.PhoneNumber = dto.phonenumber;
            employee.Addresss = dto.address;
            employee.PostalCode = dto.postalcode;
            employee.MarriedStatus = dto.marriedstatus;
            employee.HireDatee = dto.hiredate;

            foreach (var baris in dto.Skills)
            {
                employee.EmployeeSkills.Add(new EmployeeSkill
                {
                    Skill = baris.Skill,
                    Level = baris.Level
                });
            }
            db.Employees.Add(employee);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            return "success!";
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, NameLast, PlaceBirthh, DateOfBirthh, Gender, PhoneNumber, Addresss, PostalCode, MarriedStatus, HireDatee")]Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var i = (from c in db.Employees
                             where c.FirstName == employee.FirstName
                             select c).ToList();
                    if (i.Count() > 0)
                    {
                        ModelState.AddModelError("", "Unable to changes, Username already to exist");
                    }
                    else
                    {
                        db.Employees.Add(employee);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeToUpdate = db.Employees.Find(id);
            if (TryUpdateModel(employeeToUpdate, "",
               new string[] { "FirstName", "NameLast", "PlaceBirthh", "DateOfBirthh", "Gender", "PhoneNumber", "Addresss", "PostalCode", "MarriedStatus", "HireDatee" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(employeeToUpdate);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                try
                {
                    Employee employee = db.Employees.Find(id);
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }
                catch (RetryLimitExceededException/* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    return RedirectToAction("Delete", new { id = id, saveChangesError = true });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        }
    }
