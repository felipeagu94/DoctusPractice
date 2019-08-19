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
            return await _contexto.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// Retorna todas las actividades del usuario
        /// </summary>
        /// <param name="idUsuario">Usuario solicitante</param>
        /// <returns></returns>
        public async Task<List<Actividad>> RetornarActividades(int usuario) => _contexto.Actividades.Where(a => a.IdUsuario == usuario).ToList();
        /// <summary>
        /// Se agregan tiempos a una actividad
        /// </summary>
        /// <param name="actividad">actividad a actualizar</param>
        /// <returns></returns>
        public async Task<bool> ActualizarTiempos(Actividad actividad)
        {
            var actividadActual = _contexto.Actividades.FirstOrDefault(a => a.IdActividad == actividad.IdActividad);
            var detalleActividad = actividad.DetalleActividades.First();
            detalleActividad.IdActividad = actividad.IdActividad;
            if (actividadActual.DetalleActividades == null) actividadActual.DetalleActividades = new List<DetalleActividad>();
            actividadActual.DetalleActividades.Add(detalleActividad);
            _contexto.Entry(actividadActual).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// Retorna los tiempos de una actividad
        /// </summary>
        /// <param name="idActividad">actividad consultada</param>
        /// <returns></returns>
        public async Task<List<DetalleActividad>> RetornarDetallesActividad(int idActividad) => _contexto.detalleActividades.Where(a => a.IdActividad == idActividad).ToList();
    }
}
