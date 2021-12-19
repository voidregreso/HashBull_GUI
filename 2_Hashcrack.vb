Imports System.IO

Public Class Hashcrack

    Public Property OpenFileDialog As Object
    Public Encoding As String

    '### Rules Wordlist A0
    Public A0Rule1, A0Rule2, A0Rule3, A0Rule4, A0RuleG, AutoRuleG1 As String

    '### Settings
    Public CPUonly, StatusTimer, OnlyDevices, Session, AbortTemp, OtherPara, Force, Workload, Potfile, WordlistLoad As String


    '### Setting in String
    'Public DateNow As String = Format(Now, "yyyyMMdd_HHmmss")
    Public Settings1, WordlistAttac, MaskAttac As String

    Public OutputfileA0, OutputfileA3, OutputfileA1, OutputfileA6, OutputfileA7 As String

    Public CommandHCA0 As String = "hashcat.exe -a 0 -m "
    Public CommandHCA3 As String = "hashcat.exe -a 3 -m "
    Public CommandHCA1 As String = "hashcat.exe -a 1 -m "
    Public CommandHCA6 As String = "hashcat.exe -a 6 -m "
    Public CommandHCA7 As String = "hashcat.exe -a 7 -m "

    '### MaskAttack
    Public Maskload, Charset1A3, Charset2A3, Charset3A3, Charset4A3, IncrementMin, IncrementMax As String

    '### CombiAttac
    Public CombiAttac, RuleA1l, RuleA1r, WordlistA1r, WordlistA1l As String

    '### Hybrid
    Public HyleftAttac, HyrightAttac, WordlHyb, MaskHyb, CharsHyb1, CharsHyb2, CharsHyb3, CharsHyb4 As String

    '### Automatic
    Public LanguageAuto, MaskAuto1, MaskAuto2, MaskAuto3, IncAuto1, IncAuto2, IncAuto3 As String
    Public MasksAt As String
    Public OldWordlist, NewWordlist As String

    '### OutputfileWatcher
    Private Shared OutputFilewatcher As String

    '### Crack-Mail
    Private WithEvents myTimer As New System.Windows.Forms.Timer()
    Private alarmCounter As Integer = 1
    Private exitFlag As Boolean = False

    '### Brain-Server
    Public BrainPara As String




    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '#### Form Loader / Settings
        CPUCbox.Checked = My.Settings.GPUonly
        UpdateCbox.Checked = My.Settings.MinControll
        ForceCbox.Checked = My.Settings.Force
        PotfileCbox.Checked = My.Settings.CheckPot
        WorkloadCbox.Text = My.Settings.Workload
        AbortCbox.Text = My.Settings.Celsius
        EncodingCbox.Text = My.Settings.Encoding
        OnlyDevTbx.Text = My.Settings.DevOnly
        OtherParaTxb.Text = My.Settings.OtherPara
        TimerSekTxb.Text = My.Settings.TimerS
        WorlAutoTxb.Text = My.Settings.fav
        CheckLog.Checked = My.Settings.Checklog
        MailCheckOn.Checked = My.Settings.MailCheck
        BrainOn.Checked = My.Settings.BrainCheck

        '#### Session Vorgabe
        SessionTxb.Text = Format(Now, "yyyy-MM-dd")

        '#### Hybrid Wordlist > Mask vorgeben
        CheckBox5.Checked = True

        '#### Automatic Mode vorgeben (Sprache und Geschwindigkeit)
        LanguageCbox.SelectedItem = "German"
        HashSpeedCbox.SelectedItem = "2"
        AutoRuleG.Text = "1000"

        '#### Favoriten Wordlist laden
        Wordlist.Text = My.Settings.fav

        '### Wordlist laden wenn nicht gespeichert

        If My.Settings.fav = "" Then

            Wordlist.Text = Application.StartupPath & "\#_Wordlists\Hashbull_Wordlist.txt"
            WordlistLoad = Wordlist.Text
            WorlAutoTxb.Text = Wordlist.Text

        End If

        '### Sprache laden
        If My.Settings.Ger = True Then

            Button1.Text = "Datei ausw."
            Button4.Text = "Datei ausw."
            Button5.Text = "Datei ausw."
            Button6.Text = "Datei ausw."
            Button7.Text = "Datei ausw."
            Button10.Text = "Datei ausw."
            Button11.Text = "Datei ausw."
            Button12.Text = "Datei ausw."
            Button13.Text = "Datei ausw."
            Button14.Text = "Datei ausw."
            Button15.Text = "Datei ausw."
            Button16.Text = "Datei ausw."
            Button17.Text = "Datei ausw."
            Button18.Text = "Datei ausw."
            Button19.Text = "Datei ausw."
            Button20.Text = "Datei ausw."
            Button21.Text = "Datei ausw."
            Button30.Text = "Datei ausw."
            Button33.Text = "Datei ausw."
            Button99.Text = "Datei ausw."
            Button28.Text = "Datei ausw."
            Button35.Text = "Löschen"
            Button9.Text = "speichern"
            SessionOpenBtn.Text = "Session öffnen"

            Label6.Text = "Ziel-Hash:"
            Label7.Text = "Sitzungsname:"
            Label17.Text = " bis"
            Label16.Text = "Passwort-Länge"
            Label18.Text = "Wordlist (li.)"
            Label19.Text = "Wordlist (re.)"
            Label20.Text = "Rule (li.)"
            Label21.Text = "Rule (re.)"
            Label47.Text = "Hash Geschwindigkeit:"
            Label48.Text = "Sprache der Zielperson:"

            Label8.Text = "Geschwindigkeit:"
            Label9.Text = "Abbruch bei °C:"
            Label10.Text = "Devices ausw. (z.B. 2,3):"
            Label29.Text = "weitere Parameter:"
            Label34.Text = "(Anzahl zufälliger Rules)"
            Label36.Text = "(Anzahl zufälliger Rules)"
            Label35.Text = "Wählen Sie eine Hash-Datei aus. Hashcat wird versuchen den Hashtypen zu identifizieren."

            Label38.Text = "Wordlister (Zielperson)"

            CPUCbox.Text = "nur CPU benutzen"
            UpdateCbox.Text = "Update Status (in Sek.)"
            ForceCbox.Text = "Warnungen ignorieren (-- force) │ Vorsicht !"
            PotfileCbox.Text = "Pot-File deaktivieren"



        End If

        '# Aktualisieren A0, usw.
        Call Aktualisieren()

        '# Aktualisieren Automatic-Mode
        Call AutoAkt()

    End Sub


    Private Sub Hashcrack_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Welcome.Show()
        Welcome.MinimizeBox = False
        Welcome.Activate()
        Welcome.Opacity = 100

    End Sub


    '### Crack-Mail Auslöser
    Public Sub Mailtimer()

        ' Sets the timer interval to 4 seconds.
        myTimer.Interval = 4000
        myTimer.Start()

    End Sub


    Private Sub TimerEventProcessor(myObject As Object,
                                           ByVal myEventArgs As EventArgs) _
                                       Handles myTimer.Tick

        '### CrackMail wird generiert wenn eingeschaltet
        If MailCheckOn.Checked = True Then

            If File.Exists(OutputFilewatcher) Then

                myTimer.Stop()

                Try
                    Dim objOutlook As Object 'Outlook.Application
                    Dim objOutlookMsg  'As Outlook.MailItem
                    'Dim objOutlookAttach ' As Outlook.Attachment
                    ''Dim objOutlookAttach1 ' As Outlook.Attachment

                    'Erstellen der Outlook Session
                    objOutlook = CreateObject("Outlook.Application")

                    'Erstellen der E-Mail
                    objOutlookMsg = objOutlook.CreateItem(0)

                    With objOutlookMsg
                        .To = My.Settings.Mail
                        .CC = ""
                        .BCC = ""
                        .Subject = "HASHBULL >>> Message <<<"
                        .htmlbody = "The hash has been cracked. Congratulations!"
                        '//am Bildschirm anzeigen
                        '.Display()
                        .send()
                        'Attachment erstellen
                        'If RichTextBox1.Text <> "" Then  'Wenn ein Leerstring kommt gibt es einen Fehler
                        '    objOutlookAttach = .Attachments.Add(RichTextBox2.Text)
                        'End If
                    End With

                    objOutlook = Nothing
                    objOutlookMsg = Nothing

                Catch ex As Exception
                    MessageBox.Show("An error has occurred. Outlook is not installed or the Email-Address is faulty")
                End Try

                If My.Settings.Eng = True Then MsgBox("The hash has been cracked. Congratulations!", vbSystemModal)
                If My.Settings.Eng = False Then MsgBox("Der Hash wurde geknackt. Herzlichen Glückwunsch!", vbSystemModal)

            End If

        End If



        '### Crack-Message wird generiert wenn Crack-Mail ausgeschaltet
        If MailCheckOn.Checked = False Then

            If File.Exists(OutputFilewatcher) Then

                myTimer.Stop()
                If My.Settings.Eng = True Then MsgBox("The hash has been cracked. Congratulations!", vbSystemModal)
                If My.Settings.Eng = False Then MsgBox("Der Hash wurde geknackt. Herzlichen Glückwunsch!", vbSystemModal)

            End If
        End If

    End Sub



    Private Sub Aktualisieren()

        My.Settings.Reload()

        Dim DateNow As String = Format(Now, "yyyyMMdd_HHmmss")

        '### Setting Attack
        Settings1 = (Hashtyp1.Text & " " & Workload & BrainPara & Session & CPUonly & StatusTimer & Force & Encoding & Potfile & AbortTemp & OnlyDevices & OtherPara & PIMstartTxb.Text & PIMstopTxb.Text)

        '### Wordlist Attack
        WordlistAttac = (A0Rule1 & A0Rule2 & A0Rule3 & A0Rule4 & A0RuleG & HashTxb.Text & " " & WordlistLoad)
        OutputfileA0 = "-o " & Application.StartupPath & "\#_Crackout\Crack_" & DateNow & "_Mode_" & Hashtyp1.Text & ".txt "
        CommandA0Txb.Text = CommandHCA0 & Settings1 & OutputfileA0 & WordlistAttac


        '### Mask Attack
        MaskAttac = (Charset1A3 & Charset2A3 & Charset3A3 & Charset4A3 & IncrementMin & IncrementMax & " " & HashTxb.Text & " " & Maskload)
        OutputfileA3 = "-o " & Application.StartupPath & "\#_Crackout\Crack_" & DateNow & "_Mode_" & Hashtyp1.Text & ".txt "
        CommandA3Txb.Text = CommandHCA3 & Settings1 & OutputfileA3 & MaskAttac

        '### CombiAttack
        CombiAttac = (RuleA1l & RuleA1r & " " & HashTxb.Text & " " & WordlistA1left.Text & " " & WordlistA1right.Text)
        OutputfileA1 = "-o " & Application.StartupPath & "\#_Crackout\Crack_" & DateNow & "_Mode_" & Hashtyp1.Text & ".txt "
        CommandA1Txb.Text = CommandHCA1 & Settings1 & OutputfileA3 & CombiAttac


        '### Hybrid

        'Mode 6 (left)

        If CheckBox5.Checked Then
            HyleftAttac = (CharsHyb1 & CharsHyb2 & CharsHyb3 & CharsHyb4 & " " & HashTxb.Text & " " & WordlHyTxb.Text & " " & MaskHybCbox.Text)
            OutputfileA6 = "-o " & Application.StartupPath & "\#_Crackout\Crack_" & DateNow & "_Mode_" & Hashtyp1.Text & ".txt "
            CommandA6Txb.Text = CommandHCA6 & Settings1 & OutputfileA6 & HyleftAttac
        Else

            'Mode A7 (right)
            HyrightAttac = (CharsHyb1 & CharsHyb2 & CharsHyb3 & CharsHyb4 & " " & HashTxb.Text & " " & MaskHybCbox.Text & " " & WordlHyTxb.Text)
            OutputfileA7 = "-o " & Application.StartupPath & "\#_Crackout\Crack_" & DateNow & "_Mode_" & Hashtyp1.Text & ".txt "
            CommandA6Txb.Text = CommandHCA7 & Settings1 & OutputfileA7 & HyrightAttac
        End If


        '### Outputfilewatcher / Crack-Mail oder Crack-Message
        OutputFilewatcher = Application.StartupPath & "\#_Crackout\Crack_" & DateNow & "_Mode_" & Hashtyp1.Text & ".txt"


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles HashTxb.TextChanged

        '#### Überprüfen, ob die Hash-Datei leer ist

        Try

            Dim Datei2 As String = HashTxb.Text

            Dim lines() As String = File.ReadAllLines(Datei2, System.Text.Encoding.ASCII)
            If lines.Length = 0 Then 'prüfen, ob etwas in der Datei steht

                PictureBox11.Visible = True
                PictureBox12.Visible = False

                If My.Settings.Eng = True Then MsgBox("Error: The hash file is empty.")
                If My.Settings.Eng = False Then MsgBox("Es ist ein Fehler aufgetreten. Die Hashdatei ist leer.")

            Else

                PictureBox11.Visible = False
                PictureBox12.Visible = True

            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub Wordlist_TextChanged(sender As Object, e As EventArgs) Handles Wordlist.TextChanged

        WordlistLoad = Wordlist.Text
        Call Aktualisieren()

    End Sub


    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles Hashtyp1.TextChanged

        '#### Wenn ein VeraCrypt-Typ ausgewählt wird, dann PIM-Box anzeige

        If Hashtyp1.Text >= 13711 And Hashtyp1.Text <= 13773 Then HelpPIM.Show()

    End Sub


    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

        '#### Help Button
        ' Process.Start("https://www.hashbull.net")

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

        '#### Müllereimer = Alle Felder leeren
        Wordlist.Clear()
        Rule1A0.Clear()
        Rule2A0.Clear()
        Rule3A0.Clear()
        Rule4A0.Clear()
        RuleGA0.Clear()
        TextBox33.Clear()
        TextBox34.Clear()
        TextBox35.Clear()
        TextBox36.Clear()
        TextBox31.Clear()
        TextBox32.Clear()
        WordlistA1left.Clear()
        WordlistA1right.Clear()
        RuleA1left.Clear()
        RuleA1right.Clear()
        WordlHyTxb.Clear()
        CharsHyTxb1.Clear()
        CharsHyTxb2.Clear()
        CharsHyTxb3.Clear()
        CharsHyTxb4.Clear()
        CommandAutoTxb.Clear()
        CommandBatchTxb.Clear()
        ComboBox6.Text = ""
        MaskHybCbox.Text = ""

    End Sub



    '##############################################################################################################################################################
    '######## S E T T I N G S
    '##############################################################################################################################################################

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        '#### Help als pdf anzeigen
        If My.Settings.Eng = True Then
            Process.Start(System.IO.Path.Combine(Application.StartupPath, "Docs\Hashbull_User_Manual_ENG.pdf"))
        Else
            Process.Start(System.IO.Path.Combine(Application.StartupPath, "Docs\Hashbull_User_Manual_DE.pdf"))
        End If


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        '#### Hash-Target Auswahl und in TexBox1 einfügen 

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\#_Hashout"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            HashTxb.Text = openFileDialog.FileName
        End If

        Call Aktualisieren()


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '#### Wordlist Auswahl 

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\#_Wordlists"
        openFileDialog.Filter = "All Files (*.*)| *.*"

        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Wordlist.Text = openFileDialog.FileName
        End If



    End Sub

    Private Sub SessionOpenBtn_Click(sender As Object, e As EventArgs) Handles SessionOpenBtn.Click

        '### Alte Session open

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Packages\HC"
        openFileDialog.Filter = "All Files (*.restore)| *.restore"

        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim dateiNameOhneEndung As String = IO.Path.GetFileNameWithoutExtension(openFileDialog.SafeFileName)
            SessionTxb.Text = dateiNameOhneEndung
        Else

            Exit Sub

        End If




        If My.Settings.Eng = True And MailCheckOn.Checked = True Then MsgBox("Crackmail is not possible in restore mode.", vbSystemModal)
        If My.Settings.Eng = False And MailCheckOn.Checked = True Then MsgBox("Crackmail ist im Restore-Mode nicht möglich.", vbSystemModal)

        '### Alte Session mit Hashcat starten

        Dim process As New Process()
        process.StartInfo.FileName = "cmd.exe"
        process.StartInfo.WorkingDirectory = vari.Hashcat
        process.StartInfo.Arguments = ("/k " & "hashcat.exe --session " & SessionTxb.Text & " --restore")
        process.Start()



    End Sub


    Private Sub HashtypCBox_KeyPress(
  ByVal sender As Object,
  ByVal e As System.Windows.Forms.KeyPressEventArgs) _
  Handles HashtypCBox.KeyPress

        '#### Nur Zahlen und Backspace in der Hashtyp Auswahl


        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 44 ', 32
                ' Zahlen, Backspace zulassen

            Case Else
                ' alle anderen Eingaben unterdrücken
                e.Handled = True
        End Select
    End Sub


    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CPUCbox.CheckedChanged

        '#### Only CPU Settings

        If CPUCbox.Checked Then
            CPUonly = "-D 1 "
            Call Aktualisieren()

        Else
            CPUonly = ""
            Call Aktualisieren()

        End If

    End Sub


    Private Sub CheckBox2_CheckedChanged_1(sender As Object, e As EventArgs) Handles UpdateCbox.CheckedChanged

        '#### Status Timer Settings

        If UpdateCbox.Checked Then

            My.Settings.Reload()
            StatusTimer = "--status --status-timer=" & My.Settings.TimerS & " "
            Call Aktualisieren()

        Else
            StatusTimer = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub TextBox25_leave(sender As Object, e As EventArgs) Handles TimerSekTxb.Leave

        '### Satus-Timer Settings aktualisieren, wenn nur der Wert (Sek.) geändert wird. Class = Leave

        If UpdateCbox.Checked Then

            Button9.PerformClick()
            My.Settings.Reload()
            StatusTimer = "--status --status-timer=" & My.Settings.TimerS & " "
            Call Aktualisieren()

        Else
            StatusTimer = ""
            Call Aktualisieren()

        End If

    End Sub



    Private Sub CheckBox3_CheckedChanged_1(sender As Object, e As EventArgs) Handles ForceCbox.CheckedChanged

        '#### Force Settings

        If ForceCbox.Checked Then
            Force = "--force "
            Call Aktualisieren()

        Else
            Force = ""
            Call Aktualisieren()

        End If
    End Sub

    Private Sub TextBox62_TextChanged(sender As Object, e As EventArgs) Handles OnlyDevTbx.TextChanged

        '#### Only Devices

        If OnlyDevTbx.TextLength > 0 Then
            OnlyDevices = "-d " & OnlyDevTbx.Text & " "
            Call Aktualisieren()

        Else
            OnlyDevices = ""
            Call Aktualisieren()

        End If

    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        '### Settings speichern und in MySettings laden

        My.Settings.GPUonly = CPUCbox.Checked
        My.Settings.MinControll = UpdateCbox.Checked
        My.Settings.Force = ForceCbox.Checked
        My.Settings.CheckPot = PotfileCbox.Checked
        My.Settings.Workload = WorkloadCbox.Text
        My.Settings.Celsius = AbortCbox.Text
        My.Settings.DevOnly = OnlyDevTbx.Text
        My.Settings.OtherPara = OtherParaTxb.Text
        My.Settings.TimerS = TimerSekTxb.Text
        My.Settings.Encoding = EncodingCbox.Text

        My.Settings.Save()

        If My.Settings.Eng = True Then MsgBox("The settings have been saved!")
        If My.Settings.Eng = False Then MsgBox("Die Einstellungen wurden gespeichert!")

        My.Settings.Reload()

    End Sub


    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles SessionTxb.TextChanged

        '#### Session Eingaben

        If SessionTxb.Text.Length > 1 Then
            Session = "--session=" & SessionTxb.Text & " "
            Call Aktualisieren()

        Else
            Session = ""
            Call Aktualisieren()

        End If

    End Sub



    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WorkloadCbox.SelectedIndexChanged

        '### Nummer des Workloads wird aus der Auswahl extrahiert

        Dim locText As String = Nothing
        locText = WorkloadCbox.Text

        Dim locText2 As String = Nothing
        locText2 = locText.Substring(0, 1)

        Workload = "-w " & locText2 & " "

        Call Aktualisieren()


    End Sub




    Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As _
      System.EventArgs) Handles HashtypCBox.TextChanged

        '#### Hash-Typ Nummer wird auch bei manueller Eingabe richtig weiterverarbeitet

        Dim isInList As Boolean = Me.HashtypCBox.Items.Contains(Me.HashtypCBox.Text)

        Dim idx As Integer = Me.HashtypCBox.FindString(Me.HashtypCBox.Text)
        Dim pos As Integer = Me.HashtypCBox.SelectionStart
        If Not Me.HashtypCBox.Items.Count < 100 Then

            Hashtyp0.Text = HashtypCBox.Text
            SpeedAutoExtrak1.Text = HashtypCBox.Text

            Call Aktualisieren()

        End If

    End Sub

    Private Sub test()

        Dim s As String, c As String, Found As Boolean, Text As String = Nothing

        s = Hashtyp0.Text
        For i = 1 To Len(s)
            c = Mid(s, i, 1)


            ' If c = "(" Then Found = False
            If c = "_" Then Found = True
            If Not Found Then Text = Text & c

            Hashtyp1.Text = Text
        Next

        Hashtyp1.Text = HashtypCBox.Text

        Call Aktualisieren()


    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AbortCbox.SelectedIndexChanged

        '#### Temperatur Überwacher

        AbortTemp = " --hwmon-temp-abort=" & AbortCbox.Text & " "
        Call Aktualisieren()

    End Sub



    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles OtherParaTxb.TextChanged

        '#### Other Parameters werden für die Weiterverarbeitung übergeben

        OtherPara = OtherParaTxb.Text & " "
        Call Aktualisieren()

    End Sub



    Private Sub CheckBox4_CheckedChanged_1(sender As Object, e As EventArgs) Handles PotfileCbox.CheckedChanged

        '#### Potfile disable

        If PotfileCbox.Checked Then
            Potfile = " --potfile-disable "
            Call Aktualisieren()

        Else
            Potfile = ""
            Call Aktualisieren()

        End If
    End Sub


    Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs) Handles Hashtyp0.TextChanged

        Dim s As String, c As String, Found As Boolean, Text As String = Nothing

        '#### Hashtyp-Nummer wird extrahiert

        s = Hashtyp0.Text
        For i = 1 To Len(s)
            c = Mid(s, i, 1)

            ' If c = "(" Then Found = False
            If c = "_" Then Found = True
            If Not Found Then Text = Text & c

            Hashtyp1.Text = Text
        Next

    End Sub


    Private Sub TextBox26_TextChanged(sender As Object, e As EventArgs) Handles PIMvarTxb1.TextChanged

        '#### VeraCrypt PIM Start

        If PIMvarTxb1.Text.Length > 1 Then
            PIMstartTxb.Text = "--veracrypt-pim-start=" & PIMvarTxb1.Text & " "
            PIMstopTxb.Text = "--veracrypt-pim-stop=" & PIMvarTxb2.Text & " "
            Call Aktualisieren()
        Else
            PIMstartTxb.Text = ""
        End If

    End Sub

    Private Sub TextBox27_TextChanged(sender As Object, e As EventArgs) Handles PIMvarTxb2.TextChanged

        '#### VeraCrypt PIM Stop

        If PIMvarTxb2.Text.Length > 1 Then
            PIMstartTxb.Text = "--veracrypt-pim-start=" & PIMvarTxb1.Text & " "
            PIMstopTxb.Text = "--veracrypt-pim-stop=" & PIMvarTxb2.Text & " "
            Call Aktualisieren()
        Else
            PIMstopTxb.Text = ""
        End If

    End Sub


    Private Sub TextBox62_KeyPress(
  ByVal sender As Object,
  ByVal e As System.Windows.Forms.KeyPressEventArgs) _
  Handles OnlyDevTbx.KeyPress

        '#### Only Devices, nur Zahlen und Backspace und Komma 


        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 44 ', 32
                ' Zahlen, Backspace und Space zulassen

            Case Else
                ' alle anderen Eingaben unterdrücken
                e.Handled = True
        End Select
    End Sub



    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click

        '#### Help Button

        Process.Start("https://hashcat.net/wiki/doku.php?id=hashcat")
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EncodingCbox.SelectedIndexChanged

        TextBox66.Text = EncodingCbox.Text

    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click

        '### Help Encoding
        HelpEncoding.Show()

    End Sub

    Private Sub TextBox66_TextChanged(sender As Object, e As EventArgs) Handles TextBox66.TextChanged

        Dim s As String, c As String, Found As Boolean, Text As String = Nothing

        '#### ISO-Nummer wird extrahiert

        If TextBox66.Text = "_Encoding_OFF" Then

            Encoding = ""
            Call Aktualisieren()

        Else

            s = TextBox66.Text
            For i = 1 To Len(s)
                c = Mid(s, i, 1)

                ' If c = "(" Then Found = False
                If c = "_" Then Found = True


                If Not Found Then Text = Text & c

                '### Alle Wordlists müssen in UTF8 kodiert sein

                Encoding = "--encoding-from=utf-8 --encoding-to=" & Text
                Call Aktualisieren()

            Next
        End If

    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click

        '### Check Devices (-I)

        Dim process As New Process()
        process.StartInfo.FileName = "cmd.exe"
        process.StartInfo.WorkingDirectory = vari.Hashcat
        process.StartInfo.Arguments = ("/k " & "hashcat.exe -I")
        process.Start()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles MailCheckOn.CheckedChanged

        '### Crack Mail / Button On

        If My.Settings.Mail = "" And MailCheckOn.Checked = True Then


            If My.Settings.Eng = True Then MsgBox("You have to enter an email address under ""Settings""!")
            If My.Settings.Eng = False Then MsgBox("Sie müssen eine E-Mail-Adresse unter ""Settings"" einfügen!")
            MailCheckOn.Checked = False
            My.Settings.MailCheck = False

            Exit Sub

        End If

        If MailCheckOn.Checked = True Then

            My.Settings.MailCheck = True
            My.Settings.Save()
            My.Settings.Reload()

        End If

        If MailCheckOn.Checked = False Then

            My.Settings.MailCheck = False
            My.Settings.Save()
            My.Settings.Reload()

        End If

    End Sub



    Private Sub BrainOn_CheckedChanged_1(sender As Object, e As EventArgs) Handles BrainOn.CheckedChanged


        '### Brain-Server aktivieren

        If My.Settings.ClientIP = "" And BrainOn.Checked = True Then


            If My.Settings.Eng = True Then MsgBox("You have to enter an server-ip under ""Settings""!")
            If My.Settings.Eng = False Then MsgBox("Sie müssen die Server-Parameter unter ""Settings"" einfügen!")
            BrainOn.Checked = False
            BrainPara = ""
            Call Aktualisieren()
            Exit Sub

        End If

        If BrainOn.Checked = True Then

            BrainPara = "--brain-client --brain-client-features=" & My.Settings.ClientFeat & " --brain-host=" & My.Settings.ClientIP & " --brain-port=" & My.Settings.ClientPort & " --brain-password=" & My.Settings.ClientPW & " "
            Potfile = ""

            My.Settings.BrainCheck = True
            My.Settings.Save()
            My.Settings.Reload()

            Call Aktualisieren()

            End If

        If BrainOn.Checked = False Then

            BrainPara = ""
            Potfile = " --potfile-disable "

            My.Settings.BrainCheck = False
            My.Settings.Save()
            My.Settings.Reload()

            Call Aktualisieren()

        End If

    End Sub





    '##############################################################################################################
    'Wordlist Mode A0
    '##############################################################################################################


    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click

        Try

            '###Prüfen ob ein Hash ausgewählt wurde und ein Hash-Typ

            If HashtypCBox.Text.Length = 0 Or HashTxb.TextLength = 0 Then
                If My.Settings.Eng = True Then MsgBox("Please select a Target-Hash-File and a Hash-Typ.", vbExclamation)
                If My.Settings.Eng = False Then MsgBox("Bitte wählen Sie eine Ziel-Hash-Datei und einen Hash-Typ aus.", vbExclamation)
                Exit Sub
            End If


            My.Settings.Reload()

            '### Hashcat-Meldung bei erstmaliger Benutzung
            If My.Settings.CheckHelp1 = False Then HelpHashcat.ShowDialog()

            '#### Start Button führt Command-Fenster aus

            'Button22.PerformClick()

            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = vari.Hashcat
            process.StartInfo.Arguments = ("/k " & CommandA0Txb.Text)
            process.Start()

            Call Mailtimer()


            '### Attacke dokumentieren
            If My.Settings.Checklog = True Then

                Dim DateBatch As String = Format(Now, "yyyy_MM_dd_HH_mm_ss")
                Dim Pfadbatch As String = (Application.StartupPath & "\Logs\" & SessionTxb.Text & "_" & DateBatch & "_" & Hashtyp1.Text & ".txt")
                Dim fs As New FileStream(Pfadbatch, FileMode.Append, FileAccess.Write)
                Dim s As New StreamWriter(fs)
                s.WriteLine(CommandA0Txb.Text & vbNewLine)
                's.WriteLine("Pause")
                s.Close()

            End If




        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        '# Rule1 Auswahl #

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Rules"
        openFileDialog.Filter = "All Files (*.*)| *.*"

        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Rule1A0.Text = openFileDialog.FileName
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        '# Rule2 Auswahl #

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Rules"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Rule2A0.Text = openFileDialog.FileName
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        '# Rule3 Auswahl #

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Rules"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Rule3A0.Text = openFileDialog.FileName
        End If

    End Sub

    Private Sub Button99_Click(sender As Object, e As EventArgs) Handles Button99.Click

        '# Rule4 Auswahl #

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Rules"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Rule4A0.Text = openFileDialog.FileName
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Rule1A0.TextChanged

        '#### Rules nachbearbeiten

        If Rule1A0.Text.Length > 0 Then
            A0Rule1 = " -r " & Rule1A0.Text & " "
            Call Aktualisieren()
        Else
            A0Rule1 = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles Rule2A0.TextChanged

        '#### Rules nachbearbeiten

        If Rule2A0.Text.Length > 0 Then
            A0Rule2 = " -r " & Rule2A0.Text & " "
            Call Aktualisieren()
        Else
            A0Rule2 = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles Rule3A0.TextChanged

        '#### Rules nachbearbeiten

        If Rule3A0.Text.Length > 0 Then
            A0Rule3 = " -r " & Rule3A0.Text & " "
            Call Aktualisieren()
        Else
            A0Rule3 = ""
            Call Aktualisieren()
        End If

    End Sub


    Private Sub Rule4A0_TextChanged(sender As Object, e As EventArgs) Handles Rule4A0.TextChanged

        '#### Rules nachbearbeiten

        If Rule4A0.Text.Length > 0 Then
            A0Rule4 = " -r " & Rule4A0.Text & " "
            Call Aktualisieren()
        Else
            A0Rule4 = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub RuleGA0_TextChanged(sender As Object, e As EventArgs) Handles RuleGA0.TextChanged

        '#### Rule G nachbearbeiten

        If RuleGA0.Text.Length > 0 Then
            A0RuleG = " -g " & RuleGA0.Text & " "
            Call Aktualisieren()
        Else
            A0RuleG = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub RuleGA0_KeyPress(
  ByVal sender As Object,
  ByVal e As System.Windows.Forms.KeyPressEventArgs) _
  Handles RuleGA0.KeyPress

        '#### Only Devices, nur Zahlen und Backspace und Komma 


        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 44 ', 32
                ' Zahlen, Backspace und Space zulassen

            Case Else
                ' alle anderen Eingaben unterdrücken
                e.Handled = True
        End Select
    End Sub



    '################################################################################################################################################################################
    ' MASK Mode A3
    '################################################################################################################################################################################


    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click

        Try

            '### Prüfen ob ein Hash ausgewählt wurde und ein Hash-Typ

            If HashtypCBox.Text.Length = 0 Or HashTxb.TextLength = 0 Then
                If My.Settings.Eng = True Then MsgBox("Please select a Target-Hash-File and a Hash-Typ.", vbExclamation)
                If My.Settings.Eng = False Then MsgBox("Bitte wählen Sie eine Ziel-Hash-Datei und einen Hash-Typ aus.", vbExclamation)
                Exit Sub
            End If


            My.Settings.Reload()

            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = vari.Hashcat
            process.StartInfo.Arguments = ("/k " & CommandA3Txb.Text)
            process.Start()

            '### Cracktimer
            Call Mailtimer()


            '### Attacke dokumentieren
            If My.Settings.Checklog = True Then
                Dim DateBatch As String = Format(Now, "yyyy_MM_dd_HH_mm_ss")
                Dim Pfadbatch As String = (Application.StartupPath & "\Logs\" & SessionTxb.Text & "_" & DateBatch & "_" & Hashtyp1.Text & ".txt")
                Dim fs As New FileStream(Pfadbatch, FileMode.Append, FileAccess.Write)
                Dim s As New StreamWriter(fs)
                s.WriteLine(CommandA3Txb.Text & vbNewLine)
                's.WriteLine("Pause")
                s.Close()
            End If


        Catch ex As Exception

        End Try


    End Sub



    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        '###### Mask öffnen in Combobox 6

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Masks"
        openFileDialog.Filter = "All Files (*.*)| *.*"

        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ComboBox6.Text = openFileDialog.FileName
        End If

        Maskload = ComboBox6.Text
        Call Aktualisieren()

    End Sub


    Private Sub ComboBox6_TextUpdate(sender As Object, e As EventArgs) _
     Handles ComboBox6.TextUpdate

        '### Manuelle Eingaben übernehmen

        Maskload = ComboBox6.Text
        Call Aktualisieren()

    End Sub


    Private Sub ComboBox6_TextChanged(sender As Object, e As EventArgs) Handles ComboBox6.TextChanged

        '### Auswahl Combobox übernehmen

        Maskload = ComboBox6.Text
        Call Aktualisieren()

    End Sub





    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        '###### Charset öffnen in TexB 33

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Charsets"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox33.Text = openFileDialog.FileName
        End If


        If TextBox33.TextLength > 0 Then
            Charset1A3 = " -1 " & TextBox33.Text
            Call Aktualisieren()
        Else
            Charset1A3 = ""
            Call Aktualisieren()
        End If


    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        '##### Charset öffnen in TexB 34

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Charsets"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox34.Text = openFileDialog.FileName
        End If

        If TextBox34.TextLength > 0 Then
            Charset2A3 = " -2 " & TextBox34.Text
            Call Aktualisieren()
        Else
            Charset2A3 = ""
            Call Aktualisieren()
        End If


    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click

        '#### Charset öffnen in TexB 35

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Charsets"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox35.Text = openFileDialog.FileName
        End If

        If TextBox35.TextLength > 0 Then
            Charset3A3 = " -3 " & TextBox35.Text
            Call Aktualisieren()
        Else
            Charset3A3 = ""
            Call Aktualisieren()
        End If


    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

        '#### Charset öffnen in TexB 33

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Charsets"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox36.Text = openFileDialog.FileName
        End If

        If TextBox36.TextLength > 0 Then
            Charset4A3 = " -4 " & TextBox36.Text
            Call Aktualisieren()
        Else
            Charset4A3 = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub TextBox31_TextChanged(sender As Object, e As EventArgs) Handles TextBox31.TextChanged

        '#### Increment Mode (min)

        If TextBox31.TextLength > 0 Then
            IncrementMin = " --increment --increment-min " & TextBox31.Text
            Call Aktualisieren()
        Else
            IncrementMin = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub TextBox32_TextChanged(sender As Object, e As EventArgs) Handles TextBox32.TextChanged

        '#### Increment Mode (max)

        If TextBox32.TextLength > 0 Then
            IncrementMax = " --increment-max " & TextBox32.Text
            Call Aktualisieren()
        Else
            IncrementMax = ""
            Call Aktualisieren()
        End If

    End Sub



    Private Sub TextBox33_TextChanged(sender As Object, e As EventArgs) Handles TextBox33.TextChanged

        '#### Charsets weiterbearbeiten

        If TextBox33.TextLength > 0 Then
            Charset1A3 = " -1 " & TextBox33.Text
            Call Aktualisieren()
        Else
            Charset1A3 = ""
            Call Aktualisieren()
        End If

    End Sub



    Private Sub TextBox34_TextChanged(sender As Object, e As EventArgs) Handles TextBox34.TextChanged

        '#### Charsets weiterbearbeiten

        If TextBox34.TextLength > 0 Then
            Charset2A3 = " -2 " & TextBox34.Text
            Call Aktualisieren()
        Else
            Charset2A3 = ""
            Call Aktualisieren()
        End If

    End Sub



    Private Sub TextBox35_TextChanged(sender As Object, e As EventArgs) Handles TextBox35.TextChanged

        '#### Charsets weiterbearbeiten

        If TextBox35.TextLength > 0 Then
            Charset3A3 = " -3 " & TextBox35.Text
            Call Aktualisieren()
        Else
            Charset3A3 = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub TextBox36_TextChanged(sender As Object, e As EventArgs) Handles TextBox36.TextChanged

        '#### Charsets weiterbearbeiten

        If TextBox36.TextLength > 0 Then
            Charset4A3 = " -4 " & TextBox36.Text
            Call Aktualisieren()
        Else
            Charset4A3 = ""
            Call Aktualisieren()
        End If

    End Sub



    Private Sub TextBox31_KeyPress(
  ByVal sender As Object,
  ByVal e As System.Windows.Forms.KeyPressEventArgs) _
  Handles TextBox31.KeyPress

        '#### Nur Zahlen und Backspace bei Wörterlänge zulassen


        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8
                ' Zahlen, Backspace 

            Case Else
                ' alle anderen Eingaben unterdrücken
                e.Handled = True
        End Select
    End Sub



    Private Sub TextBox32_KeyPress(
ByVal sender As Object,
ByVal e As System.Windows.Forms.KeyPressEventArgs) _
Handles TextBox32.KeyPress

        '#### Nur Zahlen und Backspace bei Wörterlänge zulassen

        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8
                ' Zahlen, Backspace 

            Case Else
                ' alle anderen Eingaben unterdrücken
                e.Handled = True
        End Select
    End Sub

    Private Sub CheckLog_CheckedChanged(sender As Object, e As EventArgs) Handles CheckLog.CheckedChanged

        If CheckLog.Checked = True Then
            My.Settings.Checklog = True
            My.Settings.Save()
            My.Settings.Reload()
        Else
            My.Settings.Checklog = False
            My.Settings.Save()
            My.Settings.Reload()
        End If


    End Sub






    '#################################################################################################################################################################
    'Combinator Mode A1
    '#################################################################################################################################################################


    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click

        '### Prüfen ob ein Hash ausgewählt wurde und ein Hash-Typ

        If HashtypCBox.Text.Length = 0 Or HashTxb.TextLength = 0 Then
            If My.Settings.Eng = True Then MsgBox("Please select a Target-Hash-File And a Hash-Typ.", vbExclamation)
            If My.Settings.Eng = False Then MsgBox("Bitte wählen Sie eine Ziel-Hash-Datei und einen Hash-Typ aus.", vbExclamation)
            Exit Sub
        End If


        My.Settings.Reload()

        Dim process As New Process()
        process.StartInfo.FileName = "cmd.exe"
        process.StartInfo.WorkingDirectory = vari.Hashcat
        process.StartInfo.Arguments = ("/k " & CommandA1Txb.Text)
        process.Start()

        '### Cracktimer
        Call Mailtimer()


        '### Attacke dokumentieren
        If My.Settings.Checklog = True Then
            Dim DateBatch As String = Format(Now, "yyyy_MM_dd_HH_mm_ss")
            Dim Pfadbatch As String = (Application.StartupPath & "\Logs\" & SessionTxb.Text & "_" & DateBatch & "_" & Hashtyp1.Text & ".txt")
            Dim fs As New FileStream(Pfadbatch, FileMode.Append, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.WriteLine(CommandA1Txb.Text & vbNewLine)
            's.WriteLine("Pause")
            s.Close()
        End If


    End Sub



    Private Sub WordlHyTxb_TextChanged(sender As Object, e As EventArgs) Handles WordlHyTxb.TextChanged

        '### Wordlist wird upgedatet wenn händisch geändert
        WordlHyb = WordlHyTxb.Text
        Call Aktualisieren()

    End Sub


    ' Private Sub MaskHybCbox_TextUpdate(sender As Object, e As EventArgs) Handles MaskHybCbox.TextUpdate

    '    '### Mask wird upgedatet wenn händisch geändert
    '   MaskHyb = MaskHybCbox.Text
    'Call Aktualisieren()

    'End Sub




    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

        '#### Wordlist left auswählen

        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.InitialDirectory = Application.StartupPath & "\#_Wordlists"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            WordlistA1left.Text = openFileDialog.FileName

        End If

        WordlistA1l = WordlistA1left.Text
        Call Aktualisieren()

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click

        '#### Wordlist right auswählen

        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.InitialDirectory = Application.StartupPath & "\#_Wordlists"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            WordlistA1right.Text = openFileDialog.FileName

        End If

        WordlistA1r = WordlistA1right.Text
        Call Aktualisieren()

    End Sub

    Private Sub WordlistA1left_TextChanged(sender As Object, e As EventArgs) Handles WordlistA1left.TextChanged

        WordlistA1l = WordlistA1left.Text
        Call Aktualisieren()

    End Sub

    Private Sub WordlistA1right_TextChanged(sender As Object, e As EventArgs) Handles WordlistA1right.TextChanged

        WordlistA1r = WordlistA1right.Text
        Call Aktualisieren()

    End Sub


    Private Sub TextBox47_TextChanged(sender As Object, e As EventArgs) Handles RuleA1left.TextChanged

        '##### Rule left

        If RuleA1left.TextLength > 0 Then
            RuleA1l = " -j " & RuleA1left.Text
            Call Aktualisieren()
        Else
            RuleA1l = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub TextBox48_TextChanged(sender As Object, e As EventArgs) Handles RuleA1right.TextChanged


        '#### Rule right

        If RuleA1right.TextLength > 0 Then
            RuleA1r = " -k " & RuleA1right.Text
            Call Aktualisieren()
        Else
            RuleA1r = ""
            Call Aktualisieren()
        End If

    End Sub




    '##########################################################################################################################################################
    'Hybrid left + right
    '##########################################################################################################################################################


    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click

        Try

            '### Prüfen ob ein Hash ausgewählt wurde und ein Hash-Typ

            My.Settings.Reload()

            If HashtypCBox.Text.Length = 0 Or HashTxb.TextLength = 0 Then
                If My.Settings.Eng = True Then MsgBox("Please select a Target-Hash-File And a Hash-Typ.", vbExclamation)
                If My.Settings.Eng = False Then MsgBox("Bitte wählen Sie eine Ziel-Hash-Datei und einen Hash-Typ aus.", vbExclamation)
                Exit Sub
            End If

            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = vari.Hashcat
            process.StartInfo.Arguments = ("/k " & CommandA6Txb.Text)
            process.Start()

            '### Cracktimer
            Call Mailtimer()


            '### Attacke dokumentieren
            If My.Settings.Checklog = True Then
                Dim DateBatch As String = Format(Now, "yyyy_MM_dd_HH_mm_ss")
                Dim Pfadbatch As String = (Application.StartupPath & "\Logs\" & SessionTxb.Text & "_" & DateBatch & "_" & Hashtyp1.Text & ".txt")
                Dim fs As New FileStream(Pfadbatch, FileMode.Append, FileAccess.Write)
                Dim s As New StreamWriter(fs)
                s.WriteLine(CommandA6Txb.Text & vbNewLine)
                's.WriteLine("Pause")
                s.Close()
            End If

        Catch ex As Exception

        End Try

    End Sub



    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click

        '###### Wordlist right

        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.InitialDirectory = Application.StartupPath & "\#_Wordlists"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            WordlHyTxb.Text = openFileDialog.FileName

        End If

        WordlHyb = WordlHyTxb.Text
        Call Aktualisieren()

    End Sub



    Private Sub TextBox51_TextChanged(sender As Object, e As EventArgs) Handles CharsHyTxb1.TextChanged

        '#### Charset

        If CharsHyTxb1.TextLength > 0 Then
            CharsHyb1 = " -1 " & CharsHyTxb1.Text
            Call Aktualisieren()
        Else
            CharsHyb1 = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub TextBox52_TextChanged(sender As Object, e As EventArgs) Handles CharsHyTxb2.TextChanged

        '#### Charset

        If CharsHyTxb2.TextLength > 0 Then
            CharsHyb2 = " -2 " & CharsHyTxb2.Text
            Call Aktualisieren()
        Else
            CharsHyb2 = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub TextBox53_TextChanged(sender As Object, e As EventArgs) Handles CharsHyTxb3.TextChanged

        '#### Charset

        If CharsHyTxb3.TextLength > 0 Then
            CharsHyb3 = " -3 " & CharsHyTxb3.Text
            Call Aktualisieren()
        Else
            CharsHyb3 = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub TextBox54_TextChanged(sender As Object, e As EventArgs) Handles CharsHyTxb4.TextChanged

        '#### Charset

        If CharsHyTxb4.TextLength > 0 Then
            CharsHyb4 = " -4 " & CharsHyTxb4.Text
            Call Aktualisieren()
        Else
            CharsHyb4 = ""
            Call Aktualisieren()
        End If

    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click

        '#### Mask auswählen

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Masks"
        openFileDialog.Filter = "All Files (*.*)| *.*"

        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MaskHybCbox.Text = openFileDialog.FileName

        End If

        MaskHyb = MaskHybCbox.Text

    End Sub



    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged

        '#### Nur eine Checkbox ist aktiviert
        If CheckBox5.Checked Then
            CheckBox6.Checked = False
        End If


        '### Wenn zweimal gedrückt, dann die andere aktiviveren
        If CheckBox5.Checked = False Then
            CheckBox6.Checked = True
        End If

        Call Aktualisieren()

    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged

        '#### Nur eine Checkbox ist aktiviert
        If CheckBox6.Checked Then
            CheckBox5.Checked = False
        End If

        '### Wenn zweimal gedrückt, dann die andere aktiviveren
        If CheckBox6.Checked = False Then
            CheckBox5.Checked = True
        End If

        Call Aktualisieren()

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click

        '#### Charset auswählen

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Charsets"
        openFileDialog.Filter = "All Files (*.*)| *.*"

        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CharsHyTxb1.Text = openFileDialog.FileName
        End If

        CharsHyb1 = CharsHyTxb1.Text
        Call Aktualisieren()

    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click

        '#### Charset auswählen

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Charsets"
        openFileDialog.Filter = "All Files (*.*)| *.*"


        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CharsHyTxb2.Text = openFileDialog.FileName
        End If

        CharsHyb2 = CharsHyTxb2.Text
        Call Aktualisieren()

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click

        '#### Charset auswählen

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Charsets"
        openFileDialog.Filter = "All Files (*.*)| *.*"

        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CharsHyTxb3.Text = openFileDialog.FileName
        End If

        CharsHyb3 = CharsHyTxb3.Text
        Call Aktualisieren()

    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click

        '#### Charset auswählen

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\Charsets"
        openFileDialog.Filter = "All Files (*.*)| *.*"

        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CharsHyTxb4.Text = openFileDialog.FileName
        End If

        CharsHyb4 = CharsHyTxb4.Text
        Call Aktualisieren()

    End Sub

    Private Sub MaskHybCbox_TextUpdate(sender As Object, e As EventArgs) _
     Handles MaskHybCbox.TextUpdate

        '### Manuelle Eingaben übernehmen

        MaskHyb = MaskHybCbox.Text
        Call Aktualisieren()

    End Sub


    Private Sub MaskHybCbox_TextChanged(sender As Object, e As EventArgs) Handles MaskHybCbox.TextChanged

        '### Auswahl Combobox übernehmen

        MaskHyb = MaskHybCbox.Text
        Call Aktualisieren()

    End Sub



    '###############################################################################################################################################################################
    '## Automatic Mode
    '###############################################################################################################################################################################

    Private Sub AutoAkt()


        '############# AKTUALISERUNG!!

        Try

            My.Settings.Reload()


            Dim WLMwordlist As String = HashTxb.Text & " " & NewWordlist

            Dim Mask1 As String = LanguageAuto & " " & TextBox61.Text
            Dim Mask3 As String = "-3 ?1?2 " ' Hier werden die Charset (Sprache) zusammengefasst
            Dim MaskCom As String = " ?3?3?3?3?3?3?3?3" 'max. 8, ansonsten gfs. overload


            'If HashSpeedCbox.Text = 1 Then MaskAuto1 = Application.StartupPath & "\Masks\Hashbull_Masks_5_16.hcmask"
            'If HashSpeedCbox.Text = 2 Then MaskAuto2 = Application.StartupPath & "\Masks\Hashbull_Masks_7_16.hcmask"
            'If HashSpeedCbox.Text = 3 Then MaskAuto3 = Application.StartupPath & "\Masks\Hashbull_Masks_9_16.hcmask"



            If HashSpeedCbox.Text = 1 Then MasksAt = Application.StartupPath & "\Masks\Hashbull_Masks_5_16.hcmask"
            If HashSpeedCbox.Text = 2 Then MasksAt = Application.StartupPath & "\Masks\Hashbull_Masks_7_16.hcmask"
            If HashSpeedCbox.Text = 3 Then MasksAt = Application.StartupPath & "\Masks\Hashbull_Masks_9_16.hcmask"

            ' Dim MasksAt As String = MaskAuto1 & MaskAuto2 & MaskAuto3 'Der Warnhinweis kann ignoriert werden, da beim FormLoad Werte bereits geladen werden


            If HashSpeedCbox.Text = 1 Then IncAuto1 = " --increment --increment-min 1 --increment-max 4 " 'Hash-Geschwindigkeit Slow (1)
            If HashSpeedCbox.Text = 2 Then IncAuto1 = " --increment --increment-min 1 --increment-max 6 " 'Hash-Geschwindigkeit Middle (2)
            If HashSpeedCbox.Text = 3 Then IncAuto1 = " --increment --increment-min 1 --increment-max 8 " 'Hash-Geschwindigkeit Fast (3)


            Dim MaskAttac As String = IncAuto1 & Mask1 & " " & Mask3 & " " & HashTxb.Text & MaskCom 'Der Warnhinweis kann ignoriert werden, da beim FormLoad Werte bereits geladen werden

            Dim Settings1 As String = (Hashtyp1.Text & " " & Workload & Session & CPUonly & StatusTimer & Force & Potfile & AbortTemp & OnlyDevices & OtherPara & PIMstartTxb.Text & PIMstopTxb.Text)

            Dim wordlist As String = AutoRuleG1 & HashTxb.Text & " " & WorlAutoTxb.Text


            '#### Output Parameters

            Dim Outputfile As String
            Dim Date3 As String = Format(Now, "yyyyMMdd_HHmmss")
            Outputfile = "-o " & Application.StartupPath & "\#_Crackout\Crack_" & Date3 & "_Mode_" & Hashtyp1.Text & ".txt "
            OutputFilewatcher = Application.StartupPath & "\#_Crackout\Crack_" & Date3 & "_Mode_" & Hashtyp1.Text & ".txt"


            '#### Attacken Strategie

            Dim WLMcall As String = "call hashcat.exe -a 0 -m " & Settings1 & Encoding & " " & Outputfile & WLMwordlist
            Dim Attac1 As String = "call hashcat.exe -a 0 -m " & Settings1 & Encoding & " " & Outputfile & wordlist
            'Dim Attac2 As String = "call hashcat.exe -a 0 -m " & Settings1 & Encoding & " " & Outputfile & " -j T0 " & wordlist
            'Dim Attac3 As String = "call hashcat.exe -a 0 -m " & Settings1 & Encoding & " " & Outputfile & " -g 100 " & wordlist
            Dim Attac4 As String = "call hashcat.exe -a 3 -m " & Settings1 & Outputfile & MaskAttac
            Dim Attac5 As String = "call hashcat.exe -a 3 -m " & Settings1 & Outputfile & HashTxb.Text & " " & MasksAt


            '#### In Command Box laden

            If WLMCheck.Checked = True Then
                CommandAutoTxb.Text = WLMcall & vbNewLine & vbNewLine & Attac1 & vbNewLine & vbNewLine & "timeout /T 10 /nobreak" & vbNewLine & vbNewLine & Attac4 & vbNewLine & vbNewLine & "timeout /T 10 /nobreak" & vbNewLine & vbNewLine & Attac5
            Else
                CommandAutoTxb.Text = Attac1 & vbNewLine & vbNewLine & "timeout /T 10 /nobreak" & vbNewLine & vbNewLine & Attac4 & vbNewLine & vbNewLine & "timeout /T 10 /nobreak" & vbNewLine & vbNewLine & Attac5
            End If

        Catch ex As Exception

        End Try


    End Sub



    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click

        '###Start-Button

        Try

            '### Prüfen ob ein Hash ausgewählt wurde und ein Hash-Typ
            If HashtypCBox.Text.Length = 0 Or HashTxb.TextLength = 0 Then
                If My.Settings.Eng = True Then MsgBox("Please select a Target-Hash-File And a Hash-Typ.", vbExclamation)
                If My.Settings.Eng = False Then MsgBox("Bitte wählen Sie eine Ziel-Hash-Datei und einen Hash-Typ aus.", vbExclamation)
                Exit Sub
            End If

            '#Wordlister einblenden
            If WLMCheck.Checked = True Then

                '### WordlisterExit erstmal abschalten
                Wordlister.WordlisterExit = False

                '### Wordlister wird aufgerufen und abgewartet
                Wordlister.ShowDialog()

                If Wordlister.WordlisterExit = True Then
                    Exit Sub
                Else

                End If

                '### Wordlister-Permutation wird gestartet
                Dim WLM As String = vari.PP3 & " " & Application.StartupPath & "\Packages\Wordlister\wordlister.py --input " & Application.StartupPath & "\#_Wordlists\Wordlister_Input.txt" & Wordlister.PermX & Wordlister.MinLX & Wordlister.MaxLX & Wordlister.LeetX & Wordlister.CapX & Wordlister.UpX

                Dim process2 As New Process()
                process2.StartInfo.FileName = "cmd.exe"
                process2.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\Wordlister\"
                process2.StartInfo.Arguments = ("/c " & WLM)
                process2.Start()
                process2.WaitForExit() 'warten bis Permutation erledigt ist


                '### Wordlist-Output umbennen 
                Dim DateAuto As String = Format(Now, "HHmmss")

                OldWordlist = Application.StartupPath & "\#_Wordlists\Wordlister_Output.txt"
                NewWordlist = Application.StartupPath & "\#_Wordlists\" & SessionTxb.Text & "_Wordlister_Output_" & DateAuto & ".txt"
                ' Rename file.
                Rename(OldWordlist, NewWordlist)


                '### Zusammenführung von Output und Input in eine Datei
                Dim sFile As String = Application.StartupPath & "\#_Wordlists\Wordlister_Input.txt"
                System.IO.File.AppendAllText(NewWordlist, sFile)


                Call AutoAkt()

            Else

            End If



            '#### Start Button schreibt die Command Box in eine Batch Datei

            Dim DateBatch3 As String = Format(Now, "yyyyMMdd_HHmmss")
            'Dim Pfadbatch As String = (Application.StartupPath & "\Packages\HC\Hashbull_Batch_" & DateBatch & ".bat")
            Dim Pfadbatch3 As String = (Application.StartupPath & "\Batchjob\Hashbull_Auto_" & DateBatch3 & ".bat")
            Dim fs3 As New FileStream(Pfadbatch3, FileMode.Append, FileAccess.Write)
            Dim s3 As New StreamWriter(fs3)
            s3.WriteLine(CommandAutoTxb.Text & vbNewLine)
            's.WriteLine("Pause")    durch /k ist Pause überflüssig
            s3.Close()

            '#### Batch starten

            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\HC\"
            'process.StartInfo.Arguments = ("/k Hashbull_Batch_" & DateBatch & ".bat")
            process.StartInfo.Arguments = ("/k " & Pfadbatch3)
            process.Start()

            '### Cracktimer
            Call Mailtimer()


            '### Attacke dokumentieren
            If My.Settings.Checklog = True Then
                Dim DateBatch1 As String = Format(Now, "yyyy_MM_dd_HH_mm_ss")
                Dim Pfadbatch1 As String = (Application.StartupPath & "\Logs\" & SessionTxb.Text & "_" & DateBatch1 & "_" & Hashtyp1.Text & ".txt")
                Dim fs1 As New FileStream(Pfadbatch1, FileMode.Append, FileAccess.Write)
                Dim s1 As New StreamWriter(fs1)
                s1.WriteLine(CommandAutoTxb.Text & vbNewLine)
                's.WriteLine("Pause")
                s1.Close()
            End If

        Catch ex As Exception

        End Try

    End Sub



    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LanguageCbox.SelectedIndexChanged

        '#### Die richtigen hcchr Dateien laden bzgl. Sprache

        If LanguageCbox.Text = "Bulgarien" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\Bulgarian.hcchr"
        If LanguageCbox.Text = "English" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\English.hcchr"
        If LanguageCbox.Text = "French" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\French.hcchr"
        If LanguageCbox.Text = "German" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\German.hcchr"
        If LanguageCbox.Text = "Greek" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\Greek.hcchr"
        If LanguageCbox.Text = "Italien" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\Italien.hcchr"
        If LanguageCbox.Text = "Lithuanian" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\Lithuanian.hcchr"
        If LanguageCbox.Text = "Polish" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\Polish.hcchr"
        If LanguageCbox.Text = "Portuguese" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\Portuguese.hcchr"
        If LanguageCbox.Text = "Russian" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\Russian.hcchr"
        If LanguageCbox.Text = "Slovak" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\Slovak.hcchr"
        If LanguageCbox.Text = "Spanish" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\Spanish.hcchr"
        If LanguageCbox.Text = "Other" Then LanguageAuto = " -1 " & Application.StartupPath & "\Packages\HC\charsets\combined\English.hcchr"

        Call AutoAkt()

    End Sub

    Private Sub TextBox64_TextChanged(sender As Object, e As EventArgs) Handles SpeedAutoExtrak1.TextChanged

        '#### Ausgewählte Hashgeschwindigkeit extrahieren (letzte Ziffer im hash-Typ)

        If Hashtyp0.TextLength > 6 Then

            Dim zeichen As String
            Dim count As Integer
            For Each zeichen In SpeedAutoExtrak1.Text
                count += 1
                If count = SpeedAutoExtrak1.TextLength Then
                    SpeedAutoExtrak2.Text = zeichen
                End If
            Next

        Else
            SpeedAutoExtrak2.Text = 2
        End If

        Call AutoAkt()

    End Sub

    Private Sub TextBox65_TextChanged(sender As Object, e As EventArgs) Handles SpeedAutoExtrak2.TextChanged

        '#### Hash Geschindigkeit vorgeben bzw. laden

        HashSpeedCbox.Text = SpeedAutoExtrak2.Text

        Call AutoAkt()

    End Sub

    Private Sub WLMCheck_CheckedChanged(sender As Object, e As EventArgs) Handles WLMCheck.CheckedChanged

        '### Änderung WLM Checkbox
        Call AutoAkt()

    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click

        '#### Automatic Wordlist Auswahl 


        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = Application.StartupPath & "\#_Wordlists"
        openFileDialog.Filter = "All Files (*.*)| *.*"



        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            WorlAutoTxb.Text = openFileDialog.FileName
        End If

        Call AutoAkt()

    End Sub

    Private Sub AutoRuleG_TextChanged(sender As Object, e As EventArgs) Handles AutoRuleG.TextChanged

        '#### Auto Rule -g

        If AutoRuleG.TextLength > 0 Then
            AutoRuleG1 = " -g " & AutoRuleG.Text & " "

        Else
            AutoRuleG1 = ""

        End If

        Call AutoAkt()

    End Sub


    Private Sub HashSpeedCbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles HashSpeedCbox.SelectedIndexChanged

        If HashSpeedCbox.Text = 1 Then AutoRuleG.Text = "100"
        If HashSpeedCbox.Text = 2 Then AutoRuleG.Text = "1000"
        If HashSpeedCbox.Text = 3 Then AutoRuleG.Text = "10000"

        Call AutoAkt()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        If My.Settings.Eng = True Then MsgBox("HASHSPEED >> 1 = slow Hash, 2 = middle Hash, 3 = fast Hash", vbExclamation)
        If My.Settings.Eng = False Then MsgBox("HASHSPEED >> 1 = langsam, 2 = mittel, 3 = schnell", vbExclamation)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        If My.Settings.Eng = True Then MsgBox("Note: This setting makes only the correct assignment of the HCCHR-files. The Encoding-Parameter for the wordlist is not changed! You can change it under ""Settings"" ", vbExclamation)
        If My.Settings.Eng = False Then MsgBox("Achtung: Durch diese Einstellung wird nur die richtige Zuordnung bei den HCCHR-Dateien hergestellt. Die Encoding-Funktion für die Wordlist wird nicht geändert. Diese können Sie unter ""Settiungs"" ändern.", vbExclamation)

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click


        If My.Settings.Eng = True Then MsgBox("If you press the Start button, a query for personal information is the target person (name, date of birth, etc.). From this information, a comprehensive wordlist is generated and then checked.", vbExclamation)
        If My.Settings.Eng = False Then MsgBox("Wenn Sie den Start-Button drücken erfolgt eine Abfrage zu persönlichen Informationen der Zielperson (Name, Geburtsdatum etc.). Aus diesen Informationen wird eine umfangreiche Wordlist erzeugt und anschließend abgeprüft.", vbExclamation)


    End Sub


    '######################################################################################################################################################
    '# Batch Jobs
    '######################################################################################################################################################


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '### Prüfen ob ein Hash ausgewählt wurde und ein Hash-Typ
        If HashtypCBox.Text.Length = 0 Or HashTxb.TextLength = 0 Then
            If My.Settings.Eng = True Then MsgBox("Please select a Target-Hash-File And a Hash-Typ.", vbExclamation)
            If My.Settings.Eng = False Then MsgBox("Bitte wählen Sie eine Ziel-Hash-Datei und einen Hash-Typ aus.", vbExclamation)
            Exit Sub
        End If


        CommandBatchTxb.Text &= vbNewLine & vbNewLine & CommandA0Txb.Text

        If My.Settings.Eng = True Then MsgBox("Done. Commands were copied to Batch.")
        If My.Settings.Eng = False Then MsgBox("Die Kommandos wurden bei ""Batch"" eingefügt.")

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        '### Prüfen ob ein Hash ausgewählt wurde und ein Hash-Typ
        If HashtypCBox.Text.Length = 0 Or HashTxb.TextLength = 0 Then
            If My.Settings.Eng = True Then MsgBox("Please select a Target-Hash-File And a Hash-Typ.", vbExclamation)
            If My.Settings.Eng = False Then MsgBox("Bitte wählen Sie eine Ziel-Hash-Datei und einen Hash-Typ aus.", vbExclamation)
            Exit Sub
        End If


        '#### Batchjobs einfügen

        CommandBatchTxb.Text &= vbNewLine & vbNewLine & CommandA3Txb.Text

        If My.Settings.Eng = True Then MsgBox("Done. Commands were copied to Batch.")
        If My.Settings.Eng = False Then MsgBox("Die Kommandos wurden bei ""Batch"" eingefügt.")

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click

        '### Prüfen ob ein Hash ausgewählt wurde und ein Hash-Typ
        If HashtypCBox.Text.Length = 0 Or HashTxb.TextLength = 0 Then
            If My.Settings.Eng = True Then MsgBox("Please select a Target-Hash-File And a Hash-Typ.", vbExclamation)
            If My.Settings.Eng = False Then MsgBox("Bitte wählen Sie eine Ziel-Hash-Datei und einen Hash-Typ aus.", vbExclamation)
            Exit Sub
        End If


        '#### Batchjobs einfügen

        CommandBatchTxb.Text &= vbNewLine & vbNewLine & CommandA1Txb.Text

        If My.Settings.Eng = True Then MsgBox("Done. Commands were copied to Batch.")
        If My.Settings.Eng = False Then MsgBox("Die Kommandos wurden bei ""Batch"" eingefügt.")

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click

        '### Prüfen ob ein Hash ausgewählt wurde und ein Hash-Typ
        If HashtypCBox.Text.Length = 0 Or HashTxb.TextLength = 0 Then
            If My.Settings.Eng = True Then MsgBox("Please select a Target-Hash-File And a Hash-Typ.", vbExclamation)
            If My.Settings.Eng = False Then MsgBox("Bitte wählen Sie eine Ziel-Hash-Datei und einen Hash-Typ aus.", vbExclamation)
            Exit Sub
        End If


        '#### Batchjobs einfügen

        CommandBatchTxb.Text &= vbNewLine & vbNewLine & CommandA6Txb.Text

        If My.Settings.Eng = True Then MsgBox("Done. Commands were copied to Batch.")
        If My.Settings.Eng = False Then MsgBox("Die Kommandos wurden bei ""Batch"" eingefügt.")

    End Sub


    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click

        '#### Batchjobs in Batch Datei schreiben

        Try

            If MailCheckOn.Checked = True And My.Settings.Eng = True Then MsgBox("Comment: Crackmail is not possible in Batchjob-Mode.")
            If MailCheckOn.Checked = True And My.Settings.Eng = False Then MsgBox("Hinweis: Crackmail ist im Batchjob-Mode nicht möglich.")

            Dim DateBatch4 As String = Format(Now, "yyyyMMdd_HHmmss")
            Dim Pfadbatch4 As String = (Application.StartupPath & "\Batchjob\Hashbull_Batch_" & DateBatch4 & ".bat")
            Dim fs4 As New FileStream(Pfadbatch4, FileMode.Append, FileAccess.Write)
            Dim s4 As New StreamWriter(fs4)
            s4.WriteLine(CommandBatchTxb.Text & vbNewLine)
            's.WriteLine("Pause")
            s4.Close()

            '#### Batch starten

            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\HC\"
            process.StartInfo.Arguments = ("/k " & Pfadbatch4)
            process.Start()


            '### Attacke dokumentieren
            If My.Settings.Checklog = True Then
                Dim DateBatch2 As String = Format(Now, "yyyy_MM_dd_HH_mm_ss")
                Dim Pfadbatch2 As String = (Application.StartupPath & "\Logs\" & SessionTxb.Text & "_" & DateBatch2 & "_" & Hashtyp1.Text & ".txt")
                Dim fs2 As New FileStream(Pfadbatch2, FileMode.Append, FileAccess.Write)
                Dim s2 As New StreamWriter(fs2)
                s2.WriteLine(CommandBatchTxb.Text & vbNewLine)
                's.WriteLine("Pause")
                s2.Close()
            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click

        '### Batchjob in Txt exportieren und öffnen / Folder: Batchjob/Logs
        Dim Dateipfad As String = Application.StartupPath & "\Batchjob\Logs\Export_" & HashtypCBox.Text & "_" & SessionTxb.Text & ".txt"
        MsgBox("Save in Folder: Hashbull\Batchjob\Logs")
        System.IO.File.WriteAllText(Dateipfad, CommandBatchTxb.Text)
        Process.Start(Dateipfad)

    End Sub
    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click

        '#### Batchjob Fenster löschen
        CommandBatchTxb.Clear()

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

        '#### Hash-Typ als pdf anzeigen
        Process.Start(System.IO.Path.Combine(Application.StartupPath, "Docs\Hash_Types_Hashcat.pdf"))

    End Sub



    '##################################################################################################################################################
    '# HASHTYP-IDENTIFY
    '##################################################################################################################################################

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click

        '#### Hash-Identify
        Try

            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.InitialDirectory = Application.StartupPath & "\#_Hashout"
            openFileDialog.Filter = "All Files (*.*)| *.*"


            If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                HashIdentTxb.Text = openFileDialog.FileName


                Dim process As New Process()
                process.StartInfo.FileName = "cmd.exe"
                process.StartInfo.WorkingDirectory = vari.Hashcat
                process.StartInfo.Arguments = ("/k " & "hashcat.exe --identify " & HashIdentTxb.Text)
                process.Start()

            End If

        Catch ex As Exception

        End Try

    End Sub


End Class