using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContactos.Shared.DTOS.MediosContactos
{
    public class MediosContactoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string TipoContacto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Contacto { get; set; }   
    }
}
