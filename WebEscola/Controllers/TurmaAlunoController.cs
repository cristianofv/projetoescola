using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ensino.Web.Models;
using System.IO;
using Aspose.Cells;
using System.Data;

namespace Ensino.Web.Controllers
{
    public class TurmaAlunoController : Controller
    {
       

        // GET: TurmaAluno/Details/5
        public ActionResult Details(int id)
        {
            TurmaAluno TurmaAluno = new TurmaAluno();

            using (ISession session = NHibernateSession.OpenSession())
            {
                TurmaAluno = session.Query<TurmaAluno>().Where(b => b.ID == id).FirstOrDefault();
            }

            return View(TurmaAluno);
        }

        // GET: TurmaAluno/Create
        public ActionResult Create(int? idTurma, int? idAluno)
        {
            var model = new TurmaAluno();
            if (idTurma.HasValue)
                model.TurmaID = idTurma;
            if (idAluno.HasValue)
                model.AlunoID = idAluno;

            return View(model);
        }

        // POST: TurmaAluno/Create
        [HttpPost]
        public ActionResult Create(TurmaAluno model)
        {
            try
            {
                TurmaAluno TurmaAluno = new TurmaAluno();     //  Creating a new instance of the TurmaAluno
                TurmaAluno.DataIngresso = model.DataIngresso;
                TurmaAluno.TurmaID = model.TurmaID;
                TurmaAluno.AlunoID = model.AlunoID;
                TurmaAluno.Ativo = model.Ativo;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(TurmaAluno); //  Save the TurmaAluno in session
                        transaction.Commit();   //  Commit the changes to the database
                    }
                }

                return RedirectToAction("Details", "Turma", new { id = TurmaAluno .TurmaID});
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        // GET: TurmaAluno/Importar
        public ActionResult Importar(int? idTurma, int? idAluno)
        {
            var model = new TurmaAluno();
            if (idTurma.HasValue)
                model.TurmaID = idTurma;
            if (idAluno.HasValue)
                model.AlunoID = idAluno;

            return View(model);
        }

        // POST: TurmaAluno/Create
        [HttpPost]
        public ActionResult Importar(TurmaAluno model)
        {
            try
            {
                if (Request.Files.Count == 0)
                {
                    return View(model);
                }

                var parmInicioImportacao = System.Configuration.ConfigurationManager.AppSettings["DataInicioImportacao"];
                var parmFimImportacao = System.Configuration.ConfigurationManager.AppSettings["DataFimImportacao"];

                DateTime.TryParse(parmInicioImportacao, out DateTime DataInicioImportacao);
                DateTime.TryParse(parmFimImportacao, out DateTime DataFimImportacao);

                if (DateTime.Today < DataInicioImportacao || DateTime.Today > DataFimImportacao)
                {
                    return View(model);
                }

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase arquivo = Request.Files[i];
                    Workbook workbook = new Workbook(arquivo.InputStream);
                    Worksheet worksheet = workbook.Worksheets[0];
                    DataTable dataTable = worksheet.Cells.ExportDataTable(0, 0, 1000, 100, true);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        TurmaAluno TurmaAluno = new TurmaAluno();
                        TurmaAluno.DataIngresso = DateTime.Today;
                        TurmaAluno.TurmaID = model.TurmaID;

                        DateTime.TryParse(row["DATA_NASCIMENTO"].ToString(), out DateTime DataNascimentoAluno);

                        if (string.IsNullOrEmpty(row["NOME"].ToString()))
                            continue;

                        var aluno = new Aluno();
                        aluno.Nome = row["NOME"].ToString();
                        aluno.DataNascimento = DataNascimentoAluno;
                        aluno.Genero = row["GENERO"].ToString();

                        using (ISession session = NHibernateSession.OpenSession())
                        {
                            using (ITransaction transaction = session.BeginTransaction())  
                            {
                                session.Save(aluno); 
                                transaction.Commit();  
                            }
                        }

                        TurmaAluno.AlunoID = aluno.ID;
                        TurmaAluno.Ativo = model.Ativo;

                        // TODO: Add insert logic here
                        using (ISession session = NHibernateSession.OpenSession())
                        {
                            using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                            {
                                session.Save(TurmaAluno); //  Save the TurmaAluno in session
                                transaction.Commit();   //  Commit the changes to the database
                            }
                        }
                    }

                }
                return RedirectToAction("Details", "Turma", new { id = model.TurmaID });
              
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        // GET: TurmaAluno/Edit/5
        public ActionResult Edit(int id, int? idTurma, int? idAluno)
        {
            TurmaAluno model = new TurmaAluno();

            using (ISession session = NHibernateSession.OpenSession())
            {
                model = session.Query<TurmaAluno>().Where(b => b.ID == id).FirstOrDefault();
            }


            ViewBag.SubmitAction = "Save";
            return View(model);
        }

        // POST: TurmaAluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TurmaAluno model)
        {
            try
            {
                TurmaAluno TurmaAluno = new TurmaAluno();
                TurmaAluno.ID = id;
                TurmaAluno.DataIngresso = model.DataIngresso;
                TurmaAluno.AlunoID = model.AlunoID;
                TurmaAluno.TurmaID = model.TurmaID;
                TurmaAluno.Ativo = model.Ativo;

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(TurmaAluno);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Details", "Turma", new { id = TurmaAluno.TurmaID });
            }
            catch
            {
                return View();
            }
        }

        // GET: TurmaAluno/Delete/5
        public ActionResult Delete(int id)
        {
            // Delete the TurmaAluno
            TurmaAluno TurmaAluno = new TurmaAluno();
            using (ISession session = NHibernateSession.OpenSession())
            {
                TurmaAluno = session.Query<TurmaAluno>().Where(b => b.ID == id).FirstOrDefault();
            }
            ViewBag.SubmitAction = "Confirm delete";
            return View("Edit", TurmaAluno);
        }

        // POST: TurmaAluno/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    TurmaAluno TurmaAluno = session.Get<TurmaAluno>(id);

                    using (ITransaction trans = session.BeginTransaction())
                    {
                        session.Delete(TurmaAluno);
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