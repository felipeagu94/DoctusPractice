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
        public FachadaActividad(IActividadAccesoDatos actividadAcceso)
        {
            _actividadAcceso = actividadAcceso;
        }
        public async Task<bool> CrearActividad(Actividad actividad)
        {
            return await _actividadAcceso.CrearActividad(actividad);
        }
        public async Task<List<Actividad>> RetornarActividades(int idUsuario) => await _actividadAcceso.RetornarActividades(idUsuario);
    }
}
