Imports System.Data.OleDb
Public Class FrmAdmProveedor

    Dim adaptador1 As New OleDbDataAdapter
    Dim registros1 As New DataSet
    Dim conex As New OleDbConnection(My.Settings.Nombre) 'conexion base de datos
    Private Sub FrmAdmProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Proveedores;"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Proveedores")

        'se carga el datagridview con el data set
        DGVProveedor.DataSource = ds.Tables("Proveedores")
        conex.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' se busca el registro realizando la consulta comparando con textbuscar
        Dim consultar As String
        Dim lista As Byte
        If TxtBuscar.Text <> "" Then
            Dim resultado As String = CInt(TxtBuscar.Text)
            consultar = " select * from Proveedores where Id_Proveedor= " & resultado & " "
            MessageBox.Show(consultar)
            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Proveedores")
            lista = registros1.Tables("Proveedores").Rows.Count
            If lista <> 0 Then
                DGVProveedor.DataSource = registros1
                DGVProveedor.DataMember = "Proveedores"
            Else
                MessageBox.Show("No hay registro")
                TxtBuscar.Clear()
                TxtBuscar.Focus()
            End If

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conex.Close()
        Me.Hide()
        FrmAMB_PROV.Show()
    End Sub
End Class