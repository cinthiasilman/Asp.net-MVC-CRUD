using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_CLIENTES.Models
{
    public class Cliente
    {
        [Display(Name = "Id")]
        public int ID_CLIENTE { get; set; }

        [Required(ErrorMessage = "Informe o nome do cliente")]
        public string NOME { get; set; }

        [Required(ErrorMessage = "Informe a idade do cliente")]
        public int IDADE { get; set; }

        [Required(ErrorMessage = "Informe o endereço do cliente")]
        public string ENDERECO { get; set; }

        [Required(ErrorMessage = "Informe o telefone do cliente")]
        public string TELEFONE { get; set; }

        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Informe a cidade do cliente")]
        public string CIDADE { get; set; }

        [Required(ErrorMessage = "Informe o estado do cliente")]
        public string UF { get; set; }

    }
}