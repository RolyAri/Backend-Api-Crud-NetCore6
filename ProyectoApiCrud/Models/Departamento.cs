namespace ProyectoApiCrud.Models
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaCreacion { get; set;}
        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
