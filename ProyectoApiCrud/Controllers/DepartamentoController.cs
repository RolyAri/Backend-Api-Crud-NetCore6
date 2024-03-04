using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoApiCrud.DTOs;
using ProyectoApiCrud.Models;
using ProyectoApiCrud.Services.Implements;
using ProyectoApiCrud.Services.Interfaces;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoApiCrud.Controllers
{
    [Route("departamento")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;
        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> GetAllDepartamentos()
        {
            var _lista = await this._departamentoService.GetList();
            if (_lista != null) return Ok(_lista);
            else return NotFound();
        }
        [HttpGet("{idDepartamento}")]
        public async Task<IActionResult> GetById(int idDepartamento)
        {
            var dpto = await this._departamentoService.Get(idDepartamento);
            if (dpto != null) return Ok(dpto);
            else return NotFound();
        }
        [HttpPost("guardar")]
        public async Task<IActionResult> AddDepartamento(DepartamentoDTO _departamento)
        {
            var dpto = await this._departamentoService.Add(_departamento);
            if (dpto != null) return Ok(dpto);
            else return NotFound();
        }
        [HttpPut("actualizar/{idDepartamento}")]
        public async Task<IActionResult> UpdateDepartamento(int idDepartamento, DepartamentoDTO departamento)
        {
            var _encontrado = await this._departamentoService.Get(idDepartamento);
            if (_encontrado != null)
            {
                departamento.IdDepartamento = _encontrado.IdDepartamento;
                await this._departamentoService.Update(departamento);
                return Ok(new { Success = "Actualizado con exito" });
            }

            else return NotFound();
        }
        [HttpDelete("eliminar/{idDepartamento}")]
        public async Task<IActionResult> DeleteEmpleado(int idDepartamento)
        {
            var _encontrado = await this._departamentoService.Get(idDepartamento);
            if (_encontrado != null)
            {
                await this._departamentoService.Delete(idDepartamento);
                return Ok(new { Success = "Eliminado con exito" });
            }

            else return NotFound();
        }
    }
}
