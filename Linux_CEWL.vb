Public Class Linux_CEWL
    Private Sub Linux_CEWL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.Eng = False Then

            Button1.Text = "Linux aktivieren"
            Button2.Text = "zurück"
            Label1.Text = "Nun können Sie CeWL installieren. Drücken Sie den Button:"
            Label7.Text = "1) Updaten Sie Windows 10 auf den neuesten Stand." & vbNewLine &
                          "2) Gehen Sie in den Windows Store und installieren Sie ""Ubuntu 20.04 LTS"". Es ist kostenlos." & vbNewLine &
                          "3) Jetzt müssen Sie Linux noch aktivieren. Drücken Sie den Button." & vbNewLine &
                          "4) Im Windows-Menü unter ""Start"" finden Sie nun den Eintrag Ubuntu 20.04." & vbNewLine &
                          "5) Starten Sie Ubuntu 20.04 und vergeben Sie einen Username und Passwort."


        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim process As New Process()
        process.StartInfo.FileName = "powershell.exe"
        process.StartInfo.Verb = "runas"
        'process.StartInfo.WorkingDirectory = "c:\windows\system32"
        'process.StartInfo.Arguments = ("-noexit dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart")
        process.StartInfo.Arguments = ("-noexit Enable-WindowsOptionalFeature -O -F  Microsoft-Windows-Subsystem-Linux")
        process.Start()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        '### Bash Datei schreiben // das Clone Verzeichnis existiert bereits


        Dim Command As String = "#!/bin/bash" & vbNewLine & "sudo -s apt-get update && sudo apt-get install cewl libcurl4-gnutls-dev libxml2 libxml2-dev libxslt1-dev ruby-dev"
        Dim Datei As String = Application.StartupPath + "/Packages/CEWL/cewl.sh"

        System.IO.File.WriteAllText(Datei, Command)

        '### Bash starten mit Root Rechten

        Dim process As New Process()
        process.StartInfo.FileName = "cmd.exe"
        process.StartInfo.WorkingDirectory = Application.StartupPath & "/Packages/CEWL/"
        process.StartInfo.Arguments = ("/k ubuntu2004.exe run sudo -s bash cewl.sh")
        process.Start()



    End Sub
End Class
