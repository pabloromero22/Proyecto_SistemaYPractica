Imports System.Data.OleDb
Public Class FormBuscarOrdePago
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim consultar As String
        ' Dim Consultar1 As String

        Dim lista As Byte
        Dim adaptador1 As New OleDbDataAdapter
        Dim registros1 As New DataSet
        If TxtNOrdenPago.Text <> "" Then
            Dim resultado As String = CInt(TxtNOrdenPago.Text)
            consultar = " select * from Orden_Pago where Id_Orden_Pago= " & resultado & " "
            MessageBox.Show(consultar)
            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Orden_Pago")
            lista = registros1.Tables("Orden_Pago").Rows.Count
            If lista <> 0 Then
                DgvOrdenPago.DataSource = registros1
                DgvOrdenPago.DataMember = "Orden_Pago"


            Else
                MessageBox.Show("No hay registro")
                TxtNOrdenPago.Clear()
                TxtNOrdenPago.Focus()




            End If
        End If
    End Sub

    Private Sub FormBuscarOrdePago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Orden_Pago"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Orden_Pago")

        'se carga el datagridview con el data set
        DgvOrdenPago.DataSource = ds.Tables("Orden_Pago")
        conex.Close()


    End Sub

    Private Sub BtnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtras.Click
        conex.Close()
        Me.Hide()
        FrmOPago.Show()
    End Sub
End Class