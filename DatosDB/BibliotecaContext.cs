using BiblioMundo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BiblioMundo.DatosDB
{
    public class BibliotecaContext : DbContext
    {
        //CREAMOS LAS TABLAS
        public DbSet<PersonaModel> Personas { get; set; }
        public DbSet<LibroModel> Libros { get; set; }
        public DbSet<TipoPersonaModel> TipoPersonas { get; set; }
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<EditorialModel> Editoriales { get; set; }
        public DbSet<EstadoPrestamoModel> EstadoPrestamo { get; set; }
        public DbSet<PrestamoModel> Prestamos { get; set; }


        //CREAMOS UN CONSTRUCTOR
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //SEMBRAMOS AUTORES
            var AutorModel = new AutorModel();
            AutorModel.Id = 1;
            AutorModel.Nombre = "Jorge Revelo";
            AutorModel.Estado = true;
            modelBuilder.Entity<AutorModel>().HasData(AutorModel);

            //SEMBRAMOS DATOS DE PERSONA 

            var PersonaModel = new PersonaModel();
            PersonaModel.Id = 1;
            PersonaModel.Nombre = string.Empty;
            PersonaModel.Apellido = string.Empty;
            PersonaModel.Correo = "yugsiwilliam46@gmail.com";
            PersonaModel.Clave = "1234";
            PersonaModel.Codigo = string.Empty;
            modelBuilder.Entity<PersonaModel>().HasData(PersonaModel);

            //SEMBRAMOS TIPOS DE PERSONAS
            var TipoPersona = new TipoPersonaModel();
            TipoPersona.Id = 1;
            TipoPersona.Nombre = "Administrador";
            modelBuilder.Entity<TipoPersonaModel>().HasData(TipoPersona);

            //SEMBRAMOS ESTADO DE PRESTAMO
            var EstadoPrestamo = new EstadoPrestamoModel();
            EstadoPrestamo.Id = 1;
            EstadoPrestamo.Descripcion = "Pendiente";
            modelBuilder.Entity<EstadoPrestamoModel>().HasData(EstadoPrestamo);

            //SEMBRAMOS CATEGORIA
            var CategoriaModel = new CategoriaModel();
            CategoriaModel.Id = 1;
            CategoriaModel.Nombre = "Acción";
            CategoriaModel.Estado = true;
            modelBuilder.Entity<CategoriaModel>().HasData(CategoriaModel);

            //SEMBRAMOS EDITORIALES
            var EditorialModel = new EditorialModel();
            EditorialModel.Id = 1;
            EditorialModel.Nombre = "Santillana";
            EditorialModel.Estado = true;
            modelBuilder.Entity<EditorialModel>().HasData(EditorialModel);

            //SEMBRAMOS Libro
            var LibroModel = new LibroModel();
            LibroModel.Id = 1;
            LibroModel.Titulo = "Caperucita";
            LibroModel.AutorId = 1; // ID del autor correspondiente
            LibroModel.CategoriaId = 1;// ID de la categoría correspondiente
            LibroModel.EditorialId = 1; // ID de la editorial correspondiente
            LibroModel.Ubicacion = "Ubicación del libro";
            LibroModel.Ejemplares = 5;
            LibroModel.Estado = true;
            modelBuilder.Entity<LibroModel>().HasData(LibroModel);

            // Sembrar datos de personas
            modelBuilder.Entity<PersonaModel>().HasData(
                new PersonaModel
                {
                    Id = 2,
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    Correo = "juan@example.com",
                    Clave = "123456",
                    Codigo = "ABC123",
                    TipoPersonaId = 1,
                    Estado = true
                }
                //},
                //new PersonaModel
                //{
                //    Id = 2,
                //    Nombre = "María",
                //    Apellido = "López",
                //    Correo = "maria@example.com",
                //    Clave = "654321",
                //    Codigo = "XYZ789",
                //    TipoPersonaId = 2,
                //    Estado = true
                //}
            );

            var prestamo = new PrestamoModel
            {
                Id = 1,
                EstadoPrestamoId = 1, // ID del estado de préstamo correspondiente
                PersonaId = 2, // ID de la persona correspondiente
                LibroId = 1, // ID del libro correspondiente
                FechaDevolucion = DateTime.Now.AddDays(7),
                TextoFechaDevolucion = "Fecha de devolución",
                FechaConfirmacionDevolucion = DateTime.Now.AddDays(7),
                TextoFechaConfirmacionDevolucion = "Fecha de confirmación de devolución",
                EstadoEntregado = "Entregado",
                EstadoRecibido = "Recibido",
                Estado = true
            };

            modelBuilder.Entity<PrestamoModel>().HasData(prestamo);
        }



    }

}


