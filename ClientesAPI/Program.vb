Imports ClientesAPI.Data
Imports ClientesAPI.Repositories
Imports ClientesAPI.Services
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Public Class Program
    Public Shared Sub Main(args As String())
        Try
            Dim builder = WebApplication.CreateBuilder(args)

            ' Agregar Swagger
            builder.Services.AddSwaggerGen()

            ' Agregar Controllers
            builder.Services.AddControllers()

            ' Agregar servicios
            builder.Services.AddEndpointsApiExplorer()

            ' Agregar DbContext
            Dim connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            If String.IsNullOrEmpty(connectionString) Then
                Console.WriteLine("ERROR: Connection string no encontrada en appsettings.json")
            End If

            builder.Services.AddDbContext(Of ApplicationDbContext)(
                Sub(options)
                    options.UseSqlServer(connectionString)
                End Sub)

            ' Agregar dependencias
            builder.Services.AddScoped(GetType(IClienteRepository), GetType(ClienteRepository))
            builder.Services.AddScoped(GetType(IClienteService), GetType(ClienteService))

            ' Crear la aplicación
            Dim app = builder.Build()

            ' Habilitar Swagger en desarrollo
            If app.Environment.IsDevelopment() Then
                app.UseDeveloperExceptionPage()
                app.UseSwagger()
                app.UseSwaggerUI()
            End If

            app.UseHttpsRedirection()
            app.MapControllers()

            Console.WriteLine("✓ Iniciando aplicación...")
            app.Run()

        Catch ex As Exception
            Console.WriteLine($"✗ ERROR CRÍTICO: {ex.Message}")
            Console.WriteLine($"Stack Trace: {ex.StackTrace}")
        End Try
    End Sub
End Class