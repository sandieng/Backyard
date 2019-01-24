Imports System.Text

Public Class Form1
    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Dim byteArray() As Byte

        ' Example of hex string: 0x7B5C727466315C616E73695C616E7369637067313235325C64656666305C6465666C616E67313033337B5C666F6E7474626C7B5C66305C6673776973735C66707271325C6663686172736574302043616C696272693B7D7B5C66315C666E696C5C6663686172736574302043616C696272693B7D7D0D0A5C766965776B696E64345C7563315C706172645C6E6F77696463746C7061725C73613230305C736C3237365C736C6D756C74315C6C616E67395C66305C66733232204669727374204E616D653A5C7461625C7461625C746162204A4F455C7061720D0A4C617374204E616D653A5C7461625C7461625C7461622047554E4E45525C7061720D0A44617465206F662042697274683A5C7461625C7461625C7461622030312F30312F313939365C7061720D0A416464726573733A5C7461625C7461625C74616220312057696C6C69616D736F6E2052642C20446F6E6361737465722C2056494320333130385C66315C7061720D0A7D0D0A00

        byteArray = HexToByteArray(rtxt1.Text.Substring(2, rtxt1.Text.Length - 2))

        Dim Encoding As New ASCIIEncoding()
        rtxt2.Rtf = Encoding.GetString(byteArray, 0, Convert.ToInt32(byteArray.Length))
    End Sub


    Private Function HexToByteArray(ByVal hex As [String]) As Byte()
        Dim NumberChars As Integer = hex.Length
        Dim bytes As Byte() = New Byte(NumberChars / 2 - 1) {}
        Dim j As Integer = 0
        For i As Integer = 0 To NumberChars - 1 Step 2
            bytes(j) = Convert.ToByte(hex.Substring(i, 2), 16)
            j += 1
        Next
        Return bytes
    End Function

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Dim hexString As String = "0x"
        Dim byteArray() As Byte

        byteArray = Encoding.UTF8.GetBytes(rtxt2.Rtf)
        For Each item As Byte In byteArray
            hexString += item.ToString("X2")
        Next

        rtxt1.Text = hexString
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        'Declare a Word Application Object and a Word WdSaveOptions object
        Dim MyWord As Microsoft.Office.Interop.Word.Application
        Dim oDoNotSaveChanges As Object =
             Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges
        'Declare two strings to handle the data
        Dim sReturnString As String = ""
        Dim sConvertedString As String = ""
        Dim sRTF As String = rtxt2.Rtf

        Try
            'Instantiate the Word application,
            ' Set visible To False And create a document
            MyWord = CreateObject("Word.application")
            MyWord.Visible = False
            MyWord.Documents.Add()
            'Create a DataObject to hold the Rich Text
            'and copy it to the clipboard
            Dim doRTF As New System.Windows.Forms.DataObject
            doRTF.SetData("Rich Text Format", sRTF)
            Clipboard.SetDataObject(doRTF)
            'Paste the contents of the clipboard to the empty,
            'hidden Word Document
            MyWord.Windows(1).Selection.Paste()
            'â€¦then, select the entire contents of the document
            'and copy back to the clipboard
            MyWord.Windows(1).Selection.WholeStory()
            MyWord.Windows(1).Selection.Copy()
            'Now retrieve the HTML property of the DataObject
            'stored on the clipboard
            sConvertedString =
                 Clipboard.GetData(System.Windows.Forms.DataFormats.Html)
            'Remove some leading text that shows up in some instances
            '(like when you insert it into an email in Outlook
            sConvertedString =
                 sConvertedString.Substring(sConvertedString.IndexOf("<html"))
            'Also remove multiple Ã‚ characters that somehow end up in there
            sConvertedString = sConvertedString.Replace("Ã‚", "")
            'â€¦and you're done.
            sReturnString = sConvertedString
            If Not MyWord Is Nothing Then
                MyWord.Quit(oDoNotSaveChanges)
                MyWord = Nothing
            End If
        Catch ex As Exception
            If Not MyWord Is Nothing Then
                MyWord.Quit(oDoNotSaveChanges)
                MyWord = Nothing
            End If
            MsgBox("Error converting Rich Text to HTML")
        End Try

        rtxt3.Text = sReturnString
    End Sub
End Class
