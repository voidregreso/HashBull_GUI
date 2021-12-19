Imports System.ComponentModel
Imports System.IO
Public Class ScennerSettings

    Public Pfad As String = Application.StartupPath & "\Packages\Hashbull_lib\CS\CS.bat"
    Public T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140 As String

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        If My.Settings.Eng = False Then MsgBox("Der Dateiinhalt aller Dateien in den Ordnern Mozilla, Microsoft, Opera und Google im AppData-Ordner ""Local"" und ""Roaming"" werden nach den Begriffen gescannt.")
        If My.Settings.Eng = True Then MsgBox("The file contents of all files in the Mozilla, Microsoft, Opera and Google folders in the AppData folder "" Local "" and "" Roaming "" are scanned for the terms.")

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        If My.Settings.Eng = False Then MsgBox("Der Dateiinhalt aller Dateien in den Ordnern Mozilla, Microsoft, Opera und Google im AppData-Ordner ""Local"" und ""Roaming"" werden nach den Begriffen gescannt.")
        If My.Settings.Eng = True Then MsgBox("The file contents of all files in the Mozilla, Microsoft, Opera and Google folders in the AppData folder "" Local "" and "" Roaming "" are scanned for the terms.")

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        If My.Settings.Eng = False Then MsgBox("Es wird das gesamte Dateisystem nach Dateinamen gescannt, die folgende Begriffe enthalten. * kann als Platzhalter verwendet werden.")
        If My.Settings.Eng = True Then MsgBox("The entire file system is scanned for file names that contain the following terms. * can be used as a placeholder")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub




    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        TextBox1.Text = "blockchain.com"
        TextBox2.Text = "binance.com"
        TextBox3.Text = "bitwala.com"
        TextBox4.Text = "kraken.com"
        TextBox5.Text = "getmonero.org"
        TextBox6.Text = "coinbase.com"
        TextBox7.Text = "bitpanda.com"
        TextBox8.Text = "myetherwallet.com"
        TextBox9.Text = "ledger.com"
        TextBox10.Text = "Trezor"
        TextBox11.Text = "trezor.io"
        TextBox12.Text = "shapeshift.com"
        TextBox13.Text = "KeepKey"
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = "*bitcoin*.exe"
        TextBox18.Text = "wallet.dat"
        TextBox19.Text = "*.wallet"
        TextBox20.Text = "*electrum*.exe"
        TextBox21.Text = "*ethereum*.exe"
        TextBox22.Text = "*monero*.exe"
        TextBox23.Text = "*exodus*.exe"
        TextBox24.Text = "*ledger*.*"



    End Sub


    Private Sub ScennerSettings_Load(sender As Object, e As EventArgs) Handles Me.Load

        TextBox1.Text = My.Settings.Scanner1
        TextBox2.Text = My.Settings.Scanner2
        TextBox3.Text = My.Settings.Scanner3
        TextBox4.Text = My.Settings.Scanner4
        TextBox5.Text = My.Settings.Scanner5
        TextBox6.Text = My.Settings.Scanner6
        TextBox7.Text = My.Settings.Scanner7
        TextBox8.Text = My.Settings.Scanner8
        TextBox9.Text = My.Settings.Scanner9
        TextBox10.Text = My.Settings.Scanner10
        TextBox11.Text = My.Settings.Scanner11
        TextBox12.Text = My.Settings.Scanner12
        TextBox13.Text = My.Settings.Scanner13
        TextBox14.Text = My.Settings.Scanner14
        TextBox15.Text = My.Settings.Scanner15
        TextBox16.Text = My.Settings.Scanner16
        TextBox17.Text = My.Settings.Scanner17
        TextBox18.Text = My.Settings.Scanner18
        TextBox19.Text = My.Settings.Scanner19
        TextBox20.Text = My.Settings.Scanner20
        TextBox21.Text = My.Settings.Scanner21
        TextBox22.Text = My.Settings.Scanner22
        TextBox23.Text = My.Settings.Scanner23
        TextBox24.Text = My.Settings.Scanner24

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If TextBox1.TextLength > 0 Then
            T1 = "findstr /s /i /m /o /offline " & """" & TextBox1.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T2 = "findstr /s /i /m /o /offline " & """" & TextBox1.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T3 = "findstr /s /i /m /o /offline " & """" & TextBox1.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T4 = "findstr /s /i /m /o /offline " & """" & TextBox1.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T5 = "findstr /s /i /m /o /offline " & """" & TextBox1.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T6 = "findstr /s /i /m /o /offline " & """" & TextBox1.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T7 = "findstr /s /i /m /o /offline " & """" & TextBox1.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T8 = "findstr /s /i /m /o /offline " & """" & TextBox1.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox2.TextLength > 0 Then
            T9 = "findstr /s /i /m /o /offline " & """" & TextBox2.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T10 = "findstr /s /i /m /o /offline " & """" & TextBox2.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T11 = "findstr /s /i /m /o /offline " & """" & TextBox2.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T12 = "findstr /s /i /m /o /offline " & """" & TextBox2.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T13 = "findstr /s /i /m /o /offline " & """" & TextBox2.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T14 = "findstr /s /i /m /o /offline " & """" & TextBox2.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T15 = "findstr /s /i /m /o /offline " & """" & TextBox2.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T16 = "findstr /s /i /m /o /offline " & """" & TextBox2.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox3.TextLength > 0 Then
            T17 = "findstr /s /i /m /o /offline " & """" & TextBox3.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T18 = "findstr /s /i /m /o /offline " & """" & TextBox3.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T19 = "findstr /s /i /m /o /offline " & """" & TextBox3.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T20 = "findstr /s /i /m /o /offline " & """" & TextBox3.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T21 = "findstr /s /i /m /o /offline " & """" & TextBox3.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T22 = "findstr /s /i /m /o /offline " & """" & TextBox3.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T23 = "findstr /s /i /m /o /offline " & """" & TextBox3.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T24 = "findstr /s /i /m /o /offline " & """" & TextBox3.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox4.TextLength > 0 Then
            T25 = "findstr /s /i /m /o /offline " & """" & TextBox4.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T26 = "findstr /s /i /m /o /offline " & """" & TextBox4.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T27 = "findstr /s /i /m /o /offline " & """" & TextBox4.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T28 = "findstr /s /i /m /o /offline " & """" & TextBox4.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T29 = "findstr /s /i /m /o /offline " & """" & TextBox4.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T30 = "findstr /s /i /m /o /offline " & """" & TextBox4.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T31 = "findstr /s /i /m /o /offline " & """" & TextBox4.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T32 = "findstr /s /i /m /o /offline " & """" & TextBox4.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox5.TextLength > 0 Then
            T33 = "findstr /s /i /m /o /offline " & """" & TextBox5.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T34 = "findstr /s /i /m /o /offline " & """" & TextBox5.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T35 = "findstr /s /i /m /o /offline " & """" & TextBox5.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T36 = "findstr /s /i /m /o /offline " & """" & TextBox5.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T37 = "findstr /s /i /m /o /offline " & """" & TextBox5.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T38 = "findstr /s /i /m /o /offline " & """" & TextBox5.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T39 = "findstr /s /i /m /o /offline " & """" & TextBox5.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T40 = "findstr /s /i /m /o /offline " & """" & TextBox5.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox6.TextLength > 0 Then
            T41 = "findstr /s /i /m /o /offline " & """" & TextBox6.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T42 = "findstr /s /i /m /o /offline " & """" & TextBox6.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T43 = "findstr /s /i /m /o /offline " & """" & TextBox6.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T44 = "findstr /s /i /m /o /offline " & """" & TextBox6.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T45 = "findstr /s /i /m /o /offline " & """" & TextBox6.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T46 = "findstr /s /i /m /o /offline " & """" & TextBox6.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T47 = "findstr /s /i /m /o /offline " & """" & TextBox6.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T48 = "findstr /s /i /m /o /offline " & """" & TextBox6.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox7.TextLength > 0 Then
            T49 = "findstr /s /i /m /o /offline " & """" & TextBox7.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T50 = "findstr /s /i /m /o /offline " & """" & TextBox7.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T51 = "findstr /s /i /m /o /offline " & """" & TextBox7.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T52 = "findstr /s /i /m /o /offline " & """" & TextBox7.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T53 = "findstr /s /i /m /o /offline " & """" & TextBox7.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T54 = "findstr /s /i /m /o /offline " & """" & TextBox7.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T55 = "findstr /s /i /m /o /offline " & """" & TextBox7.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T56 = "findstr /s /i /m /o /offline " & """" & TextBox7.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox8.TextLength > 0 Then
            T57 = "findstr /s /i /m /o /offline " & """" & TextBox8.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T58 = "findstr /s /i /m /o /offline " & """" & TextBox8.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T59 = "findstr /s /i /m /o /offline " & """" & TextBox8.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T60 = "findstr /s /i /m /o /offline " & """" & TextBox8.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T61 = "findstr /s /i /m /o /offline " & """" & TextBox8.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T62 = "findstr /s /i /m /o /offline " & """" & TextBox8.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T63 = "findstr /s /i /m /o /offline " & """" & TextBox8.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T64 = "findstr /s /i /m /o /offline " & """" & TextBox8.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox9.TextLength > 0 Then
            T65 = "findstr /s /i /m /o /offline " & """" & TextBox9.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T66 = "findstr /s /i /m /o /offline " & """" & TextBox9.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T67 = "findstr /s /i /m /o /offline " & """" & TextBox9.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T68 = "findstr /s /i /m /o /offline " & """" & TextBox9.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T69 = "findstr /s /i /m /o /offline " & """" & TextBox9.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T70 = "findstr /s /i /m /o /offline " & """" & TextBox9.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T71 = "findstr /s /i /m /o /offline " & """" & TextBox9.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T72 = "findstr /s /i /m /o /offline " & """" & TextBox9.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox10.TextLength > 0 Then
            T73 = "findstr /s /i /m /o /offline " & """" & TextBox10.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T74 = "findstr /s /i /m /o /offline " & """" & TextBox10.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T75 = "findstr /s /i /m /o /offline " & """" & TextBox10.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T76 = "findstr /s /i /m /o /offline " & """" & TextBox10.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T77 = "findstr /s /i /m /o /offline " & """" & TextBox10.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T78 = "findstr /s /i /m /o /offline " & """" & TextBox10.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T79 = "findstr /s /i /m /o /offline " & """" & TextBox10.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T80 = "findstr /s /i /m /o /offline " & """" & TextBox10.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox11.TextLength > 0 Then
            T81 = "findstr /s /i /m /o /offline " & """" & TextBox11.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T82 = "findstr /s /i /m /o /offline " & """" & TextBox11.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T83 = "findstr /s /i /m /o /offline " & """" & TextBox11.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T84 = "findstr /s /i /m /o /offline " & """" & TextBox11.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T85 = "findstr /s /i /m /o /offline " & """" & TextBox11.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T86 = "findstr /s /i /m /o /offline " & """" & TextBox11.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T87 = "findstr /s /i /m /o /offline " & """" & TextBox11.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T88 = "findstr /s /i /m /o /offline " & """" & TextBox11.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox12.TextLength > 0 Then
            T89 = "findstr /s /i /m /o /offline " & """" & TextBox12.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T90 = "findstr /s /i /m /o /offline " & """" & TextBox12.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T91 = "findstr /s /i /m /o /offline " & """" & TextBox12.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T92 = "findstr /s /i /m /o /offline " & """" & TextBox12.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T93 = "findstr /s /i /m /o /offline " & """" & TextBox12.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T94 = "findstr /s /i /m /o /offline " & """" & TextBox12.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T95 = "findstr /s /i /m /o /offline " & """" & TextBox12.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T96 = "findstr /s /i /m /o /offline " & """" & TextBox12.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox13.TextLength > 0 Then
            T97 = "findstr /s /i /m /o /offline " & """" & TextBox13.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T98 = "findstr /s /i /m /o /offline " & """" & TextBox13.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T99 = "findstr /s /i /m /o /offline " & """" & TextBox13.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T100 = "findstr /s /i /m /o /offline " & """" & TextBox13.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T101 = "findstr /s /i /m /o /offline " & """" & TextBox13.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T102 = "findstr /s /i /m /o /offline " & """" & TextBox13.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T103 = "findstr /s /i /m /o /offline " & """" & TextBox13.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T104 = "findstr /s /i /m /o /offline " & """" & TextBox13.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox14.TextLength > 0 Then
            T105 = "findstr /s /i /m /o /offline " & """" & TextBox14.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T106 = "findstr /s /i /m /o /offline " & """" & TextBox14.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T107 = "findstr /s /i /m /o /offline " & """" & TextBox14.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T108 = "findstr /s /i /m /o /offline " & """" & TextBox14.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T109 = "findstr /s /i /m /o /offline " & """" & TextBox14.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T110 = "findstr /s /i /m /o /offline " & """" & TextBox14.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T111 = "findstr /s /i /m /o /offline " & """" & TextBox14.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T112 = "findstr /s /i /m /o /offline " & """" & TextBox14.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox15.TextLength > 0 Then
            T113 = "findstr /s /i /m /o /offline " & """" & TextBox15.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T114 = "findstr /s /i /m /o /offline " & """" & TextBox15.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T115 = "findstr /s /i /m /o /offline " & """" & TextBox15.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T116 = "findstr /s /i /m /o /offline " & """" & TextBox15.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T117 = "findstr /s /i /m /o /offline " & """" & TextBox15.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T118 = "findstr /s /i /m /o /offline " & """" & TextBox15.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T119 = "findstr /s /i /m /o /offline " & """" & TextBox15.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T120 = "findstr /s /i /m /o /offline " & """" & TextBox15.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox16.TextLength > 0 Then
            T121 = "findstr /s /i /m /o /offline " & """" & TextBox16.Text & """" & " ""%USERPROFILE%\AppData\Local\Mozilla\*.*"""
            T122 = "findstr /s /i /m /o /offline " & """" & TextBox16.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Mozilla\*.*"""
            T123 = "findstr /s /i /m /o /offline " & """" & TextBox16.Text & """" & " ""%USERPROFILE%\AppData\Local\Microsoft\*.*"""
            T124 = "findstr /s /i /m /o /offline " & """" & TextBox16.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Microsoft\*.*"""
            T125 = "findstr /s /i /m /o /offline " & """" & TextBox16.Text & """" & " ""%USERPROFILE%\AppData\Local\Opera Software\*.*"""
            T126 = "findstr /s /i /m /o /offline " & """" & TextBox16.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Opera Software\*.*"""
            T127 = "findstr /s /i /m /o /offline " & """" & TextBox16.Text & """" & " ""%USERPROFILE%\AppData\Local\Google\*.*"""
            T128 = "findstr /s /i /m /o /offline " & """" & TextBox16.Text & """" & " ""%USERPROFILE%\AppData\Roaming\Google\*.*"""

        End If

        If TextBox17.TextLength > 0 Then
            T129 = "dir /s /b %%d:\" & """" & TextBox17.Text & """"
        End If

        If TextBox18.TextLength > 0 Then

            T130 = "dir /s /b %%d:\" & """" & TextBox18.Text & """"
        End If

        If TextBox19.TextLength > 0 Then
            T131 = "dir /s /b %%d:\" & """" & TextBox19.Text & """"
        End If

        If TextBox20.TextLength > 0 Then
            T132 = "dir /s /b %%d:\" & """" & TextBox20.Text & """"
        End If

        If TextBox21.TextLength > 0 Then
            T133 = "dir /s /b %%d:\" & """" & TextBox21.Text & """"
        End If

        If TextBox22.TextLength > 0 Then
            T134 = "dir /s /b %%d:\" & """" & TextBox22.Text & """"
        End If

        If TextBox23.TextLength > 0 Then
            T135 = "dir /s /b %%d:\" & """" & TextBox23.Text & """"
        End If

        If TextBox24.TextLength > 0 Then
            T136 = "dir /s /b %%d:\" & """" & TextBox24.Text & """"
        End If




        System.IO.File.Delete(Pfad)
        Dim rich As String = RichTextBox1.Text


        Dim enc As Text.Encoding = System.Text.Encoding.GetEncoding(1252) '1252 = ANSI

        Dim file As New StreamWriter(Pfad, True, enc)

        file.Write(rich)

        file.WriteLine(T129)
        file.WriteLine(T130)
        file.WriteLine(T131)
        file.WriteLine(T132)
        file.WriteLine(T133)
        file.WriteLine(T134)
        file.WriteLine(T135)
        file.WriteLine(T136)
        file.WriteLine(")")
        file.WriteLine("echo ./. Desktop-Wallets search finished")
        file.WriteLine("echo\")
        file.WriteLine("echo ###############################################################################################")
        file.WriteLine("echo Online-Wallets")
        file.WriteLine("echo ###############################################################################################")
        file.WriteLine("echo\")
        file.WriteLine(T1)
        file.WriteLine(T2)
        file.WriteLine(T3)
        file.WriteLine(T4)
        file.WriteLine(T5)
        file.WriteLine(T6)
        file.WriteLine(T7)
        file.WriteLine(T8)
        file.WriteLine(T9)
        file.WriteLine(T10)
        file.WriteLine(T11)
        file.WriteLine(T12)
        file.WriteLine(T13)
        file.WriteLine(T14)
        file.WriteLine(T15)
        file.WriteLine(T16)
        file.WriteLine(T17)
        file.WriteLine(T18)
        file.WriteLine(T19)
        file.WriteLine(T20)
        file.WriteLine(T21)
        file.WriteLine(T22)
        file.WriteLine(T23)
        file.WriteLine(T24)
        file.WriteLine(T25)
        file.WriteLine(T26)
        file.WriteLine(T27)
        file.WriteLine(T28)
        file.WriteLine(T29)
        file.WriteLine(T30)
        file.WriteLine(T31)
        file.WriteLine(T32)
        file.WriteLine(T33)
        file.WriteLine(T34)
        file.WriteLine(T35)
        file.WriteLine(T36)
        file.WriteLine(T37)
        file.WriteLine(T38)
        file.WriteLine(T39)
        file.WriteLine(T40)
        file.WriteLine(T41)
        file.WriteLine(T42)
        file.WriteLine(T43)
        file.WriteLine(T44)
        file.WriteLine(T45)
        file.WriteLine(T46)
        file.WriteLine(T47)
        file.WriteLine(T48)
        file.WriteLine(T49)
        file.WriteLine(T50)
        file.WriteLine(T51)
        file.WriteLine(T52)
        file.WriteLine(T53)
        file.WriteLine(T54)
        file.WriteLine(T55)
        file.WriteLine(T56)
        file.WriteLine(T57)
        file.WriteLine(T58)
        file.WriteLine(T59)
        file.WriteLine(T60)
        file.WriteLine(T61)
        file.WriteLine(T62)
        file.WriteLine(T63)
        file.WriteLine(T64)
        file.WriteLine("echo ./. Online-Wallets search finished")
        file.WriteLine("echo\")
        file.WriteLine("echo ###############################################################################################")
        file.WriteLine("echo Hardware-Wallets")
        file.WriteLine("echo ###############################################################################################")
        file.WriteLine("echo\")
        file.WriteLine(T65)
        file.WriteLine(T66)
        file.WriteLine(T67)
        file.WriteLine(T68)
        file.WriteLine(T69)
        file.WriteLine(T70)
        file.WriteLine(T71)
        file.WriteLine(T72)
        file.WriteLine(T73)
        file.WriteLine(T74)
        file.WriteLine(T75)
        file.WriteLine(T76)
        file.WriteLine(T77)
        file.WriteLine(T78)
        file.WriteLine(T79)
        file.WriteLine(T80)
        file.WriteLine(T81)
        file.WriteLine(T82)
        file.WriteLine(T83)
        file.WriteLine(T84)
        file.WriteLine(T85)
        file.WriteLine(T86)
        file.WriteLine(T87)
        file.WriteLine(T88)
        file.WriteLine(T89)
        file.WriteLine(T90)
        file.WriteLine(T91)
        file.WriteLine(T92)
        file.WriteLine(T93)
        file.WriteLine(T94)
        file.WriteLine(T95)
        file.WriteLine(T96)
        file.WriteLine(T97)
        file.WriteLine(T98)
        file.WriteLine(T99)
        file.WriteLine(T100)
        file.WriteLine(T101)
        file.WriteLine(T102)
        file.WriteLine(T103)
        file.WriteLine(T104)
        file.WriteLine(T105)
        file.WriteLine(T106)
        file.WriteLine(T107)
        file.WriteLine(T108)
        file.WriteLine(T109)
        file.WriteLine(T110)
        file.WriteLine(T111)
        file.WriteLine(T112)
        file.WriteLine(T113)
        file.WriteLine(T114)
        file.WriteLine(T115)
        file.WriteLine(T116)
        file.WriteLine(T117)
        file.WriteLine(T118)
        file.WriteLine(T119)
        file.WriteLine(T120)
        file.WriteLine(T121)
        file.WriteLine(T122)
        file.WriteLine(T123)
        file.WriteLine(T124)
        file.WriteLine(T125)
        file.WriteLine(T126)
        file.WriteLine(T127)
        file.WriteLine(T128)


        file.WriteLine("echo ./. Hardware-Wallets search finished")
        file.WriteLine("echo\")
        file.WriteLine("echo\")
        file.WriteLine("echo ###############################################################################################")
        file.WriteLine("echo Hashbull-Scan finish ...")
        file.WriteLine("echo ###############################################################################################")
        file.WriteLine("echo\")
        file.WriteLine("@ping -n 2 localhost> nul")
        file.WriteLine("exit")
        file.Close()



        My.Settings.Scanner1 = TextBox1.Text
        My.Settings.Scanner2 = TextBox2.Text
        My.Settings.Scanner3 = TextBox3.Text
        My.Settings.Scanner4 = TextBox4.Text
        My.Settings.Scanner5 = TextBox5.Text
        My.Settings.Scanner6 = TextBox6.Text
        My.Settings.Scanner7 = TextBox7.Text
        My.Settings.Scanner8 = TextBox8.Text
        My.Settings.Scanner9 = TextBox9.Text
        My.Settings.Scanner10 = TextBox10.Text
        My.Settings.Scanner11 = TextBox11.Text
        My.Settings.Scanner12 = TextBox12.Text
        My.Settings.Scanner13 = TextBox13.Text
        My.Settings.Scanner14 = TextBox14.Text
        My.Settings.Scanner15 = TextBox15.Text
        My.Settings.Scanner16 = TextBox16.Text
        My.Settings.Scanner17 = TextBox17.Text
        My.Settings.Scanner18 = TextBox18.Text
        My.Settings.Scanner19 = TextBox19.Text
        My.Settings.Scanner20 = TextBox20.Text
        My.Settings.Scanner21 = TextBox21.Text
        My.Settings.Scanner22 = TextBox22.Text
        My.Settings.Scanner23 = TextBox23.Text
        My.Settings.Scanner24 = TextBox24.Text

        My.Settings.Save()
        My.Settings.Reload()

        Me.Close()

    End Sub

    Private Sub ScennerSettings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Welcome.Opacity = 100

    End Sub
End Class