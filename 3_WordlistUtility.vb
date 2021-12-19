Public Class WordlistUtility

    Public OldWordlistUtil, NewWordlistUtil As String

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles Me.Load

        If My.Settings.Ger = True Then

            Label7.Text = "Bulk Extractor ist eine Software, welche Wordlists, E-Mail-Adressen, Kreditkartennummern, URLs und andere Arten" & vbNewLine &
            "von Informationen aus digitalen Beweisdateien extrahieren kann. Es ist ein nützliches forensisches Untersuchungswerkzeug für" & vbNewLine &
            "viele Aufgaben wie Passwort-Cracking, Malware- und Identitätsuntersuchungen."


            Label2.Text = "Die häufigste Form von Passwörtern ist die Kombination von Wörtern und Zahlen. Ein schwaches Passwort" & vbNewLine &
                          "kann leicht erraten werden, wenn bspw. der Geburtstag, Spitzname, Adresse, Name eines Haustieres oder" & vbNewLine &
                          "der Name des Partners im Passwort verwendet wird. Wordlister und CUPP wurden entwickelt um aus" & vbNewLine &
                          "Informationen zur Zielperson möglichst viele Passwortkombinationen zu erstellen."

            Label3.Text = "CeWL ist eine linuxbasierte Software die eine bestimmte URL bis zu einer bestimmten Tiefe durchsucht und Wordlist aus den" & vbNewLine &
            "gesammelten Informationen erstellt, die dann für Hashbull verwendet werden können."

            Label4.Text = "- Der Maskenprozessor ist ein leistungsstarker Wortlistgenerator mit einem ""per-position"" konfigurierbaren Zeichensatz." & vbNewLine &
            "  Mit diesem Tool können Sie sehr schnell komplexe Wortlists und Masken erstellen." & vbNewLine &
            "- Combinator kann mehrere Wordlists miteinander verbinden."

            Label5.Text = "Der ""Hashbull-Kryptowährungs-Scanner"" scannt den Computer der Zielperson um zu analysieren, ob ggfs. Kryptowährungen genutzt" & vbNewLine &
            "wurden. Es wird nach Indizien für existierende Desktop-, Online- und Hardware-Wallets (Bitcoin, Ethereum, Monero, Exodus," & vbNewLine &
            "Blockchain, Tether, etc.) gesucht. Gefundene Desktop-Wallets können direkt mit Hashbull attackiert werden."

            Label6.Text = "Der Hashbull-Scanner scannt das gesamte Dateiensystem, inkl. der Netzlaufwerke nach verschlüsselten PDF-, Word-, Excel, 7zip," & vbNewLine &
            "Zip und RAR - Dateien. Die Treffer können direkt mit Hashbull attackiert werden."

            GroupBox1.Text = "Hashbull Kryptowährungs-Scanner"
            GroupBox2.Text = "Wordlist - Generatoren"



        End If

    End Sub



    Private Sub Form7_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Welcome.Show()
        Welcome.MinimizeBox = False
        Welcome.Activate()
        Welcome.Opacity = 100

    End Sub





    '###########################################################################################################################
    '# C U P P 
    '###########################################################################################################################

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Scanner.Show()
        Me.Hide()

    End Sub


    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        BulkEx.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        '### MP starten

        Maskprocessor.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        '### CeWL starten

        CEWL.Show()
        Me.Hide()
    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        FileScanner.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '###Wordlister

        Wordlister.ShowDialog()

        If Wordlister.WordlisterExit = False Then


            '### Wordlister-Permutation wird gestartet
            Dim WLM As String = vari.PP3 & " " & Application.StartupPath & "\Packages\Wordlister\wordlister.py --input " & Application.StartupPath & "\#_Wordlists\Wordlister_Input.txt" & Wordlister.PermX & Wordlister.MinLX & Wordlister.MaxLX & Wordlister.LeetX & Wordlister.CapX & Wordlister.UpX

            Dim process2 As New Process()
            process2.StartInfo.FileName = "cmd.exe"
            process2.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\Wordlister\"
            process2.StartInfo.Arguments = ("/c " & WLM)
            process2.Start()
            process2.WaitForExit() 'warten bis Permutation erledigt ist

            Dim DateAuto As String = Format(Now, "HHmmss")

            OldWordlistUtil = Application.StartupPath & "\#_Wordlists\Wordlister_Output.txt"
            NewWordlistUtil = Application.StartupPath & "\#_Wordlists\Wordlister_Output_" & DateAuto & ".txt"
            ' Rename file.
            Rename(OldWordlistUtil, NewWordlistUtil)

            '### Zusammenführung von Output und Input in eine Datei
            Dim sFile As String = Application.StartupPath & "\#_Wordlists\Wordlister_Input.txt"
            System.IO.File.AppendAllText(NewWordlistUtil, sFile)


        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '#### Start Button CUPP

        Dim dateoffice As String = DateTime.Now.ToString("ddMMyy_HHmmss")
        Dim Dateioffice1 As String

        Dim sAppPath As String
        sAppPath = Application.StartupPath
        Dateioffice1 = "#_Wordlists\CUPP_" & dateoffice & ".txt"


        '### CUPP im Verzeichnis "#_Wordlists ausführen


        If My.Settings.Eng = True Then

            MsgBox("You can find the CUPP-Wordlist in the folder ""#_Wordlists""" & vbNewLine & vbNewLine & "CUPP starts now!", vbYes)

            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = Application.StartupPath & "\#_Wordlists"
            process.StartInfo.Arguments = ("/k " & vari.PP3 & " " & Application.StartupPath & "\Packages\CUPP\" & "cupp_hashbull.py -i")
            process.Start()

        Else

            MsgBox("Sie finden die CUPP-Wordlist im Ordner ""#_Wordlists""" & vbNewLine & vbNewLine & "CUPP startet jetzt!", vbYes)

            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = Application.StartupPath & "\#_Wordlists"
            process.StartInfo.Arguments = ("/k " & vari.PP3 & " " & Application.StartupPath & "\Packages\CUPP\" & "cupp_hashbull_GER.py -i")
            process.Start()

        End If

        '#### Alter Befehl
        'Process.Start("cmd", "/k " & vari.PP3 & " " & Application.StartupPath & "\Packages\CUPP\" & "cupp_hashbull.py -i")



    End Sub
End Class