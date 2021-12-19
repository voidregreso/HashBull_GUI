Imports System.IO
Public Class Extraction


    Public TextMsg As String 'PDF
    Public MsgTextAll As String
    Public MsgTextENG As String = "Done! Do you want to crack the Hash now?" & vbNewLine & vbNewLine & "The following Hash-Types come into consideration with this file format: "
    Public MsgTextGER As String = "Der Passwort-Hash wurde extrahiert. Möchten Sie ihn jetzt entschlüsseln?" & vbNewLine & vbNewLine & "Die folgenden Hash-Typen kommen für dieses Dateiformat in Betracht: "
    Public MsgLinux As String
    Public MsgWin As String

    Public PDFtyp As String



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load


        '### Sprache laden

        If My.Settings.Ger = True Then

            Button2.Text = "Datei auswählen"
            Label1.Text = "Datei-Format:"

        End If

    End Sub



    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Welcome.Show()
        Welcome.MinimizeBox = False
        Welcome.Activate()
        Welcome.Opacity = 100

    End Sub





    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '######## Datei auswählen und in TexBox2 schreiben

        If My.Settings.Eng = True Then TextMsg = "Do you want to extract only one single PDF-file? Click ""Yes""." & vbNewLine & vbNewLine & "If you want to extract several PDF-files in one folder? Click ""No"""
        If My.Settings.Eng = False Then TextMsg = "Wenn Sie nur eine einzelnen PDF-Hash extrahieren möchten, dann klicken Sie ""Ja""." & vbNewLine & vbNewLine & "Wenn Sie mehrere PDF-Hashes in einem Ordner extrahieren möchten, dann klicken Sie ""Nein""."

        Dim openFileDialog1 As New OpenFileDialog()

        If ComboBox1.Text = "PDF" Then

            Dim result As DialogResult = MessageBox.Show(TextMsg, "PDF-Extraction", MessageBoxButtons.YesNoCancel)

            If result = DialogResult.Cancel Then

            ElseIf result = DialogResult.No Then


                Using f As New FolderBrowserDialog()

                    If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Dim d As New System.IO.DirectoryInfo(f.SelectedPath)
                        TextBox2.Text = f.SelectedPath & "\*.pdf"
                    End If

                End Using


            ElseIf result = DialogResult.Yes Then

                openFileDialog1.InitialDirectory = "c:\"
                openFileDialog1.Filter = "All Files (*.*)| *.*"
                openFileDialog1.InitialDirectory = Application.StartupPath

                If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    TextBox2.Text = openFileDialog1.FileName

                End If
            End If

            Exit Sub

        End If


        'Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "All Files (*.*)| *.*"
        openFileDialog1.InitialDirectory = Application.StartupPath

        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = openFileDialog1.FileName

        End If

    End Sub


    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        '#### Commad Zeile füllen
        TextBox1.Text = TextBox2.Text

    End Sub

    '#######################################################################################################################################################
    '#######################################################################################################################################################
    '#######################################################################################################################################################




    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        '### Prüfen ob alle Felder ausgefüllt wurden

        Try



            If TextBox2.TextLength = 0 Then

                If My.Settings.Eng = True Then MsgBox("Both fields must be completed.")
                If My.Settings.Eng = False Then MsgBox("Bitte beide Felder ausfüllen.")

                Exit Sub

            End If


            'ecryptfs-Extraction ################################################################################################################ 

            If ComboBox1.Text = "eCryptfs" Then



                Dim dateECR As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim DateiECR1 As String
                Dim DateiECR2 As String
                Dim DateiECR3 As String
                Dim sAppPath As String
                sAppPath = Application.StartupPath

                DateiECR1 = "#_Hashout\Hashout_eCryptfs_" & dateECR & ".txt"
                DateiECR2 = (TextBox2.Text & " > " & DateiECR1)
                DateiECR3 = ("Hashout_eCryptfs_" & dateECR & ".txt")

                '######## Process ausführen (/c cmd wird nicht offen gehalten, mit /k schon)

                Process.Start("cmd", "/c " & vari.PP3 & " " & vari.JtR & "ecryptfs2john.py " & TextBox2.Text & " > " & DateiECR1)


                '###### Outputfile Filename entfernen

                Threading.Thread.Sleep(1000)
                Dim input As String = System.IO.File.ReadAllText(sAppPath & "\" & DateiECR1)
                Dim mark = "$" ' Es wird nach dem ersten "$" gesucht

                If input.Contains(mark) Then

                    Dim markPosition = input.IndexOf(mark)
                    Dim result2 = input.Substring(markPosition) ' mit bspw (markposition + 1) wird vor dem zweiten Buchstaben gelöscht
                    Dim schreiben As New IO.StreamWriter(sAppPath & "\" & DateiECR1, False) ' True = Inhalt wird angefügt und nicht überschrieben,, bei False wird überschrieben
                    schreiben.WriteLine(result2)
                    schreiben.Close() ' Erst durch .Close() werden Zeilen abschließend gespeichert
                End If


                '######## Messagebox mit Weiterleitung zu Form4

                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "12200", "Hashbull", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = Application.StartupPath & "\" & DateiECR1
                    Hashcrack.HashtypCBox.Text = "12200_ eCryptfs (Iterations_#1"

                    Me.Close()
                    Welcome.Opacity = 0


                ElseIf result = DialogResult.No Then

                    '####### Cancel Button

                    Me.Close()

                End If

            End If



            '7zip-Extraction ################################################################################################################ 

            If ComboBox1.Text = "7zip" Then

                Dim datezip As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim Dateizip1 As String
                Dim Dateizip2 As String
                Dim Dateizip3 As String
                Dim sAppPath As String
                sAppPath = Application.StartupPath

                Dateizip1 = "#_Hashout\Hashout_7zip_" & datezip & ".txt"
                Dateizip2 = (TextBox2.Text & " > " & Dateizip1)
                Dateizip3 = ("Hashout_7zip_" & datezip & ".txt")


                '######## Process ausführen (/c cmd wird nicht offen gehalten, mit /k schon)

                'Process.Start("cmd", "/c " & vari.Perl & " Packages\Hashbull_lib\7z\7z2john.pl " & Dateizip2)
                Process.Start("cmd", "/c " & Application.StartupPath & "\Packages\Hashbull_lib\7z2hashcat\7z2hashcat6414.exe " & Dateizip2)

                '######## Messagebox mit Weiterleitung zu Form4

                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "11600", "Hashbull", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = Application.StartupPath & "\" & Dateizip1
                    Hashcrack.HashtypCBox.Text = "11600_7_#2
"
                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    '####### Cancel Button

                    Me.Close()

                End If

            End If



            'ZIP-Extraction ################################################################################################################ 

            If ComboBox1.Text = "ZIP" Then

                Dim datezip As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim Dateizip1 As String
                Dim Dateizip2 As String
                Dim Dateizip3 As String
                Dim sAppPath As String
                sAppPath = Application.StartupPath

                Dateizip1 = "#_Hashout\Hashout_ZIP_" & datezip & ".txt"
                Dateizip2 = (TextBox2.Text & " > " & Dateizip1)
                Dateizip3 = ("Hashout_ZIP_" & datezip & ".txt")


                '######## Process ausführen (/c cmd wird nicht offen gehalten, mit /k schon)

                'Process.Start("cmd", "/c " & vari.Perl & " Packages\Hashbull_lib\7z\7z2john.pl " & Dateizip2)
                Process.Start("cmd", "/c " & Application.StartupPath & "\Packages\JtR\run\zip2john.exe " & Dateizip2)


                '### 1 Sek. warten
                Threading.Thread.Sleep(1000)

                '### Die extrahierte .txt wird bereinigt (Dateiname wird gelöscht in allen Zeilen). Neue _.txt erzeugt

                Process.Start("cmd", "/c " & vari.PP2 & " " & sAppPath & "\Packages\Hashbull_lib\ZIP\Hashbull_ZIP.py " & sAppPath & "\" & Dateizip1 & " " & sAppPath & "\#_Hashout\Hashout_ZIP_" & datezip & "_.txt")

                '### 2 Sek. warten
                Threading.Thread.Sleep(2000)

                '### Alte Extraktion löschen
                My.Computer.FileSystem.DeleteFile(sAppPath & "\" & Dateizip1)



                '######## Messagebox mit Weiterleitung zu Form4

                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "13600, 17200 - 17230 (default is 17210)", "Hashbull", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = Application.StartupPath & "\#_Hashout\Hashout_ZIP_" & datezip & "_.txt"
                    Hashcrack.HashtypCBox.Text = "17210_ PKZIP (Uncompressed)_#2"

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    '####### Cancel Button

                    Me.Close()

                End If

            End If


            'RAR-Extraction ################################################################################################################ 

            If ComboBox1.Text = "RAR" Then



                Dim datezip As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim Dateizip1 As String
                Dim Dateizip2 As String
                Dim Dateizip3 As String
                Dim sAppPath As String
                sAppPath = Application.StartupPath

                Dateizip1 = "#_Hashout\Hashout_RAR_" & datezip & ".txt"
                Dateizip2 = (TextBox2.Text & " > " & Dateizip1)
                Dateizip3 = ("Hashout_RAR_" & datezip & ".txt")


                '######## Process ausführen (/c cmd wird nicht offen gehalten, mit /k schon)

                'Process.Start("cmd", "/c " & vari.Perl & " Packages\Hashbull_lib\7z\7z2john.pl " & Dateizip2)
                Process.Start("cmd", "/c " & Application.StartupPath & "\Packages\JtR\run\rar2john.exe " & Dateizip2)


                '### 1 Sek. warten
                Threading.Thread.Sleep(1000)

                '### Die extrahierte .txt wird bereinigt (Dateiname wird gelöscht in allen Zeilen). Neue _.txt erzeugt

                Process.Start("cmd", "/c " & vari.PP2 & " " & sAppPath & "\Packages\Hashbull_lib\RAR\Hashbull_RAR.py " & sAppPath & "\" & Dateizip1 & " " & sAppPath & "\#_Hashout\Hashout_RAR_" & datezip & "_.txt")

                '### 2 Sek. warten
                Threading.Thread.Sleep(2000)

                '### Alte Extraktion löschen
                My.Computer.FileSystem.DeleteFile(sAppPath & "\" & Dateizip1)



                '######## Messagebox mit Weiterleitung zu Form4

                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "12500,13000 (default is 12500)", "Hashbull", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = Application.StartupPath & "\#_Hashout\Hashout_RAR_" & datezip & "_.txt"
                    Hashcrack.HashtypCBox.Text = "12500_ RAR3_#1"

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    '####### Cancel Button

                    Me.Close()

                End If

            End If


            'PDF-Extraction ################################################################################################################ 


            If ComboBox1.Text = "PDF" Then

                Dim datepdf As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim Dateipdf1 As String
                Dim Dateipdf2 As String
                Dim Dateipdf3 As String
                Dim sAppPath As String
                Dim process As New Process()
                sAppPath = Application.StartupPath
                Dateipdf1 = "#_Hashout\Hashout_PDF_" & datepdf & ".txt"
                Dateipdf2 = (TextBox1.Text & " > " & Dateipdf1) '# Textbox1 ist die Commandbox
                Dateipdf3 = ("Hashout_PDF_" & datepdf & ".txt")

                '### Hash wird extrahiert

                Process.Start("cmd", "/c " & vari.Perl & " " & vari.JtR & "pdf2john.pl " & Dateipdf2)

                '### 1 Sek. warten
                Threading.Thread.Sleep(1000)

                '### Die extrahierte .txt wird bereinigt (Dateiname wird gelöscht in allen Zeilen). Neue _.txt erzeugt

                Process.Start("cmd", "/c " & vari.PP2 & " " & sAppPath & "\Packages\Hashbull_lib\PDF\Hashbull_PDF.py " & sAppPath & "\" & Dateipdf1 & " " & sAppPath & "\#_Hashout\Hashout_PDF_" & datepdf & "_.txt")

                '### 1 Sek. warten
                Threading.Thread.Sleep(1000)

                '### Alte Extraktion löschen
                My.Computer.FileSystem.DeleteFile(sAppPath & "\" & Dateipdf1)

                '### Sprache Msgbox
                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER



                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "10400 - 10700 (default is 10500)", "Hashbull", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = Application.StartupPath & "\#_Hashout\Hashout_PDF_" & datepdf & "_.txt"
                    Hashcrack.HashtypCBox.Text = "10500_ PDF 1.4 _#2"

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    Me.Close()

                End If

            End If



            'Office-Extraction ################################################################################################################ 


            If ComboBox1.Text = "Office (Word, Excel, etc.)" Then

                Dim dateoffice As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim Dateioffice1 As String
                Dim Dateioffice2 As String
                Dim Dateioffice3 As String
                Dim sAppPath As String
                Dim process As New Process()
                sAppPath = Application.StartupPath
                Dateioffice1 = "#_Hashout\Hashout_Office_" & dateoffice & ".txt"
                Dateioffice2 = (TextBox2.Text & " > " & Dateioffice1)
                Dateioffice3 = ("Hashout_Office_" & dateoffice & ".txt")

                Process.Start("cmd", "/c " & vari.PP2 & " " & Application.StartupPath & "\Packages\Hashbull_lib\Office\" & "office2hashcat.py " & TextBox2.Text & " > #_Hashout\Hashout_Office_" & dateoffice & ".txt")


                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "9400 - 9820 (default is 9600)", "Hashbull", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = Application.StartupPath & "\" & Dateioffice1
                    Hashcrack.HashtypCBox.Text = "9600_ MS Office 2013 (Iterations_#1
"
                    Me.Close()
                    Welcome.Opacity = 0


                ElseIf result = DialogResult.No Then

                    Me.Close()

                End If

            End If


            'Bitlocker-Extraction ################################################################################################################ 


            If ComboBox1.Text = "Bitlocker" Then

                If My.Settings.Eng = True Then MsgBox("The extraction of a Bitlocker-Hash can take some time. A 15 GB USB-Stick can last up to an hour.At the end you have to copy the second Hash with $1$ (Example: $bitlocker$1$16$6f972989ddc209f1eccf....) into a hash.txt file and then attack it with Hash-Type 22100")
                If My.Settings.Eng = False Then MsgBox("Die Extraktion des Bitlocker-Hashes kann einige Zeit in Anspruch nehmen. Die Extraktion bei einem 15GB USB-Stick dauert ca. eine Stunde. Am Ende werden mehrere Hashes angezeigt. Kopieren Sie den Hash mit $1$ (bspw.: $bitlocker$1$16$6f972989ddc209f1eccf....) in eine Hash.txt und wählen Sie den Hash-Typ 22100 aus.")


                Dim date2 As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Process.Start("cmd", "/k " & vari.JtR & "bitlocker2john.exe -i " & TextBox2.Text)

            End If


            'VeraCrypt-Container-File-Extraction ################################################################################################################ 


            If ComboBox1.Text = "VeraCrypt / TrueCrypt (File)" Then

                Dim datevera As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim Dateivera1 = Application.StartupPath & "\" & "#_Hashout\Hashout_VeraCrypt_" & datevera & ".txt"
                Dim process As New Process()


                process.StartInfo.FileName = "dd2.exe"
                process.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\DD\"
                process.StartInfo.Arguments = (" if=" & TextBox2.Text & " of=" & Application.StartupPath & "\#_Hashout\Hashout_VeraCrypt_" & datevera & ".txt " & "bs=512 count=1")
                process.Start()


                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "13711 - 13773 (default is 13721)", "Hashbull", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = Dateivera1
                    Hashcrack.HashtypCBox.Text = "13721_ VeraCrypt SHA512 + XTS 512 bit (Iterations_#1"

                    HelpPIM.Show()

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    '####### Cancel Button

                    Me.Close()

                End If

            End If



            'VeraCrypt-Partition-Extraction ################################################################################################################ 


            If ComboBox1.Text = "VeraCrypt / TrueCrypt (Partition)" Then

                Dim dateVCP As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim DateiVCP1 = Application.StartupPath & "\" & "#_Hashout\Hashout_VeraCrypt_" & dateVCP & ".txt"
                Dim process As New Process()


                process.StartInfo.FileName = "dd2.exe"
                process.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\DD\"
                process.StartInfo.Arguments = (" if=" & TextBox2.Text & " of=" & Application.StartupPath & "\#_Hashout\Hashout_VeraCrypt_" & dateVCP & ".txt " & "count=512 skip=31744 bs=1")
                process.Start()

                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "13711 - 13773 (default is 13721)", "Hashbull", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = DateiVCP1
                    Hashcrack.HashtypCBox.Text = "13721_ VeraCrypt SHA512 + XTS 512 bit (Iterations_#1"

                    HelpPIM.Show()

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    Me.Close()

                End If
            End If


            'VeraCrypt-Hidden-Partition-Extraction ################################################################################################################ 


            If ComboBox1.Text = "VeraCrypt / TrueCrypt (Hidden Partition)" Then

                Dim dateVCP As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim DateiVCP1 = Application.StartupPath & "\" & "#_Hashout\Hashout_VeraCrypt_" & dateVCP & ".txt"
                Dim process As New Process()


                process.StartInfo.FileName = "dd2.exe"
                process.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\DD\"
                process.StartInfo.Arguments = (" if=" & TextBox2.Text & " of=" & Application.StartupPath & "\#_Hashout\Hashout_VeraCrypt_" & dateVCP & ".txt " & "bs=1 skip=65536 count=512")
                process.Start()


                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "13711 - 13773 (default is 13721)", "Hashbull", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = DateiVCP1
                    Hashcrack.HashtypCBox.Text = "13721_ VeraCrypt SHA512 + XTS 512 bit (Iterations_#1"

                    HelpPIM.Show()

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    Me.Close()

                End If
            End If



            'Bitcoin-Extraction ################################################################################################################ 


            If ComboBox1.Text = "Bitcoin-Wallet" Then

                Dim dateBTC As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim DateiBTC1 As String
                Dim DateiBTC2 As String
                Dim DateiBTC3 As String
                Dim sAppPath As String
                Dim process As New Process()
                sAppPath = Application.StartupPath
                DateiBTC1 = (Application.StartupPath & "\#_Hashout\Hashout_Bitcoin_" & dateBTC & ".txt")
                DateiBTC2 = (TextBox2.Text & " > " & DateiBTC1)
                DateiBTC3 = ("Hashout_Bitcoin_" & dateBTC & ".txt")

                Process.Start("cmd", "/c " & vari.PP2 & " " & vari.JtR & "bitcoin2john.py " & TextBox2.Text & " > " & DateiBTC1)

                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "11300", "Hashbull", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = DateiBTC1
                    Hashcrack.HashtypCBox.Text = "11300_ Bitcoin/Litecoin wallet.dat (Iterations_#1"

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    '####### Cancel Button

                    Me.Close()

                End If

            End If


            'Ethereum-Extraction ################################################################################################################ 


            If ComboBox1.Text = "Ethereum (MyEtherWallet.com / Keystore-File)" Then

                Dim dateBTC As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim DateiBTC1 As String
                Dim DateiBTC2 As String
                Dim DateiBTC3 As String
                Dim sAppPath As String
                Dim process As New Process()
                sAppPath = Application.StartupPath
                DateiBTC1 = (Application.StartupPath & "\#_Hashout\Hashout_Ether_" & dateBTC & ".txt")
                DateiBTC2 = (TextBox2.Text & " > " & DateiBTC1)
                DateiBTC3 = ("Hashout_Ether_" & dateBTC & ".txt")

                Process.Start("cmd", "/c " & vari.PP2 & " " & vari.JtR & "ethereum2john.py " & TextBox2.Text & " > " & DateiBTC1)


                '###### Outputfile Filename entfernen

                Threading.Thread.Sleep(1000)
                Dim input As String = System.IO.File.ReadAllText(DateiBTC1)
                Dim mark = "$" ' Es wird nach dem ersten "$" gesucht

                If input.Contains(mark) Then

                    Dim markPosition = input.IndexOf(mark)
                    Dim result2 = input.Substring(markPosition) ' mit bspw (markposition + 1) wird vor dem zweiten Buchstaben gelöscht
                    Dim schreiben As New IO.StreamWriter(DateiBTC1, False) ' True = Inhalt wird angefügt und nicht überschrieben,, bei False wird überschrieben
                    schreiben.WriteLine(result2)
                    schreiben.Close() ' Erst durch .Close() werden Zeilen abschließend gespeichert
                End If






                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "15700", "Hashbull", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = DateiBTC1
                    Hashcrack.HashtypCBox.Text = "15700_ Ethereum Wallet, SCRYPT (Iterations_#1"

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    '####### Cancel Button

                    Me.Close()

                End If

            End If







            'Litecoin-Extraction ################################################################################################################ 


            If ComboBox1.Text = "Litecoin-Wallet" Then

                Dim dateLTC As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim DateiLTC1 As String
                Dim DateiLTC2 As String
                Dim DateiLTC3 As String
                Dim sAppPath As String
                Dim process As New Process()
                sAppPath = Application.StartupPath
                DateiLTC1 = "#_Hashout\Hashout_Litecoin_" & dateLTC & ".txt"
                DateiLTC2 = (TextBox2.Text & " > " & DateiLTC1)
                DateiLTC3 = ("Hashout_Litecoin_" & dateLTC & ".txt")


                Process.Start("cmd", "/c " & vari.PP2 & " " & vari.JtR & "bitcoin2john.py " & TextBox2.Text & " > #_Hashout\Hashout_Litecoin_" & dateLTC & ".txt")


                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "11300", "Hashbull", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = Application.StartupPath & "\" & DateiLTC1
                    Hashcrack.HashtypCBox.Text = "11300_ Bitcoin/Litecoin wallet.dat (Iterations_#1"

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    '####### Cancel Button

                    Me.Close()

                End If

            End If



            'Electrum-Extraction ################################################################################################################ 


            If ComboBox1.Text = "Electrum-Wallet" Then

                Dim dateBTC As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim DateiBTC1 As String
                Dim DateiBTC2 As String
                Dim DateiBTC3 As String
                Dim sAppPath As String
                Dim process As New Process()
                sAppPath = Application.StartupPath
                DateiBTC1 = (Application.StartupPath & "\#_Hashout\Hashout_Electrum_" & dateBTC & ".txt")
                DateiBTC2 = (TextBox2.Text & " > " & DateiBTC1)
                DateiBTC3 = ("Hashout_Electrum_" & dateBTC & ".txt")


                Process.Start("cmd", "/c " & vari.PP2 & " " & vari.JtR & "electrum2john.py " & TextBox2.Text & " > " & DateiBTC1)


                '###### Outputfile Filename entfernen

                Threading.Thread.Sleep(1000)
                Dim input As String = System.IO.File.ReadAllText(DateiBTC1)
                Dim mark = "$" ' Es wird nach dem ersten "$" gesucht

                If input.Contains(mark) Then

                    Dim markPosition = input.IndexOf(mark)
                    Dim result2 = input.Substring(markPosition) ' mit bspw (markposition + 1) wird vor dem zweiten Buchstaben gelöscht
                    Dim schreiben As New IO.StreamWriter(DateiBTC1, False) ' True = Inhalt wird angefügt und nicht überschrieben,, bei False wird überschrieben
                    schreiben.WriteLine(result2)
                    schreiben.Close() ' Erst durch .Close() werden Zeilen abschließend gespeichert
                End If


                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "16600, 21700, 21800 (default is 21700)", "Hashbull", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = DateiBTC1
                    Hashcrack.HashtypCBox.Text = "21700_ Electrum Wallet (Salt_#2"

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    '####### Cancel Button

                    Me.Close()

                End If

            End If


            'LibreOffice-Extraction ################################################################################################################ 


            If ComboBox1.Text = "LibreOffice" Then

                Dim dateilibreoffice As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim Dateilibreoffice1 As String
                Dim Dateilibreoffice2 As String
                Dim Dateilibreoffice3 As String
                Dim sAppPath As String
                Dim process As New Process()
                sAppPath = Application.StartupPath
                Dateilibreoffice1 = "#_Hashout\Hashout_LibreOffice_" & dateilibreoffice & ".txt"
                Dateilibreoffice2 = (TextBox2.Text & " > " & Dateilibreoffice1)
                Dateilibreoffice3 = ("Hashout_Office_" & dateilibreoffice & ".txt")

                Process.Start("cmd", "/c " & vari.PP3 & " " & Application.StartupPath & "\Packages\Hashbull_lib\LibreOffice\" & "libreoffice2john.py " & TextBox2.Text & " > #_Hashout\Hashout_LibreOffice_" & dateilibreoffice & ".txt")


                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "18400", "Hashbull", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = Application.StartupPath & "\" & Dateilibreoffice1
                    Hashcrack.HashtypCBox.Text = "18400_ Open Document Format (ODF) 1.2 (SHA_#1"
                    Me.Close()
                    Welcome.Opacity = 0


                ElseIf result = DialogResult.No Then

                    Me.Close()

                End If

            End If







            'LUKS (Linux Unified Key System) Extraction ################################################################################################################ 


            If ComboBox1.Text = "LUKS (Linux Unified Key System)" Then

                Dim dateLUKS As String = DateTime.Now.ToString("ddMMyy_HHmmss")
                Dim DateiLUKS1 = Application.StartupPath & "\" & "#_Hashout\Hashout_LUKS_" & dateLUKS & ".txt"
                Dim process As New Process()


                process.StartInfo.FileName = "dd2.exe"
                process.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\DD\"
                process.StartInfo.Arguments = (" if=" & TextBox2.Text & " of=" & Application.StartupPath & "\#_Hashout\Hashout_LUKS_" & dateLUKS & ".txt " & "bs=512 count=4097")
                process.Start()


                If My.Settings.Eng = True Then MsgTextAll = MsgTextENG
                If My.Settings.Eng = False Then MsgTextAll = MsgTextGER

                Dim result As DialogResult = MessageBox.Show(MsgTextAll & "14600", "Hashbull", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashTxb.Text = DateiLUKS1
                    Hashcrack.HashtypCBox.Text = "14600_ LUKS (Iterations_#1"


                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.No Then

                    '####### Cancel Button

                    Me.Close()

                End If

            End If

        Catch ex As Exception

        End Try


    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Try

            '######### Hinweise zu den einzelnen Extractions


            If ComboBox1.Text = "eCryptfs" Then

                If My.Settings.Eng = True Then
                    MsgBox("Please select the file ""wrapped-passphrase"" from the relevant linux system in the next field")
                Else
                    MsgBox("Bitte wählen Sie die Datei: ""wrapped-passphrase"" im folgendem Fenster aus.")
                End If
            End If


            'Linux Login-Extraction ################################################################################################################ 

            If ComboBox1.Text = "Linux Login Password" Then

                If My.Settings.Eng = True Then MsgLinux = "You have to copy the hash from the ""Shadow"" file in the linux directory ""etc/shadow"" into a hash.txt. The hash starts with $6$. You have to delete everything after the last colon (e.g.:18585:0:99999:7:::). Then you can attack it in hash-mode 1800"
                If My.Settings.Eng = False Then MsgLinux = "Bitte kopieren Sie den User-Hash aus der ""Shadow-Datei"" im Linux Verzeichnis ""etc/shadow"" in eine Hash.txt. Der Hash beginnt mit ""$6$"". Alles ab dem letzten Doppelpunkt müssen Sie im Hash entfernen (bspw. :18585:0:99999:7:::). Der Hash-Typ ist 1800"

                Dim result As DialogResult = MsgBox(MsgLinux, MessageBoxButtons.OKCancel)

                If result = DialogResult.OK Then

                    '######## Form4 laden und Hash und Hastyp befüllen

                    Hashcrack.Show()
                    Hashcrack.HashtypCBox.Text = "1800_ sha512crypt $6$, SHA512 (Unix) (Iterations_#1"

                    Me.Close()
                    Welcome.Opacity = 0

                ElseIf result = DialogResult.Cancel Then

                    '####### Cancel Button

                    Me.Close()

                End If
            End If



            'Windows Login-Extraction ################################################################################################################ 

            If ComboBox1.Text = "Windows Login Password" Then

                Form1.Show()
                Me.Close()
                Welcome.Opacity = 0

            End If



            'APFS - Extraction ################################################################################################################ 

            If ComboBox1.Text = "APFS (Apple MacBooks)" Then

                APFS.Show()
                Me.Close()
                Welcome.Opacity = 0

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        '#### Help als pdf anzeigen
        If My.Settings.Eng = True Then
            Process.Start(System.IO.Path.Combine(Application.StartupPath, "Docs\Hashbull_User_Manual_ENG.pdf"))
        Else
            Process.Start(System.IO.Path.Combine(Application.StartupPath, "Docs\Hashbull_User_Manual_DE.pdf"))
        End If

    End Sub
End Class