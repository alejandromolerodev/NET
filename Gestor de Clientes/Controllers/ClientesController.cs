using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestor_de_Clientes.Models;

namespace Gestor_de_Clientes.Controllers
{

    public class ClientesController: Controller
    {

        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ObtenerClientes()
        {
            var clientes = db.Clientes.ToList();
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AgregarCliente(string nombre, string email)
        {
            Cliente nuevoCliente = new Cliente
            {
                Nombre = nombre,    
                Email = email
            };
            db.Clientes.Add(nuevoCliente);
            db.SaveChanges();
            return Json(new { mensaje = "Cliente agregado correctamente" });
        }


        [HttpGet]
        public ActionResult EliminarCliente(int id)
        {
            var cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return Json(new { mensaje = "Cliente no encontrado" }, JsonRequestBehavior.AllowGet);
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return Json(new { mensaje = "Cliente eliminado correctamente" }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult EditarCliente(int id, Cliente cliente)
        {
            if (cliente == null || string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Email))
            {
                return Json(new { mensaje = "Datos del cliente no válidos" }, JsonRequestBehavior.AllowGet);
            }

            var viejocliente = db.Clientes.Find(id);
            if (viejocliente != null)
            {
                viejocliente.Nombre = cliente.Nombre;
                viejocliente.Email = cliente.Email;
                db.SaveChanges();
                return Json(new { mensaje = "Cliente editado correctamente" });
            }

            return Json(new { mensaje = "Cliente no encontrado" }, JsonRequestBehavior.AllowGet);
        }
    }
}