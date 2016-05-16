using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_CLIENTES.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o login do usuário")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public int senha { get; set; }
    }
}