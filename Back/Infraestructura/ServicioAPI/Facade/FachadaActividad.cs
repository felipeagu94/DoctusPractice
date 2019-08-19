using AccesoDatos.Interfaces;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioAPI.Facade
{
    public class FachadaActividad
    {
        IActividadAccesoDatos _actividadAcceso;
        public FachadaActividad(IActividadAccesoDatos actividadAcceso) => _actividadAcceso = actividadAcceso;
        /// <summary>
        /// Crea una nueva actividad
        /// </summary>
        /// <param name="actividad">Datos de la nueva actividad</param>
        /// <returns></returns>
        public async Task<bool> CrearActividad(Actividad actividad) => await _actividadAcceso.CrearActividad(actividad);
        /// <summary>
        /// Retorna todas las actividades del usuario
        /// </summary>
        /// <param name="idUsuario">Usuario solicitante</param>
        /// <returns></returns>
        public async Task<List<Actividad>> RetornarActividades(int usuario) => await _actividadAcceso.RetornarActividades(usuario);
        /// <summary>
        /// Se agregan tiempos a una actividad
        /// </summary>
        /// <param name="actividad">actividad a actualizar</param>
        /// <returns></returns>
        public async Task<bool> ActualizarTiempos(Actividad actividad) => await _actividadAcceso.ActualizarTiempos(actividad);
        /// <summary>
        /// Retorna los tiempos de una actividad
        /// </summary>
        /// <param name="idActividad">actividad consultada</param>
        /// <returns></returns>
        public async Task<List<DetalleActividad>> RetornarDetallesActividad(int IdActividad) => await _actividadAcceso.RetornarDetallesActividad(IdActividad);
    }
}
