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
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            ViewBag.Message = "Cadastro de Al8unos";
            IList<Aluno> Alunos;

            using (ISession session = NHibernateSession.OpenSession()) 
            {
                Alunos = session.Query<Aluno>().ToList(); //  Pega todos os alunos
            }

            return View(Alunos);
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {
            Aluno Aluno = new Aluno();

            using (ISession session = NHibernateSession.OpenSession())
            {
                Aluno = session.Query<Aluno>().Where(b => b.ID == id).FirstOrDefault();
            }

            return View(Aluno);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(Aluno model)
        {
            try
            {
                Aluno Aluno = new Aluno();     //  Creating a new instance of the Aluno
                Aluno.Nome = model.Nome;
                Aluno.DataNascimento = model.DataNascimento;
                Aluno.Genero = model.Genero;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(Aluno); //  Save the Aluno in session
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

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            Aluno Aluno = new Aluno();

            using (ISession session = NHibernateSession.OpenSession())
            {
                Aluno = session.Query<Aluno>().Where(b => b.ID == id).FirstOrDefault();
            }

            ViewBag.SubmitAction = "Save";
            return View(Aluno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Aluno model)
        {
            try
            {
                Aluno Aluno = new Aluno();
                Aluno.ID = id;
                Aluno.Nome = model.Nome;
                Aluno.DataNascimento = model.DataNascimento;
                Aluno.Genero = model.Genero;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(Aluno);
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

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            // Delete the Aluno
            Aluno Aluno = new Aluno();
            using (ISession session = NHibernateSession.OpenSession())
            {
                Aluno = session.Query<Aluno>().Where(b => b.ID == id).FirstOrDefault();
            }
            ViewBag.SubmitAction = "Confirm delete";
            return View("Edit", Aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    Aluno Aluno = session.Get<Aluno>(id);

                    using (ITransaction trans = session.BeginTransaction())
                    {
                        session.Delete(Aluno);
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