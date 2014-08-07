Imports Ontology_Module
Imports Structure_Module

Public Class UserControl_History
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_LogHistory As clsDataWork_LogHistory
    Private logRelations As List(Of clsLogRelation)

    Public Event SelectedRow()


    Public ReadOnly Property SelectedRows() As DataGridViewSelectedRowCollection
        Get
            Return DataGridView_History.SelectedRows
        End Get
    End Property

    Public Sub New(LocalConfig As clsLocalConfig)

        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)

        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = New clsLocalConfig(Globals)

        Initialize()
    End Sub

    Private sub Initialize()
        objDataWork_LogHistory = new clsDataWork_LogHistory(objLocalConfig)
    End Sub

    Public sub Initialize_History(optional LogRelations As List(Of clsLogRelation) = Nothing)
        Me.logRelations = LogRelations

        

        DataGridView_History.DataSource = Nothing

        Timer_Thread.Stop()
        If Not LogRelations Is nothing Then
            Dim objOItem_Result = objDataWork_LogHistory.GetData_History(LogRelations)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Timer_Thread.Start()
                
            Else 
                MsgBox("Die Logeinträge konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If    
        End If
        
    End Sub

    Private Sub Timer_Thread_Tick( sender As Object,  e As EventArgs) Handles Timer_Thread.Tick
        If objDataWork_LogHistory.OItem_Result_Data.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Timer_Thread.Stop()
            ToolStripProgressBar_History.Value = 0
            DataGridView_History.DataSource = New SortableBindingList(Of clsLogEntry) (objDataWork_LogHistory.LogEntryList.OrderBy(Function(log) log.DateTimeStamp))
            For Each col As DataGridViewColumn In DataGridView_History.Columns

                If col.DataPropertyName = "Name_LogState" Or 
                   col.DataPropertyName = "Name_User" Or 
                   col.DataPropertyName = "DateTimeStamp" Or 
                   col.DataPropertyName = "Message" Then
                    col.Visible = True

                Else
                    col.Visible = False
                End If
                
            Next
        ElseIf objDataWork_LogHistory.OItem_Result_Data.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            Timer_Thread.Stop()
            ToolStripProgressBar_History.Value = 0
            MsgBox("Die Daten konnten nicht ermittelt werden",MsgBoxStyle.Exclamation)
        Else
            ToolStripProgressBar_History.Value = 50
        End If
    End Sub

    Private Sub DataGridView_History_SelectionChanged( sender As Object,  e As EventArgs) Handles DataGridView_History.SelectionChanged
        RaiseEvent SelectedRow()
    End Sub
End Class
