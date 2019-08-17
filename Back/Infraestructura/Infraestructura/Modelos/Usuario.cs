using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructura.Modelos
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public String NombreUsuario { get; set; }
        public String Password { get; set; }
        public virtual ICollection<Actividad> Actividades { get; set; }
    }
}
