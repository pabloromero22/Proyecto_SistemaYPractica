Imports System.Data.OleDb
Public Class FrmNotaPedido
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Public Sub cargarbdNotaPedido()
        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Nota_Pedido"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Nota_Pedido")

        'se carga el datagridview con el data set
        DgvNPedido.DataSource = ds.Tables("Nota_Pedido")
        conex.Close()




    End Sub
    Private Sub FrmNotaPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbdNotaPedido()


    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click



        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido
        Dim cantcolum As Integer = DgvNPedido.RowCount

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString
        TxtFchaEmision.Text = fechactual
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Entrega As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy



        Dim Cantidad As String = CInt(TxtCantidad.Text)

        'Se Busca el registro del informe por el valor del descripcion para saber el Id Aticulo y guardarlo en una variable
        Dim text As String = CmbNomArticulo.Text

        Dim CodArticulo As String = "Select Id_Articulo from Articulo_ventas Where Nom_Articulo = '" & text & "'"

        conex.Open()
        Dim comna1 As New OleDbCommand(CodArticulo, conex)
        Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
        reader1.Read()
        Dim Id_Articulo As String = Convert.ToString(reader1.Item("Id_Articulo"))
        conex.Close()





        'Se Busca el registro del informe por el valor del descripcion para saber el Id Aticulo y guardarlo en una variable
        Dim text1 As String = CmbNomArticulo.Text

        Dim PrecioU As String = "Select Precio_Unitario from Articulo_ventas Where Nom_Articulo = '" & text1 & "'"

        conex.Open()
        Dim comna2 As New OleDbCommand(PrecioU, conex)
        Dim reader2 As OleDbDataReader = comna2.ExecuteReader(CommandBehavior.CloseConnection)
        reader2.Read()
        Dim Precio_Unitario As String = Convert.ToString(reader2.Item("Precio_Unitario"))
        conex.Close()


        Dim Importe_Total As Integer = CInt(Cantidad) * CInt(Precio_Unitario)









        Dim IDNotaP As String = "Select max(Id_Nota_Pedido) from Nota_Pedido"

        conex.Open()
        Dim comna8 As New OleDbCommand(IDNotaP, conex)
        Dim Nro_Nota_Pedido As Object = comna8.ExecuteScalar
        conex.Close()


        If cantcolum = 0 Then
            Nro_Nota_Pedido = Nro_Nota_Pedido + 1

            TxtNPedido.Text = Nro_Nota_Pedido
            Dim Nota_Pedido As String = "Insert Into Nota_Pedido (Id_Nota_Pedido,Fecha_Emision,Fecha_Entrega,Nom_Cliente,Id_Articulo,Nom_Articulo,Cantidad,Precio_Unitario,Importe_Total,Condicion_Venta,Nom_Vendedor) values ('" & Nro_Nota_Pedido & "','" & fechactual & "', '" & Fecha_Entrega & "', '" & CmbNomCliente.Text & "', '" & Id_Articulo & "', '" & CmbNomArticulo.Text & "', '" & Cantidad & "', '" & Precio_Unitario & "', '" & Importe_Total & "', '" & CmbCPago.Text & "','" & CmbVendedor.Text & "')"

            Dim comando2 As New OleDbCommand(Nota_Pedido, conex)
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

            cargarbdNotaPedido()
        End If


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantidad.TextChanged

    End Sub

    Private Sub CmbNomCliente_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbNomCliente.Enter

        Dim consulta2 As String = "SELECT Nom_Apellido FROM Clientes"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbNomCliente.ValueMember = "Nom_Apellido"
        CmbNomCliente.DisplayMember = "Nom_Apellido"
        CmbNomCliente.DataSource = dt2


    End Sub

    Private Sub CmbNomCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbNomCliente.SelectedIndexChanged

    End Sub

    Private Sub CmbNomArticulo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbNomArticulo.Enter
        Dim consulta2 As String = "SELECT Nom_Articulo FROM Articulo_Ventas"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbNomArticulo.ValueMember = "Nom_Articulo"
        CmbNomArticulo.DisplayMember = "Nom_Articulo"
        CmbNomArticulo.DataSource = dt2
    End Sub

    Private Sub CmbNomArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbNomArticulo.SelectedIndexChanged

    End Sub

    Private Sub CmbCPago_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCPago.Enter
        Dim consulta3 As String = "SELECT Descripcion FROM Condicion_ventas"
        Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        Dim dt3 As New DataTable()
        da3.Fill(dt3)
        CmbCPago.ValueMember = "Descripcion"
        CmbCPago.DisplayMember = "Descripcion"
        CmbCPago.DataSource = dt3
    End Sub

    Private Sub CmbCPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCPago.SelectedIndexChanged

    End Sub

    Private Sub CmbEstado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEstado.Enter
        Dim consulta5 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        Dim da5 As New OleDb.OleDbDataAdapter(consulta5, conex)
        Dim dt5 As New DataTable()
        da5.Fill(dt5)
        CmbEstado.ValueMember = "Id_Estado"
        CmbEstado.DisplayMember = "Descripcion"
        CmbEstado.DataSource = dt5

    End Sub

    Private Sub CmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEstado.SelectedIndexChanged

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        TxtNPedido.Clear()
        TxtFchaEmision.Clear()
        TxtCantidad.Clear()
        CmbNomArticulo.ResetText()
        CmbCPago.ResetText()
        CmbEstado.ResetText()
        CmbNomArticulo.ResetText()
        CmbVendedor.ResetText()
        TxtNPedido.Focus()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click


        Dim consultar As String
        Dim lista As Byte
        Dim adaptador1 As New OleDbDataAdapter
        Dim registros1 As New DataSet
        If TxtNPedido.Text <> "" Then
            Dim resultado As String = CInt(TxtNPedido.Text)
            consultar = " select * from Nota_Pedido where Id_Nota_Pedido = " & resultado & " "

            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Nota_Pedido")
            lista = registros1.Tables("Nota_Pedido").Rows.Count
            If lista <> 0 Then
                DgvNPedido.DataSource = registros1
                DgvNPedido.DataMember = "Nota_Pedido"
            Else
                MessageBox.Show("No hay registro")
                TxtNPedido.Clear()
                TxtNPedido.Focus()
            End If

        End If

    End Sub
End Class