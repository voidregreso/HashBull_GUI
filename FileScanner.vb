Imports System.ComponentModel
Imports System.Diagnostics
Public Class FileScanner

    Private WithEvents myProcess As Process
    Private eventHandled As TaskCompletionSource(Of Boolean)
    Public Shared ReadOnly Property LocalUserAppDataPath As String
    Public ReadOnly Property CancellationPending As Boolean

    Private Sub Scanner_Load(sender As Object, e As EventArgs) Handles Me.Load
        '### Form umbenennen
        If My.Settings.Eng = False Then
            Me.Text = "Hashbull Scanner für verschlüsselte Dateien"
            Button1.Text = "Einstellungen"
            Button2.Text = "Dateien kopieren"
        End If

        Call ListLoad1()

    End Sub

    Private Sub ListLoad1()


        '### Standartext #####
        Dim s As String
        If My.Settings.Eng = False Then
            s = "################################=H A S H B U L L // Encrypted-File-Scanner=################################= =Hashbull scannt nun das gesamte Dateisystem, inkl. Netzlaufwerke der Zielperon um verschlüsselte=PDF-, Office-, 7z-, ZIP und RAR-Dateien zu finden.==Der Scanvorgang kann einige Zeit in Anspruch nehmen.=Über den Button ""Crack"" kann die ausgewählte Datei direkt an Hashbull weitergeleitet werden.==Folgende Dateien konnten auf dem System lokalisiert werden:"
        Else
            s = "################################=H A S H B U L L // Encrypted-File-Scanner=################################= =Hashbull now searches the target persons computer for encrypted files.=The scanning process may take some time.=The hits can be forwarded directly to Hashbull via the ""Crack"" button.= =The following files could be located on the system:"
        End If

        '### Standardtext wird auf die Items aufgeteilt durch =-Zeichen
        Dim words As String() = s.Split(New Char() {"="c})
        Dim word As String
        For Each word In words
            ListBox1.Items.Add(word)
        Next

    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        '### Der Backgroundworker durchsucht alle Laufwerke und fügt die Treffer der Listbox hinzu

        Try

            Dim start_info As New ProcessStartInfo()
            Dim proc As New Process
            Dim std_out As System.IO.StreamReader


            My.Settings.Reload()


            '### CMD läuft versteckt
            start_info.FileName = ("cmd.exe")
            start_info.Verb = "runas"
            start_info.UseShellExecute = False
            start_info.CreateNoWindow = True
            start_info.RedirectStandardOutput = True
            start_info.WindowStyle = ProcessWindowStyle.Hidden
            start_info.WorkingDirectory = Application.StartupPath & "\Packages\JtR\run"
            start_info.Arguments = ("/k " & Application.StartupPath & "\Packages\Hashbull_lib\EFS\EFS.bat")
            'start_info.Arguments = (Param)
            proc.StartInfo = start_info
            proc.Start()

            std_out = proc.StandardOutput

            '### Schleife wird ausgeführt. Bei CancelP wird die Schleife verlassen. Letzte Eintrag wird autom. selek., damit die Liste autom. nach unten scrollt
            Do
                If Me.BackgroundWorker1.CancellationPending Then Exit Do
                Dim line As String = std_out.ReadLine()
                'ListBox1.Invoke(Sub() ListBox1.Items.Add(line))

                ListBox1.Invoke(Sub()
                                    ListBox1.Items.Add(line)
                                    ListBox1.SelectedIndex = ListBox1.Items.Count - 1
                                End Sub)

            Loop While proc.HasExited = False

        Catch ex As Exception
        End Try


    End Sub


    Public Sub StartKryptoBtn_Click(sender As Object, e As EventArgs) Handles StartKryptoBtn.Click

        Call Save()

        '### Es wird die Form neu geladen, da ansonsten bei einem erneuten Start der Worker noch läuft
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        Me.Show()

        '### Für Neustart Listbox löschen
        ListBox1.Items.Clear()


        Call ListLoad1()


        '### Worker starten
        Me.BackgroundWorker1.RunWorkerAsync()

        '### Radar einblenden
        PictureBox1.Visible = True

        '### Buttons deaktivieren
        StartKryptoBtn.Enabled = False
        ScannerStopBtn.Enabled = True
        ScannerCrackBtn.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False





    End Sub


    Public Sub Save()

        My.Settings.Reload()

        Dim drives1 As String
        Dim Perl As String
        Dim PP2 As String
        Dim PDFjohn As String
        Dim OfficeJohn As String
        Dim zJohn As String
        Dim zipJohn As String
        Dim rarJohn As String

        drives1 = "Set sDrives=" & My.Settings.EFSDrives & vbNewLine
        Perl = "Set Perl=" & vari.Perl
        PP2 = "Set PP2=" & vari.PP2
        PDFjohn = "Set PDFjohn=" & vari.JtR & "pdf2john.pl"
        OfficeJohn = "Set OfficeJohn=" & vari.JtR & "office2john.py"
        zJohn = "Set zJohn=" & vari.JtR & "7z2hashcat6414.exe"
        zipJohn = "Set zipJohn=" & vari.JtR & "zip2john.exe"
        rarJohn = "Set rarJohn=" & vari.JtR & "rar2john.exe"


        Dim save As New IO.StreamWriter(New IO.FileStream(IO.Path.Combine(Application.StartupPath & "\Packages\Hashbull_lib\EFS\EFS.bat"), IO.FileMode.Create))

        save.WriteLine(Label3.Text)
        save.WriteLine(drives1)
        save.WriteLine(Perl)
        save.WriteLine(PP2)
        save.WriteLine(PDFjohn)
        save.WriteLine(OfficeJohn)
        save.WriteLine(zJohn)
        save.WriteLine(zipJohn)
        save.WriteLine(rarJohn)


        If My.Settings.EFS2 = True Then save.WriteLine(PDF.Text)
        If My.Settings.EFS2 = True Then save.WriteLine("        %Perl% %PDFjohn% ""%%a""|findstr /ilc:""$p"" >nul 2>&1 && echo %%a")
        If My.Settings.EFS2 = True Then save.WriteLine("        @ping -n 1 localhost> nul")
        If My.Settings.EFS2 = True Then save.WriteLine("    )")
        If My.Settings.EFS2 = True Then save.WriteLine(")")

        If My.Settings.EFS3 = True Then save.WriteLine(DOC.Text)
        If My.Settings.EFS3 = True Then save.WriteLine("        %PP2% %OfficeJohn% ""%%a""|findstr /ilc:""$o"" >nul 2>&1 && echo %%a")
        If My.Settings.EFS3 = True Then save.WriteLine("        @ping -n 1 localhost> nul")
        If My.Settings.EFS3 = True Then save.WriteLine("    )")
        If My.Settings.EFS3 = True Then save.WriteLine(")")

        If My.Settings.EFS4 = True Then save.WriteLine(XLS.Text)
        If My.Settings.EFS4 = True Then save.WriteLine("        %PP2% %OfficeJohn% ""%%a""|findstr /ilc:""$o"" >nul 2>&1 && echo %%a")
        If My.Settings.EFS4 = True Then save.WriteLine("        @ping -n 1 localhost> nul")
        If My.Settings.EFS4 = True Then save.WriteLine("    )")
        If My.Settings.EFS4 = True Then save.WriteLine(")")

        If My.Settings.EFS5 = True Then save.WriteLine(Sieben.Text)
        If My.Settings.EFS5 = True Then save.WriteLine("        %zJohn% ""%%a""|findstr /ilc:""$"" >nul 2>&1 && echo %%a")
        If My.Settings.EFS5 = True Then save.WriteLine("        @ping -n 1 localhost> nul")
        If My.Settings.EFS5 = True Then save.WriteLine("    )")
        If My.Settings.EFS5 = True Then save.WriteLine(")")

        If My.Settings.EFS6 = True Then save.WriteLine(zip.Text)
        If My.Settings.EFS6 = True Then save.WriteLine("        %zipJohn% ""%%a""|findstr /ilc:""$"" >nul 2>&1 && echo %%a")
        If My.Settings.EFS6 = True Then save.WriteLine("        @ping -n 1 localhost> nul")
        If My.Settings.EFS6 = True Then save.WriteLine("    )")
        If My.Settings.EFS6 = True Then save.WriteLine(")")

        If My.Settings.EFS7 = True Then save.WriteLine(RAR.Text)
        If My.Settings.EFS7 = True Then save.WriteLine("        %rarJohn% ""%%a""|findstr /ilc:""$"" >nul 2>&1 && echo %%a")
        If My.Settings.EFS7 = True Then save.WriteLine("        @ping -n 1 localhost> nul")
        If My.Settings.EFS7 = True Then save.WriteLine("    )")
        If My.Settings.EFS7 = True Then save.WriteLine(")")

        save.WriteLine(Label6.Text) '### Hashbull finsih

        save.Close()



    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ScannerStopBtn.Click

        '### Background worker wird gestoppt. Er läuft aber solange weiter, bis er einen nächsten Treffer hat. Daher der Umweg über Neustart
        Me.BackgroundWorker1.CancelAsync()

        '### Radar abschalten
        PictureBox1.Visible = False

        '### Msgbox
        If My.Settings.Eng = False Then MsgBox("Der Scannvorgang wurde abgebrochen.")
        If My.Settings.Eng = True Then MsgBox("The scanning process was canceled.")

        '### Start Button wieder aktivieren
        StartKryptoBtn.Enabled = True
        ScannerCrackBtn.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True



    End Sub



    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        '### Select Item in Textbox darstellen
        Me.TextBox1.Text = Me.ListBox1.SelectedItem
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ScannerCrackBtn.Click

        '### Crack Buttob und Übergabe an Extraction

        Extraction.Show()
        Extraction.TextBox2.Text = TextBox1.Text

        If My.Settings.Eng = False Then MsgBox("Bitte wählen Sie den Datei-Typ aus.")
        If My.Settings.Eng = True Then MsgBox("Please Select the file type.")

        'Me.Close()
        'Welcome.Opacity = 0

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        '### Ende überwachen durch Textbox1

        If TextBox1.Text = "Hashbull-Scan finish ..." Then

            Me.BackgroundWorker1.CancelAsync()

            StartKryptoBtn.Enabled = True

            Dim DateBatch As String = Format(Now, "yyyyMMdd_HHmmss")
            Dim sav As String = (Application.StartupPath & "\Hashbull_Scanner\Hashbull_Encrypted_Files_" & DateBatch & ".txt")
            Dim text As String = ""

            '### Listbox wird in txt gespeichert
            For Each Litem As String In ListBox1.Items
                text &= vbCrLf & Litem
            Next
            IO.File.WriteAllText(sav, text)

            '### Radar ausblenden
            PictureBox1.Visible = False

            '### Msgbox
            If My.Settings.Eng = False Then MsgBox("Scanvorgang abgeschlossen. Die Ergebnisse wurden in den Ordner ""Hashbull_Scanner"" exportiert.")
            If My.Settings.Eng = True Then MsgBox("The scanning process is finished. The results were exported to the Folder ""Hashbull_Scanner"".")


        End If

    End Sub


    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick

        ScannerCrackBtn.PerformClick()

    End Sub

    Private Sub FileScanner_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        WordlistUtility.Show()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        FileScannerSettings.Show()

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        Try

            My.Settings.Reload()

            Dim CopyFolder1 As String = My.Settings.CopyFolder
            Dim Msg As String = "Der Kopiervorgang wird nun durchgeführt und kann einige Zeit in Anspruch nehmen. Sobald der Kopiervorgang beendet ist bekommen Sie eine Mitteilung."
            If My.Settings.Eng = False Then Msg = "Der Kopiervorgang wird nun durchgeführt und kann einige Zeit in Anspruch nehmen. Sobald der Kopiervorgang beendet ist bekommen Sie eine Mitteilung."
            If My.Settings.Eng = True Then Msg = "The copying process will now be carried out and may take some time. As soon as the copying process is finished you will receive a message."


            If My.Settings.CopyFolder = "" Then CopyFolder1 = (Application.StartupPath & "\Hashbull_Scanner\Copy_Folder")


            Select Case MessageBox.Show(Msg, "Hashbull", MessageBoxButtons.OKCancel)


                Case Windows.Forms.DialogResult.OK


                    Dim strPathTarget As String = CopyFolder1
                    For Each itm As String In ListBox1.Items
                        If System.IO.File.Exists(itm) Then
                            Dim dtSource As DateTime = System.IO.File.GetCreationTime(itm)
                            Dim dst As String = System.IO.Path.Combine(strPathTarget, System.IO.Path.GetFileName(itm))
                            Try
                                System.IO.File.Copy(itm, dst)
                                System.IO.File.SetCreationTime(dst, dtSource)
                            Catch ex As Exception
                                'MsgBox("Exception: " & ex.Message, MsgBoxStyle.Exclamation)
                            End Try
                        End If
                    Next

                    If My.Settings.Eng = False Then MsgBox("Der Kopiervorgang ist abgeschlossen. Sie finden die Dateien im Ordner ""Hashbull_Scanner\Copy_Folder\""")
                    If My.Settings.Eng = True Then MsgBox("The copying process is complete. You will find the files in the folder ""Hashbull_Scanner\Copy_Folder\""")



                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
            End Select

        Catch ex As Exception

        End Try

    End Sub


End Class
