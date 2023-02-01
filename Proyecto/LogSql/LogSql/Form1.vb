Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Form1
    Dim conex As New SqlConnection
    Dim com As New SqlCommand

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conex = New SqlConnection("server=PELADO;database=controladm; integrated security=true")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conex.Open()

        Dim consulta1 As String = "update loginvb set modo = modo where usuario =" & txt_usuario.Text & " and contraseña=" & txt_contra.Text & "' and modo =admins '"
        Dim consulta2 As String = "update loginvb set modo = modo where usuario =" & txt_usuario.Text & " and contraseña=" & txt_contra.Text & "' and modo = secretari@'"
        Dim consulta3 As String = "update loginvb set modo = modo where usuario =" & txt_usuario.Text & " and contraseña=" & txt_contra.Text & "' and modo = user '"

        com = New SqlCommand(consulta1, conex)
        Dim lectura1 As SqlDataReader
        lectura1 = com.ExecuteReader

        com = New SqlCommand(consulta2, conex)
        Dim lectura2 As SqlDataReader
        lectura2 = com.ExecuteReader

        com = New SqlCommand(consulta3, conex)
        Dim lectura3 As SqlDataReader
        lectura3 = com.ExecuteReader

        If lectura1.HasRows Then
            frmentry.ShowDialog()
        Else
            If lectura2.HasRows Then
                frmSec.ShowDialog()
            Else
                If lectura3.HasRows Then
                    frmUser.ShowDialog()
                Else
                    MessageBox.Show("Usuario no existente o datos erroneos")
                End If
            End If
        End If
        conex.Close()

    End Sub
End Class
