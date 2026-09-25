Imports ClientesAPI.Models

Namespace Services
    Public Interface IClienteService
        Function GetAllAsync() As Task(Of List(Of Cliente))
        Function GetByIdAsync(id As Integer) As Task(Of Cliente)
        Function CreateAsync(cliente As Cliente) As Task(Of Cliente)
        Function UpdateAsync(id As Integer, cliente As Cliente) As Task
        Function DeleteAsync(id As Integer) As Task
    End Interface
End Namespace
