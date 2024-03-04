using AutoMapper;
using Dapper;
using ProyectoApiCrud.Data;
using ProyectoApiCrud.DTOs;
using ProyectoApiCrud.Models;
using ProyectoApiCrud.Services.Interfaces;
using System.Data;

namespace ProyectoApiCrud.Services.Implements
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly DapperDBContext _dbContext;
        private IMapper _mapper;
        public DepartamentoService(DapperDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<DepartamentoDTO>> GetList()
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                var dptoList = await connection.QueryAsync<Departamento>("ObtenerDepartamentos");
                dptoList = dptoList.ToList();
                return _mapper.Map<List<DepartamentoDTO>>(dptoList);
            }
        }

        public async Task<DepartamentoDTO> Get(int idDepartamento)
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                var dpto = await connection.QueryFirstOrDefaultAsync<DepartamentoDTO>("ObtenerDepartamentoPorId", new { idDepartamento}, commandType: CommandType.StoredProcedure);
                return dpto;
            }
        }

        public async Task<DepartamentoDTO> Add(DepartamentoDTO modelo)
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                Departamento _modelo = _mapper.Map<Departamento>(modelo);
                await connection.ExecuteAsync("CrearDepartamento", new { _modelo.Nombre });

                return _mapper.Map<DepartamentoDTO>(modelo);
            }
        }

        public async Task<bool> Update(DepartamentoDTO modelo)
        {
            try
            {
                using (var connection = this._dbContext.CreateConnection())
                {
                    Departamento _modelo = _mapper.Map<Departamento>(modelo);
                    await connection.ExecuteAsync("EditarDepartamento", new { _modelo.IdDepartamento, _modelo.Nombre }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(int idDepartamento)
        {
            try
            {
                using (var connection = this._dbContext.CreateConnection())
                {
                    await connection.ExecuteAsync("EliminarDepartamento", new { idDepartamento }, commandType: CommandType.StoredProcedure);

                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
