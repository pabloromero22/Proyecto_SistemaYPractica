Imports System.Data.OleDb.OleDbDataReader
Imports System.Data.OleDb.OleDbDataAdapter
Imports System.Data.OleDb
Public Class FrmPCOT
    Dim Nro_Pc As Integer
    Dim Nro_Pc_SC As Integer
    Dim N_Pedido As String
    Dim N_Solicitud As String
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Public Sub cargarbd1()

    End Sub
    Public Sub RB()
        'Se utiliza para refrescar y cargar la tabla en el datagridview

        'Dim conex1 As New OleDb.OleDbConnection(" Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ever\Documents\Vb1\Trabajo_Integral_Prototipo\Trabajo_Integral_Prototipo\Gestion_Comercial.accdb")
        'se establece la coneccion y se crea la consulta
        ' Dim consulta1 As String = "SELECT * FROM Pedido_Cotizacion"

        'se crea el comando que ejecutará la consulta sobre la bd
        ' Dim comando As New OleDbCommand(consulta, coneccion)

        'Dim adaptador1 As New OleDb.OleDbDataAdapter(consulta1, conex1)

        'se abre la coneccion y se crea el dataset
        'conex1.Open()
        'Dim ds1 As New DataSet

        'se carga el data set con el adaptador
        'adaptador1.Fill(ds1, "Pedido_Cotizacion")

        'se carga el datagridview con el data set
        'Dpc.DataSource = ds1.Tables("Pedido_Cotizacion")
        'conex1.Close()
    End Sub
    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CmbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProveedor.SelectedIndexChanged

    End Sub

    Private Sub CmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEstado.SelectedIndexChanged

    End Sub

    Private Sub FrmPCOT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbd1()
        'carga el combo box con los datos del idPedidoReaprovisionamiento


        RB()

        '  Dim consulta2 As String = "SELECT Id_Pedido_Reaprov FROM Pedido_Reaprovisionamiento"
        '  Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        '  Dim dt2 As New DataTable()
        '  da2.Fill(dt2)
        '  CmbPRSC.ValueMember = "Id_Pedido_Reaprov"
        ' CmbPRSC.DisplayMember = "Id_Pedido_Reaprov"
        ' CmbPRSC.DataSource = dt2

        'carga el combo box con los datos del Nom_Proveedor


        Dim consulta3 As String = "SELECT Nom_proveedor FROM Proveedores"
        Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        Dim dt3 As New DataTable()
        da3.Fill(dt3)
        CmbProveedor.ValueMember = "Nom_proveedor"
        CmbProveedor.DisplayMember = "Nom_proveedor"
        CmbProveedor.DataSource = dt3

        Dim consulta5 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        Dim da5 As New OleDb.OleDbDataAdapter(consulta5, conex)
        Dim dt5 As New DataTable()
        da5.Fill(dt5)
        CmbEstado.ValueMember = "Id_Estado"
        CmbEstado.DisplayMember = "Descripcion"
        CmbEstado.DataSource = dt5

    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        cargarbd1()


        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido
        '  Dim cantcolum As Integer = Dpc.RowCount

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString


        TxtFchIngreso.Text = fechactual.ToString("dd/MM/yyyy")
        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Entrega As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy







        If RBPS.Checked Then




            'Se Busca el registro del Pedido por el valor del id_Pedido_Reaprovisionamiento para saber el codigo de barra y guardarlo en una variable
            Dim text As String = CInt(CmbPRSC.Text)
            MessageBox.Show(text)
            Dim IdArticulo As String = "Select id_Articulo from Pedido_Reaprovisionamiento Where Id_Pedido_Reaprov  = " & text & ""
            MessageBox.Show(IdArticulo)
            conex.Open()
            Dim comna As New OleDbCommand(IdArticulo, conex)
            Dim reader As OleDbDataReader = comna.ExecuteReader(CommandBehavior.CloseConnection)
            reader.Read()
            Dim Id_Articulo As String = Convert.ToString(reader.Item("id_Articulo"))
            conex.Close()
            MessageBox.Show(Id_Articulo)

            'Se Busca el registro del Pedido por el valor del id_Pedido_Reaprovisionamiento para saber el cantidad y guardarlo en una variable
            Dim text1 As String = CInt(CmbPRSC.Text)
            MessageBox.Show(text1)
            Dim Cantidad As String = "Select Cantidad from Pedido_Reaprovisionamiento Where Id_Pedido_Reaprov  = " & text1 & ""
            MessageBox.Show(Cantidad)
            conex.Open()
            Dim comna1 As New OleDbCommand(Cantidad, conex)
            Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
            reader1.Read()
            Dim Cantidad1 As String = Convert.ToString(reader1.Item("Cantidad"))
            conex.Close()
            MessageBox.Show(Cantidad1)



            'Se Busca el registro del Pedido por el valor del id_Pedido_Reaprovisionamiento para saber el cantidad y guardarlo en una variable
            Dim text4 As String = CInt(CmbPRSC.Text)
            MessageBox.Show(text4)
            Dim Descripcion As String = "Select Descripcion from Pedido_Reaprovisionamiento Where Id_Pedido_Reaprov  = " & text4 & ""
            MessageBox.Show(Descripcion)
            conex.Open()
            Dim comna4 As New OleDbCommand(Descripcion, conex)
            Dim reader4 As OleDbDataReader = comna4.ExecuteReader(CommandBehavior.CloseConnection)
            reader4.Read()
            Dim Descri As String = Convert.ToString(reader4.Item("Descripcion"))
            conex.Close()
            MessageBox.Show(Descri)





            'Se Busca el registro del informe por el valor del descripcion para saber el Id Proveedor y guardarlo en una variable
            Dim text7 As String = CmbProveedor.Text
            MessageBox.Show(text7)
            Dim Id_Prove As String = "Select Id_Proveedor from Proveedores Where Nom_Proveedor = '" & text7 & "'"
            MessageBox.Show(Id_Prove)
            conex.Open()
            Dim comna7 As New OleDbCommand(Id_Prove, conex)
            Dim reader7 As OleDbDataReader = comna7.ExecuteReader(CommandBehavior.CloseConnection)
            reader7.Read()
            Dim cdProve As String = Convert.ToString(reader7.Item("Id_proveedor"))
            conex.Close()
            MessageBox.Show(cdProve)


            '------------------------------------------------


            Dim IDPediC As String = "Select max(Id_Ped_Cotizacion) from Pedido_Cotizacion_PR"
            MessageBox.Show(IDPediC)
            conex.Open()
            Dim comna6 As New OleDbCommand(IDPediC, conex)
            Dim Nro_Pc As Object = comna6.ExecuteScalar
            conex.Close()
            MessageBox.Show(Nro_Pc)



            'If cantcolum = 0 Then
            Nro_Pc = Nro_Pc + 1

            'me muestra en el textbox el id
            Dim resultado1 As String = CInt(Nro_Pc)
            TxtPcot.Text = resultado1
            Dim Pedido_Cotizacion_PR As String = "Insert Into Pedido_Cotizacion_PR (Id_Ped_Cotizacion,Fecha_Emision,Id_Pedido_Reaprov,Fecha_Entrega, Id_Articulo,Cantidad,Nom_Proveedor,Id_Proveedor,Observaciones,Descripcion,Estado) values ('" & Nro_Pc & "','" & fechactual & "','" & CmbPRSC.Text & "','" & Fecha_Entrega & "','" & Id_Articulo & "', '" & Cantidad1 & "','" & CmbProveedor.Text & "','" & cdProve & "','" & TxtObserv.Text & "','" & Descri & "','" & CmbEstado.Text & "')"
            MessageBox.Show(Pedido_Cotizacion_PR)
            Dim comando2 As New OleDbCommand(Pedido_Cotizacion_PR, conex)
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
            '--------------------------------------------------


            '    Dim Orden_Compra_PR As String = "Select max(Id_Orden_Compra) from Orden_Compra_PR"
            '  MessageBox.Show(Orden_Compra_PR)
            '  conex.Open()
            '  Dim comna_O As New OleDbCommand(Orden_Compra_PR, conex)
            ''  Dim Nro_orden As Object = comna_O.ExecuteScalar
            '  conex.Close()
            '  MessageBox.Show(Nro_orden)

            '  Nro_orden = Nro_orden + 1
            'me muestra en el textbox el id
            ' Dim resultado As String = CInt(Nro_Pc_SC)
            'TxtPcot.Text = resultado

            'Se realiza el insert en la base de datos, utilizando el codigo de Pedido Reaprovisionamiento, la cantidad de columnas anterior y la variable con la fecha actual
            ' Dim consulta_Orden As String = "Insert Into orden_Compra_PR (Id_orden_Compra,Id_ped_Cotizacion,Id_Pedido_Cotizacion) values ('" & Nro_orden & "', '" & Nro_Pc & "','" & Nro_Pc_SC & "')"
            '  MessageBox.Show(consulta_Orden)
            '  Dim comando_Orden As New OleDbCommand(consulta_Orden, conex)
            ' Try
            '      conex.Open()
            '    comando_Orden.ExecuteNonQuery()

            'Se agrega la notificación desde la clase notificacion
            '  Dim Noti As New Notificaciones
            ''  Noti.Registroagregado()

            '   Catch ex As Exception
            'MessageBox.Show(ex.Message)
            '  End Try
            '  conex.Close()






            '---------------------

            'Me mostrara la tabla Pedido cotizacion_PR

            Dim consulta1 As String = "SELECT * FROM Pedido_Cotizacion_PR"

            'se crea el comando que ejecutará la consulta sobre la bd
            ' Dim comando As New OleDbCommand(consulta, coneccion)

            Dim adaptador1 As New OleDb.OleDbDataAdapter(consulta1, conex)

            'se abre la coneccion y se crea el dataset
            conex.Open()
            Dim ds1 As New DataSet

            'se carga el data set con el adaptador
            adaptador1.Fill(ds1, "Pedido_Cotizacion_PR")

            'se carga el datagridview con el data set
            Dpc.DataSource = ds1.Tables("Pedido_Cotizacion_PR")
            conex.Close()


            '_____________________________________________________________________
            'Me muestra la tabla Pedido Cotizacion_SC
        ElseIf RBSC.Checked Then



            'Se Busca el registro del Pedido por el valor del id_Pedido_Reaprovisionamiento para saber el codigo de barra y guardarlo en una variable
            Dim text_1 As String = CInt(CmbSC.Text)
            MessageBox.Show(text_1)
            Dim IdBienUso As String = "Select id_Bien_Uso from Solicitud_Compra Where Id_Solicitud_Compra  = " & text_1 & ""
            MessageBox.Show(IdBienUso)
            conex.Open()
            Dim comna_1 As New OleDbCommand(IdBienUso, conex)
            Dim reader_1 As OleDbDataReader = comna_1.ExecuteReader(CommandBehavior.CloseConnection)
            reader_1.Read()
            Dim Id_Bien_Uso As String = Convert.ToString(reader_1.Item("id_Bien_Uso"))
            conex.Close()
            MessageBox.Show(Id_Bien_Uso)


            'Se Busca el registro del Pedido por el valor del id_Solicitud Compra para saber el cantidad y guardarlo en una variable
            Dim text_2 As String = CInt(CmbSC.Text)
            MessageBox.Show(text_2)
            Dim Cantidad_S As String = "Select Cantidad from Solicitud_Compra Where Id_Solicitud_Compra  = " & text_2 & ""
            MessageBox.Show(Cantidad_S)
            conex.Open()
            Dim comna_2 As New OleDbCommand(Cantidad_S, conex)
            Dim reader_2 As OleDbDataReader = comna_2.ExecuteReader(CommandBehavior.CloseConnection)
            reader_2.Read()
            Dim Cantidad_2 As String = Convert.ToString(reader_2.Item("Cantidad"))
            conex.Close()
            MessageBox.Show(Cantidad_2)



            'Se Busca el registro del Pedido por el valor del id_Pedido_Reaprovisionamiento para saber el cantidad y guardarlo en una variable
            Dim text_3 As String = CInt(CmbSC.Text)
            MessageBox.Show(text_3)
            Dim Descripcion As String = "Select Descripcion from Solicitud_Compra Where Id_Solicitud_Compra  = " & text_3 & ""
            MessageBox.Show(Descripcion)
            conex.Open()
            Dim comna_3 As New OleDbCommand(Descripcion, conex)
            Dim reader_3 As OleDbDataReader = comna_3.ExecuteReader(CommandBehavior.CloseConnection)
            reader_3.Read()
            Dim Descri_1 As String = Convert.ToString(reader_3.Item("Descripcion"))
            conex.Close()
            MessageBox.Show(Descri_1)



            'Se Busca el registro del informe por el valor del descripcion para saber el Id Proveedor y guardarlo en una variable
            Dim text_4 As String = CmbProveedor.Text
            MessageBox.Show(text_4)
            Dim Id_Prove_1 As String = "Select Id_Proveedor from Proveedores Where Nom_proveedor = '" & text_4 & "'"
            MessageBox.Show(Id_Prove_1)
            conex.Open()
            Dim comna_4 As New OleDbCommand(Id_Prove_1, conex)
            Dim reader_4 As OleDbDataReader = comna_4.ExecuteReader(CommandBehavior.CloseConnection)
            reader_4.Read()
            Dim cdProveedor As String = Convert.ToString(reader_4.Item("Id_proveedor"))
            conex.Close()
            MessageBox.Show(cdProveedor)



            Dim IDPediC_SC As String = "Select max(Id_Pedido_Cotizacion) from Pedido_Cotizacion_SC"
            MessageBox.Show(IDPediC_SC)
            conex.Open()
            Dim comna_5 As New OleDbCommand(IDPediC_SC, conex)
            Dim Nro_Pc_SC As Object = comna_5.ExecuteScalar
            conex.Close()
            MessageBox.Show(Nro_Pc_SC)

            Nro_Pc_SC = Nro_Pc_SC + 1
            'me muestra en el textbox el id
            Dim resultado As String = CInt(Nro_Pc_SC)
            TxtPcot.Text = resultado


            'Se realiza el insert en la base de datos, utilizando el codigo de Pedido Reaprovisionamiento, la cantidad de columnas anterior y la variable con la fecha actual
            Dim consulta_3 As String = "Insert Into Pedido_Cotizacion_SC (Id_Pedido_Cotizacion,Id_Solicitud_Compra,Fecha_Emision,Fecha_Entrega, Id_Bien_Uso,Cantidad,Descripcion,Nom_Proveedor,Id_Proveedor,Estado) values ('" & Nro_Pc_SC & "', '" & CmbSC.Text & "','" & fechactual & "','" & Fecha_Entrega & "','" & Id_Bien_Uso & "', '" & Cantidad_2 & "','" & Descri_1 & "','" & CmbProveedor.Text & "', '" & cdProveedor & "', '" & CmbEstado.Text & "')"
            MessageBox.Show(consulta_3)
            Dim comando_1 As New OleDbCommand(consulta_3, conex)
            Try
                conex.Open()
                comando_1.ExecuteNonQuery()

                'Se agrega la notificación desde la clase notificacion
                Dim Noti As New Notificaciones
                Noti.Registroagregado()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            conex.Close()

            '-----------------------------------
            Dim Orden_Compra_PR As String = "Select max(Id_Orden_Compra) from Orden_Compra_PR"
            MessageBox.Show(Orden_Compra_PR)
            conex.Open()
            Dim comna_O As New OleDbCommand(Orden_Compra_PR, conex)
            Dim Nro_orden As Object = comna_O.ExecuteScalar
            conex.Close()
            MessageBox.Show(Nro_orden)

            Nro_orden = Nro_orden + 1
            'me muestra en el textbox el id
            ' Dim resultado As String = CInt(Nro_Pc_SC)
            'TxtPcot.Text = resultado

            'Se realiza el insert en la base de datos, utilizando el codigo de Pedido Reaprovisionamiento, la cantidad de columnas anterior y la variable con la fecha actual
            Dim consulta_Orden As String = "Insert Into orden_Compra_PR (Id_orden_Compra,Id_ped_Cotizacion,Id_Pedido_Cotizacion) values ('" & Nro_orden & "', '" & Nro_Pc & "','" & Nro_Pc_SC & "')"
            MessageBox.Show(consulta_Orden)
            Dim comando_Orden As New OleDbCommand(consulta_Orden, conex)
            Try
                conex.Open()
                comando_Orden.ExecuteNonQuery()

                'Se agrega la notificación desde la clase notificacion
                Dim Noti As New Notificaciones
                Noti.Registroagregado()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            conex.Close()



            '----------------------

            'Se refresaca la dtgridview
            ' cargarbd1()

            'Se utiliza para refrescar y cargar la tabla en el datagridview

            'Dim conex1 As New OleDb.OleDbConnection(" Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ever\Documents\Vb1\Trabajo_Integral_Prototipo\Trabajo_Integral_Prototipo\Gestion_Comercial.accdb")
            'se establece la coneccion y se crea la consulta
            Dim consulta2 As String = "SELECT * FROM Pedido_Cotizacion_SC"

            'se crea el comando que ejecutará la consulta sobre la bd
            ' Dim comando As New OleDbCommand(consulta, coneccion)

            Dim adaptador2 As New OleDb.OleDbDataAdapter(consulta2, conex)

            'se abre la coneccion y se crea el dataset
            conex.Open()
            Dim ds2 As New DataSet

            'se carga el data set con el adaptador
            adaptador2.Fill(ds2, "Pedido_Cotizacion_SC")

            'se carga el datagridview con el data set
            Dpc.DataSource = ds2.Tables("Pedido_Cotizacion_SC")
            conex.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        If RBPS.Checked Then







            cargarbd1()
            'Se utiliza para refrescar y cargar la tabla en el datagridview

            'Dim conex1 As New OleDb.OleDbConnection(" Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ever\Documents\Vb1\Trabajo_Integral_Prototipo\Trabajo_Integral_Prototipo\Gestion_Comercial.accdb")
            'se establece la coneccion y se crea la consulta
            Dim consulta1 As String = "SELECT * FROM Pedido_Cotizacion_SC"

            'se crea el comando que ejecutará la consulta sobre la bd
            ' Dim comando As New OleDbCommand(consulta, coneccion)

            Dim adaptador1 As New OleDb.OleDbDataAdapter(consulta1, conex)

            'se abre la coneccion y se crea el dataset
            conex.Open()
            Dim ds1 As New DataSet

            'se carga el data set con el adaptador
            adaptador1.Fill(ds1, "Pedido_Cotizacion_SC")

            'se carga el datagridview con el data set
            Dpc.DataSource = ds1.Tables("Pedido_Cotizacion_SC")
            conex.Close()

            'Se utiliza para refrescar y cargar la tabla en el datagridview
            cargarbd1()
            '---------------------

        ElseIf RBSC.Checked Then




            '---------------------








            'Dim conex1 As New OleDb.OleDbConnection(" Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ever\Documents\Vb1\Trabajo_Integral_Prototipo\Trabajo_Integral_Prototipo\Gestion_Comercial.accdb")
            'se establece la coneccion y se crea la consulta
            Dim consulta1 As String = "SELECT * FROM Pedido_Cotizacion_SC"

            'se crea el comando que ejecutará la consulta sobre la bd
            ' Dim comando As New OleDbCommand(consulta, coneccion)

            Dim adaptador1 As New OleDb.OleDbDataAdapter(consulta1, conex)

            'se abre la coneccion y se crea el dataset
            conex.Open()
            Dim ds1 As New DataSet

            'se carga el data set con el adaptador
            adaptador1.Fill(ds1, "Pedido_Cotizacion_SC")

            'se carga el datagridview con el data set
            Dpc.DataSource = ds1.Tables("Pedido_Cotizacion_SC")
            conex.Close()
            'Se utiliza para refrescar y cargar la tabla en el datagridview
            cargarbd1()
        End If
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        TxtPcot.Clear()
        TxtFchIngreso.Clear()
        TxtObserv.Clear()
        TxtPcot.Focus()

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        ' se busca el registro realizando la consulta comparando con textbuscar

        If RBPS.Checked Then
            Dim consultar As String
            Dim lista As Byte
            Dim adaptador1 As New OleDbDataAdapter
            Dim registros1 As New DataSet
            If TxtPcot.Text <> "" Then
                Dim resultado As String = CInt(TxtPcot.Text)
                consultar = " select * from Pedido_Cotizacion_PR where Id_Ped_Cotizacion= " & resultado & " "
                MessageBox.Show(consultar)
                adaptador1 = New OleDbDataAdapter(consultar, conex)
                registros1 = New DataSet
                adaptador1.Fill(registros1, "Pedido_Cotizacion_PR")
                lista = registros1.Tables("Pedido_Cotizacion_PR").Rows.Count
                If lista <> 0 Then
                    Dpc.DataSource = registros1
                    Dpc.DataMember = "Pedido_Cotizacion_PR"
                Else
                    MessageBox.Show("No hay registro")
                    TxtPcot.Clear()
                    TxtPcot.Focus()
                End If

            End If

        ElseIf RBSC.Checked Then

            Dim consultar_1 As String
            Dim lista_1 As Byte
            Dim adaptador_1 As New OleDbDataAdapter
            Dim registros_1 As New DataSet
            If TxtPcot.Text <> "" Then
                Dim resultado_1 As String = CInt(TxtPcot.Text)
                consultar_1 = " select * from Pedido_Cotizacion_SC where Id_Pedido_Cotizacion= " & resultado_1 & " "
                MessageBox.Show(consultar_1)
                adaptador_1 = New OleDbDataAdapter(consultar_1, conex)
                registros_1 = New DataSet
                adaptador_1.Fill(registros_1, "Pedido_Cotizacion_SC")
                lista_1 = registros_1.Tables("Pedido_Cotizacion_SC").Rows.Count
                If lista_1 <> 0 Then
                    Dpc.DataSource = registros_1
                    Dpc.DataMember = "Pedido_Cotizacion_SC"
                Else
                    MessageBox.Show("No hay registro")
                    TxtPcot.Clear()
                    TxtPcot.Focus()
                End If

            End If
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPS.CheckedChanged

        If RBPS.Checked = True Then
            conex.Open()
            Dim consulta2 As String = "SELECT Id_Pedido_Reaprov FROM Pedido_Reaprovisionamiento"
            Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
            Dim dt2 As New DataTable()
            da2.Fill(dt2)
            CmbPRSC.ValueMember = "Id_Pedido_Reaprov"
            CmbPRSC.DisplayMember = "Id_Pedido_Reaprov"
            CmbPRSC.DataSource = dt2

            Lblmostrar.Text = "Pedido de Reaprovisionamiento"



        End If
        conex.Close()

    End Sub



    Private Sub RBPS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBPS.Enter


        If RBPS.Checked = True Then
            Dim consulta2 As String = "SELECT Id_Pedido_Reaprov FROM Pedido_Reaprovisionamiento"
            Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
            Dim dt2 As New DataTable()
            da2.Fill(dt2)
            CmbPRSC.ValueMember = "Id_Pedido_Reaprov"
            CmbPRSC.DisplayMember = "Id_Pedido_Reaprov"
            CmbPRSC.DataSource = dt2
            Lblmostrar.Text = " Pedido De reaprovisionamiento"



        End If



    End Sub

    Private Sub RBSC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSC.CheckedChanged
        ' conex.Open()

        If RBSC.Checked = True Then

            Dim consultaS As String = "SELECT Id_Solicitud_Compra FROM Solicitud_Compra"
            Dim daS As New OleDb.OleDbDataAdapter(consultaS, conex)
            Dim dtS As New DataTable()
            daS.Fill(dtS)
            CmbSC.ValueMember = "Id_Solicitud_Compra"
            CmbSC.DisplayMember = "Id_Solicitud_Compra"
            CmbSC.DataSource = dtS
            conex.Close()
            Lblmostrar.Text = " Solicitud de Compra "
            conex.Close()
        End If
        ' conex.Close()
    End Sub

    Private Sub RBSC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBSC.Enter
        RB()

        If RBSC.Checked = True Then
            ' conex.Open()
            Dim consultaS As String = "SELECT Id_Solicitud_Compra FROM Solicitud_Compra"
            Dim daS As New OleDb.OleDbDataAdapter(consultaS, conex)
            Dim dtS As New DataTable()
            daS.Fill(dtS)
            CmbPRSC.ValueMember = "Id_Solicitud_Compra"
            CmbSC.DisplayMember = "Id_Solicitud_Compra"
            CmbSC.DataSource = dtS
            Lblmostrar.Text = " Solicitud de Compra "
            'conex.Close()
        End If

    End Sub
End Class