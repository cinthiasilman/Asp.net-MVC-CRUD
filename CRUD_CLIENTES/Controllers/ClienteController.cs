using CRUD_CLIENTES.Models;
using CRUD_CLIENTES.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_CLIENTES.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepositorio _repositorio;

        // GET: Cliente
        public ActionResult ObterCliente()
        {
            _repositorio = new ClienteRepositorio();
            ModelState.Clear(); //limpa todos os modelos e retorna pra view a lista de clientes que eu vou estar recebendo
            return View(_repositorio.ObterCliente());
        }

        
        public ActionResult IncluirCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirCliente(Cliente clienteObj)
        {
            try
            {
                if (ModelState.IsValid) //estará válido se eu preenchi todos os campos
                {
                    _repositorio = new ClienteRepositorio();
                    if (_repositorio.AdicionarCliente(clienteObj))
                    {
                        ViewBag.Mensagem = "Cliente cadastrado com sucesso";
                        //viewbag passa a mensagem para a view
                    }
                }
                return View();
            }
            catch(Exception)
            {
                return View("ObterCliente");
            }
        }

        public ActionResult EditarCliente(int id)
        {
            _repositorio = new ClienteRepositorio();
            return View(_repositorio.ObterCliente().Find(t => t.ID_CLIENTE == id));
        }

        [HttpPost]
        public ActionResult EditarCliente(int id, Cliente clienteObj)
        {
            try
            {
                _repositorio = new ClienteRepositorio();
                _repositorio.AtualizarCliente(clienteObj);
                return RedirectToAction("ObterCliente");
            }
            catch(Exception)
            {
                return View("ObterCliente");
            }
        }

        public ActionResult ExcluirCliente(int id)
        {
            try
            {
                _repositorio = new ClienteRepositorio();
                if(_repositorio.ExcluirCliente(id))
                {
                    //ViewBag.Mensagem = "Cliente excluído com sucesso!";
                }
                return RedirectToAction("ObterCliente");
            }
            catch(Exception)
            {
                return View("ObterCliente");
            }
        }

    }
}