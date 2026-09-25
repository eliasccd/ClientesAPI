Imports ClientesAPI.Models
Imports ClientesAPI.Repositories

Namespace Services
    Public Class ClienteService
        Implements IClienteService

        Private ReadOnly _repository As IClienteRepository

        Public Sub New(repository As IClienteRepository)
            _repository = repository
        End Sub

        Public Async Function GetAllAsync() As Task(Of List(Of Cliente)) Implements IClienteService.GetAllAsync
            Return Await _repository.GetAllAsync()
        End Function

        Public Async Function GetByIdAsync(id As Integer) As Task(Of Cliente) Implements IClienteService.GetByIdAsync
            Dim cliente = Await _repository.GetByIdAsync(id)
            If cliente Is Nothing Then
                Throw New KeyNotFoundException($"No existe el cliente con Id {id}.")
            End If
            Return cliente
        End Function

        Public Async Function CreateAsync(cliente As Cliente) As Task(Of Cliente) Implements IClienteService.CreateAsync
            If String.IsNullOrWhiteSpace(cliente.Nombre) Then
                Throw New ArgumentException("El campo Nombre es obligatorio.")
            End If

            If String.IsNullOrWhiteSpace(cliente.Apellido) Then
                Throw New ArgumentException("El campo Apellido es obligatorio.")
            End If

            If String.IsNullOrWhiteSpace(cliente.Email) Then
                Throw New ArgumentException("El campo Email es obligatorio.")
            End If

            Return Await _repository.AddAsync(cliente)
        End Function

        Public Async Function UpdateAsync(id As Integer, cliente As Cliente) As Task Implements IClienteService.UpdateAsync
            Dim existingCliente = Await _repository.GetByIdAsync(id)
            If existingCliente Is Nothing Then
                Throw New KeyNotFoundException($"No existe el cliente con Id {id}.")
            End If

            cliente.Id = id
            Await _repository.UpdateAsync(cliente)
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task Implements IClienteService.DeleteAsync
            Dim existingCliente = Await _repository.GetByIdAsync(id)
            If existingCliente Is Nothing Then
                Throw New KeyNotFoundException($"No existe el cliente con Id {id}.")
            End If

            Await _repository.DeleteAsync(id)
        End Function
    End Class
End Namespace
