﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JFernandezAlumnosDigiProEntities : DbContext
    {
        public JFernandezAlumnosDigiProEntities()
            : base("name=JFernandezAlumnosDigiProEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AlumnoMateria> AlumnoMaterias { get; set; }
        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
    }
}
