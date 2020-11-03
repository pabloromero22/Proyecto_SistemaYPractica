Imports System.Data.OleDb
Public Class FrmDV
    Dim conex As New OleDbConnection(My.Settings.Nombre)


    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

   

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub FrmDV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




        'carga el combo box con los datos del idinfo.pero indicando que muestre el nro
        '   Dim consulta3 As String = "SELECT Id_Informe_Recepcion FROM Informe_Recepcion_PR"
        '   Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        '   Dim dt3 As New DataTable()
        '   da3.Fill(dt3)
        '   CmbInfor.ValueMember = "Id_Informe_Recepcion"
        '   CmbInfor.DisplayMember = "Id_Informe_Recepcion"
        '  CmbInfor.DataSource = dt3




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
        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString

        TxtEmision.Text = fechactual.ToString("dd/MM/yyyy")



        'Se Busca el registro del Pedido Cotizacion por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
        Dim text1 As String = CInt(CmbInfor.Text)
        MessageBox.Show(text1)
        Dim cdArticulo As String = "Select id_Articulo from Informe_Recepcion_PR Where Id_Informe_Recepcion  = " & text1 & ""
        MessageBox.Show(cdArticulo)
        conex.Open()
        Dim comna1 As New OleDbCommand(cdArticulo, conex)
        Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
        reader1.Read()
        Dim Id_Articulo As String = Convert.ToString(reader1.Item("id_Articulo"))
        conex.Close()
        MessageBox.Show(Id_Articulo)



        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text5 As String = CInt(CmbInfor.Text)
        MessageBox.Show(text5)
        Dim IdProveedor As String = "Select Id_Proveedor from Informe_Recepcion_PR Where Id_Informe_Recepcion  = " & text5 & ""
        MessageBox.Show(IdProveedor)
        conex.Open()
        Dim comna5 As New OleDbCommand(IdProveedor, conex)
        Dim reader5 As OleDbDataReader = comna5.ExecuteReader(CommandBehavior.CloseConnection)
        reader5.Read()
        Dim Id_Proveedor As String = Convert.ToString(reader5.Item("Id_Proveedor"))
        conex.Close()
        MessageBox.Show(Id_Proveedor)


        'Se Busca el registro del Pedido por el valor del id_Orden_Compra para saber el Precio unitario y guardarlo en una variable
        Dim text6 As String = CInt(CmbInfor.Text)
        MessageBox.Show(text6)
        Dim NomProve As String = "Select Nom_Proveedor from Informe_Recepcion_PR Where Id_Informe_Recepcion  = " & text6 & ""
        MessageBox.Show(NomProve)
        conex.Open()
        Dim comna6 As New OleDbCommand(NomProve, conex)
        Dim reader6 As OleDbDataReader = comna6.ExecuteReader(CommandBehavior.CloseConnection)
        reader6.Read()
        Dim Nom_Proveedor As String = Convert.ToString(reader6.Item("Nom_Proveedor"))
        conex.Close()
        MessageBox.Show(Nom_Proveedor)







        Dim IDDevo As String = "Select max(Id_Devolucion) from Devoluciones_PR"
        MessageBox.Show(IDDevo)
        conex.Open()
        Dim comna8 As New OleDbCommand(IDDevo, conex)
        Dim Nro_Devolucion As Object = comna8.ExecuteScalar
        conex.Close()
        MessageBox.Show(Nro_Devolucion)





        'If cantcolum = 0 Then
        Nro_Devolucion = Nro_Devolucion + 1
        TxtNDevo.Text = Nro_Devolucion   ' el nro de informe me muestra en el txt


        Dim Devoluciones_PR As String = "Insert Into Devoluciones_PR (Id_Devolucion,Fecha_Emision,Id_Informe_Recepcion,Id_Proveedor,Nom_Proveedor,Id_Articulo,Cantidad,Estado) values ('" & Nro_Devolucion & "','" & fechactual & "', '" & CmbInfor.Text & "', '" & Id_Proveedor & "','" & Nom_Proveedor & "','" & Id_Articulo & "','" & Txtcantidad.Text & "','" & CmbEstado.Text & "')"
        MessageBox.Show(Devoluciones_PR)
        Dim comando2 As New OleDbCommand(Devoluciones_PR, conex)
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
        Dim consulta As String = "SELECT * FROM Devoluciones_PR;"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Devoluciones_PR")

        'se carga el datagridview con el data set
        DgvDevo.DataSource = ds.Tables("Devoluciones_PR")
        conex.Close()
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
        If TxtNDevo.Text <> "" Then
            Dim resultado As String = CInt(TxtNDevo.Text)
            consultar = " select * from Devoluciones_PR where Id_Devolucion = " & resultado & " "
            MessageBox.Show(consultar)
            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Devoluciones_PR")
            lista = registros1.Tables("Devoluciones_PR").Rows.Count
            If lista <> 0 Then
                DgvDevo.DataSource = registros1
                DgvDevo.DataMember = "Devoluciones_PR"
            Else
                MessageBox.Show("No hay registro")
                TxtNDevo.Clear()
                TxtNDevo.Focus()

            End If
        End If

    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        TxtNDevo.Clear()
        TxtEmision.Clear()
        TxtMotivo.Clear()
        TxtNFact.Clear()
        TxtNFact.Clear()
        TxtNRemito.Clear()
        CmbInfor.ResetText()
        CmbEstado.ResetText()
        DgvDevo.DataSource = Nothing


    End Sub

    Private Sub CmbInfor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbInfor.Enter

        'carga el combo box con los datos del idinfo.pero indicando que muestre el nro
        Dim consulta3 As String = "SELECT Id_Informe_Recepcion FROM Informe_Recepcion_PR"
        Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        Dim dt3 As New DataTable()
        da3.Fill(dt3)
        CmbInfor.ValueMember = "Id_Informe_Recepcion"
        CmbInfor.DisplayMember = "Id_Informe_Recepcion"
        CmbInfor.DataSource = dt3


    End Sub

    Private Sub CmbInfor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbInfor.SelectedIndexChanged

        'carga el combo box con los datos del idinfo.pero indicando que muestre el nro
        '  Dim consulta3 As String = "SELECT Id_Informe_Recepcion FROM Informe_Recepcion_PR"
        ' Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        ' Dim dt3 As New DataTable()
        ' da3.Fill(dt3)
        ' CmbInfor.ValueMember = "Id_Informe_Recepcion"
        ' CmbInfor.DisplayMember = "Id_Informe_Recepcion"
        ' CmbInfor.DataSource = dt3


    End Sub

   
    


End Class