Imports System.Data.OleDb
Public Class FrmRemito
    Dim conex As New OleDbConnection(My.Settings.Nombre) 'conexion base de datos
    Dim adaptador1 As New OleDbDataAdapter
    Dim registros1 As New DataSet
    Dim txtFchaEmision As Date
    Public Sub cargarbdRemito()
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub
    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub FrmRemito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbdRemito()



        Dim consulta1 As String = "SELECT Id_Informe_Recepcion FROM Informe_Recepcion_PR"
        Dim da1 As New OleDb.OleDbDataAdapter(consulta1, conex)
        Dim dt1 As New DataTable()
        da1.Fill(dt1)
        CmbInforme.ValueMember = "Id_Informe_Recepcion"
        CmbInforme.DisplayMember = "Id_Informe_Recepcion"
        CmbInforme.DataSource = dt1

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
        cargarbdRemito()


        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido
        Dim cantcolum As Integer = DGVRemito.RowCount

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString
        'me muestra la fecha actual en el textbox
        TextFchaEmision.Text = DateTime.Now.ToString("dd/MM/yyyy")

        'se guarda la fecha  de entrega  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(calendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim FechaEntrega As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy



        'Se Busca el registro del Pedido Cotizacion por el valor del id_Pedido_Cotizacion para saber el Id_Articulo y guardarlo en una variable
        Dim text1 As String = CInt(CmbInforme.Text)
        MessageBox.Show(text1)
        Dim codbarra1 As String = "Select id_Articulo from Informe_recepcion_PR Where Id_Informe_Recepcion  = " & text1 & ""

        conex.Open()
        Dim comna3 As New OleDbCommand(codbarra1, conex)
        Dim reader1 As OleDbDataReader = comna3.ExecuteReader(CommandBehavior.CloseConnection)
        reader1.Read()
        Dim cdbarra1 As String = Convert.ToString(reader1.Item("id_Articulo"))
        conex.Close()



        'Se Busca el registro del informe por el valor del id_Informe_Recepcion para saber la cantidad y guardarlo en una variable
        Dim text As String = CInt(CmbInforme.Text)

        Dim codbarra5 As String = "Select cantidad from Informe_Recepcion_PR Where Id_Informe_Recepcion  = " & text & ""

        conex.Open()
        Dim comna As New OleDbCommand(codbarra5, conex)
        Dim reader As OleDbDataReader = comna.ExecuteReader(CommandBehavior.CloseConnection)
        reader.Read()
        Dim cdbarra3 As String = Convert.ToString(reader.Item("Cantidad"))
        conex.Close()





        Dim IDRemito As String = "Select max(Id_Remito) from Remito"

        conex.Open()
        Dim comna1 As New OleDbCommand(IDRemito, conex)
        Dim Nro_Remito As Object = comna1.ExecuteScalar
        conex.Close()



        If cantcolum = 0 Then
            Nro_Remito = Nro_Remito + 1
            'me muestra en el textbox el id
            Dim resultado As String = CInt(Nro_Remito)
            LLblRemito.Text = resultado
            Dim Remito As String = "Insert Into Remito (Id_Remito,Fecha_Emision,Fecha_Entrega,Id_Informe_Recepcion,Id_Estado,Id_Articulo,Cantidad) values ('" & Nro_Remito & "','" & fechactual & "','" & FechaEntrega & "','" & CmbInforme.Text & "','" & CmbEstado.Text & "','" & cdbarra1 & "','" & cdbarra3 & "')"

            Dim comando2 As New OleDbCommand(Remito, conex)
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
        End If



        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Remito;"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Remito")

        'se carga el datagridview con el data set
        DGVRemito.DataSource = ds.Tables("Remito")
        conex.Close()



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' se busca el registro realizando la consulta comparando con textbuscar
        Dim consultar As String
        Dim lista As Byte
        If TextBuscar.Text <> "" Then
            Dim resultado As String = CInt(TextBuscar.Text)
            consultar = " select * from Remito where Id_Remito= " & resultado & " "

            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Remito")
            lista = registros1.Tables("Remito").Rows.Count
            If lista <> 0 Then
                DGVRemito.DataSource = registros1
                DGVRemito.DataMember = "Remito"
            Else
                MessageBox.Show("No hay registro")
                TextBuscar.Clear()
                TextBuscar.Focus()
            End If

        End If
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        cargarbdRemito()

        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Remito;"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Remito")

        'se carga el datagridview con el data set
        DGVRemito.DataSource = ds.Tables("Remito")
        conex.Close()
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        LLblRemito.Clear()
        'CmbInforme.Items.Clear()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click

    End Sub
End Class