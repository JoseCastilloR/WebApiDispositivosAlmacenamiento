using Microsoft.AspNetCore.Mvc;
using WebApiDispositivosAlmacenamiento.Entidades;

namespace WebApiDispositivosAlmacenamiento.Controllers
{
    [ApiController]
    [Route("api/dispositivosalmacenamiento")]
    public class DispositivosAlmacenamientoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<DispositivoAlmacenamiento>> Get()
        {
            return new List<DispositivoAlmacenamiento>()
            {
                new DispositivoAlmacenamiento { Id = 1, Capacidad = "2 TB", VelocidadLectura = "7400 MB/s", VelocidadEscritura = "6400 MB/s"},
                new DispositivoAlmacenamiento { Id = 2, Capacidad = "1 TB", VelocidadLectura = "7000 MB/s", VelocidadEscritura = "6000 MB/s"}
            };
        }
    }
}
