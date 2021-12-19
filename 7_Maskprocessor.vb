Imports System.IO

Public Class Maskprocessor



        Public CMD1 As String = "/c "
        Public Multiple As String
        Public Occur As String
        Public NumLeng1 As String
        Public NumLeng2 As String
        Public CommandW As String
        Public Charset1 As String
        Public Charset2 As String
        Public Charset3 As String
        Public Charset4 As String
        Public Ending As String = ".txt"
        Public Outputfile As String
        Public DatePub As String
        Public Combi As String
        Public StartP As String
        Public StopP As String

        Public CommandStart As String


        Private Sub Maskprocessor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

            WordlistUtility.Show()

        End Sub

        Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox8.Clear()
            TextBox9.Clear()
            TextBox10.Clear()
            TextBox11.Clear()
            TextBox12.Clear()

            File1Txb.Clear()
            File2Txb.Clear()
            File3Txb.Clear()

            LenTxb.Clear()
            LenMaxTxb.Clear()
            LenMinTxb.Clear()

        End Sub


        Sub Aktualiseren()

            If CheckBox4.Checked = True Then
                Dim Date1 As String = Format(Now, "yyyyMMdd_HHmmss")
                DatePub = Date1 & Ending
            Else
                DatePub = ""
            End If

            CommandStart = CMD1 & "mp64.exe " & CommandW & Charset1 & Charset2 & Charset3 & Charset4 & NumLeng1 & NumLeng2 & Multiple & Occur & StartP & StopP & Outputfile & DatePub & Combi
            TextBox9.Text = CommandStart

        End Sub



        Private Sub Form11_Load(sender As Object, e As EventArgs) Handles Me.Load


            CheckBox2.Checked = True
            CheckBox4.Checked = True
            TextBox10.Select()

            '### Auf Deutsch umstellen
            If My.Settings.Ger = True Then

                GroupBox1.Text = "Einstellungen"

                Label11.Text = "Kommandos:"
                Label2.Text = "Ausgabe-Typ:"
                Label4.Text = "Ausgabe in:"
                Label1.Text = "Wortlänge:"
                Label3.Text = "bis"
                Label15.Text = "bis"
                Label14.Text = "Start / Stop - Position:"
                Label12.Text = "Max. mehrere Zeichen:"
                Label13.Text = "Max. vorkomm. Zeichen:"
                Label9.Text = "(max. Anzahl aufeinanderfolgender Zeichen)"
                Label10.Text = "(max. Anzahl des Vorkommens eines Zeichens)"

                CheckBox4.Text = "Ausgabedatei"
            CheckBox3.Text = "Anzahl der Kombinationen berechnen"

            '### Combinator

            Combi1Btn.Text = "Öffnen"
            Combi2Btn.Text = "Öffnen"
            Combi3Btn.Text = "Öffnen"
            Label17.Text = "Datei 1:"
            Label18.Text = "Datei 2:"
            Label19.Text = "Datei 3:"
            Label16.Text = "Combinator kann bis zu drei Wordlists miteinander verbinden. Jedes Wort der zweiten" & vbNewLine & "und dritten Wordlist wird an jedes Wort der ersten Wordlist angehangen. Dies ist vergleichbar" & vbNewLine & "mit der Combinator-Attacke (-a 1)."
            Label23.Text = "Mit ""Len"" können Sie Passwortkandidaten mit einer bestimmten Länge aus Wordlists" & vbNewLine &
                           "in eine neue Wordlist extrahieren."

        End If

        End Sub



        Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

            '### Search-Lenght 1

            If TextBox1.TextLength > 0 Then
                NumLeng1 = "-i " & TextBox1.Text
                Call Aktualiseren()
            Else
                NumLeng1 = ""
                Call Aktualiseren()
            End If

        End Sub

        Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles TextBox1.KeyPress

            '#### Nur Zahlen und Backspace 

            Select Case Asc(e.KeyChar)
                Case 48 To 57, 8
                    ' Zahlen, Backspace 

                Case Else
                    ' alle anderen Eingaben unterdrücken
                    e.Handled = True
            End Select

        End Sub

        Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

            '### Search-Lenght 2

            If TextBox2.TextLength > 0 Then
                NumLeng2 = ":" & TextBox2.Text & " "
                Call Aktualiseren()
            Else
                NumLeng2 = ""
                Call Aktualiseren()
            End If

        End Sub

        Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
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


        Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

            '#### Multiple Chars

            If TextBox7.TextLength > 0 Then
                Multiple = " -q " & TextBox7.Text & " "
                Call Aktualiseren()
            Else
                Multiple = ""
                Call Aktualiseren()
            End If

        End Sub

        Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles TextBox7.KeyPress

            '#### Nur Zahlen und Backspace 

            Select Case Asc(e.KeyChar)
                Case 48 To 57, 8
                    ' Zahlen, Backspace 

                Case Else
                    ' alle anderen Eingaben unterdrücken
                    e.Handled = True
            End Select

        End Sub



        Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

            '#### Command Parameters

            If TextBox10.TextLength > 0 Then
                CommandW = TextBox10.Text & " "
                Call Aktualiseren()
            Else
                CommandW = ""
                Call Aktualiseren()
            End If
        End Sub

        Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

            '#### Charset 1

            If TextBox3.TextLength > 0 Then
                Charset1 = "-1 " & TextBox3.Text & " "
                Call Aktualiseren()
            Else
                Charset1 = ""
                Call Aktualiseren()
            End If


        End Sub


        Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

            '#### Charset 2

            If TextBox4.TextLength > 0 Then
                Charset2 = "-2 " & TextBox4.Text & " "
                Call Aktualiseren()
            Else
                Charset2 = ""
                Call Aktualiseren()
            End If


        End Sub


        Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

            '#### Charset 3

            If TextBox5.TextLength > 0 Then
                Charset3 = "-3 " & TextBox5.Text & " "
                Call Aktualiseren()
            Else
                Charset3 = ""
                Call Aktualiseren()
            End If


        End Sub

        Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

            '#### Charset 4

            If TextBox6.TextLength > 0 Then
                Charset4 = "-4 " & TextBox6.Text & " "
                Call Aktualiseren()
            Else
                Charset4 = ""
                Call Aktualiseren()
            End If


        End Sub

        Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

            If CheckBox2.Checked = True Then

                Ending = ".txt"
                CheckBox1.Checked = False
                Call Aktualiseren()

            End If

        End Sub

        Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

            If CheckBox1.Checked = True Then

                Ending = ".rule"
                CheckBox2.Checked = False
                Call Aktualiseren()

            End If

        End Sub

        Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
            '#### Occur Chars

            If TextBox8.TextLength > 0 Then
                Occur = " -r " & TextBox8.Text & " "
                Call Aktualiseren()
            Else
                Occur = ""
                Call Aktualiseren()
            End If

        End Sub

        Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles TextBox8.KeyPress

            '#### Nur Zahlen und Backspace 

            Select Case Asc(e.KeyChar)
                Case 48 To 57, 8
                    ' Zahlen, Backspace 

                Case Else
                    ' alle anderen Eingaben unterdrücken
                    e.Handled = True
            End Select

        End Sub

        Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged

            If CheckBox4.Checked = True Then

                Outputfile = "-o " & Application.StartupPath & "\#_Wordlists\" & "MP_Out_"
                CheckBox3.Checked = False
                Call Aktualiseren()

            Else

                Outputfile = ""
                Call Aktualiseren()

            End If


        End Sub

        Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

            If CheckBox3.Checked = True Then

                Combi = "--combinations "
                CMD1 = "/k "
                CheckBox4.Checked = False
                Call Aktualiseren()

            Else

                Combi = ""
                CMD1 = "/c "
                Call Aktualiseren()
            End If



        End Sub

        Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

            HelpMaskpro.Show()

        End Sub

        Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

            '#### Start position

            If TextBox11.TextLength > 0 Then
                StartP = " -s " & TextBox11.Text & " "
                Call Aktualiseren()
            Else
                StartP = ""
                Call Aktualiseren()
            End If

        End Sub



        Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

            '#### Stop position

            If TextBox12.TextLength > 0 Then
                StopP = " -l " & TextBox12.Text & " "
                Call Aktualiseren()
            Else
                StopP = ""
                Call Aktualiseren()
            End If

        End Sub



        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

            '#########START Button führt das Commad Fenster aus


            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\MP"
            process.StartInfo.Arguments = (CommandStart) 'TextBox9.Text)
            process.Start()


            If CheckBox4.Checked And My.Settings.Eng = True Then MsgBox("Done! You find the wordlist in the Hashbull-Folder ""#_Wordlists""." & vbNewLine & vbNewLine &
            "If no file was generated, then an error has occurred. Change the parameter ""/c"" to ""/k"" in the ""Generate-Command-Window"" to get the error message.")

            If CheckBox4.Checked And My.Settings.Eng = False Then MsgBox("Sie finden die Wordlist im Ordner ""#_Wordlists""." & vbNewLine & vbNewLine &
            "Sollten Sie die Wordlist dort nicht finden, dann wird einen Fehler unterlaufen sein. Ändern Sie den Parameter im ""Command-Fenster"" von ""/c"" auf ""/k"" um einen Fehlerhinweis zu erhalten.")


        End Sub






        '#########################################################################################################################################################################################
        '# C O M B I N A T O R
        '#########################################################################################################################################################################################


        Private Sub Combi1Btn_Click(sender As Object, e As EventArgs) Handles Combi1Btn.Click


            '#### Auswahl und in TexBox einfügen 

            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.InitialDirectory = Application.StartupPath & "\#_Wordlists"
            openFileDialog.Filter = "All Files (*.*)| *.*"


            If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                File1Txb.Text = openFileDialog.FileName
            End If


        End Sub

        Private Sub Combi2Btn_Click(sender As Object, e As EventArgs) Handles Combi2Btn.Click

            '#### Auswahl und in TexBox einfügen 

            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.InitialDirectory = Application.StartupPath & "\#_Wordlists"
            openFileDialog.Filter = "All Files (*.*)| *.*"


            If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                File2Txb.Text = openFileDialog.FileName
            End If


        End Sub

        Private Sub Combi3Btn_Click(sender As Object, e As EventArgs) Handles Combi3Btn.Click

            '#### Auswahl und in TexBox einfügen 

            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.InitialDirectory = Application.StartupPath & "\#_Wordlists"
            openFileDialog.Filter = "All Files (*.*)| *.*"


            If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                File3Txb.Text = openFileDialog.FileName
            End If


        End Sub



        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

            If File1Txb.TextLength > 1 And File2Txb.TextLength > 1 And File3Txb.TextLength < 1 Then

                Dim Date3 As String = Format(Now, "yyyyMMdd_HHmmss")
                Dim process As New Process()
                process.StartInfo.FileName = "cmd.exe"
                process.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\Hashbull_lib\HCUtils"
                process.StartInfo.Arguments = ("/c combinator.exe " & File1Txb.Text & " " & File2Txb.Text & " > " & Application.StartupPath & "\#_Wordlists\Combinator2_" & Date3 & ".txt")
                process.Start()

                If My.Settings.Eng = True Then MsgBox("The output file was created in the folder ""#_Wordlist"". The process may take some time for large files.")
                If My.Settings.Eng = False Then MsgBox("Die Ausgabedatei wird nach Fertigstellung in den Ordner ""#_Wordlist"" gespeichert. Bei sehr großen Dateien kann der Vorgang einige Zeit in Anspruch nehmen.")

            End If


            If File1Txb.TextLength > 1 And File2Txb.TextLength > 1 And File3Txb.TextLength > 1 Then

                Dim Date3 As String = Format(Now, "yyyyMMdd_HHmmss")
                Dim process As New Process()
                process.StartInfo.FileName = "cmd.exe"
                process.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\Hashbull_lib\HCUtils"
                process.StartInfo.Arguments = ("/c combinator3.exe " & File1Txb.Text & " " & File2Txb.Text & " " & File3Txb.Text & " > " & Application.StartupPath & "\#_Wordlists\Combinator3_" & Date3 & ".txt")
                process.Start()

                If My.Settings.Eng = True Then MsgBox("The output file was created in the folder ""#_Wordlist"". The process may take some time for large files.", vbSystemModal)
                If My.Settings.Eng = False Then MsgBox("Die Ausgabedatei wird nach Fertigstellung in den Ordner ""#_Wordlist"" gespeichert. Bei sehr großen Dateien kann der Vorgang einige Zeit in Anspruch nehmen.", vbSystemModal)

            End If


            If File1Txb.TextLength > 1 AndAlso File2Txb.TextLength < 1 AndAlso File3Txb.TextLength < 1 Then

                If My.Settings.Eng = True Then MsgBox("You have to fill in at least two fields", vbSystemModal)
                If My.Settings.Eng = False Then MsgBox("Sie müssen mind. zwei Felder ausfüllen.", vbSystemModal)

            End If


        End Sub






        '#########################################################################################################################################################################################
        '# L E N 
        '#########################################################################################################################################################################################



        Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

            '#### Auswahl und in TexBox einfügen 

            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.InitialDirectory = Application.StartupPath & "\#_Wordlists"
            openFileDialog.Filter = "All Files (*.*)| *.*"


            If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                LenTxb.Text = openFileDialog.FileName
            End If
        End Sub

        Private Sub LenMinTxb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles LenMinTxb.KeyPress

            '#### Nur Zahlen und Backspace 

            Select Case Asc(e.KeyChar)
                Case 48 To 57, 8
                    ' Zahlen, Backspace 

                Case Else
                    ' alle anderen Eingaben unterdrücken
                    e.Handled = True
            End Select

        End Sub

        Private Sub LenMaxTxb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles LenMaxTxb.KeyPress

            '#### Nur Zahlen und Backspace 

            Select Case Asc(e.KeyChar)
                Case 48 To 57, 8
                    ' Zahlen, Backspace 

                Case Else
                    ' alle anderen Eingaben unterdrücken
                    e.Handled = True
            End Select
        End Sub

        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If LenTxb.TextLength < 1 Or LenMinTxb.TextLength < 1 Or LenMaxTxb.TextLength < 1 Then

            If My.Settings.Eng = True Then MsgBox("You have to fill in the input fields.", vbSystemModal)
            If My.Settings.Eng = False Then MsgBox("Sie müssen die Felder ausfüllen.", vbSystemModal)
            Exit Sub

        End If

        Dim Date3 As String = Format(Now, "yyyyMMdd_HHmmss")
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.WorkingDirectory = Application.StartupPath & "\Packages\Hashbull_lib\HCUtils"
            process.StartInfo.Arguments = ("/k len.exe " & LenMinTxb.Text & " " & LenMaxTxb.Text & " <" & LenTxb.Text & "> " & Application.StartupPath & "\#_Wordlists\Len_Wordlist_" & Date3 & ".txt")
            process.Start()

            If My.Settings.Eng = True Then MsgBox("The output file was created in the folder ""#_Wordlist"". The process may take some time for large files.")
            If My.Settings.Eng = False Then MsgBox("Die Ausgabedatei wird nach Fertigstellung in den Ordner ""#_Wordlist"" gespeichert. Bei sehr großen Dateien kann der Vorgang einige Zeit in Anspruch nehmen.")


        End Sub






End Class