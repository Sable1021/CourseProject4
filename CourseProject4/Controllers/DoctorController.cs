using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject4.Controllers
{

    public class DoctorController : Controller
    {
        DoctorDAL doctorDAL = new DoctorDAL();
        [HttpGet]
        public IActionResult Index()
        {

            List<Doctor> docList = new List<Doctor>();
            docList = doctorDAL.GetAllDoctors().ToList();
            return View(docList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Doctor objDoc)
        {
            if (ModelState.IsValid)
            {
                doctorDAL.AddDoctor(objDoc);
                return RedirectToAction("Index");
            }
            return View(objDoc);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Doctor doc = doctorDAL.GetDoctorById(id);
            if (doc == null)
            {
                return NotFound();
            }
            return View(doc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int? id, [Bind] Doctor objDoc)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                doctorDAL.UpdateDoctor(objDoc);
                return RedirectToAction("Index");
            }
            return View(doctorDAL);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           

            List<Doctor> docList = new List<Doctor>();
            docList = doctorDAL.GetDoctorPatientsById(id).ToList();
            return View(docList);

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Doctor doc = doctorDAL.GetDoctorById(id);
            if (doc == null)
            {
                return NotFound();
            }
            return View(doc);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDoc(int? id)
        {
            doctorDAL.DeleteDoctor(id);
            return RedirectToAction("Index");
        }


    }
}