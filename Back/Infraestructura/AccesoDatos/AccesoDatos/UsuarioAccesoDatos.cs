using AccesoDatos.Interfaces;
using Infraestructura;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.AccesoDatos
{
    public class UsuarioAccesoDatos : IUsuarioAccesoDatos
    {
        Contexto _contexto;
        public UsuarioAccesoDatos(Contexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Creación de un Usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario nuevo</param>
        /// <returns></returns>
        public async Task<bool> CrearUsuario(Usuario usuario)
        {
            var validarUsuario = _contexto.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuario.NombreUsuario);
            if (validarUsuario != null) return false;
            await _contexto.Usuarios.AddAsync(usuario);
            return await _contexto.SaveChangesAsync() == 1;
        }
        /// <summary>
        /// Valida si el usuario y contraseña son correctos
        /// </summary>
        /// <param name="usuario">Nombre del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns></returns>
        public async Task<bool> ValidarUsuario(string usuario, string password)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuario && u.Password == password) != null;
        }
        /// <summary>
        /// Retorna el id del usuario
        /// </summary>
        /// <param name="usuario">Nombre del usuario</param>
        /// <returns></returns>
        public async Task<int> ObtenerIdUsuario(string usuario)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuario).idUsuario;
        }
    }
}
