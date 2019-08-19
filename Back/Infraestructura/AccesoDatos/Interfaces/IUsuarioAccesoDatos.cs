using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IUsuarioAccesoDatos
    {
        /// <summary>
        /// Creación de un Usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario nuevo</param>
        /// <returns></returns>
        Task<bool> CrearUsuario(Usuario usuario);
        /// <summary>
        /// Valida si el usuario y contraseña son correctos
        /// </summary>
        /// <param name="usuario">Nombre del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns></returns>
        Task<bool> ValidarUsuario(string usuario, string password);
        /// <summary>
        /// Retorna el id del usuario
        /// </summary>
        /// <param name="usuario">Nombre del usuario</param>
        /// <returns></returns>
        Task<int> ObtenerIdUsuario(string usuario);
    }
}
