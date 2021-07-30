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
    public class TurmaController : Controller
    {
        // GET: Turma
        public ActionResult Index()
        {
            ViewBag.Message = "Cadastro de Turma";
            IList<Turma> Turmas;

            using (ISession session = NHibernateSession.OpenSession()) 
            {
                Turmas = session.Query<Turma>().ToList(); //  Pega todos os Turmas
            }

            return View(Turmas);
        }

        // GET: Turma/Details/5
        public ActionResult Details(int id)
        {
            Turma Turma = new Turma();

            using (ISession session = NHibernateSession.OpenSession())
            {
                Turma = session.Query<Turma>().Where(b => b.ID == id).FirstOrDefault();
            }

            return View(Turma);
        }

        // GET: Turma/Create
        public ActionResult Create()
        {
            var model = new Turma();
            return View(model);
        }

        // POST: Turma/Create
        [HttpPost]
        public ActionResult Create(Turma model)
        {
            try
            {
                Turma Turma = new Turma();     //  Creating a new instance of the Turma
                Turma.Nome = model.Nome;
                Turma.ProfessorID = model.ProfessorID;
                Turma.DisciplinaID = model.DisciplinaID;
                Turma.Ativo = model.Ativo;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(Turma); //  Save the Turma in session
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

        // GET: Turma/Edit/5
        public ActionResult Edit(int id)
        {
            Turma model = new Turma();

            using (ISession session = NHibernateSession.OpenSession())
            {
                model = session.Query<Turma>().Where(b => b.ID == id).FirstOrDefault();
            }


            ViewBag.SubmitAction = "Save";
            return View(model);
        }

        // POST: Turma/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Turma model)
        {
            try
            {
                Turma Turma = new Turma();
                Turma.ID = id;
                Turma.Nome = model.Nome;
                Turma.ProfessorID = model.ProfessorID;
                Turma.DisciplinaID = model.DisciplinaID;
                Turma.Ativo = model.Ativo;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(Turma);
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

        // GET: Turma/Delete/5
        public ActionResult Delete(int id)
        {
            // Delete the Turma
            Turma Turma = new Turma();
            using (ISession session = NHibernateSession.OpenSession())
            {
                Turma = session.Query<Turma>().Where(b => b.ID == id).FirstOrDefault();
            }
            ViewBag.SubmitAction = "Confirm delete";
            return View("Edit", Turma);
        }

        // POST: Turma/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    Turma Turma = session.Get<Turma>(id);

                    using (ITransaction trans = session.BeginTransaction())
                    {
                        session.Delete(Turma);
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