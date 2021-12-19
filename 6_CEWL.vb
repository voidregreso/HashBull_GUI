Public Class CEWL

    Public CMax As String
    Public Cmin As String
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles Me.Load

        '### Voreinstellungen laden

        TextBox1.Text = "https://www."

        '### Start-Button deaktivieren
        Me.Button2.Enabled = False

        TextBox3.Text = "2"
        TextBox2.Text = "5"

        '### Auf Deutsch umstellen
        If My.Settings.Eng = False Then

            GroupBox1.Text = "Linux und Packages installieren"

            GroupBox2.Text = "so. Einstellungen (optinal)"

            Label3.Text = "CeWL kann aus einer URL eine Wordlist und Emailadressen extrahieren. Bitte beachten Sie die Schreibweise: " & vbNewLine &
                          "http:// oder https://. Die Extraktion wird im Ordner ""#_Wordlists"" abgelegt."
            Label1.Text = "Ziel-Homepage:"
            Label5.Text = "Wenn Sie CeWL erstmalig verwenden, müssen Sie Linux und die entsprechenden Packages installieren." & vbNewLine &
                          "Drücken Sie den Button um Linux zu installieren:"
            Label4.Text = "Tiefe (Voreinstellung: 2):"
            Label2.Text = "Minimum Wortlänge: "

        End If

    End Sub


    Private Sub CEWL_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        WordlistUtility.Show()

    End Sub


    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Private Sub C_Aktualisieren()
        '### CeWL ausführen



        Dim Date1 As String = Format(Now, "yyyyMMdd_HHmmss")

        Dim command As String = "ubuntu2004.exe" & " run cewl " & TextBox1.Text & " -w CeWL_Wordlist_" & Date1 & ".txt " & " -e  --email_file CeWL_EMails_" & Date1 & ".txt " & CMax & Cmin
        TextBox7.Text = command

        Me.Button2.Enabled = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '#########START Button führt das Commad Fenster aus

        If My.Settings.Eng = True Then

            MsgBox("The process can take up to an hour for larger websites", MessageBoxButtons.OK)

        Else

            MsgBox("Bei größeren Internetseiten kann dieser Vorgang bis zu einer Stunde dauern!", MessageBoxButtons.OK)

        End If


        Dim process As New Process()
        process.StartInfo.FileName = "cmd.exe"
        process.StartInfo.WorkingDirectory = Application.StartupPath & "\#_Wordlists"
        process.StartInfo.Arguments = ("/k " & TextBox7.Text)
        process.Start()


    End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        '### Min. Word-Length

        If TextBox2.TextLength > 0 Then

            Cmin = "-m " & TextBox2.Text & " "
        Else
            Cmin = ""

        End If

        Call C_Aktualisieren()

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        '### Depth Spider

        If TextBox3.TextLength > 0 Then

            CMax = "-d " & TextBox3.Text & " "
        Else
            CMax = ""

        End If

        Call C_Aktualisieren()

    End Sub



    Private Sub TextBox2_KeyPress(
ByVal sender As Object,
ByVal e As System.Windows.Forms.KeyPressEventArgs) _
Handles TextBox2.KeyPress

        '#### Nur Zahlen und Backspace 


        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8
                ' Zahlen, Backspace 

            Case Else
                ' alle anderen Eingaben unterdrücken
                e.Handled = True
        End Select
    End Sub


    Private Sub TextBox3_KeyPress(
ByVal sender As Object,
ByVal e As System.Windows.Forms.KeyPressEventArgs) _
Handles TextBox3.KeyPress

        '#### Nur Zahlen und Backspace 


        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8
                ' Zahlen, Backspace 

            Case Else
                ' alle anderen Eingaben unterdrücken
                e.Handled = True
        End Select
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Linux_CEWL.Show()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Call C_Aktualisieren()

    End Sub


End Class