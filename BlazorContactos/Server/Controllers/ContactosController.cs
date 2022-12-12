using BlazorContactos.Server.Model;
using BlazorContactos.Server.Model.Entities;
using BlazorContactos.Shared.DTOS.Contactos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorContactos.Server.Controllers
{
    [ApiController, Route("api/Contactos")]
    public class ContactosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ContactosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactoDto>>> GetContactos()
        {
            var contactos = await context.Contactos.ToListAsync();

            var contactosDto = new List<ContactoDto>();

            foreach (var contacto in contactos)
            {
                var contactoDto = new ContactoDto();
                contactoDto.Id = contacto.Id;
                contactoDto.Nombre = contacto.Nombre;
                
               

                contactosDto.Add(contactoDto);
            }

            return contactosDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContactoDto>> Get(int id)
        {
            var contacto = await context.Contactos.FirstOrDefaultAsync(x => x.Id == id);

            if (contacto == null)
            {
                return NotFound();
            }

            var contactoDto = new ContactoDto();
            contactoDto.Id = contacto.Id;
            contactoDto.Nombre = contacto.Nombre;
            

            return contactoDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ContactoDto contactoDto)
        {
            var contacto = new Contacto();
            contacto.Nombre = contactoDto.Nombre;

            context.Contactos.Add(contacto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] ContactoDto contactosDto)
        {
            var contactoDb = await context.Contactos.FirstOrDefaultAsync(x => x.Id == contactosDto.Id);

            if (contactoDb == null)
            {
                return NotFound();
            }

            contactoDb.Nombre = contactoDb.Nombre;

            context.Contactos.Update(contactoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var contactoDb = await context.Contactos.FirstOrDefaultAsync(x => x.Id == id);

            if (contactoDb == null)
            {
                return NotFound();
            }

            context.Contactos.Remove(contactoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

    }

}
