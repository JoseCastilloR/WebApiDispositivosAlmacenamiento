namespace WebApiDispositivosAlmacenamiento.Entidades
{
    public class DispositivoAlmacenamiento
    {
        public int Id { get; set; }

        public string Capacidad { get; set; }

        public string VelocidadLectura { get; set; }

        public string VelocidadEscritura { get; set; }
    }
}
