namespace EstructuraVentas.Infraestructura.Commons.Bases.Response
{
    public class BaseEntityResponse<T>
    {
        public int? TotalRecords { get; set; }
        public List<T>? Records { get; set; }
    }
}
