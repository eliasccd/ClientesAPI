Imports ClientesAPI.Models
Imports Microsoft.EntityFrameworkCore

Namespace Data
    Public Class ApplicationDbContext
        Inherits DbContext

        Public Sub New(options As DbContextOptions(Of ApplicationDbContext))
            MyBase.New(options)
        End Sub

        Public Property Clientes As DbSet(Of Cliente)

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

            modelBuilder.Entity(Of Cliente)().ToTable("Clientes")
            modelBuilder.Entity(Of Cliente)().HasKey(Function(c) c.Id)

            modelBuilder.Entity(Of Cliente)().Property(Function(c) c.Nombre).
                HasMaxLength(100).
                IsRequired()

            modelBuilder.Entity(Of Cliente)().Property(Function(c) c.Apellido).
                HasMaxLength(100).
                IsRequired()

            modelBuilder.Entity(Of Cliente)().Property(Function(c) c.Email).
                HasMaxLength(150).
                IsRequired()

            modelBuilder.Entity(Of Cliente)().Property(Function(c) c.Telefono).
                HasMaxLength(30)
        End Sub
    End Class
End Namespace
