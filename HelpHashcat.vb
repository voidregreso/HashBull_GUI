Public Class HelpHashcat





    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        My.Settings.CheckHelp1 = CheckBox1.Checked

        My.Settings.Save()
        My.Settings.Reload()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '#### Help Button

        Process.Start("https://hashcat.net/faq/wrongdriver")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles Me.Load

        If My.Settings.Eng = False Then TextBox1.Text = "Hashcat -Einstellungen" & vbNewLine & vbNewLine &
        "Wenn Sie Hashcat zum ersten Mal starten können Fehler auftreten, wenn nicht die richtigen Treiber" & vbNewLine &
        "für die CPU und GPU installiert sind. Wenn Sie die folgende Nachricht erhalten: " & vbNewLine & vbNewLine &
        "ATTENTION! No OpenCL or CUDA installation found. You are probably missing the CUDA or OpenCL runtime installation." & vbNewLine & vbNewLine &
        "dann installieren Sie bitte folgende Treiber:" & vbNewLine & vbNewLine &
        "AMD-GPUs unter Windows benötigen diese Treiber:" & vbNewLine &
        "AMD Radeon Adrenalin 2020 Edition (20.2.2 oder höher)" & vbNewLine & vbNewLine &
        "Intel-CPUs benötigen diese Treiber:" & vbNewLine &
        "OpenCL Runtime für Intel Core- und Intel Xeon-Prozessoren (16.1.1 oder höher)" & vbNewLine & vbNewLine &
        "NVIDIA-GPUs erfordern diese Treiber (beide):" & vbNewLine &
        "NVIDIA-Treiber (440,64 oder höher)" & vbNewLine &
        "CUDA Toolkit (9.0 oder höher)" & vbNewLine & vbNewLine &
        "Weitere Informationen unter: https://hashcat.net/faq/wrongdriver"

        If My.Settings.Eng = False Then CheckBox1.Text = "Nicht mehr anzeigen"



    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class