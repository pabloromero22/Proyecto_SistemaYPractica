Imports System.Data.OleDb


Public Class FrmFactura
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        TxtFactura.Clear()
        Txtfecha_Emitido.Clear()
        TxtProveedor.Clear()
        CmbOrdenC.ResetText()
        CmbCondPago.ResetText()
        DgvFactura.DataSource = Nothing

    End Sub

    Private Sub FrmFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim consulta2 As String = "SELECT Id_Orden_Compra FROM Orden_Compra_PR"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbOrdenC.ValueMember = "Id_Orden_Compra"
        CmbOrdenC.DisplayMember = "Id_Orden_Compra"
        CmbOrdenC.DataSource = dt2


        '  Dim consulta3 As String = "SELECT Id_Condicion_Pago,Descripcion FROM Condicion_Pago"
        ' Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        ' Dim dt3 As New DataTable()
        ' da3.Fill(dt3)
        ' CmbCondPago.ValueMember = "Id_Condicion_Pago"
        ' CmbCondPago.DisplayMember = "Descripcion"
        ' CmbCondPago.DataSource = dt3

        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta4 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        Dim da4 As New OleDb.OleDbDataAdapter(consulta4, conex)
        Dim dt4 As New DataTable()
        da4.Fill(dt4)
        CmbEstado.ValueMember = "Id_Estado"
        CmbEstado.DisplayMember = "Descripcion"
        CmbEstado.DataSource = dt4
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click


        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido
        Dim cantcolum As Integer = DgvFactura.RowCount

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString

        Txtfecha_Emitido.Text = fechactual.ToString("dd/MM/yyyy")
        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Vto As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy








        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text5 As String = CInt(CmbOrdenC.Text)
        MessageBox.Show(text5)
        Dim IdProveedor As String = "Select Id_Proveedor from Orden_Compra_PR Where Id_Orden_Compra  = " & text5 & ""
        MessageBox.Show(IdProveedor)
        conex.Open()
        Dim comna5 As New OleDbCommand(IdProveedor, conex)
        Dim reader5 As OleDbDataReader = comna5.ExecuteReader(CommandBehavior.CloseConnection)
        reader5.Read()
        Dim Id_Proveedor As String = Convert.ToString(reader5.Item("Id_Proveedor"))
        conex.Close()
        MessageBox.Show(Id_Proveedor)



        'Se Busca el registro del Orden Compra por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
        Dim text1 As String = CInt(CmbOrdenC.Text)
        MessageBox.Show(text1)
        Dim cdArticulo As String = "Select id_Articulo from Orden_Compra_PR Where Id_Orden_Compra  = " & text1 & ""
        MessageBox.Show(cdArticulo)
        conex.Open()
        Dim comna1 As New OleDbCommand(cdArticulo, conex)
        Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
        reader1.Read()
        Dim Id_Articulo As String = Convert.ToString(reader1.Item("id_Articulo"))
        conex.Close()
        MessageBox.Show(Id_Articulo)


        'Se Busca el registro del Orden Compra por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
        Dim texta As String = CInt(CmbOrdenC.Text)
        MessageBox.Show(texta)
        Dim Produc As String = "Select Descripcion from Orden_Compra_PR Where Id_Orden_Compra  = " & texta & ""
        MessageBox.Show(Produc)
        conex.Open()
        Dim comnaa As New OleDbCommand(Produc, conex)
        Dim readera As OleDbDataReader = comnaa.ExecuteReader(CommandBehavior.CloseConnection)
        readera.Read()
        Dim Producto As String = Convert.ToString(readera.Item("Descripcion"))
        conex.Close()
        MessageBox.Show(Producto)





        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber la cantidad y guardarlo en una variable
        Dim text2 As String = CInt(CmbOrdenC.Text)
        MessageBox.Show(text2)
        Dim Cant As String = "Select cantidad from Orden_Compra_PR Where Id_Orden_Compra  = " & text2 & ""
        MessageBox.Show(Cant)
        conex.Open()
        Dim comna2 As New OleDbCommand(Cant, conex)
        Dim reader2 As OleDbDataReader = comna2.ExecuteReader(CommandBehavior.CloseConnection)
        reader2.Read()
        Dim Cantidad As String = Convert.ToString(reader2.Item("Cantidad"))
        conex.Close()
        MessageBox.Show(Cantidad)


        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text3 As String = CInt(CmbOrdenC.Text)
        MessageBox.Show(text3)
        Dim Precio_U As String = "Select Precio_Unitario from Orden_Compra_PR Where Id_Orden_Compra  = " & text3 & ""
        MessageBox.Show(Precio_U)
        conex.Open()
        Dim comna3 As New OleDbCommand(Precio_U, conex)
        Dim reader3 As OleDbDataReader = comna3.ExecuteReader(CommandBehavior.CloseConnection)
        reader3.Read()
        Dim Precio_Unitario As String = Convert.ToString(reader3.Item("Precio_Unitario"))
        conex.Close()
        MessageBox.Show(Precio_Unitario)


        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text4 As String = CInt(CmbOrdenC.Text)
        MessageBox.Show(text4)
        Dim Precio_T As String = "Select Precio_Total from Orden_Compra_PR Where Id_Orden_Compra  = " & text4 & ""
        MessageBox.Show(Precio_T)
        conex.Open()
        Dim comna4 As New OleDbCommand(Precio_T, conex)
        Dim reader4 As OleDbDataReader = comna4.ExecuteReader(CommandBehavior.CloseConnection)
        reader4.Read()
        Dim Precio_Total As String = Convert.ToString(reader4.Item("Precio_Total"))
        conex.Close()
        MessageBox.Show(Precio_Total)

        Dim IVA As String = (1.21)
        Dim Importe_Total As Integer = CInt(Cantidad) * CInt(Precio_Unitario) * CInt(IVA)



        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text6 As String = CInt(CmbOrdenC.Text)
        MessageBox.Show(text6)
        Dim Condi_P As String = "Select Condicion_Pago from Orden_Compra_PR Where Id_Orden_Compra  = " & text6 & ""
        MessageBox.Show(Condi_P)
        conex.Open()
        Dim comna6 As New OleDbCommand(Condi_P, conex)
        Dim reader6 As OleDbDataReader = comna6.ExecuteReader(CommandBehavior.CloseConnection)
        reader6.Read()
        Dim Condicion_Pago As String = Convert.ToString(reader6.Item("Condicion_Pago"))
        conex.Close()
        MessageBox.Show(Condicion_Pago)

        CmbCondPago.Text = Condicion_Pago














        Dim IDFactura As String = "Select max(Id_Factura) from Factura_Compra"
        MessageBox.Show(IDFactura)
        conex.Open()
        Dim comna8 As New OleDbCommand(IDFactura, conex)
        Dim Nro_Factura As Object = comna8.ExecuteScalar
        conex.Close()
        MessageBox.Show(Nro_Factura)





        'If cantcolum = 0 Then
        Nro_Factura = Nro_Factura + 1
        'Txtfecha_Emitido.Text = Nro_Factura  ' el nro de informe me muestra en el txt


        Dim Factura As String = "Insert Into Factura_Compra(Id_Factura,Fecha_Emision,Fecha_Vto,Id_Orden_Compra,Id_Proveedor,Condicion_Pago,Id_Articulo,Cantidad,Precio_Unitario,Precio_Total,Estado) values ('" & Nro_Factura & "','" & fechactual & "','" & Fecha_Vto & "','" & CmbOrdenC.Text & "','" & Id_Proveedor & "','" & Condicion_Pago & "','" & Id_Articulo & "','" & Cantidad & "','" & Precio_Unitario & "','" & Precio_Total & "','" & CmbEstado.Text & "')"
        MessageBox.Show(Factura)
        Dim comando2 As New OleDbCommand(Factura, conex)
        Try
            conex.Open()
            comando2.ExecuteNonQuery()

            'Se agrega la notificación desde la clase notificacion
            '  Dim Noti As New Notificaciones
            ' Noti.Registroagregado()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        conex.Close()


        '________________________________________________________________________________



        ' me llenara los registro en la tabla Detalle_Factura_Compra


        Dim IDFactura_C As String = "Select max(Id_Factura) from Detalle_Factura_Compra"
        MessageBox.Show(IDFactura_C)
        conex.Open()
        Dim comna_8 As New OleDbCommand(IDFactura_C, conex)
        Dim Nro_Factura_C As Object = comna_8.ExecuteScalar
        conex.Close()
        MessageBox.Show(Nro_Factura_C)




        'If cantcolum = 0 Then
        Nro_Factura_C = Nro_Factura_C + 1
        TxtFactura.Text = Nro_Factura_C  ' el nro de informe me muestra en el txt


        Dim Detalle_Factura_Compra As String = "Insert Into Detalle_Factura_Compra(Id_Factura,Producto,Cantidad,Precio_Unitario,IVA,Importe_Total) values ('" & Nro_Factura_C & "','" & Producto & "','" & Cantidad & "','" & Precio_Unitario & "', '" & IVA & "','" & Importe_Total & "')"
        MessageBox.Show(Detalle_Factura_Compra)
        Dim comando_2 As New OleDbCommand(Detalle_Factura_Compra, conex)
        Try
            conex.Open()
            comando_2.ExecuteNonQuery()

            'Se agrega la notificación desde la clase notificacion
            Dim Noti As New Notificaciones
            Noti.Registroagregado()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        conex.Close()





        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Detalle_factura_Compra;"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Detalle_Factura_Compra")

        'se carga el datagridview con el data set
        DgvFactura.DataSource = ds.Tables("Detalle_Factura_compra")
        conex.Close()




        'se establece la coneccion y se crea la consulta
        ' Dim consulta As String = "SELECT * FROM factura_Compra;"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        ' Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        ' conex.Open()
        ' Dim ds As New DataSet

        'se carga el data set con el adaptador
        '  adaptador.Fill(ds, "Factura_Compra")

        'se carga el datagridview con el data set
        ' DgvFactura.DataSource = ds.Tables("Factura_compra")
        ' conex.Close()







    End Sub


    Private Sub CmbOrdenC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOrdenC.SelectedIndexChanged

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim consultar As String
        ' Dim Consultar1 As String

        Dim lista As Byte
        Dim adaptador1 As New OleDbDataAdapter
        Dim registros1 As New DataSet
        If TxtFactura.Text <> "" Then
            Dim resultado As String = CInt(TxtFactura.Text)
            consultar = " select * from Detalle_Factura_Compra where Id_Factura= " & resultado & " "
            MessageBox.Show(consultar)
            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Detalle_Factura_Compra")
            lista = registros1.Tables("Detalle_Factura_Compra").Rows.Count
            If lista <> 0 Then
                DgvFactura.DataSource = registros1
                DgvFactura.DataMember = "Detalle_Factura_Compra"


            Else
                MessageBox.Show("No hay registro")
                TxtFactura.Clear()
                TxtFactura.Focus()




            End If
        End If
    End Sub

    Private Sub CmbCondPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCondPago.SelectedIndexChanged

    End Sub

    Private Sub CmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEstado.SelectedIndexChanged

    End Sub
End Class