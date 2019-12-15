using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_WEB_V2.Models.ViewModels
{
    public class AddPersonaViewModel
    {
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string descripcion { get; set; }
    }
}