Imports System.Windows.Forms

Module Module1

    Sub Main()
        Dim seconds As String = InputBox("Zadejte počet sekund pro progress bar:")

        If Not IsNumeric(seconds) OrElse Val(seconds) = 0 Then
            MessageBox.Show("Chyba: Zadejte platné číslo větší než 0.", "Neplatný vstup", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Else
            Dim myForm As New Form1()
            myForm.ShowDialog()
        End If
    End Sub

End Module


