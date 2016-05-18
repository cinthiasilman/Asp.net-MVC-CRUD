using CRUD_CLIENTES.Models;
using CRUD_CLIENTES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_CLIENTES.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
          {
                return View();
          }
           else
          {
                return RedirectToAction("Login");
         }

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(USUARIO u)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                using (CRUD_CLIENTESEntities dc = new CRUD_CLIENTESEntities())
                {
                    var v = dc.USUARIOs.Where(a => a.usuario1.Equals(u.usuario1) && a.senha.Equals(u.senha)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["usuarioLogadoID"] = v.Id.ToString();
                        Session["nomeUsuarioLogado"] = v.usuario1.ToString();
                        return RedirectToAction("ObterCliente");
                    }
                }
            }
            return View(u);
        }
    }
}