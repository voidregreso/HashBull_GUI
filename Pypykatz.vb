Public Class Form1





    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Welcome.Opacity = 100

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim process As New Process()
        Process.Start("https://ppk.thu.gg/")

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        If My.Settings.Eng = False Then Label1.Text =
        "Windows-Benutzerkennwörter werden unter Windows" & vbNewLine &
        "in den Dateien SYSTEM und SAM gespeichert:" & vbNewLine & vbNewLine &
        "C: / Windows / System32 / config / SAM" & vbNewLine &
        "C: / Windows / System32 / config / SYSTEM" & vbNewLine & vbNewLine &
        "Starten Sie den Windows-Computer mit einer Linux-Distribution (z. B. Paladin, Kali oder Caine)" & vbNewLine &
        "und speichern die beiden o.a. Dateien auf einen USB-Stick. Anschließend können Sie die" & vbNewLine &
        "u.a. Internetseite starten. Alternativ können Sie auch Mimikatz oder Pypykatz verwenden." & vbNewLine & vbNewLine &
        "Wählen Sie die entsprechenden SAM- und SYSTEM-Dateien unter dem Reiter ""Registry Inputs""" & vbNewLine &
        "aus. Dann drücken Sie bitte ""Parse"" > ""Expand All"" > und den Pfeil neben ""local_users""." & vbNewLine &
        "Kopieren Sie alle Hashes neben den Einträgen zu ""nt_hash"" in eine Hash.txt." & vbNewLine &
        "Hashes die mit ""31d6cfe0d16 ..."" beginnen müssen Sie nicht kopieren, da es sich hierbei um" & vbNewLine &
        "leere Passwörter handelt. Der Hashcat-Typ-Mode ist 1000."

        If My.Settings.Eng = False Then Button1.Text = "Internetseite öffnen"

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class