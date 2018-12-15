
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms


'使用Dictionary类需要的命名空间
Imports System.Collections.Generic
'使用Linq查询类需要的命名空间。
Imports System.Linq


Namespace CmnClsLib_Func
    Public Class TextOperation


        ''' <summary>
        ''' 根据给定的编码，确定字符串的byte长度。如“Shift-JIS“
        ''' </summary>
        ''' <param name="str">要确定长度的字符串</param>
        ''' <param name="charSetName">字符集的准确全称</param>
        ''' <returns></returns>
        Public Function GetStringLengthByByte(str As String, charSetName As String) As Integer
            Dim byteLength As Integer
            Select Case charSetName
                Case "UTF8"
                    byteLength = System.Text.Encoding.UTF8.GetBytes(str).Length
                    Exit Select
                Case "Unicode"
                    byteLength = System.Text.Encoding.Unicode.GetBytes(str).Length
                    Exit Select
                Case "ASCII"
                    byteLength = System.Text.Encoding.ASCII.GetBytes(str).Length
                    Exit Select
                Case "UTF32"
                    byteLength = System.Text.Encoding.UTF32.GetBytes(str).Length
                    Exit Select
                Case "BigEndianUnicode"
                    byteLength = System.Text.Encoding.BigEndianUnicode.GetBytes(str).Length
                    Exit Select
                Case "UTF7"
                    byteLength = System.Text.Encoding.UTF7.GetBytes(str).Length
                    Exit Select
                Case Else
                    byteLength = System.Text.Encoding.GetEncoding(charSetName).GetBytes(str).Length
                    Exit Select
            End Select
            Return byteLength
        End Function


        ''' <summary>
        ''' 控件输入内容合法性检测
        ''' </summary>
        ''' <param name="objects">Object后需要加[]，表示是Object类型的一维数组，params后必须是一维数组，使用Control类需要System.Web.UI命名空间</param>
        ''' <returns></returns>
        Public Function MustInputCheckForObject(objects As Object()) As Boolean
            Dim isCheckPass As Boolean = True
            For Each obj In objects
                Select Case (obj.GetType()).Name
                    Case "TextBox"
                        Dim tbx As Windows.Forms.TextBox = CType(obj, Windows.Forms.TextBox)
                        If String.IsNullOrEmpty(tbx.Text) = True Then
                            isCheckPass = False
                            Exit Function
                        End If
                    Case "ComboBox"
                        Dim cmbBox As Windows.Forms.ComboBox = CType(obj, Windows.Forms.ComboBox)
                        If String.IsNullOrEmpty(cmbBox.SelectedValue.ToString()) = True Then
                            isCheckPass = False
                            Exit Function
                        End If
                    Case "Label"
                        Dim lbl As Windows.Forms.Label = CType(obj, Windows.Forms.Label)
                        If String.IsNullOrEmpty(lbl.Text) = True Then
                            isCheckPass = False
                            Exit Function
                        End If
                End Select
            Next
            Return isCheckPass
        End Function

        ''' <summary>
        ''' 将合法的Code39字符串增加一个校验位
        ''' </summary>
        ''' <param name="strNeedCheckDigit"></param>
        ''' <returns></returns>
        Public Function Code39Mod43Check(strNeedCheckDigit As String) As String

            Dim Code39Mod43Dic As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)()
            Code39Mod43Dic.Add("0", 0)
            Code39Mod43Dic.Add("1", 1)
            Code39Mod43Dic.Add("2", 2)
            Code39Mod43Dic.Add("3", 3)
            Code39Mod43Dic.Add("4", 4)
            Code39Mod43Dic.Add("5", 5)
            Code39Mod43Dic.Add("6", 6)
            Code39Mod43Dic.Add("7", 7)
            Code39Mod43Dic.Add("8", 8)
            Code39Mod43Dic.Add("9", 9)
            Code39Mod43Dic.Add("A", 10)
            Code39Mod43Dic.Add("B", 11)
            Code39Mod43Dic.Add("C", 12)
            Code39Mod43Dic.Add("D", 13)
            Code39Mod43Dic.Add("E", 14)
            Code39Mod43Dic.Add("F", 15)
            Code39Mod43Dic.Add("G", 16)
            Code39Mod43Dic.Add("H", 17)
            Code39Mod43Dic.Add("I", 18)
            Code39Mod43Dic.Add("J", 19)
            Code39Mod43Dic.Add("K", 20)
            Code39Mod43Dic.Add("L", 21)
            Code39Mod43Dic.Add("M", 22)
            Code39Mod43Dic.Add("N", 23)
            Code39Mod43Dic.Add("O", 24)
            Code39Mod43Dic.Add("P", 25)
            Code39Mod43Dic.Add("Q", 26)
            Code39Mod43Dic.Add("R", 27)
            Code39Mod43Dic.Add("S", 28)
            Code39Mod43Dic.Add("T", 29)
            Code39Mod43Dic.Add("U", 30)
            Code39Mod43Dic.Add("V", 31)
            Code39Mod43Dic.Add("W", 32)
            Code39Mod43Dic.Add("X", 33)
            Code39Mod43Dic.Add("Y", 34)
            Code39Mod43Dic.Add("Z", 35)
            Code39Mod43Dic.Add("-", 36)
            Code39Mod43Dic.Add(".", 37)
            Code39Mod43Dic.Add(" ", 38)
            Code39Mod43Dic.Add("$", 39)
            Code39Mod43Dic.Add("/", 40)
            Code39Mod43Dic.Add("+", 41)
            Code39Mod43Dic.Add("%", 42)

            strNeedCheckDigit = strNeedCheckDigit.ToUpper()        '将字符串改为大写
            ' 字符串中每个字符映射之和
            Dim mappingSum As Integer = 0
            For i As Integer = 0 To strNeedCheckDigit.Length
                mappingSum = mappingSum + Code39Mod43Dic(strNeedCheckDigit.Substring(i, 1))
            Next
            Dim modOfSum As Integer = mappingSum Mod 43                                 '将映射之和按照43取余
            Dim checkDigit As String = String.Empty


            '''/取得字典中Value对应的Key方法1，Foreach循环
            'foreach KeyValuePair < String, Int() > kvp In Code39Mod43Dic)

            'If kvp.Value = modOfSum Then

            '    checkDigit = kvp.Key.ToString()
            'End If
            'Next

            ''/取得字典中Value对应的Key方法2，Foreach循环
            For Each key In Code39Mod43Dic.Keys
                If Code39Mod43Dic(key) = modOfSum Then
                    checkDigit = key.ToString()
                End If
            Next


            '''/取得字典中Value对应的Key方法3，Linq取得所有Keys
            'var Keys = Code39Mod43Dic.Where(q >= q.Value == modOfSum).Select(q >= q.Key)         '取得余数对应的字符，作为校验位。


            '''/取得字典中Value对应的Key方法4，Linq取得所有Keys
            'Dim keyList As List(Of String) = (From q In Code39Mod43Dic
            '                                  Where q.Value = modOfSum
            '                                  Select q.Key).ToList(Of String)


            ''取得字典中Value对应的Key方法5，Linq取得第一个Key
            'checkDigit = Code39Mod43Dic.FirstOrDefault(q >= q.Value == modOfSum).Key.ToString()


            Dim checkedStr As String = "*" + strNeedCheckDigit + checkDigit.ToString() + "*"

                Return checkedStr
        End Function



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="code39Char"></param>
        ''' <returns></returns>
        Public Function Code39Map(code39Char As String) As Integer
            Select Case code39Char
                Case "0" : Return 0
                Case "1" : Return 1
                Case "2" : Return 2
                Case "3" : Return 3
                Case "4" : Return 4
                Case "5" : Return 5
                Case "6" : Return 6
                Case "7" : Return 7
                Case "8" : Return 8
                Case "9" : Return 9
                Case "A" : Return 10
                Case "B" : Return 11
                Case "C" : Return 12
                Case "D" : Return 13
                Case "E" : Return 14
                Case "F" : Return 15
                Case "G" : Return 16
                Case "H" : Return 17
                Case "I" : Return 18
                Case "J" : Return 19
                Case "K" : Return 20
                Case "L" : Return 21
                Case "M" : Return 22
                Case "N" : Return 23
                Case "O" : Return 24
                Case "P" : Return 25
                Case "Q" : Return 26
                Case "R" : Return 27
                Case "S" : Return 28
                Case "T" : Return 29
                Case "U" : Return 30
                Case "V" : Return 31
                Case "W" : Return 32
                Case "X" : Return 33
                Case "Y" : Return 34
                Case "Z" : Return 35
                Case "-" : Return 36
                Case "." : Return 37
                Case " " : Return 38
                Case "$" : Return 39
                Case "/" : Return 40
                Case "+" : Return 41
                Case "%" : Return 42
                Case Else : Return 43
            End Select
        End Function

        Public Function Code39Map(code39Int As Integer) As String
            Select Case code39Int
                Case 0 : Return "0"
                Case 1 : Return "1"
                Case 2 : Return "2"
                Case 3 : Return "3"
                Case 4 : Return "4"
                Case 5 : Return "5"
                Case 6 : Return "6"
                Case 7 : Return "7"
                Case 8 : Return "8"
                Case 9 : Return "9"
                Case 10 : Return "A"
                Case 11 : Return "B"
                Case 12 : Return "C"
                Case 13 : Return "D"
                Case 14 : Return "E"
                Case 15 : Return "F"
                Case 16 : Return "G"
                Case 17 : Return "H"
                Case 18 : Return "I"
                Case 19 : Return "J"
                Case 20 : Return "K"
                Case 21 : Return "L"
                Case 22 : Return "M"
                Case 23 : Return "N"
                Case 24 : Return "O"
                Case 25 : Return "P"
                Case 26 : Return "Q"
                Case 27 : Return "R"
                Case 28 : Return "S"
                Case 29 : Return "T"
                Case 30 : Return "U"
                Case 31 : Return "V"
                Case 32 : Return "W"
                Case 33 : Return "X"
                Case 34 : Return "Y"
                Case 35 : Return "Z"
                Case 36 : Return "-"
                Case 37 : Return "."
                Case 38 : Return " "
                Case 39 : Return "$"
                Case 40 : Return "/"
                Case 41 : Return "+"
                Case 42 : Return "%"
                Case Else : Return "ERROR"
            End Select
        End Function

    End Class

End Namespace
