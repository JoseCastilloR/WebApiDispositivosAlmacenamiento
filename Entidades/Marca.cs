namespace WebApiDispositivosAlmacenamiento.Entidades
{
    public class Marca
    {
        public int Id { get; set; }

        public string NombreMarca { get; set; }

        public string Servicios { get; set; }

        public List<Modelo> Modelos { get; set; }
    }
}
