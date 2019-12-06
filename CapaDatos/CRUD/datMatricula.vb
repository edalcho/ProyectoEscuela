﻿Imports System.Data.SqlClient
Imports CapaEntidad
Public Class datMatricula
    Inherits datConexion
    Public Function registrarMatricula(objMatricula As entMatricula) As Boolean
        Using conexion = ObtenerConexion()
            conexion.Open()
            Using Command = New SqlCommand()
                Command.Connection = conexion
                Command.CommandText = "registrarMatricula"
                Command.Parameters.AddWithValue("@fechaMatricula", objMatricula._fechaMatricula)
                Command.Parameters.AddWithValue("@codigoGrado", objMatricula.objentgrado._codigoGrado)
                Command.Parameters.AddWithValue("@dniAlumno", objMatricula.objentAlumno._dniAlumno)
                Command.Parameters.AddWithValue("@numeroAnno", objMatricula.objentAnnoEscolar._numeroAnno)
                Command.Parameters.AddWithValue("@codigoSeccion", objMatricula.objentSeccion._codigoSeccion)
                Command.Parameters.AddWithValue("@nivelAlumno", objMatricula._nivelAlumno)
                Command.Parameters.AddWithValue("@eliminacionLogica", objMatricula._eliminacionLogica)
                Command.CommandType = CommandType.StoredProcedure
                If Command.ExecuteNonQuery Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
        Return False
    End Function
    
    Public Function VerificarSiExisteAlumno(dni As String) As Integer
        Using conexion = ObtenerConexion()
            conexion.Open()
            Dim dt As DataTable
            Dim da As SqlDataAdapter
            Using Command = New SqlCommand()
                Command.Connection = conexion
                Command.CommandType = CommandType.StoredProcedure
                Command.CommandText = "VerificarSiExisteAlumno"
                Command.Parameters.AddWithValue("@dni", dni)
                If Command.ExecuteNonQuery Then
                    dt = New DataTable
                    da = New SqlDataAdapter(Command)
                    da.Fill(dt)
                    If dt.Rows.Count = 0 Then
                        Return 0
                    Else
                        Return 1
                    End If
                Else
                    Return Nothing
                End If
            End Using
        End Using
    End Function
   
    Public Function obtenerTabla() As DataTable
        Using conexion = ObtenerConexion()
            conexion.Open()
            Dim dt As DataTable
            Dim da As SqlDataAdapter
            Using Command = New SqlCommand()
                Command.Connection = conexion
                Command.CommandType = CommandType.Text
                Command.CommandText = "obtenerTablaMatricula"
                If Command.ExecuteNonQuery Then
                    dt = New DataTable
                    da = New SqlDataAdapter(Command)
                    da.Fill(dt)
                    Return dt
                Else
                    Return Nothing
                End If
            End Using
        End Using
    End Function
End Class
