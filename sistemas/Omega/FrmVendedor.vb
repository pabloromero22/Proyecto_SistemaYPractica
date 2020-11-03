Imports System.Data.OleDb
Public Class FrmVendedor
    Dim conex As New OleDbConnection(My.Settings.Nombre)

    Public Sub cargarbdVendedor()
        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Vendedores"

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Vendedores")

        'se carga el datagridview con el data set
        DgvVendedores.DataSource = ds.Tables("Vendedores")
        conex.Close()

    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFechaAlta.TextChanged

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub

    Private Sub FrmVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbdVendedor()


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

    Private Sub CmbLocalidad_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbLocalidad.Enter
        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta2 As String = "SELECT Id_Localidad,Nom_Localidad FROM Localidad"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbLocalidad.ValueMember = "Id_Localidad"
        CmbLocalidad.DisplayMember = "Nom_Localidad"
        CmbLocalidad.DataSource = dt2
    End Sub

    Private Sub CmbLocalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLocalidad.SelectedIndexChanged

    End Sub

    Private Sub CmbProvincia_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbProvincia.Enter
        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta3 As String = "SELECT Id_Provincia,Descripcion FROM Provincia"
        Dim da3 As New OleDb.OleDbDataAdapter(consulta3, conex)
        Dim dt3 As New DataTable()
        da3.Fill(dt3)
        CmbProvincia.ValueMember = "Id_Provincia"
        CmbProvincia.DisplayMember = "Descripcion"
        CmbProvincia.DataSource = dt3
    End Sub

    Private Sub CmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProvincia.SelectedIndexChanged

    End Sub

    Private Sub CmbPais_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPais.Enter
        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta5 As String = "SELECT Id_Pais,Descripcion FROM Pais"
        Dim da5 As New OleDb.OleDbDataAdapter(consulta5, conex)
        Dim dt5 As New DataTable()
        da5.Fill(dt5)
        CmbPais.ValueMember = "Id_Pais"
        CmbPais.DisplayMember = "Descripcion"
        CmbPais.DataSource = dt5
    End Sub

    Private Sub CmbPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPais.SelectedIndexChanged

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Dim fechactual As Date = Now.ToShortDateString
        'me muestra la fecha actual en el textbox
        TxtFechaAlta.Text = fechactual.ToString("dd/MM/yyyy")

        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(calendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim FechaBaja As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy



        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim FechaNac As Date = Format(FechaNacDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Nac As Date = FechaNac.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy





        Dim IDvendedor As String = "Select max(Id_Vendedor) from Vendedores"

        conex.Open()
        Dim comna1 As New OleDbCommand(IDvendedor, conex)
        Dim Nro_Vendedor As Object = comna1.ExecuteScalar
        conex.Close()


        ' If cantcolum = 0 Then
        Nro_Vendedor = Nro_Vendedor + 1
        'me muestra en el textbox el id
        Dim resultado As String = CInt(Nro_Vendedor)
        TxtVendedor.Text = resultado

        Dim Vendedores As String = "Insert Into Vendedores (Id_Vendedor,Fecha_Alta,Fecha_Baja,Nro_Legajo,Calle,Nro_Calle,Nom_Apellido,DNI,Fecha_Nac,Estado,Localidad,Provincia,Pais,Codigo_Postal) values ('" & Nro_Vendedor & "','" & fechactual & "','" & FechaBaja & "','" & TxtNLegajo.Text & "','" & TxtCalle.Text & "','" & TxtNrCalle.Text & "', '" & TxtNomApell.Text & "','" & TxtDni.Text & "','" & Fecha_Nac & "', '" & CmbEstado.Text & "','" & CmbLocalidad.Text & "', '" & CmbProvincia.Text & "', '" & CmbPais.Text & "','" & TxtCPostal.Text & "')"

        Dim comando2 As New OleDbCommand(Vendedores, conex)
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


        'Resfreca datagridview
        cargarbdVendedor()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        TxtVendedor.Clear()
        TxtNLegajo.Clear()
        TxtCalle.Clear()
        TxtCPostal.Clear()
        TxtDni.Clear()
        TxtFechaAlta.Clear()
        TxtNomApell.Clear()
        TxtNrCalle.Clear()
        CmbEstado.ResetText()
        CmbLocalidad.ResetText()
        CmbProvincia.ResetText()
        CmbPais.ResetText()

    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim consultar As String
        Dim lista As Byte
        Dim adaptador1 As New OleDbDataAdapter
        Dim registros1 As New DataSet
        If TxtVendedor.Text <> "" Then
            Dim resultado As String = CInt(TxtVendedor.Text)
            consultar = " select * from Vendedores where Id_Vendedor = " & resultado & " "

            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Vendedores")
            lista = registros1.Tables("Vendedores").Rows.Count
            If lista <> 0 Then
                DgvVendedores.DataSource = registros1
                DgvVendedores.DataMember = "Vendedores"
            Else
                MessageBox.Show("No hay registro")
                TxtVendedor.Clear()
                TxtVendedor.Focus()
            End If

        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class