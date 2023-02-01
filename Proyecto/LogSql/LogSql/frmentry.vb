Imports System.Data.SqlClient
Public Class frmentry
    Dim con As New SqlConnection(My.Settings.conexion)
    Dim mensaje, sentencia As String

    Sub ejecutarSql(ByVal sql As String, ByVal msg As String)
        Try
            Dim cmd As New SqlCommand(sql, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox(msg)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sentencia = "insert into registros values('" + txt_cod.Text + "','" + txt_name.Text + "','" + txt_contraseña.Text + "')"
        mensaje = "Datos insertados correctamente"
        ejecutarSql(sentencia, mensaje)
        Try
            Dim da As New SqlDataAdapter("Select *from registros", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim da As New SqlDataAdapter("select *from registros", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sentencia = "update registros set nombre = '" + txt_cod.Text + "','" + txt_name.Text + "','" + txt_contraseña.Text + "'"
        mensaje = "Datos actualizados correctamente"
        ejecutarSql(sentencia, mensaje)
        Try
            Dim da As New SqlDataAdapter("Select *from registros", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        sentencia = "Delete registros where id = '" + txt_cod.Text + "'"
        mensaje = "Datos eliminados correctamente"
        ejecutarSql(sentencia, mensaje)
        Try
            Dim da As New SqlDataAdapter("Select *from registros", con)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmentry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class