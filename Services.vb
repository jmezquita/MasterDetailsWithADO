Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Autofac
Imports Autofac.Core
Module Services

    '  Private _Services As IServiceCollection
    ' Private _Provider As IServiceProvider

    'Public Property Services() As IServiceCollection
    '    Get
    '        Return _Services
    '    End Get
    '    Set(value As IServiceCollection)
    '        _Services = value
    '    End Set

    'End Property

    Private _container As Container
    Private _Services As New ContainerBuilder

    Public ReadOnly Property Services() As ContainerBuilder
        Get
            Return If(_Services, New ContainerBuilder())
        End Get


    End Property


#Region "IServiceCollection"
    Public Sub ConfigureDefaultServices()
        Services.RegisterType(Of Cnn).As(Of ICnn)()
        Services.RegisterType(Of Data).As(Of IData)()
        _container = Services.Build()
    End Sub


    ''' <summary>
    ''' Indica si el Site contiene un determinado servicio
    ''' </summary>
    ''' <typeparam name="T">Servicio</typeparam>
    ''' <returns>true is contain service or false if not contain</returns>
    Public Function Contains(Of T)() As Boolean
        Return _container?.IsRegistered(Of T)
        'Return Not Services.Any(Function(x) x.ServiceType = GetType(T))
    End Function

    ''' <summary>
    ''' contains service count 
    ''' </summary>
    ''' <returns>service count </returns>
    Public Function Count() As Integer
        ' Return Services.Build().i
    End Function
#End Region


    ''' <summary>
    ''' Add the service to the collection
    ''' </summary>
    ''' <typeparam name="T">Service</typeparam>
    ''' <param name="serviceInstance">Service implementation</param>
    ''' <returns></returns>
    'Public Function Add(Of T As Class)(ByVal serviceInstance As Object) As T
    '    If Not Contains(Of T)() Then


    '        _Services.RegisterType(Of T).As(Of serviceInstance)()

    '        Services.AddSingleton(GetType(T), serviceInstance)
    '    End If

    '    Return [Get](Of T)()
    'End Function



    ''' <summary>
    ''' Add the service to the collection
    ''' </summary>
    ''' <typeparam name="T">Service</typeparam>
    ''' <param name="serviceInstance">Service implementation</param>
    ''' <returns></returns>
    Public Function Add(Of T As Class, serviceInstance)() As T
        If Not Contains(Of T)() Then
            Services.RegisterType(Of T).As(Of serviceInstance)()
            _container = Services.Build()

        End If

        Return [Get](Of T)()
    End Function


    Public Function [Get](Of T As Class)() As T

        If Not Contains(Of T)() Then
            Return Nothing
        Else
            Return _container.Resolve(Of T)()
        End If

    End Function

End Module
