using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_WEB_V2.Models;
using CRUD_WEB_V2.Models.ViewModels;

namespace CRUD_WEB_V2.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            List<PersonaViewModel> lst;
            using (crudEntities db = new crudEntities())
            {
                lst = (from registro in db.personaprueba
                           select new PersonaViewModel
                           {
                               idPersona = registro.idPersona,
                               nombre = registro.nombre,
                               edad = (int)registro.edad,
                               descripcion = registro.descripcion
                           }).ToList();
            }

            return View(lst);
        }


        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PersonaViewModel personaVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (crudEntities db = new crudEntities())
                    {
                        var persona = new personaprueba();
                        persona.nombre = personaVM.nombre;
                        persona.edad = personaVM.edad;
                        persona.descripcion = personaVM.descripcion;

                        db.personaprueba.Add(persona);
                        db.SaveChanges();
                    }
                    return Redirect("/Persona/Index");
                }

                return View(personaVM);

                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            PersonaViewModel personaVM = new PersonaViewModel();
            using (crudEntities db = new crudEntities())
            {
                var persona = db.personaprueba.Find(id);
                personaVM.nombre = persona.nombre;
                personaVM.edad = (int)persona.edad;
                personaVM.descripcion = persona.descripcion;
                personaVM.idPersona = persona.idPersona;

            }
            return View(personaVM);
        }

        [HttpPost]
        public ActionResult Editar(PersonaViewModel personaVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (crudEntities db = new crudEntities())
                    {
                        var persona = db.personaprueba.Find(personaVM.idPersona);
                        persona.nombre = personaVM.nombre;
                        persona.edad = personaVM.edad;
                        persona.descripcion = personaVM.descripcion;

                        db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/Persona/Index");
                }

                return View(personaVM);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
           
            using (crudEntities db = new crudEntities())
            {
                var persona = db.personaprueba.Find(id);
                db.personaprueba.Remove(persona);
                db.SaveChanges();

            }
            return Redirect("~/Persona/Index");
        }
    }
}