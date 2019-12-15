using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_WEB_V2.Models.ViewModels
{
    public class PersonaViewModel
    {
        public int idPersona { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int edad { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string descripcion { get; set; }
    }
}