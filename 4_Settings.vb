
Public Class Settings


    Public Property OpenFileDialog As Object

    Public IP1, IP2, IP3, IP4, IP5, IP6, IP7, IP8, IP9, IP10, IP11, IP12, IP13, IP14, IP15 As String

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        IPAdressen.Show()

    End Sub



    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        '##### Settings laden

        TextBox1.Text = My.Settings.Hashcat
        TextBox2.Text = My.Settings.JTR
        TextBox3.Text = My.Settings.PP2
        TextBox4.Text = My.Settings.PP3
        TextBox5.Text = My.Settings.Perl
        TextBox6.Text = My.Settings.Bulk
        TextBox8.Text = My.Settings.Mail

        ClientIP.Text = My.Settings.ClientIP
        ClientPort.Text = My.Settings.ClientPort
        ClientPW.Text = My.Settings.ClientPW
        ClientFeat.Text = My.Settings.ClientFeat
        ServerIP.Text = My.Settings.ServerIP
        ServerPort.Text = My.Settings.ServerPort
        ServerPW.Text = My.Settings.ServerPW


        TextBox7.Text = My.Settings.fav
        If My.Settings.fav = "" Then TextBox7.Text = Application.StartupPath & "\#_Wordlists\Hashbull_Wordlist.txt"

        CheckBox2.Checked = My.Settings.Eng
        CheckBox3.Checked = My.Settings.Ger

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False

        If CheckBox3.Checked Then

            GroupBox1.Text = "Einstellungen"
            GroupBox2.Text = "Programm-Pfade"

            CheckBox2.Text = "Englisch"
            CheckBox3.Text = "Deutsch"

            Label7.Text = "favorisierte Wordlist:"
            Label10.Text = "Sprache:"
            Label8.Text = "Crack-Email-Adresse:"

            Button1.Text = "Speichern"
            Button4.Text = "Über Hashbull"
            Button5.Text = "Hilfe"
            Button6.Text = "Versionen"
            Button2.Text = "Abbrechen"
            Button7.Text = "Öffnen"


        End If

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Close()

    End Sub

    Private Sub Form3_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Welcome.Show()
        Welcome.Opacity = 100
        Welcome.Activate()

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '###### Die Änderung in die Settings festschreiben

        My.Settings.Hashcat = TextBox1.Text
        My.Settings.JTR = TextBox2.Text
        My.Settings.PP2 = TextBox3.Text
        My.Settings.PP3 = TextBox4.Text
        My.Settings.Perl = TextBox5.Text
        My.Settings.Bulk = TextBox6.Text
        My.Settings.fav = TextBox7.Text
        My.Settings.Eng = CheckBox2.Checked
        My.Settings.Ger = CheckBox3.Checked
        My.Settings.Mail = TextBox8.Text

        My.Settings.ClientIP = ClientIP.Text
        My.Settings.ClientPort = ClientPort.Text
        My.Settings.ClientPW = ClientPW.Text
        My.Settings.ClientFeat = ClientFeat.Text
        My.Settings.ServerIP = ServerIP.Text
        My.Settings.ServerPort = ServerPort.Text
        My.Settings.ServerPW = ServerPW.Text

        My.Settings.Save()
        My.Settings.Reload()

        Me.Close()


    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        '#### About Hashbull Button

        HelpAbout.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        '#### Help Button
        'Process.Start("https://www.hashbull.org/contact")

        '#### Help als pdf anzeigen
        If My.Settings.Eng = True Then
            Process.Start(System.IO.Path.Combine(Application.StartupPath, "Docs\Hashbull_User_Manual_ENG.pdf"))
        Else
            Process.Start(System.IO.Path.Combine(Application.StartupPath, "Docs\Hashbull_User_Manual_DE.pdf"))
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        HelpVers.Show()

    End Sub



    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        '#### Nur eine Checkbox aktiv und speichern

        If CheckBox2.Checked Then

            My.Settings.Eng = CheckBox2.Checked
            CheckBox3.Checked = False

        End If


        '#### Wenn die Checkbox zweimal gedrückt wird, dann die andere aktivieren

        If CheckBox2.Checked = False Then

            CheckBox3.Checked = True

        End If


    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

        '#### Nur eine Checkbox aktiv

        If CheckBox3.Checked = True Then

            My.Settings.Ger = CheckBox3.Checked
            CheckBox2.Checked = False

        End If


        '#### Wenn die Checkbox zweimal gedrückt wird, dann die andere aktivieren

        If CheckBox3.Checked = False Then

            CheckBox2.Checked = True

        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        '#### Wordlist Auswahl und in TexBox7 einfügen 

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\#_Wordlists"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox7.Text = openFileDialog.FileName 'System.IO.Path.GetFileName(openFileDialog.FileName)
        End If

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

        If My.Settings.Eng = True Then MsgBox("Under Hash Crack you have to activate Crack-Mail. Hashbull automatically sends an email when the hash has been cracked. Outlook must be installed on the PC. Please enter your email address here.")
        If My.Settings.Eng = False Then MsgBox("Hashbull versendet automatisch eine Email, wenn das Passwort geknackt wurde. Outlook muss auf dem PC installiert sein. Bitte tragen Sie hier eine Email-Adresse ein.")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Wordlist.Show()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        '### Start Brain-Server

        My.Settings.ServerIP = ServerIP.Text
        My.Settings.ServerPort = ServerPort.Text
        My.Settings.ServerPW = ServerPW.Text

        My.Settings.Save()
        My.Settings.Reload()

        Dim process As New Process()
        process.StartInfo.FileName = "cmd.exe"
        process.StartInfo.WorkingDirectory = vari.Hashcat
        process.StartInfo.Arguments = ("/k " & "hashcat.exe --brain-server --brain-host=" & My.Settings.ServerIP & " --brain-port=" & My.Settings.ServerPort & " --brain-password=" & My.Settings.ServerPW)
        process.Start()

    End Sub


End Class
