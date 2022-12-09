using System.ComponentModel.DataAnnotations;

namespace BlazorContactos.Server.Model.Entities
{
    public class Contacto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }    

        public List<MediosContacto> Contactos { get; set; }
    }
}
