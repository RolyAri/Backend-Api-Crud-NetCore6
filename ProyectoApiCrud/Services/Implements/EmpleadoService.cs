using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoApiCrud.Data;
using ProyectoApiCrud.DTOs;
using ProyectoApiCrud.Models;
using ProyectoApiCrud.Services.Interfaces;
using System.Data;

namespace ProyectoApiCrud.Services.Implements
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly DapperDBContext _dbContext;
        private IMapper _mapper;
        public EmpleadoService(DapperDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<EmpleadoDTO>> GetList()
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                var empleadoList = await connection.QueryAsync<EmpleadoDTO>("ObtenerEmpleadosDTO");
                empleadoList.ToList();
                return _mapper.Map<List<EmpleadoDTO>>(empleadoList);
            }
        }
        public async Task<EmpleadoDTO> Get(int idEmpleado)
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                var empleado = await connection.QueryFirstOrDefaultAsync<EmpleadoDTO>("ObtenerEmpleadoConDepartamentoPorId", new {idEmpleado}, commandType: CommandType.StoredProcedure);
                return empleado;
            }
        }

        public async Task<EmpleadoDTO> Add(EmpleadoDTO modelo)
        {
            using (var connection = this._dbContext.CreateConnection())
            {
                Empleado _modelo = _mapper.Map<Empleado>(modelo);
                await connection.ExecuteAsync("CrearEmpleado", new { _modelo.NombreCompleto, _modelo.IdDepartamento, _modelo.Sueldo, _modelo.FechaContrato });
                
                return _mapper.Map<EmpleadoDTO>(modelo);
            }
        }

        public async Task<bool> Update(EmpleadoDTO modelo)
        {
            try
            {
                using (var connection = this._dbContext.CreateConnection())
                {
                    Empleado _modelo = _mapper.Map<Empleado>(modelo);
                    await connection.ExecuteAsync("EditarEmpleado", new { _modelo.IdEmpleado, _modelo.NombreCompleto, _modelo.IdDepartamento, modelo.Sueldo, _modelo.FechaContrato }, commandType: CommandType.StoredProcedure);
                }
                return true;
            }catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<bool> Delete(int idEmpleado)
        {
            try
            {
                using (var connection = this._dbContext.CreateConnection())
                {
                    await connection.ExecuteAsync("EliminarEmpleado", new { idEmpleado}, commandType: CommandType.StoredProcedure);
                    
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
