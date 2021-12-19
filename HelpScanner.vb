Public Class HelpScanner

    Private Sub HelpScanner_Load(sender As Object, e As EventArgs) Handles Me.Load

        '### Sprache laden
        If My.Settings.Eng = False Then RichTextBox2.Visible = False
        If My.Settings.Eng = True Then RichTextBox1.Visible = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub RichTextBox2_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox2.TextChanged

    End Sub
End Class