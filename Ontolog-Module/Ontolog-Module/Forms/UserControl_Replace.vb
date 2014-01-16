Imports OntologyClasses.BaseClasses
Imports System.Text.RegularExpressions
Imports Structure_Module
Imports System.Threading

Public Class UserControl_Replace
    Public Property ItemList As List(Of clsOntologyItem)

    Private objThreadReplace As Threading.Thread

    Private strSearch As String
    Private strReplace As String

    Private boolReplaced As Boolean

    Public Event Replaced

    Public Sub New(itemList As List(Of clsOntologyItem))
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        Me.ItemList = itemList

        Initialize()
    End Sub

    Private sub Initialize()
        
        DataGridView_Items.DataSource = New SortableBindingList(Of clsOntologyItem)(ItemList)

        For Each column As DataGridViewColumn In DataGridView_Items.Columns
            If column.DataPropertyName="Name" Then
                column.Visible = True
                column.Width = 300
            ElseIf column.DataPropertyName="Additional1" then
                column.Visible = True
                column.HeaderText = "Replaced Name"
                column.Width = 300
            Else 
                column.Visible = False
            End If
        Next

        ToolStripLabel_Count.Text = DataGridView_Items.RowCount
    End Sub

    Private Sub ToolStripTextBox_Search_TextChanged( sender As Object,  e As EventArgs) Handles ToolStripTextBox_Search.TextChanged
        Timer_Replace.Stop()
        Timer_StartReplace.Stop()
        Try
            objThreadReplace.Abort()
        Catch ex As Exception

        End Try
        

        Timer_StartReplace.Start()    
    End Sub

    Private Sub ToolStripTextBox_Replace_TextChanged( sender As Object,  e As EventArgs) Handles ToolStripTextBox_Replace.TextChanged
        Timer_Replace.Stop()
        Timer_StartReplace.Stop()
        Try
            objThreadReplace.Abort()
        Catch ex As Exception

        End Try
    
        Timer_StartReplace.Start()
    End Sub

    Private Sub Timer_Replace_Tick( sender As Object,  e As EventArgs) Handles Timer_Replace.Tick
        DataGridView_Items.Refresh()
        If boolReplaced=True Then
            RaiseEvent Replaced
            Timer_Replace.Stop()
        Else 

        End If
    End Sub

    Private sub ReplaceAsync()
        Dim objRegEx As System.Text.RegularExpressions.Regex = Nothing
        
        If strSearch <> "" Then
        
            objRegEx = new Regex(strSearch)    
        
            
        End If
        
        
        For Each objDGVR As DataGridViewRow In DataGridView_Items.Rows
            Dim objObject As clsOntologyItem = objDGVR.DataBoundItem

            If objRegEx Is Nothing Then
                objObject.Additional1 = ""
            Else 
                objObject.Additional1 = objRegEx.Replace(objObject.Name,strReplace)
                
            End If    
        Next
        boolReplaced = True
    End Sub

    Private Sub Timer_StartReplace_Tick( sender As Object,  e As EventArgs) Handles Timer_StartReplace.Tick
        Timer_StartReplace.Stop()
        strSearch = ToolStripTextBox_Search.Text
        strReplace = ToolStripTextBox_Replace.Text

        Try
            boolReplaced = False
            Dim objRegEx = new Regex(strSearch)
            
            objThreadReplace = new Thread(AddressOf ReplaceAsync)
            objThreadReplace.Start()
            Timer_Replace.Start()
            ToolStripTextBox_Search.BackColor= Nothing
        Catch ex As Exception
            ToolStripTextBox_Search.BackColor = color.Yellow
        End Try
        
    End Sub
End Class
