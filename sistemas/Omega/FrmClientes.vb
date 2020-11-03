Imports System.Data.OleDb
Public Class FrmClientes
    Dim conex As New OleDbConnection(My.Settings.Nombre) 'conexion base de datos
    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox6_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNomApell.TextChanged

    End Sub

    Private Sub CmbEstado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEstado.Enter
        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta4 As String = "SELECT Id_Estado,Descripcion FROM Estado"
        Dim da4 As New OleDb.OleDbDataAdapter(consulta4, conex)
        Dim dt4 As New DataTable()
        da4.Fill(dt4)
        CmbEstado.ValueMember = "Id_Estado"
        CmbEstado.DisplayMember = "Descripcion"
        CmbEstado.DataSource = dt4
    End Sub

    Private Sub CmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbEstado.SelectedIndexChanged

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub CmbCategoriaFiscal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCategoriaFiscal.Enter
        'carga el combo box con los datos del idestado.pero indicando que muestre la descripcion del estado
        Dim consulta6 As String = "SELECT Id_Categoria_Fiscal,Descripcion FROM Categoria_Fiscal"
        Dim da6 As New OleDb.OleDbDataAdapter(consulta6, conex)
        Dim dt6 As New DataTable()
        da6.Fill(dt6)
        CmbCategoriaFiscal.ValueMember = "Id_Categoria_Fiscal"
        CmbCategoriaFiscal.DisplayMember = "Descripcion"
        CmbCategoriaFiscal.DataSource = dt6
    End Sub

    Private Sub CmbCategoriaFiscal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCategoriaFiscal.SelectedIndexChanged

      
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Dim fechactual As Date = Now.ToShortDateString
        'me muestra la fecha actual en el textbox
        TxtFchaAlta.Text = fechactual.ToString("dd/MM/yyyy")

        'se guarda la fecha  para de baja  en una variable para utilizar como fecha entrega. datetimepickert
        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim FechaBaja As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy






        Dim IDCliente As String = "Select max(Id_Cliente) from Clientes"

        conex.Open()
        Dim comna1 As New OleDbCommand(IDCliente, conex)
        Dim Nro_Cliente As Object = comna1.ExecuteScalar
        conex.Close()


        ' If cantcolum = 0 Then
        Nro_Cliente = Nro_Cliente + 1
        'me muestra en el textbox el id
        Dim resultado As String = CInt(Nro_Cliente)
        TxtNCliente.Text = resultado

        Dim Clientes As String = "Insert Into Clientes (Id_Cliente,Razon_Social,Fecha_Alta,Fecha_Baja,Cuit,Calle,Nro_Calle,Nom_Apellido,Email,Telefono,Telefono_Alternativo,Observaciones,Estado,Categoria_Fiscal,Localidad,Provincia,Pais,Codigo_Postal) values ('" & Nro_Cliente & "','" & TxtRazon_Social.Text & "','" & fechactual & "','" & FechaBaja & "','" & TxtCuit.Text & "','" & TxtCalle.Text & "','" & TxtNroCalle.Text & "', '" & TxtNomApell.Text & "','" & TxtEmail.Text & "','" & TxtTelefono.Text & "','" & TxtTelefAlt.Text & "','" & TxtObserv.Text & "', '" & CmbEstado.Text & "', '" & CmbCategoriaFiscal.Text & "', '" & CmbLocalidad.Text & "', '" & CmbProvincia.Text & "', '" & CmbPais.Text & "','" & TxtCPostal.Text & "')"

        Dim comando2 As New OleDbCommand(Clientes, conex)
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




    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        TxtNCliente.Clear()
        TxtRazon_Social.Clear()
        TxtCuit.Clear()
        TxtEmail.Clear()
        TxtCPostal.Clear()
        TxtCuit.Clear()
        TxtNomApell.Clear()
        TxtNroCalle.Clear()
        TxtObserv.Clear()
        TxtCalle.Clear()
        CmbEstado.ResetText()
        CmbCategoriaFiscal.ResetText()
        CmbLocalidad.ResetText()
        CmbProvincia.ResetText()
        CmbPais.ResetText()


    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click

        FrmbuscarClientes.Show()
        Me.Hide()
    End Sub

    Private Sub FrmClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class