Imports System.Data.OleDb
Public Class FrmbuscarClientes
    Dim conex As New OleDbConnection(My.Settings.Nombre) 'conexion base de datos
    Private Sub FrmbuscarClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta1 As String = "SELECT * FROM Clientes"

        'se crea el comando que ejecutará la consulta sobre la bd
        ' Dim comando As New OleDbCommand(consulta, coneccion)

        Dim adaptador1 As New OleDb.OleDbDataAdapter(consulta1, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds1 As New DataSet

        'se carga el data set con el adaptador
        adaptador1.Fill(ds1, "Clientes")

        'se carga el datagridview con el data set
        DgvClientes.DataSource = ds1.Tables("Clientes")
        conex.Close()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim consultar As String
        ' Dim Consultar1 As String

        Dim lista As Byte
        Dim adaptador1 As New OleDbDataAdapter
        Dim registros1 As New DataSet
        If TxtNCliente.Text <> "" Then
            Dim resultado As String = CInt(TxtNCliente.Text)
            consultar = " select * from Clientes where Id_Cliente = " & resultado & " "

            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Clientes")
            lista = registros1.Tables("Clientes").Rows.Count
            If lista <> 0 Then
                DgvClientes.DataSource = registros1
                DgvClientes.DataMember = "Clientes"


            Else
                MessageBox.Show("No hay registro")
                TxtNCliente.Clear()
                TxtNCliente.Focus()




            End If
        End If
    End Sub

    Private Sub BtnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtras.Click
        conex.Close()
        Me.Hide()
        FrmClientes.Show()
    End Sub
End Class