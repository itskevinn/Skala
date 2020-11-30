using System;
using entity;
using Microsoft.EntityFrameworkCore;

namespace datos
{
  public class SkalaContext : DbContext
  {
    public SkalaContext(DbContextOptions options) : base(options) { }

    public DbSet<Persona> Personas { get; set; }
  }
}
