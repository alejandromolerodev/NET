using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gestor_de_Clientes.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }


    }
}