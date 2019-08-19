using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructura.Modelos
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DetalleActividad
    {
        [Key]
        public int IdDetalleActividad { get; set; }
        public DateTime fecha { get; set; }
        public int tiempo { get; set; }
        public int IdActividad { get; set; }
        [JsonIgnore]
        public virtual Actividad Actividad { get; set; }
    }
}
