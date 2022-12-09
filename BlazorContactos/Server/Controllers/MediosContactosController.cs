using BlazorContactos.Server.Model;
using BlazorContactos.Server.Model.Entities;
using BlazorContactos.Shared.DTOS.Contactos;
using BlazorContactos.Shared.DTOS.MediosContactos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorContactos.Server.Controllers
{
    [ApiController, Route("/[Controller]")]
    public class MediosContactosController : ControllerBase 
    {
        private readonly ApplicationDbContext context;

        public MediosContactosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MediosContactoDto>>> Get()
        {
            var mediosContactos = await context.MediosContactos.ToListAsync();

            var mediosContactosDto = new List<MediosContactoDto>();

            foreach (var mediosContacto in mediosContactos)
            {
                var mediosContactoDto = new MediosContactoDto();
                mediosContactoDto.Id = mediosContacto.Id;
                mediosContactoDto.TipoContacto = mediosContacto.TipoContacto;
                mediosContactoDto.Contacto = mediosContacto.Contacto;



                mediosContactosDto.Add(mediosContactoDto);
            }

            return mediosContactosDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MediosContactoDto>> Get(int id)
        {
            var mediosContacto = await context.MediosContactos.FirstOrDefaultAsync(x => x.Id == id);

            if (mediosContacto == null)
            {
                return NotFound();
            }

            var mediosContactoDto = new MediosContactoDto();
            mediosContactoDto.Id = mediosContacto.Id;
            mediosContactoDto.TipoContacto = mediosContacto.TipoContacto;
            mediosContactoDto.Contacto = mediosContacto.Contacto;


            return mediosContactoDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MediosContactoDto mediosContactoDto)
        {
            var mediosContacto = new MediosContacto();
            mediosContacto.TipoContacto = mediosContactoDto.TipoContacto;
            mediosContacto.Contacto = mediosContactoDto.Contacto;
            mediosContacto.Id = mediosContactoDto.Id;

            context.MediosContactos.Add(mediosContacto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] MediosContactoDto mediosContactosDto)
        {
            var mediosContactoDb = await context.MediosContactos.FirstOrDefaultAsync(x => x.Id == mediosContactosDto.Id);

            if (mediosContactoDb == null)
            {
                return NotFound();
            }

            mediosContactoDb.TipoContacto = mediosContactoDb.TipoContacto;
            mediosContactoDb.Contacto = mediosContactoDb.Contacto;

            context.MediosContactos.Update(mediosContactoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var mediosContactoDb = await context.MediosContactos.FirstOrDefaultAsync(x => x.Id == id);

            if (mediosContactoDb == null)
            {
                return NotFound();
            }

            context.MediosContactos.Remove(mediosContactoDb);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}

