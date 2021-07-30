using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ensino.Web.Models;
using NHibernate.Linq;
using NHibernate.Dialect;
using NHibernate.Cfg;
using NHibernate.Driver;
using System.Reflection;

namespace Ensino.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}