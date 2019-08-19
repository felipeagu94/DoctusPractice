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
    public class UsuarioController : ControllerBase
    {
        FachadaUsuario _FachadaUsuario;
        public UsuarioController(FachadaUsuario fachadaUsuario)
        {
            _FachadaUsuario = fachadaUsuario;
        }
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                String mensajeUsuario = "El usuario no es valido o ya existe";
                if (await _FachadaUsuario.CrearUsuario(usuario)) mensajeUsuario = "El usuario fue creado.";
                return new JsonResult(new { message = mensajeUsuario });
            }
            return BadRequest(new { message = "Los datos no son validos para la creación." });
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> login([FromBody] Usuario usuario)
        {
            if(!string.IsNullOrEmpty(usuario.NombreUsuario) && !string.IsNullOrEmpty(usuario.Password))
            {
                return new JsonResult(new { message = await _FachadaUsuario.ValidarUsuario(usuario.NombreUsuario, usuario.Password) ? 1 : 0 });
            }
            return BadRequest(new { message = "Falta información para realizar la validación." });
        }
        [HttpGet]
        [Route("Obtener")]
        public async Task<JsonResult> List([FromQuery] String usuario) => new JsonResult(await _FachadaUsuario.ObtenerIdUsuario(usuario));
    }
}