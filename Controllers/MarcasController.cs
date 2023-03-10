using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDispositivosAlmacenamiento.Entidades;

namespace WebApiDispositivosAlmacenamiento.Controllers
{
    [ApiController]
    [Route("marca")]
    public class MarcasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MarcasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marca>>> GetAll()
        {
            return await _context.Marcas.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Marca>> GetById(int id)
        {
            return await _context.Marcas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Marca marca)
        {
            _context.Add(marca);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Marca marca, int id)
        {
            var existeMarca = await _context.Marcas.AnyAsync(x => x.Id == marca.Id);

            if (!existeMarca)
            {
                return BadRequest("No existe la marca.");
            }

            if (marca.Id != id)
            {
                return BadRequest("El ID de la marca no coincide con el establecido en la URL.");
            }

            _context.Update(marca);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Marcas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No se encontró el registro en la base de datos.");
            }

            _context.Remove(new Marca() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
