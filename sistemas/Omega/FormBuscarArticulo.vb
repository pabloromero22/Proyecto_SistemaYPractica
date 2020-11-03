Imports System.Data.OleDb
Public Class FormBuscarArticulo
    Dim adaptador1 As New OleDbDataAdapter
    Dim registros1 As New DataSet
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Public Sub cargarbd1()
        'Se utiliza para refrescar y cargar la tabla en el datagridview

        'Dim conex1 As New OleDb.OleDbConnection(" Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ever\Documents\Vb1\Trabajo_Integral_Prototipo\Trabajo_Integral_Prototipo\Gestion_Comercial.accdb")
        'se establece la coneccion y se crea la consulta
        Dim consulta1 As String = "SELECT * FROM Articulo_Stock"

        'se crea el comando que ejecutará la consulta sobre la bd
        ' Dim comando As New OleDbCommand(consulta, coneccion)

        Dim adaptador1 As New OleDb.OleDbDataAdapter(consulta1, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds1 As New DataSet

        'se carga el data set con el adaptador
        adaptador1.Fill(ds1, "Articulo_Stock")

        'se carga el datagridview con el data set
        DgvArt_Stock.DataSource = ds1.Tables("Articulo_Stock")
        conex.Close()
    End Sub
    Private Sub FormBuscarArticulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbd1()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        ' se busca el registro realizando la consulta comparando con textbuscar
        Dim consultar As String
        Dim lista As Byte
        If TxtBuscar.Text <> "" Then
            Dim resultado As String = CInt(TxtBuscar.Text)
            consultar = " select * from Articulo_Stock where Id_Articulo= " & resultado & " "
            MessageBox.Show(consultar)
            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Articulo_Stock")
            lista = registros1.Tables("Articulo_Stock").Rows.Count
            If lista <> 0 Then
                DgvArt_Stock.DataSource = registros1
                DgvArt_Stock.DataMember = "Articulo_Stock"
            Else
                MessageBox.Show("No hay registro")
                TxtBuscar.Clear()
                TxtBuscar.Focus()
            End If

        End If
    End Sub

    Private Sub BtnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtras.Click
        conex.Close()
        Me.Hide()
        FrmABMStock.Show()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class