
Imports System.Data.OleDb
Public Class FrmCheque
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub FrmCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CmbNOrdenPago_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbNOrdenPago.Enter
        Dim consulta2 As String = "SELECT Id_Orden_Pago FROM Orden_Pago"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbNOrdenPago.ValueMember = "Id_Orden_Pago"
        CmbNOrdenPago.DisplayMember = "Id_Orden_Pago"
        CmbNOrdenPago.DataSource = dt2
    End Sub

    Private Sub CmbNOrdenPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbNOrdenPago.SelectedIndexChanged

    End Sub

    Private Sub CmbBanco_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBanco.Enter
        Dim consulta2 As String = "SELECT Descripcion FROM Banco"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbBanco.ValueMember = "Descripcion"
        CmbBanco.DisplayMember = "Descripcion"
        CmbBanco.DataSource = dt2
    End Sub

    Private Sub CmbBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBanco.SelectedIndexChanged

    End Sub

    Private Sub BtnTraer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTraer.Click

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString

        TxtFchEmision.Text = fechactual.ToString("dd/MM/yyyy")




        'Se Busca el registro del orden por el valor del id_Orden Pago para saber el banco y guardarlo en una variable
        Dim text1 As String = CInt(CmbNOrdenPago.Text)
        MessageBox.Show(text1)
        Dim banc As String = "Select Banco from Orden_Pago Where Id_Orden_Pago  = " & text1 & ""
        MessageBox.Show(banc)
        conex.Open()
        Dim comna1 As New OleDbCommand(banc, conex)
        Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
        reader1.Read()
        Dim Banco As String = Convert.ToString(reader1.Item("Banco"))
        conex.Close()
        MessageBox.Show(Banco)

        CmbBanco.Text = Banco


        'Se Busca el registro del orden por el valor del id_Orden Pago para saber el banco y guardarlo en una variable
        Dim text2 As String = CInt(CmbNOrdenPago.Text)
        MessageBox.Show(text2)
        Dim NroCuenta As String = "Select Nro_Cuenta from Orden_Pago Where Id_Orden_Pago  = " & text2 & ""
        MessageBox.Show(NroCuenta)
        conex.Open()
        Dim comna2 As New OleDbCommand(NroCuenta, conex)
        Dim reader2 As OleDbDataReader = comna2.ExecuteReader(CommandBehavior.CloseConnection)
        reader2.Read()
        Dim Nro_Cuenta As String = Convert.ToString(reader2.Item("Nro_Cuenta"))
        conex.Close()
        MessageBox.Show(Nro_Cuenta)

        txtNCuenta.Text = Nro_Cuenta



        'Se Busca el registro del orden por el valor del id_factura_Compra para saber el Id:Proveedor y guardarlo en una variable
        Dim text3 As String = CInt(CmbNOrdenPago.Text)
        MessageBox.Show(text3)
        Dim Importetotal As String = "Select Importe_Total from Orden_Pago Where Id_Orden_Pago  = " & text3 & ""
        MessageBox.Show(Importetotal)
        conex.Open()
        Dim comna3 As New OleDbCommand(Importetotal, conex)
        Dim reader3 As OleDbDataReader = comna3.ExecuteReader(CommandBehavior.CloseConnection)
        reader3.Read()
        Dim Importe_Total As String = Convert.ToString(reader3.Item("Importe_Total"))
        conex.Close()
        MessageBox.Show(Importe_Total)

        TxtImporte.Text = Importe_Total



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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Movimiento As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy



        'Se Busca el registro del orden por el valor del id_factura_Compra para saber el Id:Proveedor y guardarlo en una variable
        Dim text4 As String = CInt(CmbNOrdenPago.Text)
        MessageBox.Show(text4)
        Dim NomProveedor As String = "Select Nom_Proveedor from Orden_Pago Where Id_Orden_Pago  = " & text4 & ""
        MessageBox.Show(NomProveedor)
        conex.Open()
        Dim comna4 As New OleDbCommand(NomProveedor, conex)
        Dim reader4 As OleDbDataReader = comna4.ExecuteReader(CommandBehavior.CloseConnection)
        reader4.Read()
        Dim Nom_Proveedor As String = Convert.ToString(reader4.Item("Nom_Proveedor"))
        conex.Close()
        MessageBox.Show(Nom_Proveedor)






        Dim IDCheque As String = "Select max(Id_Cheque) from Cheque"
        MessageBox.Show(IDCheque)
        'If CDbl(IDOrdenPago) = 0 Then
        'IDOrdenPago = IDOrdenPago + 1
        ' Else

        conex.Open()
        Dim comna8 As New OleDbCommand(IDCheque, conex)
        Dim Nro_Cheque As Object = comna8.ExecuteScalar
        conex.Close()
        MessageBox.Show(Nro_Cheque)





        'If cantcolum = 0 Then
        Nro_Cheque = Nro_Cheque + 1
        TxtNCheque.Text = Nro_Cheque  ' el nro de informe me muestra en el txt


        Dim Cheque As String = "Insert Into Cheque (Id_Cheque,Fecha_Emision,Fecha_Movimiento,Id_Orden_Pago,Nom_Proveedor,Banco,Cantidad,Nro_Cuenta,Nro_Cheque_Desde,Nro_Cheque_Hasta,Importe_Total,Estado) values ('" & Nro_Cheque & "','" & TxtFchEmision.Text & "','" & Fecha_Movimiento & "','" & CmbNOrdenPago.Text & "','" & Nom_Proveedor & "','" & CmbBanco.Text & "','" & TxtCantidad.Text & "','" & txtNCuenta.Text & "','" & TxtChequeD.Text & "','" & TxtChequeH.Text & "','" & TxtImporte.Text & "','" & CmbEstado.Text & "')"
        MessageBox.Show(Cheque)
        Dim comando2 As New OleDbCommand(Cheque, conex)
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


        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Cheque "

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Cheque")

        'se carga el datagridview con el data set
        DgvCheques.DataSource = ds.Tables("Cheque")
        conex.Close()




    End Sub

    Private Sub TxtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtImporte.TextChanged

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        TxtNCheque.Clear()
        txtNCuenta.Clear()
        TxtCantidad.Clear()
        TxtChequeD.Clear()
        TxtChequeH.Clear()
        TxtFchEmision.Clear()
        TxtImporte.Clear()
        CmbBanco.ResetText()
        CmbNOrdenPago.ResetText()
        TxtNCheque.Focus()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim consultar As String
        ' Dim Consultar1 As String

        Dim lista As Byte
        Dim adaptador1 As New OleDbDataAdapter
        Dim registros1 As New DataSet
        If TxtNCheque.Text <> "" Then
            Dim resultado As String = CInt(TxtNCheque.Text)
            consultar = " select * from Cheque where Id_Cheque= " & resultado & " "
            MessageBox.Show(consultar)
            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Cheque")
            lista = registros1.Tables("Cheque").Rows.Count
            If lista <> 0 Then
                DgvCheques.DataSource = registros1
                DgvCheques.DataMember = "Cheque"


            Else
                MessageBox.Show("No hay registro")
                TxtNCheque.Clear()
                TxtNCheque.Focus()




            End If
        End If
    End Sub
End Class