using Microsoft.AspNetCore.Mvc;
using ProyectoApiCrud.DTOs;
using ProyectoApiCrud.Services.Interfaces;

namespace ProyectoApiCrud.Controllers
{
    [Route("empleado")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> GetAllEmpleados()
        {
            var _lista = await this._empleadoService.GetList();
            if (_lista != null) return Ok(_lista);
            else return NotFound();
        }
        [HttpGet("{idEmpleado}")]
        public async Task<IActionResult> GetById(int idEmpleado)
        {
            var empleado = await this._empleadoService.Get(idEmpleado);
            if (empleado != null) return Ok(empleado);
            else return NotFound();
        }
        [HttpPost("guardar")]
        public async Task<IActionResult> AddEmpleado(EmpleadoDTO _empleado)
        {
            var empleado = await this._empleadoService.Add(_empleado);
            if (empleado != null) return Ok(empleado);
            else return NotFound();
        }
        [HttpPut("actualizar/{idEmpleado}")]
        public async Task<IActionResult> UpdateEmpleado(int idEmpleado, EmpleadoDTO empleado)
        {
            var _encontrado = await this._empleadoService.Get(idEmpleado);
            if (_encontrado != null)
            {
                empleado.IdEmpleado = _encontrado.IdEmpleado;
                await this._empleadoService.Update(empleado);
                return Ok(new { Success="Actualizado con exito"});
            }
            
            else return NotFound();
        }
        [HttpDelete("eliminar/{idEmpleado}")]
        public async Task<IActionResult> DeleteEmpleado(int idEmpleado)
        {
            var _encontrado = await this._empleadoService.Get(idEmpleado);
            if (_encontrado != null)
            {
                await this._empleadoService.Delete(idEmpleado);
                return Ok(new { Success = "Eliminado con exito" });
            }

            else return NotFound();
        }
    }
}
