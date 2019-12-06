﻿Imports CapaDatos
Imports CapaEntidad
Public Class negProfesor
    Dim objentProfesor As New entProfesor
    Dim objdatProfesor As New datProfesor

    Public Function registrarProfesor(objentProfesor) As Boolean
        Return objdatProfesor.registrarProfesor(objentProfesor)
    End Function

    Public Function actualizarProfesor(objentProfesor) As Boolean
        Return objdatProfesor.actualizarProfesor(objentProfesor)
    End Function

    Public Function eliminarProfesor(objentProfesor) As Boolean
        Return objdatProfesor.eliminarProfesor(objentProfesor)
    End Function

    Public Function buscarProfesor(objentProfesor) As DataTable
        Return objdatProfesor.buscarProfesor(objentProfesor)
    End Function

    Public Function obtenerTabla() As DataTable
        Dim dat As New datProfesor
        Return dat.obtenerTabla()
    End Function
    Public Function ListarProfesor() As DataTable
        Dim dat As New datProfesor
        Return dat.ProfesoresLibres()
    End Function
    Public Function ObtenerReporteProfesor() As DataTable
        Dim dat As New datProfesor
        Return dat.ObtenerReporteProfesor()
    End Function
End Class
