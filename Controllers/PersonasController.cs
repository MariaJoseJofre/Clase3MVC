using Clase3MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase3MVC.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        private readonly RepositorioPersona repositorioPersona;
       
        public PersonasController()
        {
            repositorioPersona = new RepositorioPersona();
        }
        public ActionResult Index()
        {
            /* IList<Persona> lista = new List<Persona>();
           lista.Add(new Persona { Id = 1, Nombre = "Juan" });
           lista.Add(new Persona { Id = 2, Nombre = "Juana" });
           lista.Add(new Persona { Id = 3, Nombre = "Juancito" });
           lista.Add(new Persona { Id = 4, Nombre = "Juanzoto" });
           lista.Add(new Persona { Id = 5, Nombre = "Juanes" });
           */
            var lista = repositorioPersona.Obtener();
            ViewData[nameof(Persona)] = lista;
            //ViewBag.Persona = lista; Este es equivalente al ViewData, es otra forma de acceder a los datos de forma dinamica
            return View();
        }

        public IActionResult CrearPersona()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrearPersona(Persona p)
        {
            repositorioPersona.Alta(p);
            return View();
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            var p = new Persona { Id = id, Nombre = "Juan" };

            //Si la lista esta hardcodeada puedo acceder al verdadero nombre de cada id y no a Juan mediante:
            //var p = lista.First(x -> x.Id == id);

            return View(p);
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
