Imports Ontolog_Module
Public Class clsBlobConnection
    Private objLocalConfig As clsLocalConfig

    Private objDataWork As clsDataWork

    Private byteFile() As Byte
    Private strHash_File As String

    Private Function getHash(ByVal byteFile() As Byte, ByVal intLength As Integer) As String
        Dim byteHash() As Byte
        Dim strHash As String
        Dim objMD5 As Security.Cryptography.MD5

        objMD5 = New Security.Cryptography.MD5CryptoServiceProvider
        byteHash = objMD5.ComputeHash(byteFile, 0, intLength - 1)
        strHash = BitConverter.ToString(byteHash)

        Return strHash

    End Function

    Public Function compare_File(ByVal strFilePath As String) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_HashObj As clsOntologyItem

        Dim objFileStream_OS As New IO.FileStream(strFilePath, IO.FileMode.Open, IO.FileAccess.Read)

        Dim objBinaryReader As New IO.BinaryReader(objFileStream_OS)

        If objFileStream_OS.Length > 4000 Then
            ReDim byteFile(4000)
            objFileStream_OS.Seek(0, IO.SeekOrigin.Begin)
            For i = 0 To 2000
                byteFile(i) = objBinaryReader.ReadByte
            Next

            strHash_File = getHash(byteFile, 2000)
            objFileStream_OS.Seek(-2001, IO.SeekOrigin.End)
            For i = 0 To 2000
                byteFile(i) = objBinaryReader.ReadByte
            Next
            strHash_File = strHash_File & getHash(byteFile, 2000)
        Else
            ReDim byteFile(objFileStream_OS.Length)
            For i = 0 To objFileStream_OS.Length - 1
                byteFile(i) = objFileStream_OS.ReadByte
            Next

            strHash_File = getHash(byteFile, objFileStream_OS.Length - 1)

        End If

        If objFileStream_OS.Length > 4000 Then
            ReDim byteFile(4000)
            objFileStream_OS.Seek(0, IO.SeekOrigin.Begin)
            For i = 0 To 2000
                byteFile(i) = objBinaryReader.ReadByte
            Next

            strHash_File = getHash(byteFile, 2000)
            objFileStream_OS.Seek(-2001, IO.SeekOrigin.End)
            For i = 0 To 2000
                byteFile(i) = objBinaryReader.ReadByte
            Next
            strHash_File = strHash_File & getHash(byteFile, 2000)
        Else
            ReDim byteFile(objFileStream_OS.Length)
            For i = 0 To objFileStream_OS.Length - 1
                byteFile(i) = objFileStream_OS.ReadByte
            Next

            strHash_File = getHash(byteFile, objFileStream_OS.Length - 1)

        End If

        objOItem_HashObj = objDataWork.search_Hash(strHash_File)

        objOItem_Result = objLocalConfig.Globals.LState_Success

        If Not objOItem_HashObj Is Nothing Then

        End If

        Return objOItem_Result
    End Function

    Public Sub New()
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDataWork = New clsDataWork(objLocalConfig)
    End Sub
End Class
