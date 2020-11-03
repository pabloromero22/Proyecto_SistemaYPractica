Imports System.Data.OleDb.OleDbDataReader
Imports System.Data.OleDb.OleDbDataAdapter
Imports System.Data.OleDb
Public Class FrmABMStock
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    ' Public Sub cargarbd1()
    'Se utiliza para refrescar y cargar la tabla en el datagridview

    'Dim conex1 As New OleDb.OleDbConnection(" Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ever\Documents\Vb1\Trabajo_Integral_Prototipo\Trabajo_Integral_Prototipo\Gestion_Comercial.accdb")
    'se establece la coneccion y se crea la consulta
    '   Dim consulta1 As String = "SELECT * FROM Articulo_Stock"

    'se crea el comando que ejecutará la consulta sobre la bd
    ' Dim comando As New OleDbCommand(consulta, coneccion)

    ' Dim adaptador1 As New OleDb.OleDbDataAdapter(consulta1, conex)

    'se abre la coneccion y se crea el dataset
    ' conex.Open()
    '  Dim ds1 As New DataSet

    'se carga el data set con el adaptador
    ' adaptador1.Fill(ds1, "Articulo_Stock")

    'se carga el datagridview con el data set
    ' DgvArt_Stock.DataSource = ds1.Tables("Articulo_Stock")
    ' conex.Close()
    ' End Sub



    Private Sub FrmABMStock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' If (MsgBox("¿Esta seguro de salir?", vbCritical + vbYesNo) = vbYes) Then
        'End
        '  Else
        '  e.Cancel = True
        '  Frm_Inicio.Show()
        '  End If

    End Sub




    Private Sub FrmABMStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' cargarbd1()

        'carga el combo box con los datos del id_tipo_Articulo


        Dim consulta2 As String = "SELECT Id_Tipo,Descripcion FROM Tipo_Articulo"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbTipoArt.ValueMember = "Id_Tipo"
        CmbTipoArt.DisplayMember = "Descripcion"
        CmbTipoArt.DataSource = dt2


        'carga el combo box con los datos del id_Marca


        Dim consulta3 As String = "SELECT Id_Marca,Descripcion FROM Marca"
        Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        Dim dt3 As New DataTable()
        da3.Fill(dt3)
        CmbMarca.ValueMember = "Id_Marca"
        CmbMarca.DisplayMember = "Descripcion"
        CmbMarca.DataSource = dt3
        'carga el combo box con los datos del ¨Punto_Pedido


        Dim consulta4 As String = "SELECT Punto_Pedido FROM Punto_Pedido"
        Dim da4 As New OleDb.OleDbDataAdapter(consulta4, conex)
        Dim dt4 As New DataTable()
        da4.Fill(dt4)
        CmbPuntoP.ValueMember = "Punto_Pedido"
        CmbPuntoP.DisplayMember = "Punto_Pedido"
        CmbPuntoP.DataSource = dt4

        'carga el combo box con los datos del id_Estado

        Dim consulta5 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        Dim da5 As New OleDb.OleDbDataAdapter(consulta5, conex)
        Dim dt5 As New DataTable()
        da5.Fill(dt5)
        CmbEstado.ValueMember = "Id_Estado"
        CmbEstado.DisplayMember = "Descripcion"
        CmbEstado.DataSource = dt5

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido
        'Dim cantcolum As Integer = DgvArt_Stock.RowCount

        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString
        TxtFchaIngreso.Text = fechactual.ToString("dd/MM/yyyy")
        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim FechaBaja As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy

        'creo una variable para guardar datos de lo que ingreo desde un textbox 
        Dim CodBarra As Integer = (TxtCodArt.Text)
        Dim Descripcion As String = (TxtDescripcion.Text)
        Dim Cantidad As String = (TxtCantidad.Text)
        Dim Talle As String = (TxtTalle.Text)
        Dim Precio As Integer = (TxtPrecio.Text)

        Dim IDArticulo As String = "Select max(Id_Articulo) from Articulo_Stock"
        MessageBox.Show(IDArticulo)
        conex.Open()
        Dim comna1 As New OleDbCommand(IDArticulo, conex)
        Dim Num_Articulo As Object = comna1.ExecuteScalar
        conex.Close()
        MessageBox.Show(Num_Articulo)

        Num_Articulo = Num_Articulo + 1
        'me muestra en el textbox el id
        Dim resultado As String = CInt(Num_Articulo)
        TxtNroArticulo.Text = resultado



        'Se realiza el insert en la base de datos, utilizando el codigo de Pedido Reaprovisionamiento, la cantidad de columnas anterior y la variable con la fecha actual
        Dim consulta As String = "Insert Into Articulo_Stock (Id_Articulo,Fecha_Ingreso,Codigo_Barra_Articulo,Descripcion,Marca,Tipo,Cantidad,Talle,Estado,Precio,Punto_Pedido,Fecha_Baja) values ('" & Num_Articulo & "','" & fechactual & "','" & CodBarra & "', '" & Descripcion & "','" & CmbMarca.Text & "','" & CmbTipoArt.Text & "', '" & Cantidad & "','" & Talle & "','" & CmbEstado.Text & "','" & Precio & "','" & CmbPuntoP.Text & "','" & FechaBaja & "')"
        MessageBox.Show(consulta)
        Dim comando As New OleDbCommand(consulta, conex)
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
        'cargarbd1()
    End Sub

    Private Sub CmbTipoArt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoArt.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mostrar.Click
        FormBuscarArticulo.Show()
        Me.Hide()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        'limpia lo que esta en el textbox

        TxtNroArticulo.Clear()
        TxtCodArt.Clear()
        TxtDescripcion.Clear()
        TxtCantidad.Clear()
        TxtPrecio.Clear()
        TxtFchaIngreso.Clear()
        TxtTalle.Clear()
        TxtNroArticulo.Focus()


    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

End Class