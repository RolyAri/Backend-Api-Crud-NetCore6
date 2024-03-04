using ProyectoApiCrud.DTOs;
using ProyectoApiCrud.Models;

namespace ProyectoApiCrud.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDTO>> GetList();
        Task<EmpleadoDTO> Get(int idEmpleado);
        Task<EmpleadoDTO> Add(EmpleadoDTO modelo);
        Task<bool> Update(EmpleadoDTO modelo);
        Task<bool> Delete(int idEmpleado);
    }
}
