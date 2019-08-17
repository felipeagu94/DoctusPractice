using Infraestructura.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<DetalleActividad> detalleActividades { get; set; }
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        { }
    }
}
