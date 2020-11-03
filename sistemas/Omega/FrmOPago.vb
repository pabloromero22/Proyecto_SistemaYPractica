Imports System.Data.OleDb
Public Class FrmOPago

    Dim Id_Proveedor As Integer
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub FrmOPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click









        Dim IDOrdenPago As String = "Select max(Id_Orden_Pago) from Orden_Pago"
        MessageBox.Show(IDOrdenPago)
        'If CDbl(IDOrdenPago) = 0 Then
        'IDOrdenPago = IDOrdenPago + 1
        ' Else

        conex.Open()
        Dim comna8 As New OleDbCommand(IDOrdenPago, conex)
        Dim Nro_Orden_Pago As Object = comna8.ExecuteScalar
        conex.Close()
        MessageBox.Show(Nro_Orden_Pago)





        'If cantcolum = 0 Then
        Nro_Orden_Pago = Nro_Orden_Pago + 1
        TxtOPago.Text = Nro_Orden_Pago  ' el nro de informe me muestra en el txt


        Dim Orden_Pago As String = "Insert Into Orden_Pago (Id_Orden_Pago,Fecha_Emision,Id_Factura,Nom_Proveedor,Condicion_Pago,Banco,Nro_Cuenta,Nro_Cheque,Concepto,Importe_Total,Estado) values ('" & Nro_Orden_Pago & "','" & TxtFecha_Emision.Text & "','" & CmbNFactura.Text & "','" & CmbProveedor.Text & "','" & CmbCondPago.Text & "','" & CmBanco.Text & "','" & TxtNCuenta.Text & "','" & TxtNCheque.Text & "','" & TxtConcepto.Text & "','" & TxtImporte.Text & "','" & CmbEstado.Text & "')"
        MessageBox.Show(Orden_Pago)
        Dim comando2 As New OleDbCommand(Orden_Pago, conex)
        Try
            conex.Open()
            comando2.ExecuteNonQuery()

            'Se agrega la notificación desde la clase notificacion
            Dim Noti As New Notificaciones
            Noti.Registroagregado()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        conex.Close()

        '  End If

    End Sub

    Private Sub CmbNFactura_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbNFactura.Enter
        Dim consulta2 As String = "SELECT Id_Factura FROM Factura_Compra"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbNFactura.ValueMember = "Id_Factura"
        CmbNFactura.DisplayMember = "Id_Factura"
        CmbNFactura.DataSource = dt2
    End Sub

    Private Sub CmbNFactura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbNFactura.SelectedIndexChanged

    End Sub

    Private Sub CmBanco_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmBanco.Enter
        Dim consulta2 As String = "SELECT Descripcion FROM Banco"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmBanco.ValueMember = "Descripcion"
        CmBanco.DisplayMember = "Descripcion"
        CmBanco.DataSource = dt2
    End Sub

    Private Sub CmBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmBanco.SelectedIndexChanged

    End Sub

    Private Sub CmbEstado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEstado.Enter
        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta4 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        Dim da4 As New OleDb.OleDbDataAdapter(consulta4, conex)
        Dim dt4 As New DataTable()
        da4.Fill(dt4)
        CmbEstado.ValueMember = "Id_Estado"
        CmbEstado.DisplayMember = "Descripcion"
        CmbEstado.DataSource = dt4
    End Sub

    Private Sub CmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEstado.SelectedIndexChanged

    End Sub

    Private Sub CmbCondPago_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCondPago.Enter
        Dim consulta3 As String = "SELECT Id_Condicion_Pago,Descripcion FROM Condicion_Pago"
        Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        Dim dt3 As New DataTable()
        da3.Fill(dt3)
        CmbCondPago.ValueMember = "Id_Condicion_Pago"
        CmbCondPago.DisplayMember = "Descripcion"
        CmbCondPago.DataSource = dt3
    End Sub

    Private Sub CmbCondPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCondPago.SelectedIndexChanged

    End Sub

    Private Sub BtnTraer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTraer.Click

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString

        TxtFecha_Emision.Text = fechactual.ToString("dd/MM/yyyy")



        'Se Busca el registro del orden por el valor del id_factura_Compra para saber el Id:Proveedor y guardarlo en una variable
        Dim text5 As String = CInt(CmbNFactura.Text)
        MessageBox.Show(text5)
        Dim IdProveedor As String = "Select Id_Proveedor from Factura_Compra Where Id_Factura  = " & text5 & ""
        MessageBox.Show(IdProveedor)
        conex.Open()
        Dim comna5 As New OleDbCommand(IdProveedor, conex)
        Dim reader5 As OleDbDataReader = comna5.ExecuteReader(CommandBehavior.CloseConnection)
        reader5.Read()
        Dim Id_Proveedor As String = Convert.ToString(reader5.Item("Id_Proveedor"))
        conex.Close()
        MessageBox.Show(Id_Proveedor)



        'Se Busca el registro del orden por el valor del id_factura_Compra para saber el Id:Proveedor y guardarlo en una variable
        Dim text4 As String = Id_Proveedor
        MessageBox.Show(text4)
        Dim NomProveedor As String = "Select Nom_Proveedor from Proveedores Where Id_Proveedor  = " & text4 & ""
        MessageBox.Show(NomProveedor)
        conex.Open()
        Dim comna4 As New OleDbCommand(NomProveedor, conex)
        Dim reader4 As OleDbDataReader = comna4.ExecuteReader(CommandBehavior.CloseConnection)
        reader4.Read()
        Dim Nom_Proveedor As String = Convert.ToString(reader4.Item("Nom_Proveedor"))
        conex.Close()
        MessageBox.Show(Nom_Proveedor)

        CmbProveedor.Text = Nom_Proveedor  'me llena en el combobox






        'Se Busca el registro del orden por el valor del id_factura_Compra para saber el Id:Proveedor y guardarlo en una variable
        Dim text3 As String = CInt(CmbNFactura.Text)
        MessageBox.Show(text3)
        Dim Importetotal As String = "Select Importe_Total from Detalle_Factura_Compra Where Id_Factura  = " & text3 & ""
        MessageBox.Show(Importetotal)
        conex.Open()
        Dim comna3 As New OleDbCommand(Importetotal, conex)
        Dim reader3 As OleDbDataReader = comna3.ExecuteReader(CommandBehavior.CloseConnection)
        reader3.Read()
        Dim Importe_Total As String = Convert.ToString(reader3.Item("Importe_Total"))
        conex.Close()
        MessageBox.Show(Importe_Total)

        TxtImporte.Text = Importe_Total



        'Se Busca el registro del orden por el valor del id_factura_Compra para saber el Id:Proveedor y guardarlo en una variable
        Dim text2 As String = CInt(CmbNFactura.Text)
        MessageBox.Show(text2)
        Dim Estad As String = "Select Estado from Factura_Compra Where Id_Factura  = " & text2 & ""
        MessageBox.Show(Estad)
        conex.Open()
        Dim comna2 As New OleDbCommand(Estad, conex)
        Dim reader2 As OleDbDataReader = comna2.ExecuteReader(CommandBehavior.CloseConnection)
        reader2.Read()
        Dim Estado As String = Convert.ToString(reader2.Item("Estado"))
        conex.Close()
        MessageBox.Show(Estado)

        CmbEstado.Text = Estado




    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        FormBuscarOrdePago.Show()
        Me.Hide()
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        TxtOPago.Clear()
        TxtConcepto.Clear()
        TxtFecha_Emision.Clear()
        TxtImporte.Clear()
        TxtNCheque.Clear()
        TxtNCuenta.Clear()
        CmBanco.ResetText()
        CmbCondPago.ResetText()
        CmbProveedor.ResetText()
        CmbEstado.ResetText()
        CmbNFactura.ResetText()


    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub
End Class