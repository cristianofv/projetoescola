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
    public class InstituicaoController : Controller
    {
        // GET: Instituicao
        public ActionResult Index()
        {
            ViewBag.Message = "Cadastro de Al8unos";
            IList<Instituicao> Instituicaos;

            using (ISession session = NHibernateSession.OpenSession()) 
            {
                Instituicaos = session.Query<Instituicao>().ToList(); //  Pega todos os Instituicaos
            }

            return View(Instituicaos);
        }

        // GET: Instituicao/Details/5
        public ActionResult Details(int id)
        {
            Instituicao Instituicao = new Instituicao();

            using (ISession session = NHibernateSession.OpenSession())
            {
                Instituicao = session.Query<Instituicao>().Where(b => b.ID == id).FirstOrDefault();
            }

            return View(Instituicao);
        }

        // GET: Instituicao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instituicao/Create
        [HttpPost]
        public ActionResult Create(Instituicao model)
        {
            try
            {
                Instituicao Instituicao = new Instituicao();     //  Creating a new instance of the Instituicao
                Instituicao.Nome = model.Nome;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(Instituicao); //  Save the Instituicao in session
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

        // GET: Instituicao/Edit/5
        public ActionResult Edit(int id)
        {
            Instituicao Instituicao = new Instituicao();

            using (ISession session = NHibernateSession.OpenSession())
            {
                Instituicao = session.Query<Instituicao>().Where(b => b.ID == id).FirstOrDefault();
            }

            ViewBag.SubmitAction = "Save";
            return View(Instituicao);
        }

        // POST: Instituicao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Instituicao model)
        {
            try
            {
                Instituicao Instituicao = new Instituicao();
                Instituicao.ID = id;
                Instituicao.Nome = model.Nome;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(Instituicao);
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

        // GET: Instituicao/Delete/5
        public ActionResult Delete(int id)
        {
            // Delete the Instituicao
            Instituicao Instituicao = new Instituicao();
            using (ISession session = NHibernateSession.OpenSession())
            {
                Instituicao = session.Query<Instituicao>().Where(b => b.ID == id).FirstOrDefault();
            }
            ViewBag.SubmitAction = "Confirm delete";
            return View("Edit", Instituicao);
        }

        // POST: Instituicao/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    Instituicao Instituicao = session.Get<Instituicao>(id);

                    using (ITransaction trans = session.BeginTransaction())
                    {
                        session.Delete(Instituicao);
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