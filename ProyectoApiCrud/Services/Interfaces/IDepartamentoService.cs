using ProyectoApiCrud.DTOs;
using ProyectoApiCrud.Models;

namespace ProyectoApiCrud.Services.Interfaces
{
    public interface IDepartamentoService
    {
        Task<List<DepartamentoDTO>> GetList();
        Task<DepartamentoDTO> Get(int idDepartamento);
        Task<DepartamentoDTO> Add(DepartamentoDTO modelo);
        Task<bool> Update(DepartamentoDTO modelo);
        Task<bool> Delete(int idDepartamento);
    }
}
