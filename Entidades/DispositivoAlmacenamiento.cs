namespace WebApiDispositivosAlmacenamiento.Entidades
{
    public class DispositivoAlmacenamiento
    {
        public int Id { get; set; }

        public string TipoDispositivo { get; set; }

        public string Capacidad { get; set; }

        public List<Modelo> Modelos { get; set; }
    }
}
