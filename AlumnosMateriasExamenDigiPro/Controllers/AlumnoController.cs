using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlumnosMateriasExamenDigiPro.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAlumnos()
        {
            ML.Result  result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();
            alumno.Alumnos = result.Objects;
            return View(alumno);
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            if (IdAlumno == null)
            {
                return View(alumno);
            }
            else
            {
                //Update
                ML.Result result = BL.Alumno.GetByIdLQ(IdAlumno.Value);
                if (result.Correct)
                {
                    alumno.IdAlumno = ((ML.Alumno)result.Object).IdAlumno;
                    alumno.Nombre = ((ML.Alumno)result.Object).Nombre;
                    alumno.ApellidoPaterno = ((ML.Alumno)result.Object).ApellidoPaterno;
                    alumno.ApellidoMaterno = ((ML.Alumno)result.Object).ApellidoMaterno;
                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("validacion");
                }
            }
        }

        // Add
        [HttpPost]
        public ActionResult Form(ML.Alumno Alumno)
        {
            ML.Result result = new ML.Result();
            if (Alumno.IdAlumno == 0)
            {
                result = BL.Alumno.Add(Alumno);
                ViewBag.Message = "El alumno se agrego correctamente";
            }
            else
            {
                //update
                result = BL.Alumno.Update(Alumno);
                ViewBag.Message = "El alumno se modifico correctamente";
            }
            //si es incorrecto
            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar el departamento";
            }
            return PartialView("validacion");
        }

        // GET: Alumno/Create
        [HttpGet]
        public ActionResult Delete(int? IdAlumno)
        {
            //delete
            BL.Alumno.Delete(IdAlumno.Value);
            ViewBag.Message = "El alumno se elimino correctamente";
            return PartialView("validacion");
        }

        // POST: Alumno/Create
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

        // GET: Alumno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alumno/Edit/5
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

        // GET: Alumno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alumno/Delete/5
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
