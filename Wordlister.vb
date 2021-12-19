Public Class Wordlister

    Public PermX As String
    Public MinLX As String
    Public MaxLX As String
    Public LeetX As String
    Public CapX As String
    Public UpX As String
    Public RuleX As String
    Public WordlisterExit As Boolean

    Private Sub Wordlister_Load(sender As Object, e As EventArgs) Handles Me.Load

        '### Sprache laden
        If My.Settings.Ger = True Then

            Label1.Text = "Zielperson"
            Label2.Text = "Ehepartner"
            Label3.Text = "Kind 1"
            Label4.Text = "Kind 2"
            Label5.Text = "Kind 3"
            Label6.Text = "Mutter"
            Label7.Text = "Vater"
            Label8.Text = "Spitzname"
            Label9.Text = "Vorname"
            Label10.Text = "Nachname"
            Label11.Text = "Geburtstag (TTMM)"
            Label12.Text = "Geburtsjahr (JJJJ)"
            Label13.Text = "Sonstiges (bspw. Name des Haustieres, Fussballclub, ...). In jedes Feld nur einen Eintrag."
            Label14.Text = "Permutationen"
            Label15.Text = "min. Länge"
            Label16.Text = "max. Länge"
            Label19.Text = "Leet-Sprache"
            Label18.Text = "Vorne Großbuchstaben"
            Label17.Text = "Alles Großbuchstaben"
            Label20.Text = "Alle Eingaben in Kleinbuchstaben vornehmen! Geburtsdatum ohne Punkte eingeben!"

            Button1.Text = "START"
            Button2.Text = "Abbruch"
            Button3.Text = "Löschen"


            GroupBox1.Text = "Informationen zur Zielperson"
            GroupBox2.Text = "Weitere Informationen zur Zielperson"


        End If

        '# Standardwerte laden
        Perm.Text = "3"
        MinL.Text = "6"
        MaxL.Text = "17"


        '### WordlisterExit erst immer auf False
        WordlisterExit = False


        '#### Standard laden

        TextBox46.Text =
            "#" & vbNewLine &
            "," & vbNewLine &
            "!" & vbNewLine &
            "!!" & vbNewLine &
            "_" & vbNewLine &
            "@" & vbNewLine &
            ":" & vbNewLine &
            "$" & vbNewLine &
            "&" & vbNewLine &
            "." & vbNewLine &
            ";" & vbNewLine &
            "+" & vbNewLine &
            "?" & vbNewLine &
            "*" & vbNewLine &
            "-" & vbNewLine &
            "/" & vbNewLine &
            "\" & vbNewLine &
            "=" & vbNewLine &
            "§" & vbNewLine &
            "'" & vbNewLine &
            "[" & vbNewLine &
            "]" & vbNewLine &
            "%" & vbNewLine &
            """" & vbNewLine &
            "^" & vbNewLine &
            "°" & vbNewLine &
            "(" & vbNewLine &
            ")" & vbNewLine &
            ">" & vbNewLine &
            "<" & vbNewLine &
            "{" & vbNewLine &
            "}" & vbNewLine &
            "~" & vbNewLine &
            "|" & vbNewLine &
            " " & vbNewLine &
            "0" & vbNewLine &
            "1" & vbNewLine &
            "2" & vbNewLine &
            "3" & vbNewLine &
            "4" & vbNewLine &
            "5" & vbNewLine &
            "6" & vbNewLine &
            "7" & vbNewLine &
            "8" & vbNewLine &
            "9" & vbNewLine &
            "11" & vbNewLine &
            "22" & vbNewLine &
            "33" & vbNewLine &
            "44" & vbNewLine &
            "55" & vbNewLine &
            "66" & vbNewLine &
            "77" & vbNewLine &
            "88" & vbNewLine &
            "99" & vbNewLine &
            "007" & vbNewLine &
            "000" & vbNewLine &
            "111" & vbNewLine &
            "012" & vbNewLine &
            "123" & vbNewLine &
            "234" & vbNewLine &
            "345" & vbNewLine &
            "456" & vbNewLine &
            "567" & vbNewLine &
            "678" & vbNewLine &
            "789" & vbNewLine &
            "222" & vbNewLine &
            "333" & vbNewLine &
            "444" & vbNewLine &
            "555" & vbNewLine &
            "666" & vbNewLine &
            "777" & vbNewLine &
            "888" & vbNewLine &
            "999" & vbNewLine &
            "1234" & vbNewLine &
            "12345" & vbNewLine &
            "123456" & vbNewLine &
            "1234567" & vbNewLine &
            "12345678" & vbNewLine &
            "123456789" & vbNewLine &
            "1000" & vbNewLine &
            "1111" & vbNewLine &
            "2222" & vbNewLine &
            "3333" & vbNewLine &
            "4444" & vbNewLine &
            "5555" & vbNewLine &
            "6666" & vbNewLine &
            "7777" & vbNewLine &
            "8888" & vbNewLine &
            "9999" & vbNewLine &
            "0815" & vbNewLine &
            "1980" & vbNewLine &
            "1981" & vbNewLine &
            "1982" & vbNewLine &
            "1983" & vbNewLine &
            "1984" & vbNewLine &
            "1985" & vbNewLine &
            "1986" & vbNewLine &
            "1987" & vbNewLine &
            "1988" & vbNewLine &
            "1989" & vbNewLine &
            "1990" & vbNewLine &
            "1991" & vbNewLine &
            "1992" & vbNewLine &
            "1993" & vbNewLine &
            "1994" & vbNewLine &
            "1995" & vbNewLine &
            "1996" & vbNewLine &
            "1997" & vbNewLine &
            "1998" & vbNewLine &
            "1999" & vbNewLine &
            "2000" & vbNewLine &
            "2001" & vbNewLine &
            "2002" & vbNewLine &
            "2003" & vbNewLine &
            "2004" & vbNewLine &
            "2005" & vbNewLine &
            "2006" & vbNewLine &
            "2007" & vbNewLine &
            "2008" & vbNewLine &
            "2009" & vbNewLine &
            "2010" & vbNewLine &
            "2011" & vbNewLine &
            "2012" & vbNewLine &
            "2013" & vbNewLine &
            "2014" & vbNewLine &
            "2015" & vbNewLine &
            "2016" & vbNewLine &
            "2017" & vbNewLine &
            "2018" & vbNewLine &
            "2019" & vbNewLine &
            "2020" & vbNewLine &
            "2021" & vbNewLine &
            "2022" & vbNewLine &
            "2023" & vbNewLine &
            "2024" & vbNewLine &
            "2025" & vbNewLine &
            "2026" & vbNewLine &
            "2027" & vbNewLine &
            "2028" & vbNewLine &
            "2029" & vbNewLine &
            "2030" & vbNewLine &
            "2031" & vbNewLine &
            "2032" & vbNewLine &
            "2033" & vbNewLine &
            "2034" & vbNewLine &
            "2035" & vbNewLine &
            "2036" & vbNewLine &
            "2037" & vbNewLine &
            "2038" & vbNewLine &
            "2039" & vbNewLine &
            "2040" & vbNewLine

    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            Dim save As New IO.StreamWriter(New IO.FileStream(IO.Path.Combine(Application.StartupPath & "\#_Wordlists\Wordlister_Input.txt"), IO.FileMode.Create))

            '### Standard-Wordlist
            save.WriteLine(TextBox46.Text)

            '### Subjektive Wordlist

            If TextBox1.Text <> "" Then save.WriteLine(TextBox1.Text)
            If TextBox2.Text <> "" Then save.WriteLine(TextBox2.Text)
            If TextBox3.Text <> "" Then save.WriteLine(TextBox3.Text)
            If TextBox4.Text <> "" Then save.WriteLine(TextBox4.Text)
            If TextBox5.Text <> "" Then save.WriteLine(TextBox5.Text)
            If TextBox6.Text <> "" Then save.WriteLine(TextBox6.Text)
            If TextBox7.Text <> "" Then save.WriteLine(TextBox7.Text)
            If TextBox8.Text <> "" Then save.WriteLine(TextBox8.Text)
            If TextBox9.Text <> "" Then save.WriteLine(TextBox9.Text)
            If TextBox10.Text <> "" Then save.WriteLine(TextBox10.Text)
            If TextBox11.Text <> "" Then save.WriteLine(TextBox11.Text)
            If TextBox12.Text <> "" Then save.WriteLine(TextBox12.Text)
            If TextBox13.Text <> "" Then save.WriteLine(TextBox13.Text)
            If TextBox14.Text <> "" Then save.WriteLine(TextBox14.Text)
            If TextBox15.Text <> "" Then save.WriteLine(TextBox15.Text)
            If TextBox16.Text <> "" Then save.WriteLine(TextBox16.Text)
            If TextBox17.Text <> "" Then save.WriteLine(TextBox17.Text)
            If TextBox18.Text <> "" Then save.WriteLine(TextBox18.Text)
            If TextBox19.Text <> "" Then save.WriteLine(TextBox19.Text)
            If TextBox20.Text <> "" Then save.WriteLine(TextBox20.Text)
            If TextBox21.Text <> "" Then save.WriteLine(TextBox21.Text)
            If TextBox22.Text <> "" Then save.WriteLine(TextBox22.Text)
            If TextBox23.Text <> "" Then save.WriteLine(TextBox23.Text)
            If TextBox24.Text <> "" Then save.WriteLine(TextBox24.Text)
            If TextBox25.Text <> "" Then save.WriteLine(TextBox25.Text)
            If TextBox26.Text <> "" Then save.WriteLine(TextBox26.Text)
            If TextBox27.Text <> "" Then save.WriteLine(TextBox27.Text)
            If TextBox28.Text <> "" Then save.WriteLine(TextBox28.Text)
            If TextBox29.Text <> "" Then save.WriteLine(TextBox29.Text)
            If TextBox30.Text <> "" Then save.WriteLine(TextBox30.Text)
            If TextBox31.Text <> "" Then save.WriteLine(TextBox31.Text)
            If TextBox32.Text <> "" Then save.WriteLine(TextBox32.Text)
            If TextBox33.Text <> "" Then save.WriteLine(TextBox33.Text)
            If TextBox34.Text <> "" Then save.WriteLine(TextBox34.Text)
            If TextBox35.Text <> "" Then save.WriteLine(TextBox35.Text)
            If TextBox36.Text <> "" Then save.WriteLine(TextBox36.Text)
            If TextBox37.Text <> "" Then save.WriteLine(TextBox37.Text)
            If TextBox38.Text <> "" Then save.WriteLine(TextBox38.Text)
            If TextBox39.Text <> "" Then save.WriteLine(TextBox39.Text)
            If TextBox40.Text <> "" Then save.WriteLine(TextBox40.Text)
            If TextBox41.Text <> "" Then save.WriteLine(TextBox41.Text)
            If TextBox42.Text <> "" Then save.WriteLine(TextBox42.Text)
            If TextBox43.Text <> "" Then save.WriteLine(TextBox43.Text)
            If TextBox44.Text <> "" Then save.WriteLine(TextBox44.Text)
            If TextBox45.Text <> "" Then save.WriteLine(TextBox45.Text)

            save.Close()



            '### Target-Words dokumentieren
            Dim DateBatch As String = Format(Now, "yyyy_MM_dd_HH_mm_ss")
            Dim SourceFile, DestinationFile As String
            SourceFile = Application.StartupPath & "\#_Wordlists\Wordlister_Input.txt"   ' Define source file name.
            DestinationFile = Application.StartupPath & "\Logs\" & Hashcrack.SessionTxb.Text & "_" & DateBatch & "_Wordlister.txt"   ' Define target file name.
            FileCopy(SourceFile, DestinationFile)   ' Copy source to target.




        Catch ex As Exception

        End Try


        '# in die Variablen schreiben
        PermX = " --perm " & Perm.Text
        MinLX = " --min " & MinL.Text
        MaxLX = " --max " & MaxL.Text


        If Leet.Checked = True Then
            LeetX = " --leet "
        Else
            LeetX = ""
        End If

        If Cap.Checked = True Then
            CapX = " --cap "
        Else
            CapX = ""
        End If


        If Up.Checked = True Then
            UpX = " --up "
        Else
            UpX = ""
        End If


        If My.Settings.Eng = True Then MsgBox("The wordlist will now be created and saved in the folder ""\#_Wordlists\"". This can take up to 10 minutes.")
        If My.Settings.Eng = False Then MsgBox("Die Wordlist wird jetzt erstellt und im Ordner ""\#_Wordlists\"" abgespeichert. Dies kann bis zu 10 Min. dauern.")


        Me.Close()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

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
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()
        TextBox20.Clear()
        TextBox21.Clear()
        TextBox22.Clear()
        TextBox23.Clear()
        TextBox24.Clear()
        TextBox25.Clear()
        TextBox26.Clear()
        TextBox27.Clear()
        TextBox28.Clear()
        TextBox29.Clear()
        TextBox30.Clear()
        TextBox31.Clear()
        TextBox32.Clear()
        TextBox33.Clear()
        TextBox34.Clear()
        TextBox35.Clear()
        TextBox36.Clear()
        TextBox37.Clear()
        TextBox38.Clear()
        TextBox39.Clear()
        TextBox40.Clear()
        TextBox41.Clear()
        TextBox42.Clear()
        TextBox43.Clear()
        TextBox44.Clear()
        TextBox45.Clear()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Beenden ohne die Ausführung des restlichen Codes
        WordlisterExit = True
        Me.Close()

    End Sub


End Class