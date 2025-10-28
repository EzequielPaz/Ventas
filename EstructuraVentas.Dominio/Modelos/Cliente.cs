namespace EstructuraVentas.Dominio
{
    public class Cliente
    {
        public int IDClientes { get; set; }
        public string? NombreCliente { get; set; }
        public string? Email { get; set; }
        public string? Documento { get; set; }
        public string? Celular { get; set; }
        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
        public Estado Estado { get; set; } = Estado.Activo;

    }

    public enum Estado
    {
        Activo = 0,
        Inactivo = 1
    }
}
