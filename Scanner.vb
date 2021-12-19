Imports System.ComponentModel
Imports System.Diagnostics
Public Class Scanner

    Private WithEvents myProcess As Process
    Private eventHandled As TaskCompletionSource(Of Boolean)

    Public Shared ReadOnly Property LocalUserAppDataPath As String
    Public ReadOnly Property CancellationPending As Boolean

    Private Sub Scanner_Load(sender As Object, e As EventArgs) Handles Me.Load
        '### Form umbenennen
        If My.Settings.Eng = False Then
            Button1.Text = "Hilfe"
            Button2.Text = "Einstellungen"
            Me.Text = "Krypto-Scanner"
        End If

        Call ListLoad1()

    End Sub

    Private Sub ListLoad1()


        '### Standartext #####
        Dim s As String
        If My.Settings.Eng = False Then
            s = "##########################=H A S H B U L L // Krypto-Scanner=##########################= =Hashbull durchsucht nun den Computer der Zielperson nach Indizien fuer die Nutzung von Kryptowaehrungen.=Hashbull scannt das gesamte Dateisystem, inkl. Netzlaufwerke um zu analysieren, ob es Anzeichen für die Nutzung=von Krytowaehrungen gibt.==Unter Parameter können Sie den Suchfilter eintragen.==Der Scanvorgang kann einige Zeit in Anspruch nehmen. Sollten Treffer angezeigt werden, stellen diese nur=ein Indiz fuer die Nutzung von Kryptowaehrungen dar. Sollte eine Bitcoin-Desktop-Wallet gefunden werden,=wird diese am Ende des Scanvorgangs automatisch selektiert. Ueber den Button ""Crack"" kann die Wallet=direkt an Hashbull weitergeleitet werden.= =Folgende Hash-Typen kommen für Desktop-Wallets in Betracht:=Bitcoin-Wallet: 11300=Ethereum-Wallet: 15600, 15700, 16300=Electrum-Wallet: 16600, 21700, 21800=MyBlockchain-Wallet: 12700, 15200 ,18800==Folgende Indizien konnten auf dem System lokalisiert werden:"
        Else
            s = "##########################=H A S H B U L L // Crypto-Scanner=##########################= =Hashbull now searches the target persons computer for evidence of the use of cryptocurrencies.=Hashbull scans the entire file system, including network drives, to check whether there are file name=that indicate the use of cryptocurrencies.==You can enter the search filter under Parameters.==The scanning process may take some time. If hits are displayed, these are only an indication of=the use of crypto currency. If a Bitcoin-Desktop-Wallet is found, it will be selected automatically at=the end of the scanning process. The wallet can be forwarded directly to Hashbull via the ""Crack"" button.= =The following hash types can be used for desktop wallets:=Bitcoin-Wallet: 11300=Ethereum-Wallet: 15600, 15700, 16300=Electrum-Wallet: 16600, 21700, 21800=MyBlockchain-Wallet: 12700, 15200 ,18800==The following indications could be located on the system:"
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
            start_info.WorkingDirectory = Application.StartupPath & "\Packages\Hashbull_lib\CS"
            start_info.Arguments = ("/k " & Application.StartupPath & "\Packages\Hashbull_lib\CS\CS.bat")
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


    Private Sub StartKryptoBtn_Click(sender As Object, e As EventArgs) Handles StartKryptoBtn.Click

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

        '### Buttons aktivieren
        StartKryptoBtn.Enabled = False
        ScannerStopBtn.Enabled = True
        ScannerCrackBtn.Enabled = False
        Button2.Enabled = False


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
        Button2.Enabled = True

    End Sub


    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        '### Select Item in Textbox darstellen
        Me.TextBox1.Text = Me.ListBox1.SelectedItem
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ScannerCrackBtn.Click

        '### Crack Buttob und Übergabe an Extraction
        If My.Settings.Eng = False Then

            Select Case MessageBox.Show("Haben Sie eine Wallet ausgewählt, bspw. wallet.dat (Bitcoin) oder default_wallet (Electrum)?" & vbNewLine & vbNewLine & "Wenn nein, dann selektieren Sie zuerst eine Wallet.", "Hashbull", MessageBoxButtons.YesNo)
                Case Windows.Forms.DialogResult.Yes

                Case Windows.Forms.DialogResult.No
                    Exit Sub
            End Select
        End If

        If My.Settings.Eng = True Then

            Select Case MessageBox.Show("Have you selected a wallet, e.g. wallet.dat (Bitcoin) or default_wallet (Electrum)?" & vbNewLine & vbNewLine & "If not, then first select a wallet.", "Hashbull", MessageBoxButtons.YesNo)
                Case Windows.Forms.DialogResult.Yes

                Case Windows.Forms.DialogResult.No
                    Exit Sub
            End Select
        End If


        Extraction.Show()
        Extraction.TextBox2.Text = TextBox1.Text
        Extraction.ComboBox1.SelectedItem = "Bitcoin-Wallet"

        'Me.Close()
        Welcome.Opacity = 0

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        '### Ende überwachen durch Textbox1

        If TextBox1.Text = "Hashbull-Scan finish ..." Then

            Me.BackgroundWorker1.CancelAsync()

            StartKryptoBtn.Enabled = True

            Dim DateBatch As String = Format(Now, "yyyyMMdd_HHmmss")
            Dim sav As String = (Application.StartupPath & "\Hashbull_Scanner\Hashbull_Crypto_Analysis_" & DateBatch & ".txt")
            Dim text As String = ""

            '### Listbox wird in txt gespeichert
            For Each Litem As String In ListBox1.Items
                text &= vbCrLf & Litem
            Next
            IO.File.WriteAllText(sav, text)

            '### Radar ausblenden
            PictureBox1.Visible = False

            '### Sollte eine Wallet.dat vorhanden sein, dann selektieren
            Dim searchstring As String = "wallet.dat"
            Dim Index As Integer = (Array.FindIndex(ListBox1.Items.Cast(Of Object).Select(Function(o) ListBox1.GetItemText(o)).ToArray, Function(s) s Like String.Format("*{0}", searchstring)))

            If searchstring <> String.Empty Then
                If Index <> -1 Then
                    ListBox1.SetSelected(Index, True)
                End If
            End If

            '### Msgbox
            If My.Settings.Eng = False Then MsgBox("Scanvorgang abgeschlossen. Die Ergebnisse wurden in den Hashbull-Ordner ""Crypto_Scanner"" exportiert.")
            If My.Settings.Eng = True Then MsgBox("The scanning process is finished. The results were exported to the Hashbull-Folder ""Crypto_Scanner"".")


        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

        HelpScanner.Show()

    End Sub


    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick

        Dim para As String
        para = ListBox1.SelectedItem

        '### CMD läuft versteckt
        Dim process As New Process()
        process.StartInfo.FileName = "notepad.exe"
        process.StartInfo.WorkingDirectory = vari.Hashcat
        process.StartInfo.Arguments = (para)
        process.Start()

    End Sub



    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click

        HelpScanner.Show()

    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click

        ScennerSettings.Show()

    End Sub

    Private Sub Scanner_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        WordlistUtility.Show()
    End Sub
End Class