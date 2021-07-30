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
    public class ContratoController : Controller
    {
        // GET: Contrato
        public ActionResult Index()
        {
            ViewBag.Message = "Cadastro de Contratos";
            IList<Contrato> Contratos;

            using (ISession session = NHibernateSession.OpenSession()) 
            {
                Contratos = session.Query<Contrato>().ToList(); //  Pega todos os Contratos
            }

            return View(Contratos);
        }

        // GET: Contrato/Details/5
        public ActionResult Details(int id)
        {
            Contrato Contrato = new Contrato();

            using (ISession session = NHibernateSession.OpenSession())
            {
                Contrato = session.Query<Contrato>().Where(b => b.ID == id).FirstOrDefault();
            }

            return View(Contrato);
        }

        // GET: Contrato/Create
        public ActionResult Create()
        {
            var Contrato = new Contrato();
            return View(Contrato);
        }

        // POST: Contrato/Create
        [HttpPost]
        public ActionResult Create(Contrato model)
        {
            try
            {
                Contrato Contrato = new Contrato();     //  Creating a new instance of the Contrato
                Contrato.AlunoID = model.AlunoID;
                Contrato.InstituicaoID = model.InstituicaoID;
                Contrato.ValorMensalidade = model.ValorMensalidade;
                Contrato.Data = model.Data;
                Contrato.Ativo = model.Ativo;
                Contrato.DiaVencimento = model.DiaVencimento;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(Contrato); //  Save the Contrato in session
                        transaction.Commit();   //  Commit the changes to the database
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        // GET: Contrato/Edit/5
        public ActionResult Edit(int id)
        {
            Contrato Contrato = new Contrato();

            using (ISession session = NHibernateSession.OpenSession())
            {
                Contrato = session.Query<Contrato>().Where(b => b.ID == id).FirstOrDefault();
            }

            ViewBag.SubmitAction = "Save";
            return View(Contrato);
        }

        // POST: Contrato/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contrato model)
        {
            try
            {
                Contrato Contrato = new Contrato();
                Contrato.ID = id;
                Contrato.AlunoID = model.AlunoID;
                Contrato.InstituicaoID = model.InstituicaoID;
                Contrato.ValorMensalidade = model.ValorMensalidade;
                Contrato.Data = model.Data;
                Contrato.Ativo = model.Ativo;
                Contrato.DiaVencimento = model.DiaVencimento;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(Contrato);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Contrato/Delete/5
        public ActionResult Delete(int id)
        {
            // Delete the Contrato
            Contrato Contrato = new Contrato();
            using (ISession session = NHibernateSession.OpenSession())
            {
                Contrato = session.Query<Contrato>().Where(b => b.ID == id).FirstOrDefault();
            }
            ViewBag.SubmitAction = "Confirm delete";
            return View("Edit", Contrato);
        }

        // POST: Contrato/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    Contrato Contrato = session.Get<Contrato>(id);

                    using (ITransaction trans = session.BeginTransaction())
                    {
                        session.Delete(Contrato);
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