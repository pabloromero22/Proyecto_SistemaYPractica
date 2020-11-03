Imports System.Data.OleDb.OleDbDataReader
Imports System.Data.OleDb.OleDbDataAdapter

Imports System.Data.OleDb

Public Class FrmSC
    Dim conex As New OleDbConnection(My.Settings.Nombre)

    Public Sub cargarbd()
        ''Se utiliza para refrescar y cargar la tabla en el datagridview


        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Solicitud_Compra"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Solicitud_Compra")

        'se carga el datagridview con el data set
        DGV_SC.DataSource = ds.Tables("Solicitud_Compra")
        conex.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter
        '  Dim consulta As String = "SELECT Descripcion FROM Articulo_Inventario"
        '  Dim da As New OleDbDataAdapter(consulta, conex)
        '  Dim dt As New DataTable()
        '  da.Fill(dt)
        '  CmbBien_Uso.ValueMember = "Descripcion"
        ' CmbBien_Uso.DisplayMember = "Descripcion"
        ' CmbBien_Uso.DataSource = dt
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNuevo.Click

        TxtSolicitud.Clear()
        TxtCantidad.Clear()
        TxtEmision.Clear()
        TxtDetalle.Clear()
        TxtSolicitud.Focus()





    End Sub

    Private Sub FrmSC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbd()
        Dim consulta As String = "SELECT Descripcion FROM Articulo_Inventario"
        Dim da As New OleDbDataAdapter(consulta, conex)
        Dim dt As New DataTable()
        da.Fill(dt)
        CmbBien_Uso.ValueMember = "Descripcion"
        CmbBien_Uso.DisplayMember = "Descripcion"
        CmbBien_Uso.DataSource = dt

        Dim consulta7 As String = "SELECT Descripcion FROM Estado"
        Dim da7 As New OleDb.OleDbDataAdapter(consulta7, conex)
        Dim dt7 As New DataTable()
        da7.Fill(dt7)
        CmbEstado.ValueMember = "Descripcion"
        CmbEstado.DisplayMember = "Descripcion"
        CmbEstado.DataSource = dt7



        Dim consulta5 As String = "SELECT Descripcion FROM Sector"
        Dim da5 As New OleDb.OleDbDataAdapter(consulta5, conex)
        Dim dt5 As New DataTable()
        da5.Fill(dt5)
        CmbSector.ValueMember = "Descripcion"
        CmbSector.DisplayMember = "Descripcion"
        CmbSector.DataSource = dt5


    End Sub

    Private Sub CmbSector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSector.SelectedIndexChanged
        
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' se busca el registro realizando la consulta comparando con textbuscar
        Dim consultar As String
        Dim adaptador1 As New OleDbDataAdapter
        Dim registros1 As New DataSet
        Dim lista As Byte
        If TxtSolicitud.Text <> "" Then
            Dim resultado As String = CInt(TxtSolicitud.Text)
            consultar = " select * from Solicitud_Compra where Id_Solicitud_Compra= " & resultado & " "
            MessageBox.Show(consultar)
            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "SoLicitud_Compra")
            lista = registros1.Tables("Solicitud_Compra").Rows.Count
            If lista <> 0 Then
                DGV_SC.DataSource = registros1
                DGV_SC.DataMember = "Solicitud_Compra"
            Else
                MessageBox.Show("No hay registro")
                TxtSolicitud.Clear()
                TxtSolicitud.Focus()
            End If

        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Dim fechactual As Date = Now.ToShortDateString
        'Dim cantrows As Integer = DGV_SC.RowCount
        TxtEmision.Text = fechactual
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Requeri As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy

        'creo variable donde me guardara lo que ingreso desde un textbox
        Dim Detalle As String = TxtDetalle.Text
        Dim Cantidad As Integer = TxtCantidad.Text


        Dim text As String = CmbBien_Uso.Text
        MessageBox.Show(text)
        Dim descripcion As String = "Select Id_Bien_Uso from Articulo_Inventario Where Descripcion = '" & text & "'"
        MessageBox.Show(descripcion)
        conex.Open()
        Dim comna1 As New OleDbCommand(descripcion, conex)
        Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
        reader1.Read()
        Dim Id_Bien_Uso As String = Convert.ToString(reader1.Item("Id_Bien_Uso"))
        conex.Close()
        MessageBox.Show(Id_Bien_Uso)








        Dim IDsoc As String = "Select max(Id_Solicitud_Compra) from Solicitud_Compra"
        MessageBox.Show(IDsoc)
        conex.Open()
        Dim comna6 As New OleDbCommand(IDsoc, conex)
        Dim Nro_Sc As Object = comna6.ExecuteScalar
        conex.Close()
        MessageBox.Show(Nro_Sc)


        ' If cantrows = 0 Then
        Nro_Sc = Nro_Sc + 1
        'me muestra en el textbox el id
        Dim resultado As String = CInt(Nro_Sc)
        TxtSolicitud.Text = resultado

        Dim Solicitud_Compra As String = "Insert Into Solicitud_Compra (Id_Solicitud_Compra,Descripcion,Id_Bien_Uso,Fecha_Emision,Fecha_Requerimiento,Sector,Id_Estado,Detalle,Cantidad) values ('" & Nro_Sc & "','" & CmbBien_Uso.Text & "','" & Id_Bien_Uso & "','" & fechactual & "','" & Fecha_Requeri & "','" & CmbSector.Text & "','" & CmbEstado.Text & "','" & Detalle & "', '" & Cantidad & "')"
        MessageBox.Show(Solicitud_Compra)
        Dim comando2 As New OleDbCommand(Solicitud_Compra, conex)
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


        cargarbd()
    End Sub
End Class