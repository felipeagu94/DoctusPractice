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
        /// <summary>
        /// Se agregan tiempos a una actividad
        /// </summary>
        /// <param name="actividad">actividad a actualizar</param>
        /// <returns></returns>
        Task<bool> ActualizarTiempos(Actividad actividad);
        /// <summary>
        /// Retorna los tiempos de una actividad
        /// </summary>
        /// <param name="idActividad">actividad consultada</param>
        /// <returns></returns>
        Task<List<DetalleActividad>> RetornarDetallesActividad(int idActividad);
    }
}
