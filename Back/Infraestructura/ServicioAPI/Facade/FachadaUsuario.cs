using AccesoDatos.Interfaces;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioAPI.Facade
{
    public class FachadaUsuario
    {
        IUsuarioAccesoDatos _usuarioAcceso;
        public FachadaUsuario(IUsuarioAccesoDatos usuarioAcceso)
        {
            _usuarioAcceso = usuarioAcceso;
        }
        /// <summary>
        /// Creación de un Usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario nuevo</param>
        /// <returns></returns>
        public async Task<bool> CrearUsuario(Usuario usuario)
        {
            return await _usuarioAcceso.CrearUsuario(usuario);
        }
        /// <summary>
        /// Valida si el usuario y contraseña son correctos
        /// </summary>
        /// <param name="usuario">Nombre del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns></returns>
        public async Task<bool> ValidarUsuario(string usuario, string password)
        {
            return await _usuarioAcceso.ValidarUsuario(usuario, password);
        }
        public async Task<int> ObtenerIdUsuario(string usuario) => await _usuarioAcceso.ObtenerIdUsuario(usuario);
    }
}
