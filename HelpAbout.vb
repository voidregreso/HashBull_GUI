Public Class HelpAbout
    Private Sub Form9_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Welcome.Activate()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        '#### Logo Button

        Process.Start("https://www.hashbull.net")

    End Sub


End Class