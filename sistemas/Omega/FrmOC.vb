Imports System.Data.OleDb
Public Class FrmOC
    Dim conex As New OleDbConnection(My.Settings.Nombre)


    Public Sub cargarbd()
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOC.TextChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPC.SelectedIndexChanged

    End Sub

    Private Sub FrmOC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbd()

        'carga el combo box con los datos del idPedidoCotizacion


        '  Dim consulta2 As String = "SELECT Id_Ped_Cotizacion FROM Pedido_Cotizacion_PR"
        '  Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        '  Dim dt2 As New DataTable()
        '  da2.Fill(dt2)
        '  CmbPC.ValueMember = "Id_Ped_Cotizacion"
        '  CmbPC.DisplayMember = "Id_Ped_Cotizacion"
        '  CmbPC.DataSource = dt2

        'carga el combo box con los datos del idCondiciondepagopero indicando que muestre la descripcion del ondicion de Pago


        Dim consulta3 As String = "SELECT Id_Condicion_Pago,Descripcion FROM Condicion_Pago"
        Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        Dim dt3 As New DataTable()
        da3.Fill(dt3)
        CmbCP.ValueMember = "Id_Condicion_Pago"
        CmbCP.DisplayMember = "Descripcion"
        CmbCP.DataSource = dt3

        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta4 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        Dim da4 As New OleDb.OleDbDataAdapter(consulta4, conex)
        Dim dt4 As New DataTable()
        da4.Fill(dt4)
        CmbEstado_OC.ValueMember = "Id_Estado"
        CmbEstado_OC.DisplayMember = "Descripcion"
        CmbEstado_OC.DataSource = dt4



    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        cargarbd()


        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido
        Dim cantcolum As Integer = DvgOrdenCompra.RowCount

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString

        TxtFecha_Emision.Text = fechactual.ToString("dd/MM/yyyy")
        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Entrega As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy


        If RBPR.Checked Then


            'Se Busca el registro del Pedido por el valor del id_Pedido_Cotizacion para saber la cantidad y guardarlo en una variable
            Dim text As String = CInt(CmbPC.Text)
            MessageBox.Show(text)
            Dim cant As String = "Select cantidad from Pedido_Cotizacion_PR Where Id_Ped_Cotizacion  = " & text & ""
            MessageBox.Show(cant)
            conex.Open()
            Dim comna As New OleDbCommand(cant, conex)
            Dim reader As OleDbDataReader = comna.ExecuteReader(CommandBehavior.CloseConnection)
            reader.Read()
            Dim Cantidad As String = Convert.ToString(reader.Item("Cantidad"))
            conex.Close()
            MessageBox.Show(Cantidad)


            'Se Busca el registro del Pedido por el valor del id_Pedido_Cotizacion para saber el Precio unitario y guardarlo en una variable
            Dim text2 As String = CInt(CmbPC.Text)
            MessageBox.Show(text2)
            Dim cdProveedor As String = "Select Id_Proveedor from Pedido_Cotizacion_PR Where Id_Ped_Cotizacion  = " & text2 & ""
            MessageBox.Show(cdProveedor)
            conex.Open()
            Dim comna1 As New OleDbCommand(cdProveedor, conex)
            Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
            reader1.Read()
            Dim Id_Proveedor As String = Convert.ToString(reader1.Item("Id_Proveedor"))
            conex.Close()
            MessageBox.Show(Id_Proveedor)


            'Se Busca el registro del Pedido por el valor del id_Pedido_Cotizacion para saber el Precio unitario y guardarlo en una variable
            Dim text3 As String = CInt(CmbPC.Text)
            MessageBox.Show(text3)
            Dim NomProveedor As String = "Select Nom_proveedor from Pedido_Cotizacion_PR Where Id_Ped_Cotizacion  = " & text3 & ""
            MessageBox.Show(NomProveedor)
            conex.Open()
            Dim comna2 As New OleDbCommand(NomProveedor, conex)
            Dim reader2 As OleDbDataReader = comna2.ExecuteReader(CommandBehavior.CloseConnection)
            reader2.Read()
            Dim Nom_Proveedor As String = Convert.ToString(reader2.Item("Nom_Proveedor"))
            conex.Close()
            MessageBox.Show(Nom_Proveedor)

            'Proveedor
            TxtProveedor.Text = Nom_Proveedor








            'con los datos obtenidos de las consultas  de la  cantidad y precio unitario se realiza la mutiplicacion para tener el resultado el precio total
            'Preciototal =cantidad multiplicado por precio unitario
            Dim Preciototal As Integer = CInt(Cantidad) * CInt(TxtPrecioU.Text)

            MessageBox.Show(Preciototal)






            'Se Busca el registro del Pedido Cotizacion por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
            Dim text4 As String = CInt(CmbPC.Text)
            MessageBox.Show(text)
            Dim cdArticulo As String = "Select id_Articulo from Pedido_Cotizacion_PR Where Id_Ped_Cotizacion  = " & text4 & ""
            MessageBox.Show(cdArticulo)
            conex.Open()
            Dim comna3 As New OleDbCommand(cdArticulo, conex)
            Dim reader3 As OleDbDataReader = comna3.ExecuteReader(CommandBehavior.CloseConnection)
            reader3.Read()
            Dim Id_Articulo As String = Convert.ToString(reader3.Item("id_Articulo"))
            conex.Close()
            MessageBox.Show(Id_Articulo)


            'Se Busca el registro del Pedido Cotizacion por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
            Dim text5 As String = CInt(CmbPC.Text)
            MessageBox.Show(text5)
            Dim Descri As String = "Select Descripcion from Pedido_Cotizacion_PR Where Id_Ped_Cotizacion  = " & text5 & ""
            MessageBox.Show(Descri)
            conex.Open()
            Dim comna5 As New OleDbCommand(Descri, conex)
            Dim reader5 As OleDbDataReader = comna5.ExecuteReader(CommandBehavior.CloseConnection)
            reader5.Read()
            Dim Descripcion As String = Convert.ToString(reader5.Item("Descripcion"))
            conex.Close()
            MessageBox.Show(Descripcion)



            Dim IDOrden As String = "Select max(Id_Orden_Compra) from Orden_Compra_PR"
            MessageBox.Show(IDOrden)
            conex.Open()
            Dim comna6 As New OleDbCommand(IDOrden, conex)
            Dim Nro_Orden_Compra As Object = comna6.ExecuteScalar
            conex.Close()
            MessageBox.Show(Nro_Orden_Compra)


            'If cantcolum = 0 Then
            Nro_Orden_Compra = Nro_Orden_Compra + 1
            TxtOC.Text = Nro_Orden_Compra
            Dim Orden_Compra_PR As String = "Insert Into Orden_Compra_PR (Id_Orden_Compra,Fecha_Emision,Id_Ped_Cotizacion,Fecha_Entrega,Id_Proveedor,Nom_proveedor,Descripcion, Id_Articulo,Cantidad,Precio_Unitario,Precio_Total,Condicion_Pago,Estado) values ('" & Nro_Orden_Compra & "','" & fechactual & "','" & CmbPC.Text & "','" & Fecha_Entrega & "', '" & Id_Proveedor & "','" & Nom_Proveedor & "', '" & Descripcion & "' ,'" & Id_Articulo & "','" & Cantidad & "', '" & TxtPrecioU.Text & "','" & Preciototal & "','" & CmbCP.Text & "','" & CmbEstado_OC.Text & "')"
            MessageBox.Show(Orden_Compra_PR)
            Dim comando2 As New OleDbCommand(Orden_Compra_PR, conex)
            Try
                conex.Open()
                comando2.ExecuteNonQuery()

                'Se agrega la notificación desde la clase notificacion
                'Dim Noti As New Notificaciones
                'Noti.Registroagregado()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            conex.Close()
            'End If
            '---------------------




            'se establece la coneccion y se crea la consulta
            Dim consulta As String = "SELECT * FROM Orden_Compra_PR;"

            'se crea el comando que ejecutará la consulta sobre la bd
            'dim comando as new oledbcommand(consulta, coneccion)

            Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

            'se abre la coneccion y se crea el dataset
            conex.Open()
            Dim ds As New DataSet

            'se carga el data set con el adaptador
            adaptador.Fill(ds, "Orden_Compra_PR")

            'se carga el datagridview con el data set
            DvgOrdenCompra.DataSource = ds.Tables("Orden_Compra_PR")
            conex.Close()

            '______________________________________________________________

        ElseIf RBSC.Checked Then


            'Se Busca el registro del Pedido por el valor del id_Pedido_Cotizacion para saber la cantidad y guardarlo en una variable
            Dim text_1 As String = CInt(CmbPSC.Text)
            MessageBox.Show(text_1)
            Dim cant_1 As String = "Select cantidad from Pedido_Cotizacion_SC Where Id_Pedido_Cotizacion  = " & text_1 & ""
            MessageBox.Show(cant_1)
            conex.Open()
            Dim comna_1 As New OleDbCommand(cant_1, conex)
            Dim reader_1 As OleDbDataReader = comna_1.ExecuteReader(CommandBehavior.CloseConnection)
            reader_1.Read()
            Dim Cantidad_1 As String = Convert.ToString(reader_1.Item("Cantidad"))
            conex.Close()
            MessageBox.Show(Cantidad_1)


            'Se Busca el registro del Pedido por el valor del id_Pedido_Cotizacion para saber el Precio unitario y guardarlo en una variable
            Dim text_2 As String = CInt(CmbPSC.Text)
            MessageBox.Show(text_2)
            Dim cdProveedor_1 As String = "Select Id_Proveedor from Pedido_Cotizacion_SC Where Id_Pedido_Cotizacion  = " & text_2 & ""
            MessageBox.Show(cdProveedor_1)
            conex.Open()
            Dim comna_2 As New OleDbCommand(cdProveedor_1, conex)
            Dim reader_2 As OleDbDataReader = comna_2.ExecuteReader(CommandBehavior.CloseConnection)
            reader_2.Read()
            Dim Id_Proveedor_1 As String = Convert.ToString(reader_2.Item("Id_Proveedor"))
            conex.Close()
            MessageBox.Show(Id_Proveedor_1)


            'Se Busca el registro del Pedido por el valor del id_Pedido_Cotizacion para saber el Precio unitario y guardarlo en una variable
            Dim text_3 As String = CInt(CmbPSC.Text)
            MessageBox.Show(text_3)
            Dim RazonSocial_1 As String = "Select Nom_Proveedor from Pedido_Cotizacion_SC Where Id_Pedido_Cotizacion  = " & text_3 & ""
            MessageBox.Show(RazonSocial_1)
            conex.Open()
            Dim comna_3 As New OleDbCommand(RazonSocial_1, conex)
            Dim reader_3 As OleDbDataReader = comna_3.ExecuteReader(CommandBehavior.CloseConnection)
            reader_3.Read()
            Dim Nom_Proveedor_1 As String = Convert.ToString(reader_3.Item("Nom_Proveedor"))
            conex.Close()
            MessageBox.Show(Nom_Proveedor_1)

            'Proveedor
            TxtProveedor.Text = Nom_Proveedor_1








            'con los datos obtenidos de las consultas  de la  cantidad y precio unitario se realiza la mutiplicacion para tener el resultado el precio total
            'Preciototal =cantidad multiplicado por precio unitario
            Dim Preciototal_1 As Integer = CInt(Cantidad_1) * CInt(TxtPrecioU.Text)

            MessageBox.Show(Preciototal_1)






            'Se Busca el registro del Pedido Cotizacion por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
            Dim text_4 As String = CInt(CmbPSC.Text)
            MessageBox.Show(text_4)
            Dim BienUso As String = "Select id_Bien_Uso from Pedido_Cotizacion_SC Where Id_Pedido_Cotizacion  = " & text_4 & ""
            MessageBox.Show(BienUso)
            conex.Open()
            Dim comna_4 As New OleDbCommand(BienUso, conex)
            Dim reader_4 As OleDbDataReader = comna_4.ExecuteReader(CommandBehavior.CloseConnection)
            reader_4.Read()
            Dim Id_Bien_Uso As String = Convert.ToString(reader_4.Item("id_Bien_Uso"))
            conex.Close()
            MessageBox.Show(Id_Bien_Uso)


            'Se Busca el registro del Pedido Cotizacion por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
            Dim text_5 As String = CInt(CmbPSC.Text)
            MessageBox.Show(text_5)
            Dim Descri_1 As String = "Select Descripcion from Pedido_Cotizacion_SC Where Id_Pedido_Cotizacion  = " & text_5 & ""
            MessageBox.Show(Descri_1)
            conex.Open()
            Dim comna_5 As New OleDbCommand(Descri_1, conex)
            Dim reader_5 As OleDbDataReader = comna_5.ExecuteReader(CommandBehavior.CloseConnection)
            reader_5.Read()
            Dim Descripcion_1 As String = Convert.ToString(reader_5.Item("Descripcion"))
            conex.Close()
            MessageBox.Show(Descripcion_1)



            Dim IDOrdenCompra As String = "Select max(Id_Orden_Compra) from Orden_Compra_SC"
            MessageBox.Show(IDOrdenCompra)
            conex.Open()
            Dim comna_6 As New OleDbCommand(IDOrdenCompra, conex)
            Dim Nro_Orden_Compra_Sc As Object = comna_6.ExecuteScalar
            conex.Close()
            MessageBox.Show(Nro_Orden_Compra_Sc)


            'If cantcolum = 0 Then
            Nro_Orden_Compra_Sc = Nro_Orden_Compra_Sc + 1
            TxtOC.Text = Nro_Orden_Compra_Sc
            Dim Orden_Compra_SC As String = "Insert Into Orden_Compra_SC (Id_Orden_Compra,Fecha_Emision,Id_Pedido_Cotizacion,Fecha_Entrega,Id_Proveedor,Nom_Proveedor,Descripcion, Id_Bien_uso,Cantidad,Precio_Unitario,Precio_Total,Condicion_Pago,Estado) values ('" & Nro_Orden_Compra_Sc & "','" & fechactual & "','" & CmbPSC.Text & "','" & Fecha_Entrega & "', '" & Id_Proveedor_1 & "','" & Nom_Proveedor_1 & "', '" & Descripcion_1 & "' ,'" & Id_Bien_Uso & "','" & Cantidad_1 & "', '" & TxtPrecioU.Text & "','" & Preciototal_1 & "','" & CmbCP.Text & "','" & CmbEstado_OC.Text & "')"
            MessageBox.Show(Orden_Compra_SC)
            Dim comando_2 As New OleDbCommand(Orden_Compra_SC, conex)
            Try
                conex.Open()
                comando_2.ExecuteNonQuery()

                'Se agrega la notificación desde la clase notificacion
                'Dim Noti As New Notificaciones
                'Noti.Registroagregado()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            conex.Close()
            'End If
            '---------------------




            'se establece la coneccion y se crea la consulta
            Dim consulta As String = "SELECT * FROM Orden_Compra_SC"

            'se crea el comando que ejecutará la consulta sobre la bd
            'dim comando as new oledbcommand(consulta, coneccion)

            Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

            'se abre la coneccion y se crea el dataset
            conex.Open()
            Dim ds As New DataSet

            'se carga el data set con el adaptador
            adaptador.Fill(ds, "Orden_Compra_SC")

            'se carga el datagridview con el data set
            DvgOrdenCompra.DataSource = ds.Tables("Orden_Compra_SC")
            conex.Close()












        End If
    End Sub

    Private Sub RBSC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSC.CheckedChanged
        If RBSC.Checked = True Then

            Dim consultaS As String = "SELECT Id_Pedido_Cotizacion FROM Pedido_Cotizacion_SC"
            Dim daS As New OleDb.OleDbDataAdapter(consultaS, conex)
            Dim dtS As New DataTable()
            daS.Fill(dtS)
            CmbPSC.ValueMember = "Id_Pedido_Cotizacion"
            CmbPSC.DisplayMember = "Id_Pedido_Cotizacion"
            CmbPSC.DataSource = dtS
            conex.Close()
            Lblmostrar.Text = " Solicitud de Compra "

        End If
    End Sub

    Private Sub RBSC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBSC.Enter
        If RBSC.Checked = True Then

            Dim consultaS As String = "SELECT Id_Pedido_Cotizacion FROM Pedido_Cotizacion_SC"
            Dim daS As New OleDb.OleDbDataAdapter(consultaS, conex)
            Dim dtS As New DataTable()
            daS.Fill(dtS)
            CmbPSC.ValueMember = "Id_Pedido_Cotizacion"
            CmbPSC.DisplayMember = "Id_Pedido_Cotizacion"
            CmbPSC.DataSource = dtS

            Lblmostrar.Text = " Solicitud de Compra "

        End If
    End Sub

    Private Sub RBPR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPR.CheckedChanged
        If RBPR.Checked Then
            Dim consulta2 As String = "SELECT Id_Ped_Cotizacion FROM Pedido_Cotizacion_PR"
            Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
            Dim dt2 As New DataTable()
            da2.Fill(dt2)
            CmbPC.ValueMember = "Id_Ped_Cotizacion"
            CmbPC.DisplayMember = "Id_Ped_Cotizacion"
            CmbPC.DataSource = dt2

            Lblmostrar.Text = "Pedido de Reaprovisionamiento"
        End If
    End Sub

    Private Sub RBPR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBPR.Enter
        If RBPR.Checked Then

            Dim consulta2 As String = "SELECT Id_Ped_Cotizacion FROM Pedido_Cotizacion_PR"
            Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
            Dim dt2 As New DataTable()
            da2.Fill(dt2)
            CmbPC.ValueMember = "Id_Ped_Cotizacion"
            CmbPC.DisplayMember = "Id_Ped_Cotizacion"
            CmbPC.DataSource = dt2
            Lblmostrar.Text = "Pedido de Reaprovisionamiento"
        End If
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Orden_Compra_PR;"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Orden_Compra_PR")

        'se carga el datagridview con el data set
        DvgOrdenCompra.DataSource = ds.Tables("Orden_Compra_PR")
        conex.Close()
    End Sub

    Private Sub Btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsalir.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click

        If RBPR.Checked Then
            Dim consultar As String
            Dim lista As Byte
            Dim adaptador1 As New OleDbDataAdapter
            Dim registros1 As New DataSet
            If TxtOC.Text <> "" Then
                Dim resultado As String = CInt(TxtOC.Text)
                consultar = " select * from Orden_Compra_PR where Id_Orden_Compra= " & resultado & " "
                MessageBox.Show(consultar)
                adaptador1 = New OleDbDataAdapter(consultar, conex)
                registros1 = New DataSet
                adaptador1.Fill(registros1, "Orden_Compra_PR")
                lista = registros1.Tables("Orden_Compra_PR").Rows.Count
                If lista <> 0 Then
                    DvgOrdenCompra.DataSource = registros1
                    DvgOrdenCompra.DataMember = "Orden_Compra_PR"
                Else
                    MessageBox.Show("No hay registro")
                    TxtOC.Clear()
                    TxtOC.Focus()
                End If

            End If

        ElseIf RBSC.Checked Then

            Dim consultar_1 As String
            Dim lista_1 As Byte
            Dim adaptador_1 As New OleDbDataAdapter
            Dim registros_1 As New DataSet
            If TxtOC.Text <> "" Then
                Dim resultado_1 As String = CInt(TxtOC.Text)
                consultar_1 = " select * from Orden_Compra_SC where Id_Orden_Compra= " & resultado_1 & " "
                MessageBox.Show(consultar_1)
                adaptador_1 = New OleDbDataAdapter(consultar_1, conex)
                registros_1 = New DataSet
                adaptador_1.Fill(registros_1, "Orden_Compra_SC")
                lista_1 = registros_1.Tables("Orden_Compra_SC").Rows.Count
                If lista_1 <> 0 Then
                    DvgOrdenCompra.DataSource = registros_1
                    DvgOrdenCompra.DataMember = "Orden_Compra_SC"
                Else
                    MessageBox.Show("No hay registro")
                    TxtOC.Clear()
                    TxtOC.Focus()
                End If

            End If
        End If
    End Sub

    Private Sub Btnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnuevo.Click
        TxtOC.Clear()
        TxtPrecioU.Clear()
        TxtProveedor.Clear()
        TxtFecha_Emision.Clear()

    End Sub

    Private Sub CmbCP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCP.SelectedIndexChanged

    End Sub
End Class