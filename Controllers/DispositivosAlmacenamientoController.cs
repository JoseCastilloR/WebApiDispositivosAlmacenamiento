using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDispositivosAlmacenamiento.Entidades;

namespace WebApiDispositivosAlmacenamiento.Controllers
{
    [ApiController]
    [Route("api/dispositivosalmacenamiento")]
    public class DispositivosAlmacenamientoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DispositivosAlmacenamientoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<DispositivoAlmacenamiento>> Get()
        {
            return new List<DispositivoAlmacenamiento>()
            {
                new DispositivoAlmacenamiento { Id = 1, TipoDispositivo = "HDD", Capacidad = "2 TB"},
                new DispositivoAlmacenamiento { Id = 2, TipoDispositivo = "SSD", Capacidad = "1 TB"}
            };
        }

        [HttpPost]
        public async Task<ActionResult> Post(DispositivoAlmacenamiento dispositivoAlmacenamiento)
        {
            _context.Add(dispositivoAlmacenamiento);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("/lista")]
        public async Task<ActionResult<List<DispositivoAlmacenamiento>>> GetAll()
        {
            return await _context.DispositivosAlmacenamiento.Include(x => x.Modelos).ThenInclude(x => x.Marca).ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(DispositivoAlmacenamiento dispositivoAlmacenamiento, int id)
        {
            if(dispositivoAlmacenamiento.Id != id)
            {
                return BadRequest("El ID del dispositivo de almacenamiento no coincide con el establecido en la URL.");
            }

            _context.Update(dispositivoAlmacenamiento);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.DispositivosAlmacenamiento.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("No se encontró el registro en la base de datos.");
            }

            _context.Remove(new DispositivoAlmacenamiento() { Id = id});
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
