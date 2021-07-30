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
    public class ProfessorController : Controller
    {
        // GET: Professor
        public ActionResult Index()
        {
            ViewBag.Message = "Cadastro de Al8unos";
            IList<Professor> Professors;

            using (ISession session = NHibernateSession.OpenSession()) 
            {
                Professors = session.Query<Professor>().ToList(); //  Pega todos os Professors
            }

            return View(Professors);
        }

        // GET: Professor/Details/5
        public ActionResult Details(int id)
        {
            Professor Professor = new Professor();

            using (ISession session = NHibernateSession.OpenSession())
            {
                Professor = session.Query<Professor>().Where(b => b.ID == id).FirstOrDefault();
            }

            return View(Professor);
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            var model = new Professor();
            using (ISession session = NHibernateSession.OpenSession())
            {
                model.ListaInstituicao = session.Query<Instituicao>().ToList();
            }
            return View(model);
        }

        // POST: Professor/Create
        [HttpPost]
        public ActionResult Create(Professor model)
        {
            try
            {
                Professor Professor = new Professor();     //  Creating a new instance of the Professor
                Professor.Nome = model.Nome;
                Professor.InstituicaoID = model.InstituicaoID;
                Professor.Ativo = model.Ativo;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(Professor); //  Save the Professor in session
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

        // GET: Professor/Edit/5
        public ActionResult Edit(int id)
        {
            Professor model = new Professor();

            using (ISession session = NHibernateSession.OpenSession())
            {
                model = session.Query<Professor>().Where(b => b.ID == id).FirstOrDefault();
            }

            using (ISession session = NHibernateSession.OpenSession())
            {
                model.ListaInstituicao = session.Query<Instituicao>().ToList();
            }

            ViewBag.SubmitAction = "Save";
            return View(model);
        }

        // POST: Professor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Professor model)
        {
            try
            {
                Professor Professor = new Professor();
                Professor.ID = id;
                Professor.Nome = model.Nome;
                Professor.InstituicaoID = model.InstituicaoID;
                Professor.Ativo = model.Ativo;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(Professor);
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

        // GET: Professor/Delete/5
        public ActionResult Delete(int id)
        {
            // Delete the Professor
            Professor Professor = new Professor();
            using (ISession session = NHibernateSession.OpenSession())
            {
                Professor = session.Query<Professor>().Where(b => b.ID == id).FirstOrDefault();
            }
            ViewBag.SubmitAction = "Confirm delete";
            return View("Edit", Professor);
        }

        // POST: Professor/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    Professor Professor = session.Get<Professor>(id);

                    using (ITransaction trans = session.BeginTransaction())
                    {
                        session.Delete(Professor);
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