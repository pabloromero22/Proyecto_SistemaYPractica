Imports System.Data.OleDb
Public Class FrmIR

    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Dim adaptador1 As New OleDbDataAdapter
    Dim registros1 As New DataSet
    Public Sub cargarbd()
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvInfRecep.CellContentClick

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        cargarbd()


        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido
        Dim cantcolum As Integer = DgvInfRecep.RowCount

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString

        TxtFcha_Emision.Text = fechactual.ToString("dd/MM/yyyy")
        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Entrega As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy





        If RBOPR.Checked Then





            'Se Busca el registro del Pedido Cotizacion por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
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




            'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
            Dim text7 As String = CInt(CmbOrdenC.Text)
            MessageBox.Show(text7)
            Dim Descri As String = "Select Descripcion from Orden_Compra_PR Where Id_Orden_Compra  = " & text7 & ""
            MessageBox.Show(Descri)
            conex.Open()
            Dim comna7 As New OleDbCommand(Descri, conex)
            Dim reader7 As OleDbDataReader = comna7.ExecuteReader(CommandBehavior.CloseConnection)
            reader7.Read()
            Dim Descripcion As String = Convert.ToString(reader7.Item("Descripcion"))
            conex.Close()
            MessageBox.Show(Descripcion)



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


            'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
            Dim text6 As String = CInt(CmbOrdenC.Text)
            MessageBox.Show(text6)
            Dim NomProve As String = "Select Nom_Proveedor from Orden_Compra_PR Where Id_Orden_Compra  = " & text6 & ""
            MessageBox.Show(NomProve)
            conex.Open()
            Dim comna6 As New OleDbCommand(NomProve, conex)
            Dim reader6 As OleDbDataReader = comna6.ExecuteReader(CommandBehavior.CloseConnection)
            reader6.Read()
            Dim Nom_Proveedor As String = Convert.ToString(reader6.Item("Nom_Proveedor"))
            conex.Close()
            MessageBox.Show(Nom_Proveedor)








            Dim IDInforme As String = "Select max(Id_Informe_Recepcion) from Informe_Recepcion_PR"
            MessageBox.Show(IDInforme)
            conex.Open()
            Dim comna8 As New OleDbCommand(IDInforme, conex)
            Dim Nro_Informe_Recepcion As Object = comna8.ExecuteScalar
            conex.Close()
            MessageBox.Show(Nro_Informe_Recepcion)





            'If cantcolum = 0 Then
            Nro_Informe_Recepcion = Nro_Informe_Recepcion + 1
            TxtNInfo.Text = Nro_Informe_Recepcion   ' el nro de informe me muestra en el txt


            Dim Informe_Recepcion_PR As String = "Insert Into Informe_Recepcion_PR (Id_Informe_Recepcion,Fecha_Emision,Fecha_Entrega,Id_Orden_Compra,Id_Proveedor,Nom_Proveedor,Id_Articulo,Descripcion,Cantidad,Precio_Unitario,Precio_Total,Estado) values ('" & Nro_Informe_Recepcion & "','" & fechactual & "', '" & Fecha_Entrega & "','" & CmbOrdenC.Text & "', '" & Id_Proveedor & "','" & Nom_Proveedor & "','" & Id_Articulo & "','" & Descripcion & "','" & Cantidad & "','" & Precio_Unitario & "','" & Precio_Total & "','" & CmbEstadoIR.Text & "')"
            MessageBox.Show(Informe_Recepcion_PR)
            Dim comando2 As New OleDbCommand(Informe_Recepcion_PR, conex)
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
            Dim consulta As String = "SELECT * FROM Informe_Recepcion_PR;"

            'se crea el comando que ejecutará la consulta sobre la bd
            'dim comando as new oledbcommand(consulta, coneccion)

            Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

            'se abre la coneccion y se crea el dataset
            conex.Open()
            Dim ds As New DataSet

            'se carga el data set con el adaptador
            adaptador.Fill(ds, "Informe_Recepcion_PR")

            'se carga el datagridview con el data set
            DgvInfRecep.DataSource = ds.Tables("Informe_Recepcion_PR")
            conex.Close()


            '_________________________________________________________________________


        ElseIf RBOSC.Checked Then


            'Se Busca el registro del Pedido Cotizacion por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
            Dim text_1 As String = CInt(CmbOSC.Text)
            MessageBox.Show(text_1)
            Dim cdArticulo_1 As String = "Select id_Bien_Uso from Orden_Compra_SC Where Id_Orden_Compra  = " & text_1 & ""
            MessageBox.Show(cdArticulo_1)
            conex.Open()
            Dim comna_1 As New OleDbCommand(cdArticulo_1, conex)
            Dim reader_1 As OleDbDataReader = comna_1.ExecuteReader(CommandBehavior.CloseConnection)
            reader_1.Read()
            Dim Id_Bien_Uso As String = Convert.ToString(reader_1.Item("id_Bien_Uso"))
            conex.Close()
            MessageBox.Show(Id_Bien_Uso)




            'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
            Dim text_7 As String = CInt(CmbOSC.Text)
            MessageBox.Show(text_7)
            Dim Descri_1 As String = "Select Descripcion from Orden_Compra_SC Where Id_Orden_Compra  = " & text_7 & ""
            MessageBox.Show(Descri_1)
            conex.Open()
            Dim comna_7 As New OleDbCommand(Descri_1, conex)
            Dim reader_7 As OleDbDataReader = comna_7.ExecuteReader(CommandBehavior.CloseConnection)
            reader_7.Read()
            Dim Descripcion_1 As String = Convert.ToString(reader_7.Item("Descripcion"))
            conex.Close()
            MessageBox.Show(Descripcion_1)



            'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber la cantidad y guardarlo en una variable
            Dim text_2 As String = CInt(CmbOSC.Text)
            MessageBox.Show(text_2)
            Dim Cant_1 As String = "Select cantidad from Orden_Compra_SC Where Id_Orden_Compra  = " & text_2 & ""
            MessageBox.Show(Cant_1)
            conex.Open()
            Dim comna_2 As New OleDbCommand(Cant_1, conex)
            Dim reader_2 As OleDbDataReader = comna_2.ExecuteReader(CommandBehavior.CloseConnection)
            reader_2.Read()
            Dim Cantidad_1 As String = Convert.ToString(reader_2.Item("Cantidad"))
            conex.Close()
            MessageBox.Show(Cantidad_1)



            'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
            Dim text_3 As String = CInt(CmbOSC.Text)
            MessageBox.Show(text_3)
            Dim Precio_U_1 As String = "Select Precio_Unitario from Orden_Compra_SC Where Id_Orden_Compra  = " & text_3 & ""
            MessageBox.Show(Precio_U_1)
            conex.Open()
            Dim comna_3 As New OleDbCommand(Precio_U_1, conex)
            Dim reader_3 As OleDbDataReader = comna_3.ExecuteReader(CommandBehavior.CloseConnection)
            reader_3.Read()
            Dim Precio_Unitario_1 As String = Convert.ToString(reader_3.Item("Precio_Unitario"))
            conex.Close()
            MessageBox.Show(Precio_Unitario_1)



            'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
            Dim text_4 As String = CInt(CmbOSC.Text)
            MessageBox.Show(text_4)
            Dim Precio_T_1 As String = "Select Precio_Total from Orden_Compra_SC Where Id_Orden_Compra  = " & text_4 & ""
            MessageBox.Show(Precio_T_1)
            conex.Open()
            Dim comna_4 As New OleDbCommand(Precio_T_1, conex)
            Dim reader_4 As OleDbDataReader = comna_4.ExecuteReader(CommandBehavior.CloseConnection)
            reader_4.Read()
            Dim Precio_Total_1 As String = Convert.ToString(reader_4.Item("Precio_Total"))
            conex.Close()
            MessageBox.Show(Precio_Total_1)



            'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
            Dim text_5 As String = CInt(CmbOSC.Text)
            MessageBox.Show(text_5)
            Dim IdProveedor_1 As String = "Select Id_Proveedor from Orden_Compra_SC Where Id_Orden_Compra  = " & text_5 & ""
            MessageBox.Show(IdProveedor_1)
            conex.Open()
            Dim comna_5 As New OleDbCommand(IdProveedor_1, conex)
            Dim reader_5 As OleDbDataReader = comna_5.ExecuteReader(CommandBehavior.CloseConnection)
            reader_5.Read()
            Dim Id_Proveedor_1 As String = Convert.ToString(reader_5.Item("Id_Proveedor"))
            conex.Close()
            MessageBox.Show(Id_Proveedor_1)


            'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
            Dim text_6 As String = CInt(CmbOSC.Text)
            MessageBox.Show(text_6)
            Dim NomProve_1 As String = "Select Nom_Proveedor from Orden_Compra_SC Where Id_Orden_Compra  = " & text_6 & ""
            MessageBox.Show(NomProve_1)
            conex.Open()
            Dim comna_6 As New OleDbCommand(NomProve_1, conex)
            Dim reader_6 As OleDbDataReader = comna_6.ExecuteReader(CommandBehavior.CloseConnection)
            reader_6.Read()
            Dim Nom_Proveedor_1 As String = Convert.ToString(reader_6.Item("Nom_Proveedor"))
            conex.Close()
            MessageBox.Show(Nom_Proveedor_1)
            'me muestra en el txt el nombre del proveedor
            TxtNomPr.Text = Nom_Proveedor_1






            Dim IDInforme_SC As String = "Select max(Id_Informe_Recepcion) from Informe_Recepcion_SC"
            MessageBox.Show(IDInforme_SC)
            conex.Open()
            Dim comna_8 As New OleDbCommand(IDInforme_SC, conex)
            Dim Nro_Informe_Recepcion_SC As Object = comna_8.ExecuteScalar
            conex.Close()
            MessageBox.Show(Nro_Informe_Recepcion_SC)





            'If cantcolum = 0 Then
            Nro_Informe_Recepcion_SC = Nro_Informe_Recepcion_SC + 1
            TxtNInfo.Text = Nro_Informe_Recepcion_SC   ' el nro de informe me muestra en el txt


            Dim Informe_Recepcion_SC As String = "Insert Into Informe_Recepcion_SC (Id_Informe_Recepcion,Fecha_Emision,Fecha_Entrega,Id_Orden_Compra,Id_Proveedor,Nom_Proveedor,Id_Bien_Uso,Descripcion,Cantidad,Precio_Unitario,Precio_Total,Estado) values ('" & Nro_Informe_Recepcion_SC & "','" & fechactual & "', '" & Fecha_Entrega & "','" & CmbOSC.Text & "', '" & Id_Proveedor_1 & "','" & Nom_Proveedor_1 & "','" & Id_Bien_Uso & "','" & Descripcion_1 & "','" & Cantidad_1 & "','" & Precio_Unitario_1 & "','" & Precio_Total_1 & "','" & CmbEstadoIR.Text & "')"
            MessageBox.Show(Informe_Recepcion_SC)
            Dim comando2 As New OleDbCommand(Informe_Recepcion_SC, conex)
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
            Dim consulta As String = "SELECT * FROM Informe_Recepcion_SC"

            'se crea el comando que ejecutará la consulta sobre la bd
            'dim comando as new oledbcommand(consulta, coneccion)

            Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

            'se abre la coneccion y se crea el dataset
            conex.Open()
            Dim ds As New DataSet

            'se carga el data set con el adaptador
            adaptador.Fill(ds, "Informe_Recepcion_SC")

            'se carga el datagridview con el data set
            DgvInfRecep.DataSource = ds.Tables("Informe_Recepcion_SC")
            conex.Close()

        End If

    End Sub

    Private Sub FrmIR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbd()

        'carga el combo box con los datos del idOrdenCompra


        '  Dim consulta1 As String = "SELECT Id_Orden_Compra FROM Orden_Compra_PR"
        ' Dim da1 As New OleDb.OleDbDataAdapter(consulta1, conex)
        ' Dim dt1 As New DataTable()
        ' da1.Fill(dt1)
        ' CmbOrdenC.ValueMember = "Id_orden_Compra"
        ' CmbOrdenC.DisplayMember = "Id_Orden_Compra"
        ' CmbOrdenC.DataSource = dt1



        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta4 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        Dim da4 As New OleDb.OleDbDataAdapter(consulta4, conex)
        Dim dt4 As New DataTable()
        da4.Fill(dt4)
        CmbEstadoIR.ValueMember = "Id_Estado"
        CmbEstadoIR.DisplayMember = "Descripcion"
        CmbEstadoIR.DataSource = dt4

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        TxtNInfo.Clear()
        TxtNomPr.Clear()
        TxtFcha_Emision.Clear()
        CmbOSC.ResetText()
        CmbOrdenC.ResetText()
        CmbEstadoIR.ResetText()
        Lblmostrar.ResetText()
        DgvInfRecep.DataSource = Nothing
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBOPR.CheckedChanged
        If RBOPR.Checked Then
            Dim consulta2 As String = "SELECT Id_Orden_Compra FROM Orden_Compra_PR"
            Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
            Dim dt2 As New DataTable()
            da2.Fill(dt2)
            CmbOrdenC.ValueMember = "Id_Orden_Compra"
            CmbOrdenC.DisplayMember = "Id_Orden_Compra"
            CmbOrdenC.DataSource = dt2

            Lblmostrar.Text = "Pedido de Reaprovisionamiento"
        End If
    End Sub

    Private Sub RBOPR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBOPR.Enter
        If RBOPR.Checked Then
            Dim consulta2 As String = "SELECT Id_Orden_Compra FROM Orden_Compra_PR"
            Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
            Dim dt2 As New DataTable()
            da2.Fill(dt2)
            CmbOrdenC.ValueMember = "Id_Orden_Compra"
            CmbOrdenC.DisplayMember = "Id_Orden_Compra"
            CmbOrdenC.DataSource = dt2

            Lblmostrar.Text = "Pedido de Reaprovisionamiento"
        End If
    End Sub

    Private Sub RBOSC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBOSC.CheckedChanged
        If RBOSC.Checked = True Then

            Dim consultaS As String = "SELECT Id_Orden_Compra FROM Orden_Compra_SC"
            Dim daS As New OleDb.OleDbDataAdapter(consultaS, conex)
            Dim dtS As New DataTable()
            daS.Fill(dtS)
            CmbOSC.ValueMember = "Id_Orden_Compra"
            CmbOSC.DisplayMember = "Id_Orden_Compra"
            CmbOSC.DataSource = dtS
            conex.Close()
            Lblmostrar.Text = " Solicitud de Compra "

        End If
    End Sub

    Private Sub RBOSC_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBOSC.Enter
        If RBOSC.Checked = True Then

            Dim consultaS As String = "SELECT Id_Orden_Compra FROM Orden_Compra_SC"
            Dim daS As New OleDb.OleDbDataAdapter(consultaS, conex)
            Dim dtS As New DataTable()
            daS.Fill(dtS)
            CmbOSC.ValueMember = "Id_Orden_Compra"
            CmbOSC.DisplayMember = "Id_Orden_Compra"
            CmbOSC.DataSource = dtS
            conex.Close()
            Lblmostrar.Text = " Solicitud de Compra "

        End If
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click

        If RBOPR.Checked Then
            Dim consultar As String
            Dim lista As Byte
            Dim adaptador1 As New OleDbDataAdapter
            Dim registros1 As New DataSet
            If TxtNInfo.Text <> "" Then
                Dim resultado As String = CInt(TxtNInfo.Text)
                consultar = " select * from Informe_Recepcion_PR where Id_Informe_Recepcion = " & resultado & " "
                MessageBox.Show(consultar)
                adaptador1 = New OleDbDataAdapter(consultar, conex)
                registros1 = New DataSet
                adaptador1.Fill(registros1, "Informe_Recepcion_PR")
                lista = registros1.Tables("Informe_Recepcion_PR").Rows.Count
                If lista <> 0 Then
                    DgvInfRecep.DataSource = registros1
                    DgvInfRecep.DataMember = "Informe_recepcion_PR"
                Else
                    MessageBox.Show("No hay registro")
                    TxtNInfo.Clear()
                    TxtNInfo.Focus()
                End If

            End If

        ElseIf RBOSC.Checked Then

            Dim consultar_1 As String
            Dim lista_1 As Byte
            Dim adaptador_1 As New OleDbDataAdapter
            Dim registros_1 As New DataSet
            If TxtNInfo.Text <> "" Then
                Dim resultado_1 As String = CInt(TxtNInfo.Text)
                consultar_1 = " select * from Informe_Recepcion_SC where Id_Informe_Recepcion= " & resultado_1 & " "
                MessageBox.Show(consultar_1)
                adaptador_1 = New OleDbDataAdapter(consultar_1, conex)
                registros_1 = New DataSet
                adaptador_1.Fill(registros_1, "Informe_Recepcion_SC")
                lista_1 = registros_1.Tables("Informe_recepcion_SC").Rows.Count
                If lista_1 <> 0 Then
                    DgvInfRecep.DataSource = registros_1
                    DgvInfRecep.DataMember = "informe_Recepcion_SC"
                Else
                    MessageBox.Show("No hay registro")
                    TxtNInfo.Clear()
                    TxtNInfo.Focus()
                End If

            End If
        End If
    End Sub

    Private Sub CmbOrdenC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOrdenC.SelectedIndexChanged

    End Sub
End Class