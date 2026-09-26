Imports ClientesAPI.Models
Imports ClientesAPI.Services
Imports Microsoft.AspNetCore.Mvc

Namespace Controllers
    <ApiController>
    <Route("api/[controller]")>
    Public Class ClientesController
        Inherits ControllerBase

        Private ReadOnly _clienteService As IClienteService

        Public Sub New(clienteService As IClienteService)
            _clienteService = clienteService
        End Sub

        <HttpGet>
        Public Async Function GetClientes() As Task(Of ActionResult(Of List(Of Cliente)))
            Dim clientes = Await _clienteService.GetAllAsync()
            Return Ok(clientes)
        End Function

        <HttpGet("{id:int}")>
        Public Async Function GetCliente(id As Integer) As Task(Of ActionResult(Of Cliente))
            Try
                Dim cliente = Await _clienteService.GetByIdAsync(id)
                Return Ok(cliente)
            Catch ex As KeyNotFoundException
                Return NotFound(New With {.message = ex.Message})
            End Try
        End Function

        <HttpPost>
        Public Async Function CreateCliente(<FromBody> cliente As Cliente) As Task(Of ActionResult(Of Cliente))
            Try
                Dim createdCliente = Await _clienteService.CreateAsync(cliente)
                Return CreatedAtAction(NameOf(GetCliente), New With {.id = createdCliente.Id}, createdCliente)
            Catch ex As ArgumentException
                Return BadRequest(New With {.message = ex.Message})
            End Try
        End Function

        <HttpPut("{id:int}")>
        Public Async Function UpdateCliente(id As Integer, <FromBody> cliente As Cliente) As Task(Of ActionResult)
            Try
                Await _clienteService.UpdateAsync(id, cliente)
                Return NoContent()
            Catch ex As KeyNotFoundException
                Return NotFound(New With {.message = ex.Message})
            Catch ex As ArgumentException
                Return BadRequest(New With {.message = ex.Message})
            End Try
        End Function

        <HttpDelete("{id:int}")>
        Public Async Function DeleteCliente(id As Integer) As Task(Of ActionResult)
            Try
                Await _clienteService.DeleteAsync(id)
                Return NoContent()
            Catch ex As KeyNotFoundException
                Return NotFound(New With {.message = ex.Message})
            End Try
        End Function
    End Class
End Namespace
