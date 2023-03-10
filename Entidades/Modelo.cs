namespace WebApiDispositivosAlmacenamiento.Entidades
{
    public class Modelo
    {
        public int Id { get; set; }

        public string NombreModelo { get; set; }

        public string VelocidadLectura { get; set; }

        public string VelocidadEscritura { get; set; }

        public string Firmware { get; set; }

        public int DispositivoAlmacenamientoId { get; set; }

        public DispositivoAlmacenamiento DispositivoAlmacenamiento { get; set; }

        public int MarcaId { get; set; }

        public Marca Marca { get; set; }
    }
}
