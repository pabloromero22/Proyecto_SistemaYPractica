Imports System.Data.OleDb
Public Class FrmNotaCredito
    Dim resultado As String
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub FrmNotaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbNFactura.SelectedIndexChanged
        ' Dim consulta2 As String = "SELECT Id_Factura FROM Factura_Compra"
        ' Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        ' Dim dt2 As New DataTable()
        ' da2.Fill(dt2)
        ' CmbNFactura.ValueMember = "Id_Factura"
        ' CmbNFactura.DisplayMember = "Id_Factura"
        '  CmbNFactura.DataSource = dt2

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido
        Dim cantcolum As Integer = DgvNotaCredito.RowCount

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString

        TxtFecha_Emision.Text = fechactual.ToString("dd/MM/yyyy")
        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Vto As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy






        'Se Busca el registro  por el valor del id_factura para saber el Id_Articulo y guardarlo en una variable
        Dim text1 As String = CInt(CmbNFactura.Text)

        Dim cdArticulo As String = "Select id_Articulo from Factura_Compra Where Id_Factura  = " & text1 & ""

        conex.Open()
        Dim comna1 As New OleDbCommand(cdArticulo, conex)
        Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
        reader1.Read()
        Dim Id_Articulo As String = Convert.ToString(reader1.Item("id_Articulo"))
        conex.Close()




        'Se Busca el registro del Orden Compra por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
        Dim text2 As String = CInt(CmbNFactura.Text)

        Dim Descrip As String = "Select Descripcion from Factura_Compra Where Id_factura  = " & text2 & ""

        conex.Open()
        Dim comna2 As New OleDbCommand(Descrip, conex)
        Dim reader2 As OleDbDataReader = comna2.ExecuteReader(CommandBehavior.CloseConnection)
        reader2.Read()
        Dim Descripcion As String = Convert.ToString(reader2.Item("Descripcion"))
        conex.Close()




        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text5 As String = CInt(CmbNFactura.Text)

        Dim IdProveedor As String = "Select Id_Proveedor from Factura_Compra Where Id_Factura  = " & text5 & ""

        conex.Open()
        Dim comna5 As New OleDbCommand(IdProveedor, conex)
        Dim reader5 As OleDbDataReader = comna5.ExecuteReader(CommandBehavior.CloseConnection)
        reader5.Read()
        Dim Id_Proveedor As String = Convert.ToString(reader5.Item("Id_Proveedor"))
        conex.Close()





        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber la cantidad y guardarlo en una variable
        Dim text6 As String = CInt(CmbNFactura.Text)

        Dim Cant As String = "Select Cantidad from Factura_Compra Where Id_Factura  = " & text6 & ""

        conex.Open()
        Dim comna6 As New OleDbCommand(Cant, conex)
        Dim reader6 As OleDbDataReader = comna6.ExecuteReader(CommandBehavior.CloseConnection)
        reader6.Read()
        Dim Cantidad As String = Convert.ToString(reader6.Item("Cantidad"))
        conex.Close()




        ' Se Busca el registro del Pedido por el valor del id_FacturA para saber el Precio unitario y guardarlo en una variable
        Dim text3 As String = CInt(CmbNFactura.Text)

        Dim Precio_U As String = "Select Precio_Unitario from Factura_Compra Where Id_factura  = " & text3 & ""

        conex.Open()
        Dim comna3 As New OleDbCommand(Precio_U, conex)
        Dim reader3 As OleDbDataReader = comna3.ExecuteReader(CommandBehavior.CloseConnection)
        reader3.Read()
        Dim Precio_Unitario As String = Convert.ToString(reader3.Item("Precio_Unitario"))
        conex.Close()




        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text4 As String = CInt(CmbNFactura.Text)

        Dim Importe_T As String = "Select Precio_Total from Factura_Compra Where Id_factura  = " & text4 & ""

        conex.Open()
        Dim comna4 As New OleDbCommand(Importe_T, conex)
        Dim reader4 As OleDbDataReader = comna4.ExecuteReader(CommandBehavior.CloseConnection)
        reader4.Read()
        Dim Importe_Total As String = Convert.ToString(reader4.Item("Precio_Total"))
        conex.Close()








        Dim IDNotaCredito As String = "Select max(Id_Nota_Credito) from Nota_Credito"

        conex.Open()
        Dim comna8 As New OleDbCommand(IDNotaCredito, conex)
        Dim Nro_Nota_Credito As Object = comna8.ExecuteScalar
        conex.Close()






        'If cantcolum = 0 Then
        Nro_Nota_Credito = Nro_Nota_Credito + 1
        TxtNCredito.Text = Nro_Nota_Credito  ' el nro de informe me muestra en el txt


        Dim Nota_Credito As String = "Insert Into Nota_Credito(Id_Nota_Credito,Fecha_Emision,Fecha_Vto,Id_Factura,Id_Proveedor,Condicion_Pago,Id_Articulo,Descripcion,Cantidad,Precio_Unitario,Importe_Total,Estado) values ('" & Nro_Nota_Credito & "','" & fechactual & "','" & Fecha_Vto & "','" & CmbNFactura.Text & "','" & Id_Proveedor & "','" & CmbCondPago.Text & "','" & Id_Articulo & "', '" & Descripcion & "','" & Cantidad & "','" & Precio_Unitario & "','" & Importe_Total & "','" & CmbEstado.Text & "')"

        Dim comando2 As New OleDbCommand(Nota_Credito, conex)
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



        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Nota_Credito"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Nota_Credito")

        'se carga el datagridview con el data set
        DgvNotaCredito.DataSource = ds.Tables("Nota_Credito")
        conex.Close()



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
        'Dim consulta3 As String = "SELECT Id_Condicion_Pago,Descripcion FROM Condicion_Pago"
        'Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        'Dim dt3 As New DataTable()
        'da3.Fill(dt3)
        'CmbCondPago.ValueMember = "Id_Condicion_Pago"
        'CmbCondPago.DisplayMember = "Descripcion"
        'CmbCondPago.DataSource = dt3

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
        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        ' Dim consulta4 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        ' Dim da4 As New OleDb.OleDbDataAdapter(consulta4, conex)
        ' Dim dt4 As New DataTable()
        ' da4.Fill(dt4)
        ' CmbEstado.ValueMember = "Id_Estado"
        ' CmbEstado.DisplayMember = "Descripcion"
        ' CmbEstado.DataSource = dt4
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim consultar As String
        Dim lista As Byte
        Dim adaptador1 As New OleDbDataAdapter
        Dim registros1 As New DataSet
        If TxtNCredito.Text <> "" Then
            Dim resultado As String = CInt(TxtNCredito.Text)
            consultar = " select * from Nota_Credito where Id_Nota_Credito = " & resultado & " "

            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Nota_Credito")
            lista = registros1.Tables("Nota_Credito").Rows.Count


            If lista <> 0 Then

                Dim bs As New BindingSource
                DgvNotaCredito.DataSource = registros1
                DgvNotaCredito.DataMember = "Nota_Credito"

                ' bs.DataSource = registros1 ' Objeto DataSet
                '  bs.DataMember = "Nota_Credito" ' Nombre de un objeto DataTable
                '  TxtFecha_Emision.DataBindings.Add("Text", bs, "Fecha_Emision")
                'TextBox2.DataBindings.Add("Text", _bs, "Nombre")

            Else
                MessageBox.Show("No hay registro")
                TxtNCredito.Clear()
                TxtNCredito.Focus()

            End If
        End If

        
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        TxtNCredito.Clear()
        TxtFecha_Emision.Clear()
        CmbCondPago.ResetText()
        CmbEstado.ResetText()
        CmbNFactura.ResetText()
        DgvNotaCredito.DataSource = Nothing
    End Sub
End Class