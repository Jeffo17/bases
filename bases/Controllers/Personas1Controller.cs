using bases.Data;
using bases.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bases.Controllers
{
    [Authorize]
    public class Personas1Controller : Controller
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public Personas1Controller(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
       [Authorize(Roles = "Jeff,Usuario")]
        public IActionResult Index()
        {
            List<Persona> personas = new List<Persona>();
            personas = _applicationDbContext.Persona.ToList();
            return View(personas);
        }
       [Authorize(Roles = "Jeff,Usuario")]
        public IActionResult Details(int Codigo)
        {

            if (Codigo == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(x => x.Codigo == Codigo).FirstOrDefault();
            if (persona == null)
                return RedirectToAction("Index");
            return View(persona);

        }
        [Authorize(Roles = "Jeff")]
        public IActionResult Create()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            try
            {
                persona.Estado = 1;
                _applicationDbContext.Add(persona);
                _applicationDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return View(persona);
            }

            return RedirectToAction("Index");
        }
       [Authorize(Roles = "Jeff")]
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(x => x.Codigo == id).FirstOrDefault();
            if (persona == null)
                return RedirectToAction("Index");
            return View(persona);

        }
       [Authorize(Roles = "Jeff")]
        [HttpPost]
        public IActionResult Edit(int id, Persona persona)
        {
            if (id != persona.Codigo)
                return RedirectToAction("Index");
            try
            {

                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return View(persona);
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Jeff")]
        public IActionResult Desactivar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(x => x.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 0;
                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Jeff")]
        public IActionResult Activar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(a => a.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 1;
                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }






    }
}
