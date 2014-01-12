Imports OntologyClasses.BaseClasses
Public Class clsFilter
    Private objLocalConfig As clsLocalConfig

    Private strFilter As String

    Private _filtersAmount As List(Of clsFilterAmount) = New List(Of clsFilterAmount)
    Private _filtersContract As List(Of clsOntologyItem) = New List(Of clsOntologyItem)
    Private _filtersNameGuid As List(Of clsOntologyItem) = New List(Of clsOntologyItem)
    Private _filtersPaymentDate As List(Of clsObjectAtt) = New List(Of clsObjectAtt)
    Private _filtersSemItems As List(Of clsOntologyItem) = New List(Of clsOntologyItem)
    Private _filtersToPay As List(Of clsObjectAtt) = New List(Of clsObjectAtt)
    Private _filtersTransactionDate As List(Of clsObjectAtt) = New List(Of clsObjectAtt)

    Public Property ParseError As Boolean
    Public Property NoFilterType As Boolean
    Public Property OItem_Filter As clsOntologyItem

    Public ReadOnly Property FiltersAmount As List(Of clsFilterAmount)
        Get
            Return _filtersAmount

        End Get
    End Property

    Public ReadOnly Property FiltersContract As List(Of clsOntologyItem)
        Get
            Return _filtersContract

        End Get
    End Property

    Public ReadOnly Property FiltersNameGuid As List(Of clsOntologyItem)
        Get
            Return _filtersNameGuid
        End Get
    End Property

    Public ReadOnly Property FiltersPaymentDate As List(Of clsObjectAtt)
        Get
            Return _filtersPaymentDate
        End Get
    End Property

    Public ReadOnly Property FiltersSemItem As List(Of clsOntologyItem)
        Get
            Return _filtersSemItems
        End Get
    End Property

    Public ReadOnly Property FiltersToPay As List(Of clsObjectAtt)
        Get
            Return _filtersToPay
        End Get
    End Property

    Public ReadOnly Property FiltersTransactionDate As List(Of clsObjectAtt)
        Get
            Return _filtersTransactionDate
        End Get
    End Property

    Public Property Filter As String
        Get
            Return strFilter
        End Get
        Set(value As String)
            strFilter = value
            parseFilter()
        End Set
    End Property

    Public Property OItem_FilterItem As clsOntologyItem

    Public Property OItem_FilterType As clsOntologyItem

    Public Sub New(localConfig As clsLocalConfig)
        objLocalConfig = localConfig
    End Sub

    Private Sub parseFilter()
        Dim strAFilter = strFilter.Split(" ")
        ParseError = False
        NoFilterType = False

        _filtersAmount.Clear()
        _filtersContract.Clear()
        _filtersNameGuid.Clear()
        _filtersPaymentDate.Clear()
        _filtersSemItems.Clear()
        _filtersToPay.Clear()
        _filtersTransactionDate.Clear()

        If OItem_FilterType Is Nothing Then
            NoFilterType = True
            Return

        End If

        If Not strAFilter.Any Then
            ParseError = True
            Return
        End If

        Select Case OItem_FilterType.GUID
            Case objLocalConfig.OItem_Object_Search_Template_Amount_.GUID
                If strAFilter.Count > 4 Then
                    ParseError = True
                    Return
                End If

                Dim intAmountMin As Integer
                Dim intAmountMax As Integer
                Dim strMenge As String
                'Erster Parameter
                If Integer.TryParse(strAFilter(0), intAmountMin) Then
                    If strAFilter.Count = 1 Then
                        _filtersAmount.Add(New clsFilterAmount With {.Menge = intAmountMin})
                    ElseIf strAFilter.Count = 2 Then
                        _filtersAmount.Add(New clsFilterAmount With {.Menge = intAmountMin})
                        If Integer.TryParse(strAFilter(1), intAmountMax) Then
                            _filtersAmount.Add(New clsFilterAmount With {.Menge = intAmountMax})
                        Else
                            ParseError = True
                            Return
                        End If
                    ElseIf strAFilter.Count = 3 Then
                        _filtersAmount.Add(New clsFilterAmount With {.Menge = intAmountMin})
                        If Integer.TryParse(strAFilter(1), intAmountMax) Then
                            _filtersAmount.Add(New clsFilterAmount With {.Menge = intAmountMax, .Einheit = New clsOntologyItem With {.Name = strAFilter(2)}})
                        Else
                            If Integer.TryParse(strAFilter(2), intAmountMax) Then
                                _filtersAmount.Add(New clsFilterAmount With {.Menge = intAmountMax})
                            Else
                                ParseError = True
                                Return
                            End If
                        End If
                    ElseIf strAFilter.Count = 4 Then
                        _filtersAmount.Add(New clsFilterAmount With {.Menge = intAmountMin, .Einheit = New clsOntologyItem With {.Name = strAFilter(1)}})
                        If Integer.TryParse(strAFilter(2), intAmountMax) Then
                            _filtersAmount.Add(New clsFilterAmount With {.Menge = intAmountMax, .Einheit = New clsOntologyItem With {.Name = strAFilter(3)}})
                        Else
                            ParseError = True
                            Return
                        End If
                    End If
                Else
                    If strAFilter.Count > 1 Then
                        'Erster Parameter ist keine Zahl, also nur Menge als Filter
                        ParseError = True
                        Return
                    End If

                    strMenge = strAFilter(0)

                    _filtersAmount.Add(New clsFilterAmount With {.Einheit = New clsOntologyItem With {.Name = strMenge}})
                End If
            Case objLocalConfig.OItem_Object_Search_Template_Contractee_Contractor_.GUID
                If OItem_FilterItem Is Nothing Then
                    If objLocalConfig.Globals.is_GUID(strAFilter(0)) Then
                        _filtersContract.Add(New clsOntologyItem With {.GUID = strAFilter(0)})
                    Else
                        _filtersContract.Add(New clsOntologyItem With {.Name = strAFilter(0)})
                    End If
                Else
                    _filtersContract.Add(OItem_FilterItem)
                End If
            Case objLocalConfig.OItem_Object_Search_Template_Name_.GUID
                If objLocalConfig.Globals.is_GUID(strAFilter(0)) Then
                    _filtersNameGuid.Add(New clsOntologyItem With {.GUID = strAFilter(0)})
                Else
                    _filtersNameGuid.Add(New clsOntologyItem With {.Name = strAFilter(0)})
                End If
            Case objLocalConfig.OItem_Object_Search_Template_Payment_Date_.GUID
                If strAFilter.Count = 1 Then
                    Dim dateStart As DateTime
                    If DateTime.TryParse(strAFilter(0), dateStart) Then
                        _filtersPaymentDate.Add(New clsObjectAtt With {.Val_Date = dateStart})
                    Else
                        ParseError = True
                        Return
                    End If
                ElseIf strAFilter.Count = 2 Then
                    Dim dateStart As Date
                    Dim dateEnd As Date

                    If DateTime.TryParse(strAFilter(0), dateStart) And DateTime.TryParse(strAFilter(0), dateEnd) Then
                        _filtersPaymentDate.Add(New clsObjectAtt With {.Val_Date = dateStart})
                        _filtersPaymentDate.Add(New clsObjectAtt With {.Val_Date = dateEnd})
                    Else
                        ParseError = True
                        Return
                    End If
                Else
                    ParseError = True
                    Return

                End If
            Case objLocalConfig.OItem_Object_Search_Template_Related_Sem_Item_.GUID
                If Not OItem_FilterItem Is Nothing Then
                    _filtersSemItems.Add(OItem_FilterItem)
                Else
                    ParseError = True
                    Return
                End If
            Case objLocalConfig.OItem_Object_Search_Template_to_Pay_.GUID
                If strAFilter.Count = 1 Then
                    Dim payFrom As Double
                    If Double.TryParse(strAFilter(0), payFrom) Then
                        _filtersToPay.Add(New clsObjectAtt With {.Val_Double = payFrom})

                    Else
                        ParseError = True
                        Return
                    End If
                ElseIf strAFilter.Count = 2 Then
                    Dim payFrom As Double
                    Dim payTo As Double
                    If Double.TryParse(strAFilter(0), payFrom) And Double.TryParse(strAFilter(1), payTo) Then
                        _filtersToPay.Add(New clsObjectAtt With {.Val_Double = payFrom})
                        _filtersToPay.Add(New clsObjectAtt With {.Val_Double = payTo})
                    Else
                        ParseError = True
                        Return
                    End If
                Else
                    ParseError = True
                    Return
                End If
        End Select
    End Sub

End Class
