Imports ClientesAPI.Data
Imports ClientesAPI.Repositories
Imports ClientesAPI.Services
Imports Microsoft.EntityFrameworkCore

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        builder.Services.AddControllers()
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()

        Dim connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        builder.Services.AddDbContext(Of ApplicationDbContext)(Sub(options)
            options.UseSqlServer(connectionString)
        End Sub)

        builder.Services.AddScoped(GetType(IClienteRepository), GetType(ClienteRepository))
        builder.Services.AddScoped(GetType(IClienteService), GetType(ClienteService))

        Dim app = builder.Build()

        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If

        app.UseHttpsRedirection()
        app.UseAuthorization()
        app.MapControllers()
        app.Run()
    End Sub
End Module
