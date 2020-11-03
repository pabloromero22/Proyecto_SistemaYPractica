Imports System.Data.OleDb.OleDbDataReader
Imports System.Data.OleDb.OleDbDataAdapter
Imports System.Data.OleDb


Public Class FrmPR
    
    'objeto conexion
    Dim conex As New OleDb.OleDbConnection(My.Settings.Nombre)

    Public Sub cargarbd()
        'Se utiliza para refrescar y cargar la tabla en el datagridview


        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Pedido_Reaprovisionamiento;"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "pedidoR")

        'se carga el datagridview con el data set
        DGWPR.DataSource = ds.Tables("pedidoR")
        conex.Close()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        cargarbd()
        'carga el combo box con los datos del idarticulo 


        Dim consulta As String = "SELECT Descripcion FROM Articulo_Stock"
        Dim da As New OleDb.OleDbDataAdapter(consulta, conex)
        Dim dt As New DataTable()
        da.Fill(dt)
        Idart.ValueMember = "Descripcion"
        Idart.DisplayMember = "Descripcion"
        Idart.DataSource = dt


        Dim consulta5 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        Dim da5 As New OleDb.OleDbDataAdapter(consulta5, conex)
        Dim dt5 As New DataTable()
        da5.Fill(dt5)
        CmbEstado.ValueMember = "Id_Estado"
        CmbEstado.DisplayMember = "Descripcion"
        CmbEstado.DataSource = dt5

        Dim consulta6 As String = "SELECT talle FROM Articulo_Stock"
        Dim da6 As New OleDb.OleDbDataAdapter(consulta6, conex)
        Dim dt6 As New DataTable()
        da6.Fill(dt6)
        CmbTalle.ValueMember = "talle"
        CmbTalle.DisplayMember = "talle"
        CmbTalle.DataSource = dt6



    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido
        'Dim cantcolum As Integer = DGWPR.RowCount

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString
        TxtFchEmision.Text = fechactual
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim FechaReaprov As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy

        'Se Busca el registro del informe por el valor del descripcion para saber el Id Aticulo y guardarlo en una variable
        Dim text As String = Idart.Text
        MessageBox.Show(text)
        Dim Id_Articulo As String = "Select Id_Articulo from Articulo_Stock Where Descripcion = '" & text & "'"
        MessageBox.Show(Id_Articulo)
        conex.Open()
        Dim comna1 As New OleDbCommand(Id_Articulo, conex)
        Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
        reader1.Read()
        Dim cdArtic As String = Convert.ToString(reader1.Item("Id_Articulo"))
        conex.Close()
        MessageBox.Show(cdArtic)



        ' Se Busca el registro del informe por el valor del descripcion para saber el CodBarra y guardarlo en una variable
        Dim text1 As String = Idart.Text
        MessageBox.Show(text1)
        Dim CodBarra As String = "Select Codigo_Barra_Articulo from Articulo_Stock Where Descripcion = '" & text1 & "'"
        MessageBox.Show(CodBarra)
        conex.Open()
        Dim comna2 As New OleDbCommand(CodBarra, conex)
        Dim reader2 As OleDbDataReader = comna2.ExecuteReader(CommandBehavior.CloseConnection)
        reader2.Read()
        Dim cdbarra1 As String = Convert.ToString(reader2.Item("Codigo_Barra_Articulo"))
        conex.Close()
        MessageBox.Show(cdbarra1)


        ' Se Busca el registro del informe por el valor del descripcion para saber el IdMarca y guardarlo en una variable
        Dim text2 As String = Idart.Text
        MessageBox.Show(text2)
        Dim Marca As String = "Select   Marca from Articulo_Stock Where Descripcion = '" & text2 & "'"
        MessageBox.Show(CodBarra)
        conex.Open()
        Dim comna3 As New OleDbCommand(Marca, conex)
        Dim reader3 As OleDbDataReader = comna3.ExecuteReader(CommandBehavior.CloseConnection)
        reader3.Read()
        Dim Id_Marca As String = Convert.ToString(reader3.Item("Marca"))
        conex.Close()
        MessageBox.Show(Id_Marca)

        ' Se Busca el registro del informe por el valor del descripcion para saber el IdTipo y guardarlo en una variable
        Dim text3 As String = Idart.Text
        MessageBox.Show(text3)
        Dim TipoArti As String = "Select tipo from Articulo_Stock Where Descripcion = '" & text3 & "'"
        MessageBox.Show(TipoArti)
        conex.Open()
        Dim comna4 As New OleDbCommand(TipoArti, conex)
        Dim reader4 As OleDbDataReader = comna4.ExecuteReader(CommandBehavior.CloseConnection)
        reader4.Read()
        Dim Id_tipo As String = Convert.ToString(reader4.Item("tipo"))
        conex.Close()
        MessageBox.Show(Id_tipo)


       




      




        Dim IDPedido_Reaprov As String = "Select max(Id_Pedido_Reaprov) from Pedido_Reaprovisionamiento"
        MessageBox.Show(IDPedido_Reaprov)
        conex.Open()
        Dim comna As New OleDbCommand(IDPedido_Reaprov, conex)
        Dim Num_Pedido As Object = comna.ExecuteScalar
        conex.Close()
        MessageBox.Show(Num_Pedido)

        Num_Pedido = Num_Pedido + 1
        'me muestra en el textbox el id
        Dim resultado As String = CInt(Num_Pedido)
        TxtNroReap.Text = resultado




        'Se realiza el insert en la base de datos, utilizando el codigo de barra anterior, la cantidad de columnas anterior y la variable con la fecha actual
        Dim consulta2 As String = "Insert Into Pedido_Reaprovisionamiento (Id_Pedido_Reaprov,Fecha_Emision,Fecha_Reaprovisiona,Id_Articulo,Codigo_Barra_Articulo,Descripcion,Cantidad,Stock_Critico,Detalle,Id_Estado,Id_Marca,Id_tipo,talle) values ('" & Num_Pedido & "','" & fechactual & "','" & FechaReaprov & "' ,'" & cdArtic & "','" & cdbarra1 & "','" & Idart.Text & "','" & Cantidad.Text & "','" & Critico.Text & "','" & Detalle.Text & "','" & CmbEstado.Text & "','" & Id_Marca & "','" & Id_tipo & "','" & CmbTalle.Text & "')"
        MessageBox.Show(consulta2)
        Dim comando As New OleDbCommand(consulta2, conex)
        Try
            conex.Open()
            comando.ExecuteNonQuery()

            'Se agrega la notificación desde la clase notificacion
            Dim Noti As New Notificaciones
            Noti.Registroagregado()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        conex.Close()
        'Se refresaca la dtgridview
        cargarbd()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Idart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Idart.SelectedIndexChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        ' se busca el registro realizando la consulta comparando con textbuscar
        Dim consultar As String
        Dim lista As Byte
        Dim adaptador1 As New OleDbDataAdapter
        Dim registros1 As New DataSet
        If TxtNroReap.Text <> "" Then
            Dim resultado As String = CInt(TxtNroReap.Text)
            consultar = " select * from Pedido_Reaprovisionamiento where Id_Pedido_Reaprov= " & resultado & " "
            MessageBox.Show(consultar)
            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Pedido_Reaprovisionamiento")
            lista = registros1.Tables("Pedido_Reaprovisionamiento").Rows.Count
            If lista <> 0 Then
                DGWPR.DataSource = registros1
                DGWPR.DataMember = "Pedido_Reaprovisionamiento"
            Else
                MessageBox.Show("No hay registro")
                TxtNroReap.Clear()
                TxtNroReap.Focus()
            End If

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TxtFchEmision.Clear()
        TxtNroReap.Clear()
        Cantidad.Clear()

    End Sub

    Private Sub CmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEstado.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Try
        ' Using con As New OleDbConnection("MiCadenaConexion")

        'conex.Open()
        '  If TxtNroReap.Text <> "" Then
        'Dim resultado As String = CInt(TxtNroReap.Text)
        '   Dim query = "Delete from Pedido_Reaprovisionamiento where Id_Pedido_Reaprov = " & resultado & "  "

        '  Dim cmd As New OleDbCommand(query, conex)
        '  cmd.Parameters.AddWithValue("@p1", txtCodigo.Text)

        'Ejecutamos la consulta
        '   cmd.ExecuteNonQuery()

        'Mensaje informativo
        '  MessageBox.Show("Se eliminó....")
        '  End If
        ' End Using
        '  Catch ex As Exception
        'Si se produce algún error lo mostramos
        'MessageBox.Show(ex.Message)
        '   End Try
        '  conex.Close()
        '  cargarbd()


        '--------------------------------------------------------

        Dim eliminar As String
        Dim si As Byte
        conex.Open()
        si = MsgBox(" Esta seguro de  elimibar el Pedido?", vbYesNo, "???")
        If si = vbYes Then
            eliminar = "Delete from Pedido_Reaprovisionamiento where Id_Pedido_Reaprov = " & TxtNroReap.Text & " "
            Dim comando As New OleDbCommand(eliminar, conex)
            comando.ExecuteNonQuery()
            MsgBox(" eliminanado correctamente", vbInformation, "Correcto")
        Else
            MsgBox("Ud cancelo", vbCritical, " Atencion")





        End If
        conex.Close()
        cargarbd()

    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Dim Modificar As String
        conex.Open()
        Modificar = " UPDATE  Pedido_Reaprovisionamiento Set Cantidad = " & Cantidad.Text & " , Talle = " & CmbTalle.Text & "  where Id_Pedido_Reaprov = " & TxtNroReap.Text & ""
        Dim comando As New OleDbCommand(Modificar, conex)
        comando.ExecuteNonQuery()
        MsgBox(" Modifico correctamente", vbInformation, "Correctamente")

        conex.Close()
        cargarbd()
    End Sub
End Class
