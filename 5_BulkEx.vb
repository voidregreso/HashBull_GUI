Public Class BulkEx


    Public Outputfile As String = Application.StartupPath & "\#_Wordlists\" & "Wordlist_BulkExtractor"

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '#### Form Loader / Output und Check1


        CheckBox1.Checked = True


        If My.Settings.Ger = True Then
            Label1.Text = "Image-Datei:"
            Label2.Text = "Wortlänge:"
            Label3.Text = "bis"


            Button1.Text = "Datei auswählen"
            Button2.Text = "BULK starten"

            CheckBox1.Text = "nur Wordlist"
            CheckBox2.Text = "volle Extraktion"
        End If


    End Sub

    Private Sub Form5_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        WordlistUtility.Show()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '#### Image Datei auswählen

        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "All Files (*.*)| *.*"
        openFileDialog1.InitialDirectory = Application.StartupPath

        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = openFileDialog1.FileName

        End If
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '#### Check1 = nur Wordlist

        If CheckBox1.Checked = True Then


            Dim dateBulk As String = DateTime.Now.ToString("ddMMyy_HHmmss")
            Dim Bulkin As String = TextBox1.Text
            'Dim Bulkout As String = Application.StartupPath & "\#_Wordlists\Wordlists_" & dateBulk
            Dim Bulkout As String = Outputfile & "_" & dateBulk

            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = Application.StartupPath & "Packages\BuEx"
            process.StartInfo.Arguments = ("/k " & vari.Bulk & " " & TextBox4.Text & TextBox5.Text & "-E wordlist -o " & Bulkout & "/ " & Bulkin)
            process.Start()
        End If

        '#### Check2 = Alles extrahieren

        If CheckBox2.Checked = True Then


            Dim dateBulk As String = DateTime.Now.ToString("ddMMyy_HHmmss")
            Dim Bulkin As String = TextBox1.Text
            Dim Bulkout As String = Application.StartupPath & "\#_Wordlists\Wordlists_" & dateBulk


            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = Application.StartupPath & "Packages\BuEx"
            process.StartInfo.Arguments = ("/k " & vari.Bulk & " " & TextBox4.Text & TextBox5.Text & "-e base16 -e facebook -e outlook -e sceadan -e wordlist -e xor -o " & Bulkout & "/ " & Bulkin)
            process.Start()
        End If


    End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        '#### Wortlänge (min)

        If TextBox2.Text.Length > 0 Then
            TextBox4.Text = " -S word_min=" & TextBox2.Text & " "
        Else
            TextBox4.Text = ""
        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        '#### Wortlänge (max)

        If TextBox3.Text.Length > 0 Then
            TextBox5.Text = " -S word_max=" & TextBox3.Text & " "
        Else
            TextBox5.Text = ""
        End If


    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        '#### Nur eine Checkbox aktiv

        If CheckBox1.Checked Then
            CheckBox2.Checked = False
        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        '#### Nur eine Checkbox aktiv

        If CheckBox2.Checked Then
            CheckBox1.Checked = False
        End If

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


    Private Sub TextBox3_KeyPress(
ByVal sender As Object,
ByVal e As System.Windows.Forms.KeyPressEventArgs) _
Handles TextBox3.KeyPress

        '#### Nur Zahlen und Backspace bei Wörterlänge zulassen

        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8 ', 32
                ' Zahlen, Backspace und Space zulassen

            Case Else
                ' alle anderen Eingaben unterdrücken
                e.Handled = True
        End Select
    End Sub





    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

        '#### Help Button

        Process.Start("https://www.hashbull.net/contact")

    End Sub


End Class

