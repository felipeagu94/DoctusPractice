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
    public class ActividadAccesoDatos : IActividadAccesoDatos
    {
        Contexto _contexto;
        public ActividadAccesoDatos(Contexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Crea una nueva actividad
        /// </summary>
        /// <param name="actividad">Datos de la nueva actividad</param>
        /// <returns></returns>
        public async Task<bool> CrearActividad(Actividad actividad)
        {
            await _contexto.Actividades.AddAsync(actividad);
            return await _contexto.SaveChangesAsync() == 1;
        }
        /// <summary>
        /// Retorna todas las actividades del usuario
        /// </summary>
        /// <param name="idUsuario">Usuario solicitante</param>
        /// <returns></returns>
        public async Task<List<Actividad>> RetornarActividades(int idUsuario)
        {
            return _contexto.Actividades.Where(a => a.IdUsuario == idUsuario).ToList();
        }
    }
}
