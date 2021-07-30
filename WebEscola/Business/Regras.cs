using Ensino.Web.Models;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace Ensino.Web.Business
{
    public class Regras
    {

        /// <summary>
        /// Lista de Professores
        /// </summary>
        /// <returns></returns>
        public static List<Professor> ListaProfessor()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<Professor>().ToList();
            }
        }

        /// <summary>
        /// Lista de Disciplina
        /// </summary>
        /// <returns></returns>
        public static List<Disciplina> ListaDisciplina()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<Disciplina>().ToList();
            }
        }


        /// <summary>
        /// Lista de Turmas
        /// </summary>
        /// <returns></returns>
        public static List<Turma> ListaTurma()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<Turma>().ToList();
            }
        }

        /// <summary>
        /// Lista de alunos
        /// </summary>
        /// <returns></returns>
        public static List<Aluno> ListaAluno()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<Aluno>().ToList();
            }
        }

        /// <summary>
        /// Lista de alunos
        /// </summary>
        /// <returns></returns>
        public static List<Instituicao> ListaInstituicao()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<Instituicao>().ToList();
            }
        }
    }
}