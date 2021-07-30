using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ensino.Web.Models;

namespace Ensino.Web.Controllers
{
    public class DisciplinaController : Controller
    {
        // GET: Disciplina
        public ActionResult Index()
        {
            ViewBag.Message = "Cadastro de Al8unos";
            IList<Disciplina> Disciplinas;

            using (ISession session = NHibernateSession.OpenSession()) 
            {
                Disciplinas = session.Query<Disciplina>().ToList(); //  Pega todos os Disciplinas
            }

            return View(Disciplinas);
        }

        // GET: Disciplina/Details/5
        public ActionResult Details(int id)
        {
            Disciplina Disciplina = new Disciplina();

            using (ISession session = NHibernateSession.OpenSession())
            {
                Disciplina = session.Query<Disciplina>().Where(b => b.ID == id).FirstOrDefault();
            }

            return View(Disciplina);
        }

        // GET: Disciplina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disciplina/Create
        [HttpPost]
        public ActionResult Create(Disciplina model)
        {
            try
            {
                Disciplina Disciplina = new Disciplina();     //  Creating a new instance of the Disciplina
                Disciplina.Nome = model.Nome;
                Disciplina.Ativo = model.Ativo;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(Disciplina); //  Save the Disciplina in session
                        transaction.Commit();   //  Commit the changes to the database
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Disciplina/Edit/5
        public ActionResult Edit(int id)
        {
            Disciplina Disciplina = new Disciplina();

            using (ISession session = NHibernateSession.OpenSession())
            {
                Disciplina = session.Query<Disciplina>().Where(b => b.ID == id).FirstOrDefault();
            }

            ViewBag.SubmitAction = "Save";
            return View(Disciplina);
        }

        // POST: Disciplina/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Disciplina model)
        {
            try
            {
                Disciplina Disciplina = new Disciplina();
                Disciplina.ID = id;
                Disciplina.Nome = model.Nome;
                Disciplina.Ativo = model.Ativo;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(Disciplina);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Disciplina/Delete/5
        public ActionResult Delete(int id)
        {
            // Delete the Disciplina
            Disciplina Disciplina = new Disciplina();
            using (ISession session = NHibernateSession.OpenSession())
            {
                Disciplina = session.Query<Disciplina>().Where(b => b.ID == id).FirstOrDefault();
            }
            ViewBag.SubmitAction = "Confirm delete";
            return View("Edit", Disciplina);
        }

        // POST: Disciplina/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    Disciplina Disciplina = session.Get<Disciplina>(id);

                    using (ITransaction trans = session.BeginTransaction())
                    {
                        session.Delete(Disciplina);
                        trans.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}