Public Class clsDirections
    Private objDirection_LeftRight As clsOntologyItem
    Private objDirection_RightLeft As clsOntologyItem

    Private objClasses As New clsClasses
    Private objTypes As New clsTypes

    Public ReadOnly Property Direction_LeftRight As clsOntologyItem
        Get
            Return objDirection_LeftRight
        End Get
    End Property

    Public ReadOnly Property Direction_RightLeft As clsOntologyItem
        Get
            Return objDirection_RightLeft
        End Get
    End Property

    Public Sub New()
        objDirection_LeftRight = New clsOntologyItem("cc99d5365d564fd29d4f45b48af33029", "Left-Right", objClasses.OItem_Class_Directions.GUID, objTypes.ObjectType)
        objDirection_RightLeft = New clsOntologyItem("061243fc4c134bd5800c2c33b70e99b2", "Right-Left", objClasses.OItem_Class_Directions.GUID, objTypes.ObjectType)
    End Sub
End Class
