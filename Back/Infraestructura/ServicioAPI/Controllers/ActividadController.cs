using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Modelos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioAPI.Facade;

namespace ServicioAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class ActividadController : ControllerBase
    {

        FachadaActividad _fachadaActividad;
        public ActividadController(FachadaActividad fachadaActividad)
        {
            _fachadaActividad = fachadaActividad;
        }
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Create([FromBody] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                String mensajeUsuario = "Hay actividades superiores a 8 horas.";
                if (actividad.DetalleActividades.Where(d => d.tiempo > 8).Count() == 0)
                {
                    if (await _fachadaActividad.CrearActividad(actividad)) mensajeUsuario = "La actividad se regristro correctamente.";
                }
                return new JsonResult(new { message = mensajeUsuario });
            }
            return BadRequest(new { message = "Los datos no son validos para la creación." });
        }
        [HttpGet]
        [Route("Obtener")]
        public async Task<JsonResult> List([FromQuery] int usuario) => new JsonResult(await _fachadaActividad.RetornarActividades(usuario));
        [HttpGet]
        [Route("ObtenerDetalles")]
        public async Task<JsonResult> ListDetalle([FromQuery] int actividad) => new JsonResult(await _fachadaActividad.RetornarDetallesActividad(actividad));
        [HttpPost]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] Actividad actividad)
        {
            if(ModelState.IsValid)
            {
                String mensajeUsuario = "Hay actividades superiores a 8 horas.";
                if (actividad.DetalleActividades.Where(d => d.tiempo > 8).Count() == 0)
                {
                    if (await _fachadaActividad.ActualizarTiempos(actividad)) mensajeUsuario = "Se registro correctamente el tiempo.";
                }
                return new JsonResult(new { message = mensajeUsuario });
            }
            return BadRequest(new { message = "Los datos no son validos para la creación." });
        }
    }
}