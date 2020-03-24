using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject4.Controllers
{
  
    public class PatientController : Controller
    {
        PatientDAL patientDAL = new PatientDAL();
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {

            List<Patient> patList = new List<Patient>();
            patList = patientDAL.GetAllPatients().ToList();
            return View(patList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Patient objPat)
        {
            if (ModelState.IsValid)
            {
                patientDAL.AddPatient(objPat);
                return RedirectToAction("Index");
            }
            return View(objPat);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Patient pat = patientDAL.GetPatientById(id);
            if (pat == null)
            {
                return NotFound();
            }
            return View(pat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int? id,[Bind] Patient objPat)
        {
            if (id == null)
            {
                return NotFound();
            }
           if(ModelState.IsValid)
            {
                patientDAL.UpdatePatient(objPat);
                return RedirectToAction("Index");
             }
            return View(patientDAL);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Patient pat = patientDAL.GetPatientById(id);
            if (pat == null)
            {
                return NotFound();
            }
            return View(pat);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Patient pat = patientDAL.GetPatientById(id);
            if (pat == null)
            {
                return NotFound();
            }
            return View(pat);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePat(int? id)
        {
            patientDAL.DeletePatient(id);
            return RedirectToAction("Index");
        }
    }
}