Public Class HelpPIM

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '#### VeraCrypt Vorgabe 0

        TextBox1.Text = 0
        TextBox2.Text = 0


        If My.Settings.Ger = True Then
            Label1.Text = "PIM steht für ""Personal Iterations Multiplier"". Es ist ein Parameter" & vbNewLine &
                          "der in VeraCrypt 1.12 eingeführt wurde. Dessen Wert steuert die" & vbNewLine &
                          "Anzahl der Iterationen, die von der ""Header Key Derivation Function""" & vbNewLine &
                          "verwendet wird. Der PIM-Mindestwert für kurze Kennwörter beträgt bei" & vbNewLine &
                          "System-Verschlüsselungen ""98"". Dies gilt nicht bei SHA-512 und Whirlpool." & vbNewLine &
                          "Bei allen anderen wird die Standard-PIM ""485"" genutzt." & vbNewLine & vbNewLine &
                          "Bei einem Kennwort mit 20 Zeichen und mehr beträgt der PIM-Mindestwert 1." & vbNewLine &
                          "In allen anderen Fällen wird die PIM leer gelassen oder auf ""0"" gesetzt." & vbNewLine & vbNewLine &
                          "Beide Felder müssen ausgefüllt werden.   " & vbNewLine

            Button1.Text = "Weiter"
            Button2.Text = "Abbruch"
            Button3.Text = "Hilfe"

        End If



    End Sub



    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '#### Übergabe der PIMs in Form4

        Hashcrack.PIMvarTxb1.Text = TextBox1.Text
        Hashcrack.PIMvarTxb2.Text = TextBox2.Text

        Me.Close()

    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        '#### Zweites Feld automatisch füllen

        If TextBox1.TextLength > 1 Then
            TextBox2.Text = TextBox1.Text
        Else
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub TextBox1_KeyPress(
  ByVal sender As Object,
  ByVal e As System.Windows.Forms.KeyPressEventArgs) _
  Handles TextBox1.KeyPress

        '#### Nur Zahlen und Backspace bei Wörterlänge zulassen


        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8 ', 32
                ' Zahlen, Backspace und Space zulassen

            Case Else
                ' alle anderen Eingaben unterdrücken
                e.Handled = True
        End Select
    End Sub


    Private Sub TextBox2_KeyPress(
  ByVal sender As Object,
  ByVal e As System.Windows.Forms.KeyPressEventArgs) _
  Handles TextBox2.KeyPress

        '#### Nur Zahlen und Backspace bei Wörterlänge zulassen


        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8 ', 32
                ' Zahlen, Backspace und Space zulassen

            Case Else
                ' alle anderen Eingaben unterdrücken
                e.Handled = True
        End Select
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '#### Cancel Button

        Me.Close()
        Hashcrack.Activate()


    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        '##### Help Button

        Process.Start("https://www.hashbull.net/contact")

    End Sub
End Class