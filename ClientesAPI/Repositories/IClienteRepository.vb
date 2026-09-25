Imports ClientesAPI.Models

Namespace Repositories
    Public Interface IClienteRepository
        Function GetAllAsync() As Task(Of List(Of Cliente))
        Function GetByIdAsync(id As Integer) As Task(Of Cliente)
        Function AddAsync(cliente As Cliente) As Task(Of Cliente)
        Function UpdateAsync(cliente As Cliente) As Task
        Function DeleteAsync(id As Integer) As Task
    End Interface
End Namespace
