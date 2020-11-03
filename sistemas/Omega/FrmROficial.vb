Imports System.Data.OleDb
Public Class FrmROficial
    Dim conex As New OleDbConnection(My.Settings.Nombre)
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub FrmROficial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CmbNCheque_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbNCheque.Enter
        Dim consulta2 As String = "SELECT Id_Cheque FROM Cheque"
        Dim da2 As New OleDb.OleDbDataAdapter(consulta2, conex)
        Dim dt2 As New DataTable()
        da2.Fill(dt2)
        CmbNCheque.ValueMember = "Id_Cheque"
        CmbNCheque.DisplayMember = "Id_Cheque"
        CmbNCheque.DataSource = dt2
    End Sub

    Private Sub CmbNCheque_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbNCheque.SelectedIndexChanged

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

    Private Sub BtnTraer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTraer.Click


        'Se guarda la fecha actual en una variable para utilizarla como fecha de emision 
        Dim fechactual As Date = Now.ToShortDateString

        TxtFchaEmision.Text = fechactual.ToString("dd/MM/yyyy")





        'Se Busca el registro del orden por el valor del id_Orden Pago para saber el banco y guardarlo en una variable
        Dim text1 As String = CInt(CmbNCheque.Text)
        MessageBox.Show(text1)
        Dim banc As String = "Select Banco from Cheque Where Id_Cheque  = " & text1 & ""
        MessageBox.Show(banc)
        conex.Open()
        Dim comna1 As New OleDbCommand(banc, conex)
        Dim reader1 As OleDbDataReader = comna1.ExecuteReader(CommandBehavior.CloseConnection)
        reader1.Read()
        Dim Banco As String = Convert.ToString(reader1.Item("Banco"))
        conex.Close()
        MessageBox.Show(Banco)

        CmbBanco.Text = Banco


        'Se Busca el registro del orden por el valor del id_factura_Compra para saber el Id:Proveedor y guardarlo en una variable
        Dim text4 As String = CInt(CmbNCheque.Text)
        MessageBox.Show(text4)
        Dim NomProveedor As String = "Select Nom_Proveedor from Cheque Where Id_Cheque  = " & text4 & ""
        MessageBox.Show(NomProveedor)
        conex.Open()
        Dim comna4 As New OleDbCommand(NomProveedor, conex)
        Dim reader4 As OleDbDataReader = comna4.ExecuteReader(CommandBehavior.CloseConnection)
        reader4.Read()
        Dim Nom_Proveedor As String = Convert.ToString(reader4.Item("Nom_Proveedor"))
        conex.Close()
        MessageBox.Show(Nom_Proveedor)

        CmbProveedor.Text = Nom_Proveedor



        'Se Busca el registro del orden por el valor del id_factura_Compra para saber el Id:Proveedor y guardarlo en una variable
        Dim text3 As String = CInt(CmbNCheque.Text)
        MessageBox.Show(text3)
        Dim Importetotal As String = "Select Importe_Total from Cheque Where Id_Cheque  = " & text3 & ""
        MessageBox.Show(Importetotal)
        conex.Open()
        Dim comna3 As New OleDbCommand(Importetotal, conex)
        Dim reader3 As OleDbDataReader = comna3.ExecuteReader(CommandBehavior.CloseConnection)
        reader3.Read()
        Dim Importe_Total As String = Convert.ToString(reader3.Item("Importe_Total"))
        conex.Close()
        MessageBox.Show(Importe_Total)

        TxtImporte.Text = Importe_Total


    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click


        Dim miFecha As Date = Format(CalendarioDate.Value.ToShortDateString, "Short Date") ' formato corto

        Dim Fecha_Recibo As Date = miFecha.ToString("dd/MM/yyyy") 'solo que me muestre el dd/mm/yyyy






        Dim IDReciboOficial As String = "Select max(Id_Recibo_Oficial) from Recibo_Oficial"
        MessageBox.Show(IDReciboOficial)
        'If CDbl(IDOrdenPago) = 0 Then
        'IDOrdenPago = IDOrdenPago + 1
        ' Else

        conex.Open()
        Dim comna8 As New OleDbCommand(IDReciboOficial, conex)
        Dim Nro_Recibo_Oficial As Object = comna8.ExecuteScalar
        conex.Close()
        MessageBox.Show(Nro_Recibo_Oficial)





        'If cantcolum = 0 Then
        Nro_Recibo_Oficial = Nro_Recibo_Oficial + 1
        TxtNROficial.Text = Nro_Recibo_Oficial  ' el nro de informe me muestra en el txt


        Dim Recibo_Oficial As String = "Insert Into Recibo_Oficial (Id_Recibo_Oficial,Fecha_Emision,Fecha_Recibo,Id_Cheque,Nom_Proveedor,Banco,Importe_Total,Estado) values ('" & Nro_Recibo_Oficial & "','" & TxtFchaEmision.Text & "','" & Fecha_Recibo & "','" & CmbNCheque.Text & "','" & CmbProveedor.Text & "','" & CmbBanco.Text & "','" & TxtImporte.Text & "','" & CmbEstado.Text & "')"
        MessageBox.Show(Recibo_Oficial)
        Dim comando2 As New OleDbCommand(Recibo_Oficial, conex)
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

        '  End If


        'se establece la coneccion y se crea la consulta
        Dim consulta As String = "SELECT * FROM Recibo_Oficial "

        'se crea el comando que ejecutará la consulta sobre la bd
        'dim comando as new oledbcommand(consulta, coneccion)

        Dim adaptador As New OleDb.OleDbDataAdapter(consulta, conex)

        'se abre la coneccion y se crea el dataset
        conex.Open()
        Dim ds As New DataSet

        'se carga el data set con el adaptador
        adaptador.Fill(ds, "Recibo_Oficial")

        'se carga el datagridview con el data set
        DgvROficial.DataSource = ds.Tables("Recibo_Oficial")
        conex.Close()





    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        conex.Close()
        Me.Close()
        Frm_Inicio.Show()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click

        Dim consultar As String
        ' Dim Consultar1 As String

        Dim lista As Byte
        Dim adaptador1 As New OleDbDataAdapter
        Dim registros1 As New DataSet
        If TxtNROficial.Text <> "" Then
            Dim resultado As String = CInt(TxtNROficial.Text)
            consultar = " select * from Recibo_Oficial where Id_Recibo_Oficial = " & resultado & " "
            MessageBox.Show(consultar)
            adaptador1 = New OleDbDataAdapter(consultar, conex)
            registros1 = New DataSet
            adaptador1.Fill(registros1, "Recibo_Oficial")
            lista = registros1.Tables("Recibo_Oficial").Rows.Count
            If lista <> 0 Then
                DgvROficial.DataSource = registros1
                DgvROficial.DataMember = "Recibo_Oficial"


            Else
                MessageBox.Show("No hay registro")
                TxtNROficial.Clear()
                TxtNROficial.Focus()




            End If
        End If



    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click

        TxtNROficial.Clear()
        TxtFchaEmision.Clear()
        TxtNROficial.Clear()
        TxtImporte.Clear()
        CmbBanco.ResetText()
        CmbEstado.ResetText()
        CmbNCheque.ResetText()
        CmbProveedor.ResetText()
        TxtNROficial.Focus()


    End Sub
End Class