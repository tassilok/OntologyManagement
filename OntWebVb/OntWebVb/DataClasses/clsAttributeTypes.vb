Public Class clsAttributeTypes
    Private objOItem_AttributeType_WMI_ProcessorID As clsOntologyItem
    Private objOITem_AttributeType_WMI_BaseBoardSerial As clsOntologyItem

    Private objTypes As New clsTypes

    Public ReadOnly Property OItem_AttributeType_WMI_ProcessorID As clsOntologyItem
        Get
            Return objOItem_AttributeType_WMI_ProcessorID
        End Get
    End Property

    Public ReadOnly Property OITem_AttributeType_WMI_BaseBoardSerial As clsOntologyItem
        Get
            Return objOITem_AttributeType_WMI_BaseBoardSerial
        End Get
    End Property

    Public Sub New()
        objOItem_AttributeType_WMI_ProcessorID = New clsOntologyItem("a1b4945219dc4eaea000ef3802de35a9", _
                                                                         "ProcessorID", _
                                                                         objTypes.AttributeType)

        objOITem_AttributeType_WMI_BaseBoardSerial = New clsOntologyItem("30b76a621b224f17b9a5ff665e08f35a", _
                                                                         "BaseboardSerial",
                                                                         objTypes.AttributeType)

    End Sub
End Class
