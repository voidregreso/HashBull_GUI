Imports System.IO
Public Class FileScannerSettings

    Public Drives1 As String
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then TextBox1.ReadOnly = True
        If CheckBox1.Checked = False Then TextBox1.ReadOnly = False

        If CheckBox1.Checked = False Then
            If My.Settings.Eng = False Then MsgBox("Bitte geben Sie die Laufwerksbuchstaben getrennt mit Leerzeichen ein. Nicht vorhandene Laufwerksbuchstaben werden automatisch übersprungen.")
            If My.Settings.Eng = True Then MsgBox("Please enter the drive letters separated by spaces. Drive letters that do not exist are automatically skipped.")
        End If

    End Sub

    Private Sub FileScannerSettings_Load(sender As Object, e As EventArgs) Handles Me.Load

        CheckBox1.Checked = True

        TextBox1.Text = My.Settings.EFSDrives
        TextBox2.Text = My.Settings.CopyFolder

        CheckBox2.Checked = My.Settings.EFS2
        CheckBox3.Checked = My.Settings.EFS3
        CheckBox4.Checked = My.Settings.EFS4
        CheckBox5.Checked = My.Settings.EFS5
        CheckBox6.Checked = My.Settings.EFS6
        CheckBox7.Checked = My.Settings.EFS7

        If TextBox1.TextLength = 0 Then TextBox1.Text = "C D E F G H I J K L M N O P Q R S T U V W X Y Z"
        If TextBox2.TextLength = 0 Then TextBox2.Text = Application.StartupPath & "\Hashbull_Scanner\Copy_Folder"

        If My.Settings.Eng = False Then
            Label1.Text = "Laufwerke:"
            Label2.Text = "Datei-Formate:"
            SaveSettings.Text = "Speichern"
            Button2.Text = "Werkseinstellungen"
            Button3.Text = "Abbrechen"
            Label3.Text = "Kopierordner:"
            Button1.Text = "Öffnen"



        End If




    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles SaveSettings.Click

        My.Settings.EFSDrives = TextBox1.Text
        My.Settings.CopyFolder = TextBox2.Text

        My.Settings.EFS2 = CheckBox2.Checked
        My.Settings.EFS3 = CheckBox3.Checked
        My.Settings.EFS4 = CheckBox4.Checked
        My.Settings.EFS5 = CheckBox5.Checked
        My.Settings.EFS6 = CheckBox6.Checked
        My.Settings.EFS7 = CheckBox7.Checked

        My.Settings.Save()
        My.Settings.Reload()

        Me.Close()





    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.Text = "C D E F G H I J K L M N O P Q R S T U V W X Y Z"
        TextBox2.Text = Application.StartupPath & "\Hashbull_Scanner\Copy_Folder"

        CheckBox2.Checked = True
        CheckBox3.Checked = True
        CheckBox4.Checked = True
        CheckBox5.Checked = True
        CheckBox6.Checked = True
        CheckBox7.Checked = True


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        '#### Copy Folder 

        Using f As New FolderBrowserDialog()
            If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim d As New System.IO.DirectoryInfo(f.SelectedPath)
                TextBox2.Text = f.SelectedPath
            End If
        End Using

    End Sub
End Class