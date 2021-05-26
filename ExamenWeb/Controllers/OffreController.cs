using Domaine.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenWeb.Controllers
{
    public class OffreController : Controller
    {
        EntrepriseService EntrepriseSV = new EntrepriseService();
        OffreService OffreSV = new OffreService();
        // GET: Offre
        public ActionResult Index()
        {
            var list = OffreSV.GetAll();


            return View(list);
        }
        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = OffreSV.GetAll();


            // filtrage 
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(m => m.Entreprise.Adresse.Ville.Equals(filtre)).ToList();
            }

            return View(list);



        }

        // GET: Offre/Details/5
        public ActionResult Details(int id)
        {
            return View(OffreSV.GetById(id));
        }

        // GET: Offre/Create
        public ActionResult Create()
        {
            var Entreprise = EntrepriseSV.GetAll();
            
            ViewBag.EntrepriseList = new SelectList(Entreprise, "IdEntreprise", "NomEntreprise");

            return View();
        }

        // POST: Offre/Create
        [HttpPost]
        public ActionResult Create(Offre o)
        {
            OffreSV.Add(o);
            OffreSV.Commit();


            // TODO: Add insert logic here

            return RedirectToAction("Index");
        }

        // GET: Offre/Edit/5
        public ActionResult Edit(int id)
        {
            return View(OffreSV.GetById(id));
        }

        // POST: Offre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Offre o)
        {

            OffreSV.Update(o);
            OffreSV.Commit();
            return RedirectToAction("Index");
            
               
           
        }

        // GET: Offre/Delete/5
        public ActionResult Delete(int id)
        {
            return View(OffreSV.GetById(id));
        }

        // POST: Offre/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Offre o)
        {
            OffreSV.Delete(o);
            OffreSV.Commit();
            return RedirectToAction("Index");
        }
    }
}
