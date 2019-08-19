using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructura.Modelos
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Actividad
    {
        [Key]
        public int IdActividad { get; set; }
        public String DescripcionActividad { get; set; }
        public int IdUsuario { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<DetalleActividad> DetalleActividades { get; set; }
    }
}
