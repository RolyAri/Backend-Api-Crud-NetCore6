﻿namespace ProyectoApiCrud.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? NombreCompleto { get; set; }
        public int? IdDepartamento { get; set; }
        public string? NombreDepartamento { get; set; }
        public int? Sueldo { get; set; }
        public DateTime? FechaContrato { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
