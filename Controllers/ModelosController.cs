using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDispositivosAlmacenamiento.Entidades;

namespace WebApiDispositivosAlmacenamiento.Controllers
{
    [ApiController]
    [Route("modelo")]
    public class ModelosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ModelosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Modelo>>> GetAll()
        {
            return await _context.Modelos.Include(x => x.Marca).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Modelo>> GetById(int id)
        {
            return await _context.Modelos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Modelo modelo)
        {
            var existeDispositivoAlmacenamiento = await _context.DispositivosAlmacenamiento.AnyAsync(x => x.Id == modelo.DispositivoAlmacenamientoId);
            var existeMarca = await _context.Marcas.AnyAsync(x => x.Id == modelo.MarcaId);

            if(!existeDispositivoAlmacenamiento)
            {
                return BadRequest("No existe el dispositivo de almacenamiento.");
            }

            if(!existeMarca)
            {
                return BadRequest("No existe la marca.");
            }

            _context.Add(modelo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Modelo modelo, int id)
        {
            var existeModelo = await _context.Modelos.AnyAsync(x => x.Id == modelo.Id);

            if(!existeModelo)
            {
                return BadRequest("No existe el modelo.");
            }

            if(modelo.Id != id)
            {
                return BadRequest("El ID del modelo no coincide con el establecido en la URL.");
            }

            _context.Update(modelo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Modelos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No se encontró el registro en la base de datos.");
            }

            _context.Remove(new Modelo() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
