
Imports System.Data.OleDb
Public Class FrmABMInventario
    Dim adaptador1 As New OleDbDataAdapter
    Dim registros1 As New DataSet
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Public Sub cargarbd1()
        'Se utiliza para refrescar y cargar la tabla en el datagridview

        'Dim conex1 As New OleDb.OleDbConnection(" Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ever\Documents\Vb1\Trabajo_Integral_Prototipo\Trabajo_Integral_Prototipo\Gestion_Comercial.accdb")
        'se establece la coneccion y se crea la consulta
        Dim consulta1 As String = "SELECT * FROM Articulo_Inventario"

        'se crea el comando que ejecutará la consulta sobre la bd
        ' Dim comando As New OleDbCommand(consulta, coneccion)

        Dim adaptador1 As New OleDb.OleDbDataAdapter(consulta1, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds1 As New DataSet

        'se carga el data set con el adaptador
        adaptador1.Fill(ds1, "Articulo_Inventario")

        'se carga el datagridview con el data set
        DgvAdmInve.DataSource = ds1.Tables("Articulo_Inventario")
        conex.Close()




    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub





    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        TxtNroBienUso.Clear()
        TxtDescrBien.Clear()
        TxtCantidad.Clear()
        TxtFchIngreso.Clear()
        TxtNroBienUso.Focus()
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtNroBienUso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroBienUso.TextChanged

    End Sub

    Private Sub FrmABMInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbd1()
        Dim consulta5 As String = "SELECT Descripcion FROM Estado"
        Dim da5 As New OleDb.OleDbDataAdapter(consulta5, conex)
        Dim dt5 As New DataTable()
        da5.Fill(dt5)
        CmbEstado.ValueMember = "Descripcion"
        CmbEstado.DisplayMember = "Descripcion"
        CmbEstado.DataSource = dt5


        Dim consulta4 As String = "SELECT Descripcion FROM Tipo_Articulo_Bien_Uso"
        Dim da4 As New OleDb.OleDbDataAdapter(consulta4, conex)
        Dim dt4 As New DataTable()
        da4.Fill(dt4)
        CmbTipoBien.ValueMember = "Descripcion"
        CmbTipoBien.DisplayMember = "Descripcion"
        CmbTipoBien.DataSource = dt4
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString
        TxtFchIngreso.Text = fechactual.ToString("dd/MM/yyyy")
        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim FechaBaja As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre
        'creo variable donde me guardara lo que ingreso desde un textbox
        Dim Descripcion As String = TxtDescrBien.Text
        Dim Cantidad As Integer = TxtCantidad.Text


        'Realiza la consulta  donde pido que que mustre el id_Bien
        Dim IDBienUso As String = "Select max(Id_Bien_Uso) from Articulo_Inventario"
        MessageBox.Show(IDBienUso)
        conex.Open()
        Dim comna1 As New OleDbCommand(IDBienUso, conex)
        Dim Num_Bien_Uso As Object = comna1.ExecuteScalar
        conex.Close()
        MessageBox.Show(Num_Bien_Uso)

        Num_Bien_Uso = Num_Bien_Uso + 1
        'me muestra en el textbox el id
        Dim resultado As String = CInt(Num_Bien_Uso)
        TxtNroBienUso.Text = resultado

        Dim consulta As String = "Insert Into Articulo_Inventario (Id_Bien_Uso,Fecha_Ingreso,Fecha_Baja,Descripcion,Cantidad,Id_Estado,Id_tipo) values ('" & Num_Bien_Uso & "', '" & fechactual & "','" & FechaBaja & "','" & Descripcion & "','" & Cantidad & "','" & CmbEstado.Text & "','" & CmbTipoBien.Text & "')"
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
        cargarbd1()





    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        ' se busca el registro realizando la consulta comparando con textbuscar
        Dim consultar As String
        Dim lista As Byte
        If TxtNroBienUso.Text <> "" Then
            Dim resultado As String = CInt(TxtNroBienUso.Text)
            consultar = " select * from Articulo_Inventario where Id_Bien_uso = " & resultado & " "
            MessageBox.Show(consultar)
            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Articulo_Stock")
            lista = registros1.Tables("Articulo_Stock").Rows.Count
            If lista <> 0 Then
                DgvAdmInve.DataSource = registros1
                DgvAdmInve.DataMember = "Articulo_Stock"
            Else
                MessageBox.Show("No hay registro")
                TxtNroBienUso.Clear()
                TxtNroBienUso.Focus()
            End If

        End If
    End Sub
End Class