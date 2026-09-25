Imports ClientesAPI.Data
Imports ClientesAPI.Models
Imports Microsoft.EntityFrameworkCore

Namespace Repositories
    Public Class ClienteRepository
        Implements IClienteRepository

        Private ReadOnly _context As ApplicationDbContext

        Public Sub New(context As ApplicationDbContext)
            _context = context
        End Sub

        Public Async Function GetAllAsync() As Task(Of List(Of Cliente)) Implements IClienteRepository.GetAllAsync
            Return Await _context.Clientes.OrderBy(Function(c) c.Id).ToListAsync()
        End Function

        Public Async Function GetByIdAsync(id As Integer) As Task(Of Cliente) Implements IClienteRepository.GetByIdAsync
            Return Await _context.Clientes.FirstOrDefaultAsync(Function(c) c.Id = id)
        End Function

        Public Async Function AddAsync(cliente As Cliente) As Task(Of Cliente) Implements IClienteRepository.AddAsync
            _context.Clientes.Add(cliente)
            Await _context.SaveChangesAsync()
            Return cliente
        End Function

        Public Async Function UpdateAsync(cliente As Cliente) As Task Implements IClienteRepository.UpdateAsync
            Dim existingCliente = Await _context.Clientes.FirstOrDefaultAsync(Function(c) c.Id = cliente.Id)
            If existingCliente Is Nothing Then
                Throw New KeyNotFoundException($"No existe el cliente con Id {cliente.Id}.")
            End If

            _context.Entry(existingCliente).CurrentValues.SetValues(cliente)
            Await _context.SaveChangesAsync()
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task Implements IClienteRepository.DeleteAsync
            Dim cliente = Await _context.Clientes.FirstOrDefaultAsync(Function(c) c.Id = id)
            If cliente Is Nothing Then
                Throw New KeyNotFoundException($"No existe el cliente con Id {id}.")
            End If

            _context.Clientes.Remove(cliente)
            Await _context.SaveChangesAsync()
        End Function
    End Class
End Namespace
