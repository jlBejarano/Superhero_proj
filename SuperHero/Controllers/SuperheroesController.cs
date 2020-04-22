using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero.Data;
using SuperHero.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SuperHero.Controllers
{
    public class SuperherosController : Controller
    {
        // GET: Superheros
        private ApplicationDbContext db;

        public Superheros SuperHeroes { get; private set; }

        public SuperherosController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var superheroes = db.Superheroes.ToList();
            return View(superheroes);
        }

        // GET: Superheros/Details/5
        public ActionResult Details(int id)
        {
            var superhero = db.Superheroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superhero);
        }

        // GET: Superheros/Create
        public ActionResult Create(SuperherosController superHero)
        {
            db.Superheroes.Add(SuperHeroes);
            db.SaveChanges();
            return View();
        }

        // POST: Superheros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superheros Superheros)
        {


            // TODO: Add insert logic here
            {
                SuperHeroes = db.Superheroes.Find();
                db.Superheroes.Add(Superheros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        } 
                
            
        

        // GET: Superheros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Superheros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superheros Superheros)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add update logic here
                var heroInDb = db.Superheroes.Find(id);
                heroInDb.AlterEgo = Superheros.AlterEgo;
                db.Entry(Superheros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(Superheros);
        }

        // GET: Superheros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superheros/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superheros superhero)
        {
            try
            {
                // TODO: Add delete logic here
                SuperHeroes = db.Superheroes.Where(s => s.Id == id).SingleOrDefault();
                db.Superheroes.Remove(superhero);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}