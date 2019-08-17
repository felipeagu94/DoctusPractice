using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IActividadAccesoDatos
    {
        /// <summary>
        /// Crea una nueva actividad
        /// </summary>
        /// <param name="actividad">Datos de la nueva actividad</param>
        /// <returns></returns>
        Task<bool> CrearActividad(Actividad actividad);
        /// <summary>
        /// Retorna todas las actividades del usuario
        /// </summary>
        /// <param name="idUsuario">Usuario solicitante</param>
        /// <returns></returns>
        Task<List<Actividad>> RetornarActividades(int idUsuario);
    }
}
