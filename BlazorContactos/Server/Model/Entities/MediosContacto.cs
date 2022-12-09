using System.ComponentModel.DataAnnotations;

namespace BlazorContactos.Server.Model.Entities
{
    public class MediosContacto
    {
        public int Id { get; set; }

        [Required]
        public string TipoContacto { get; set; }
        [Required]
        public string Contacto { get; set; }
        public int ContactoId { get; set; }

       
    }
}
