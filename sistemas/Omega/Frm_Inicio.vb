Imports System
Imports System.Data
Imports System.Data.OleDb


    Public Class Frm_Inicio
    ' Dim mystr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Gestion_Comercial.accdb"
    ' Dim conex As New OleDbConnection(mystr)
        Private Sub AlnacenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlnacenesToolStripMenuItem.Click

        End Sub

        Private Sub ProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub PedidoReaprovisionamientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidoReaprovisionamientoToolStripMenuItem.Click
            FrmPR.Show()
        Me.Hide()

    End Sub

    Private Sub SolicitudComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudComprasToolStripMenuItem.Click
        FrmSC.Show()
        Me.Hide()

    End Sub

    Private Sub PedidoDeCotizaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidoDeCotizaciónToolStripMenuItem.Click
        FrmPCOT.Show()
        Me.Hide()

    End Sub

    Private Sub OrdenCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdenCompraToolStripMenuItem.Click
        FrmOC.Show()
        Me.Hide()
    End Sub

    Private Sub InformeRecepciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformeRecepciónToolStripMenuItem.Click
        FrmIR.Show()
        Me.Hide()
    End Sub

    Private Sub FacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmFactura.Show()
        Me.Hide()
    End Sub

    Private Sub AMBProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AMBProveedorToolStripMenuItem.Click
        FrmAMB_PROV.Show()
        Me.Hide()
    End Sub

    Private Sub CtaCteProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtaCteProveedorToolStripMenuItem.Click
        FrmCtaCte_Prov.Show()
        Me.Hide()
    End Sub

    Private Sub ABMStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ABMStockToolStripMenuItem.Click
        FrmABMStock.Show()
        Me.Hide()
    End Sub

    Private Sub ABMInventariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ABMInventariosToolStripMenuItem.Click
        FrmABMInventario.Show()
        Me.Hide()
    End Sub

    Private Sub NotaDeCreditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotaDeCreditoToolStripMenuItem.Click
        FrmNotaCredito.Show()
        Me.Hide()
    End Sub

    Private Sub OrdenDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdenDePagoToolStripMenuItem.Click
        FrmOPago.Show()
        Me.Hide()
    End Sub

    Private Sub ChequeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChequeToolStripMenuItem.Click
        FrmCheque.Show()
        Me.Hide()
    End Sub

    Private Sub ReciboOficialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReciboOficialToolStripMenuItem.Click
        FrmROficial.Show()
        Me.Hide()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasToolStripMenuItem.Click

    End Sub

    Private Sub ComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComprasToolStripMenuItem.Click

    End Sub

    Private Sub RemitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemitoToolStripMenuItem.Click
        FrmRemito.Show()
        Me.Hide()
    End Sub

    Private Sub Frm_Inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DevolucionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionesToolStripMenuItem.Click
        FrmDV.Show()
        Me.Hide()
    End Sub

    Private Sub FacturaToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaToolStripMenuItem.Click
        FrmFactura.Show()
        Me.Hide()
    End Sub

    Private Sub ABMClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ABMClienteToolStripMenuItem.Click
        FrmClientes.Show()
        Me.Hide()
    End Sub

    Private Sub ABMNotaDePedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ABMNotaDePedidoToolStripMenuItem.Click
        FrmNotaPedido.Show()
        Me.Hide()
    End Sub

    Private Sub ABMVendedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ABMVendedoresToolStripMenuItem.Click
        FrmVendedor.Show()
        Me.Hide()
    End Sub

    Private Sub ABMFacturaClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ABMFacturaClientesToolStripMenuItem.Click
        FrmFactura_Venta.Show()
        Me.Hide()
    End Sub
End Class