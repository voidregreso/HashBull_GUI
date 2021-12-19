Public Class Wordlist

    Private Sub Wordlist_Load(sender As Object, e As EventArgs) Handles Me.Load

        If My.Settings.Eng = False Then

            Label1.Text = "Ca. 1,4 Milliarden Passwörter / Größe: 4,3 GB"
            Label2.Text = "Ca. 1.500 Wordlists. Die weltweit größte Sammlung."
            Label3.Text = "Ca. 300 Millionen Passw. in 90 Wordl. / Größe: 5 GB"
            Label5.Text = "Ca. 190 Wordlists aus unterschiedlichen Themengebieten"
            Button1.Text = "Homepage öffnen"
            Button2.Text = "Homepage öffnen"
            Button4.Text = "Homepage öffnen"
            Button5.Text = "Homepage öffnen"


        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Process.Start("https://crackstation.net/crackstation-wordlist-password-cracking-dictionary.htm")

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Process.Start("https://weakpass.com/wordlist")


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Process.Start("https://web.archive.org/web/20120207113205/http://www.insidepro.com/eng/download.shtml")

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        Process.Start("https://packetstormsecurity.com/Crackers/wordlists/")

    End Sub


End Class