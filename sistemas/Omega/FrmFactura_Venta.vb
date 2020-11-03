Imports System.Data.OleDb
Public Class FrmFactura_Venta
    Dim conex As New OleDbConnection(My.Settings.Nombre)


    Public Sub cargarbdFactura_venta()
        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Factura_Venta"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Factura_Venta")

        'se carga el datagridview con el data set
        DgvFactura.DataSource = ds.Tables("Factura_Venta")
        conex.Close()
    End Sub
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CmbNPedido_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbNPedido.Enter

        Dim consulta2 As String = "SELECT Id_Nota_Pedido FROM Nota_Pedido"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbNPedido.ValueMember = "Id_Nota_Pedido"
        CmbNPedido.DisplayMember = "Id_Nota_Pedido"
        CmbNPedido.DataSource = dt2
    End Sub

    Private Sub CmbNPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbNPedido.SelectedIndexChanged

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

    Private Sub FrmFactura_Venta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cargarbdFactura_venta()

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido
        Dim cantcolum As Integer = DgvFactura.RowCount

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString

        TxFechaEmision.Text = fechactual.ToString("dd/MM/yyyy")
        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Vto As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy









        'Se Busca el registro del Orden Compra por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
        Dim text1 As String = CInt(CmbNPedido.Text)
        MessageBox.Show(text1)
        Dim cdArticulo As String = "Select id_Articulo from Nota_Pedido Where Id_Nota_Pedido  = " & text1 & ""
        MessageBox.Show(cdArticulo)
        conex.Open()
        Dim comna1 As New OleDbCommand(cdArticulo, conex)
        Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
        reader1.Read()
        Dim Id_Articulo As String = Convert.ToString(reader1.Item("id_Articulo"))
        conex.Close()
        MessageBox.Show(Id_Articulo)


        'Se Busca el registro del Orden Compra por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
        Dim texta As String = CInt(CmbNPedido.Text)
        MessageBox.Show(texta)
        Dim NomArticulo As String = "Select Nom_Articulo from Nota_Pedido Where Id_Nota_Pedido  = " & texta & ""
        MessageBox.Show(NomArticulo)
        conex.Open()
        Dim comnaa As New OleDbCommand(NomArticulo, conex)
        Dim readera As OleDbDataReader = comnaa.ExecuteReader(CommandBehavior.CloseConnection)
        readera.Read()
        Dim Nom_Articulo As String = Convert.ToString(readera.Item("Nom_Articulo"))
        conex.Close()
        MessageBox.Show(Nom_Articulo)





        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber la cantidad y guardarlo en una variable
        Dim text2 As String = CInt(CmbNPedido.Text)
        MessageBox.Show(text2)
        Dim Cant As String = "Select cantidad from Nota_Pedido Where Id_Nota_Pedido  = " & text2 & ""
        MessageBox.Show(Cant)
        conex.Open()
        Dim comna2 As New OleDbCommand(Cant, conex)
        Dim reader2 As OleDbDataReader = comna2.ExecuteReader(CommandBehavior.CloseConnection)
        reader2.Read()
        Dim Cantidad As String = Convert.ToString(reader2.Item("Cantidad"))
        conex.Close()
        MessageBox.Show(Cantidad)


        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text3 As String = CInt(CmbNPedido.Text)
        MessageBox.Show(text3)
        Dim Precio_U As String = "Select Precio_Unitario from Nota_Pedido Where Id_Nota_Pedido  = " & text3 & ""
        MessageBox.Show(Precio_U)
        conex.Open()
        Dim comna3 As New OleDbCommand(Precio_U, conex)
        Dim reader3 As OleDbDataReader = comna3.ExecuteReader(CommandBehavior.CloseConnection)
        reader3.Read()
        Dim Precio_Unitario As String = Convert.ToString(reader3.Item("Precio_Unitario"))
        conex.Close()
        MessageBox.Show(Precio_Unitario)


        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text4 As String = CInt(CmbNPedido.Text)
        MessageBox.Show(text4)
        Dim ImporteTotal As String = "Select Importe_Total from Nota_Pedido Where Id_Nota_Pedido  = " & text4 & ""
        MessageBox.Show(ImporteTotal)
        conex.Open()
        Dim comna4 As New OleDbCommand(ImporteTotal, conex)
        Dim reader4 As OleDbDataReader = comna4.ExecuteReader(CommandBehavior.CloseConnection)
        reader4.Read()
        Dim Importe_Total As String = Convert.ToString(reader4.Item("Importe_total"))
        conex.Close()
        MessageBox.Show(Importe_Total)


       




        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text6 As String = CInt(CmbNPedido.Text)
        MessageBox.Show(text6)
        Dim Condi_P As String = "Select Condicion_Venta from Nota_Pedido Where Id_Nota_Pedido  = " & text6 & ""
        MessageBox.Show(Condi_P)
        conex.Open()
        Dim comna6 As New OleDbCommand(Condi_P, conex)
        Dim reader6 As OleDbDataReader = comna6.ExecuteReader(CommandBehavior.CloseConnection)
        reader6.Read()
        Dim Condicion_Venta As String = Convert.ToString(reader6.Item("Condicion_Venta"))
        conex.Close()
        MessageBox.Show(Condicion_Venta)

        CmbVenta.Text = Condicion_Venta





        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text5 As String = CInt(CmbNPedido.Text)
        MessageBox.Show(text5)
        Dim NomCliente As String = "Select Nom_Cliente from Nota_Pedido Where Id_Nota_Pedido  = " & text5 & ""
        MessageBox.Show(NomCliente)
        conex.Open()
        Dim comna5 As New OleDbCommand(NomCliente, conex)
        Dim reader5 As OleDbDataReader = comna5.ExecuteReader(CommandBehavior.CloseConnection)
        reader5.Read()
        Dim Nom_Cliente As String = Convert.ToString(reader5.Item("Nom_Cliente"))
        conex.Close()
        MessageBox.Show(Nom_Cliente)

        CmbCliente.Text = Nom_Cliente











        Dim IDFacturaV As String = "Select max(Id_Factura) from Factura_Venta"
        MessageBox.Show(IDFacturaV)
        conex.Open()
        Dim comna8 As New OleDbCommand(IDFacturaV, conex)
        Dim Nro_Factura As Object = comna8.ExecuteScalar
        conex.Close()
        MessageBox.Show(Nro_Factura)





        'If cantcolum = 0 Then
        Nro_Factura = Nro_Factura + 1
        TxtNFactura.Text = Nro_Factura  ' el nro de informe me muestra en el txt


        Dim Factura_Venta As String = "Insert Into Factura_Venta(Id_Factura,Fecha_Emision,Fecha_Vto,Id_Nota_Pedido,Nom_Cliente,Condicion_Venta,Id_Articulo,Nom_Articulo,Cantidad,Precio_Unitario,Importe_Total,Estado) values ('" & Nro_Factura & "','" & fechactual & "','" & Fecha_Vto & "','" & CmbNPedido.Text & "','" & Nom_Cliente & "','" & Condicion_Venta & "','" & Id_Articulo & "', '" & Nom_Cliente & "' ,'" & Cantidad & "','" & Precio_Unitario & "','" & Importe_Total & "','" & CmbEstado.Text & "')"
        MessageBox.Show(Factura_Venta)
        Dim comando2 As New OleDbCommand(Factura_Venta, conex)
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
        cargarbdFactura_venta()
    End Sub
End Class