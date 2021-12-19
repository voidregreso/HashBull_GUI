Public Class HelpEncoding
    Private Sub HelpEncoding_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.Eng = False Then RichTextBox1.Visible = True
        If My.Settings.Eng = True Then RichTextBox2.Visible = True

    End Sub

    Private Sub RichTextBox2_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox2.TextChanged

    End Sub
End Class