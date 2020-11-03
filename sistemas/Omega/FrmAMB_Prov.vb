Imports System.Data.OleDb
Public Class FrmAMB_PROV
    Public DGVProveedor
    Dim conex As New OleDbConnection(My.Settings.Nombre) 'conexion base de datos
    Public Sub cargarbdProveedor()

        'se establece la coneccion y se crea la consulta
        ' Dim consulta As String = "SELECT * FROM Proveedores;"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        ' Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        ' conex.Open()
        '  Dim ds As New DataSet

        'se carga el data set con el adaptador
        'adaptador.Fill(ds, "Proveedores")

        'se carga el datagridview con el data set
        'DGVProveedor.DataSource = ds.Tables("Proveedores")
        'conex.Close()
    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub FrmAMB_PROV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbdProveedor()


        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta4 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        Dim da4 As New OleDb.OleDbDataAdapter(consulta4, conex)
        Dim dt4 As New DataTable()
        da4.Fill(dt4)
        CmbEstado.ValueMember = "Id_Estado"
        CmbEstado.DisplayMember = "Descripcion"
        CmbEstado.DataSource = dt4

        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta2 As String = "SELECT Id_Localidad,Nom_Localidad FROM Localidad"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbLocalidad.ValueMember = "Id_Localidad"
        CmbLocalidad.DisplayMember = "Nom_Localidad"
        CmbLocalidad.DataSource = dt2




        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta3 As String = "SELECT Id_Provincia,Descripcion FROM Provincia"
        Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        Dim dt3 As New DataTable()
        da3.Fill(dt3)
        CmbProv.ValueMember = "Id_Provincia"
        CmbProv.DisplayMember = "Descripcion"
        CmbProv.DataSource = dt3


        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta5 As String = "SELECT Id_Pais,Descripcion FROM Pais"
        Dim da5 As New OleDb.OleDbDataAdapter(consulta5, conex)
        Dim dt5 As New DataTable()
        da5.Fill(dt5)
        CmbPais.ValueMember = "Id_Pais"
        CmbPais.DisplayMember = "Descripcion"
        CmbPais.DataSource = dt5


        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta6 As String = "SELECT Id_Categoria_Fiscal,Descripcion FROM Categoria_Fiscal"
        Dim da6 As New OleDb.OleDbDataAdapter(consulta6, conex)
        Dim dt6 As New DataTable()
        da6.Fill(dt6)
        CmbCategoriaFiscal.ValueMember = "Id_Categoria_Fiscal"
        CmbCategoriaFiscal.DisplayMember = "Descripcion"
        CmbCategoriaFiscal.DataSource = dt6

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click



        'Se cuentan la cantidad de filas para guardar el numero en una variable que será el id del pedido

        ' Dim cantcolum As Integer = DGVPro.RowCount

        'cantcolum = cantcolum + 1
        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString
        'me muestra la fecha actual en el textbox
        TxtFchAlta.Text = fechactual.ToString("dd/MM/yyyy")

        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(calendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim FechaBaja As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy
        'se ingresa la razon Social
        Dim RazonSocial As String = (TxtRazonSocial.Text)
        Dim CuilProv As String = CInt(TxtCuil.Text)
        Dim Calle As String = (TxtCalle.Text)
        Dim Nro_Calle As String = CInt(TxtNroCalle.Text)
        ' Dim Localidad As String = (TxtLocalidad.Text)
        Dim Email As String = (TxtEmail.Text)
        Dim telefono As String = CInt(TxtTelef.Text)
        Dim TeleAlt As String = CInt(TxtTelefAl.Text)
        Dim Observacion As String = (TxtObserv.Text)
        Dim CodPostal As String = CInt(TxtCodPostal.Text)

        Dim IDProveedor As String = "Select max(Id_Proveedor) from Proveedores"
        MessageBox.Show(IDProveedor)
        conex.Open()
        Dim comna1 As New OleDbCommand(IDProveedor, conex)
        Dim Num_Proveedor As Object = comna1.ExecuteScalar
        conex.Close()
        MessageBox.Show(Num_Proveedor)

        ' If cantcolum = 0 Then
        Num_Proveedor = Num_Proveedor + 1
        'me muestra en el textbox el id
        Dim resultado As String = CInt(Num_Proveedor)
        TxtProve.Text = resultado

        Dim Proveedores As String = "Insert Into Proveedores (Id_Proveedor,Razon_Social,Fecha_Alta,Fecha_Baja,Cuit,Calle,Nro_Calle,Email,Telefono,Telefono_Alternativo,Observaciones,Id_Estado, Id_Categoria_Fiscal,Id_Localidad,Id_Provincia,Id_Pais,Codigo_Postal) values ('" & Num_Proveedor & "','" & RazonSocial & "','" & fechactual & "','" & FechaBaja & "','" & CuilProv & "','" & Calle & "','" & Nro_Calle & "','" & Email & "','" & telefono & "','" & TeleAlt & "','" & Observacion & "', '" & CmbEstado.Text & "', '" & CmbCategoriaFiscal.Text & "', '" & CmbLocalidad.Text & "', '" & CmbProv.Text & "', '" & CmbPais.Text & "','" & CodPostal & "')"
        MessageBox.Show(Proveedores)
        Dim comando2 As New OleDbCommand(Proveedores, conex)
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


        cargarbdProveedor()



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cargarbdProveedor()
        'se establece la coneccion y se crea la consulta
        '   Dim consulta As String = "SELECT * FROM Proveedores;"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        '   Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        '   conex.Open()
        '   Dim ds As New DataSet

        'se carga el data set con el adaptador
        '   adaptador.Fill(ds, "Proveedores")

        'se carga el datagridview con el data set
        'DGVPro.DataSource = ds.Tables("Proveedores")
        '   conex.Close()



        FrmAdmProveedor.Show()
        Me.Hide()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        TxtProve.Clear()
        TxtRazonSocial.Clear()
        TxtCalle.Clear()
        TxtCodPostal.Clear()
        TxtCuil.Clear()
        TxtEmail.Clear()
        TxtObserv.Clear()
        TxtNroCalle.Clear()
        TxtTelef.Clear()
        TxtTelefAl.Clear()
        TxtProve.Focus()


    End Sub

    Private Sub DGVProveedor_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
       
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub CmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEstado.SelectedIndexChanged

    End Sub
End Class