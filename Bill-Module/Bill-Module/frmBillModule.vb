Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Security_Module
Public Class frmBillModule
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BaseConfig As clsDataWork_BaseConfig
    Private objTransaction_FinancialTransaction As clsTransaction_FinancialTransaction
    Private WithEvents objUserControl_BillTree As UserControl_BillTree
    Private WithEvents objUserControl_TransactionDetail As UserControl_TransactionDetail
    Private WithEvents objUserControl_Documents As UserControl_Documents
    Private objFrmArchive As frmArchive
    Private objFrmAuthenticate As frmAuthenticate
    Private objFrm_Name As frm_Name
    Private SplashScreen As SplashScreen_OntologyModule
    Private AboutBox As AboutBox_OntologyItem
    Private objOItem_Open As clsOntologyItem
    Private objOItem_FinancialTransaction As clsOntologyItem

    Private Sub new_Transaction(OItem_Partner As clsOntologyItem, boolContractee As Boolean, OItem_FinancialTransaction_Parent As clsOntologyItem) Handles objUserControl_BillTree.new_Transaction
        Dim objOItem_FinancialTransaction As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_RelationType As clsOntologyItem
        Dim objOItem_Currency As clsOntologyItem
        Dim objOItem_TaxRate As clsOntologyItem

        objFrm_Name = New frm_Name("New Transacon", _
                                   objLocalConfig.Globals)
        objFrm_Name.ShowDialog(Me)
        If objFrm_Name.DialogResult = Windows.Forms.DialogResult.OK Then
            objOItem_FinancialTransaction = New clsOntologyItem(objLocalConfig.Globals.NewGUID, _
                                                                objFrm_Name.Value1, _
                                                                objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                objLocalConfig.Globals.Type_Object)

            objOItem_Result = objTransaction_FinancialTransaction.save_001_FinancialTransaction(objOItem_FinancialTransaction)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_Result = objTransaction_FinancialTransaction.save_002_FinancialTransaction__TransactionDate(Now)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    objOItem_Currency = New clsOntologyItem(objDataWork_BaseConfig.OL_Currency(0).ID_Other, _
                                                            objDataWork_BaseConfig.OL_Currency(0).Name_Other, _
                                                            objLocalConfig.OItem_Class_Currencies.GUID, _
                                                            objLocalConfig.Globals.Type_Object)

                    objOItem_Result = objTransaction_FinancialTransaction.save_005_FinancialTransaction_To_Currency(objOItem_Currency)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objTransaction_FinancialTransaction.save_006_FinancialTransaction__gross(True)

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_TaxRate = New clsOntologyItem(objDataWork_BaseConfig.OL_TaxRate(0).ID_Other, _
                                                                   objDataWork_BaseConfig.OL_TaxRate(0).Name_Other, _
                                                                   objLocalConfig.OItem_Class_Tax_Rates.GUID, _
                                                                   objLocalConfig.Globals.Type_Object)

                            objOItem_Result = objTransaction_FinancialTransaction.save_007_FinancialTransaction_To_TaxRate(objOItem_TaxRate)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                If boolContractee = True Then
                                    objOItem_RelationType = objLocalConfig.OItem_RelationType_belonging_Contractee
                                Else
                                    objOItem_RelationType = objLocalConfig.OItem_RelationType_belonging_Contractor
                                End If
                                objOItem_Result = objTransaction_FinancialTransaction.save_008_FinancialTransaction_To_Partner(OItem_Partner, _
                                                                                                                               objOItem_RelationType)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    If Not OItem_FinancialTransaction_Parent Is Nothing Then
                                        objOItem_Result = objTransaction_FinancialTransaction.save_009_FinancialTransaction_To_FinancialTransaction(OItem_FinancialTransaction_Parent)
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

                                            objOItem_Result = objTransaction_FinancialTransaction.del_008_FinancialTransaction_To_Partner
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                objOItem_Result = objTransaction_FinancialTransaction.del_007_FinancialTransaction_To_TaxRate
                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                    objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                        objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                            objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                            objOItem_Result = objLocalConfig.Globals.LState_Error
                                        End If
                                    End If

                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objUserControl_BillTree.create_SubNode(objOItem_FinancialTransaction)
                                    End If
                                Else
                                    objOItem_Result = objTransaction_FinancialTransaction.del_007_FinancialTransaction_To_TaxRate
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                    objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                End If
                                            End If
                                        End If
                                    End If

                                End If
                            Else
                                objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                        End If
                                    End If
                                End If

                            End If


                        Else
                            objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                End If
                            End If


                            MsgBox("Die Transaktion konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                        End If

                    Else
                        objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                        End If

                        MsgBox("Die Transaktion konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                    End If


                Else
                    objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                    MsgBox("Die Transaktion konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("Die Transaktion konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub selected_FinancialTransaction(ByVal OItem_FinancialTransaction As clsOntologyItem) Handles objUserControl_BillTree.selected_FinancialTransactions
        objOItem_FinancialTransaction = OItem_FinancialTransaction

        configure_TabPages()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        objOItem_Open = objDataWork_BaseConfig.get_Data_BaseConfig()
        If objOItem_Open.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objFrmAuthenticate = New frmAuthenticate(objLocalConfig.Globals, True, False, frmAuthenticate.ERelateMode.NoRelate, True)
            objFrmAuthenticate.ShowDialog(Me)
            If objFrmAuthenticate.DialogResult = Windows.Forms.DialogResult.OK Then
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User
            Else
                Environment.Exit(0)
            End If


            objUserControl_BillTree = New UserControl_BillTree(objLocalConfig, objDataWork_BaseConfig)
            objUserControl_BillTree.Dock = DockStyle.Fill
            SplitContainer1.Panel1.Controls.Add(objUserControl_BillTree)

            objUserControl_TransactionDetail = New UserControl_TransactionDetail(objLocalConfig, objDataWork_BaseConfig)
            objUserControl_TransactionDetail.Dock = DockStyle.Fill
            TabPage_TransactionDetails.Controls.Add(objUserControl_TransactionDetail)

            objUserControl_Documents = New UserControl_Documents(objLocalConfig)
            objUserControl_Documents.Dock = DockStyle.Fill
            TabPage_Documents.Controls.Add(objUserControl_Documents)

            ToolStripTextBox_Database.Text = objLocalConfig.Globals.Index & "@" & objLocalConfig.Globals.Server

            configure_TabPages()
        End If
    End Sub

    Private Sub configure_TabPages()
        Select Case TabControl1.SelectedTab.Name
            Case TabPage_TransactionDetails.Name
                objUserControl_TransactionDetail.initialize(objOItem_FinancialTransaction)
            Case TabPage_Documents.Name
                objUserControl_Documents.initialize_Documents(objOItem_FinancialTransaction)
        End Select
    End Sub

    Private Sub set_DBConnection()
        objDataWork_BaseConfig = New clsDataWork_BaseConfig(objLocalConfig)
        objTransaction_FinancialTransaction = New clsTransaction_FinancialTransaction(objLocalConfig)
    End Sub

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Private Sub frmBillModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not SplashScreen Is Nothing Then
            SplashScreen.Close()
        End If
        If objOItem_Open.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Die Konfiguration konnte nicht geladen werden!", MsgBoxStyle.Exclamation)
            Me.Close()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        configure_TabPages()
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        AboutBox = New AboutBox_OntologyItem()
        AboutBox.ShowDialog(Me)
    End Sub

    Private Sub ArchiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchiveToolStripMenuItem.Click
        objFrmArchive = New frmArchive(objLocalConfig)
        objFrmArchive.ShowDialog(Me)
    End Sub
End Class
