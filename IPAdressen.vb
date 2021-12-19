Imports System.Net

Public Class IPAdressen



    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        Try

            '### IP slektieren und in SystemIP.text schreiben

            Settings.ServerIP.Text = Me.ListBox1.SelectedItem
            Me.Close()

        Catch ex As Exception

        End Try

    End Sub

    <Obsolete>
    Private Sub IPAdressen_Load(sender As Object, e As EventArgs) Handles Me.Load

        If My.Settings.Eng = False Then Label1.Text = "Bitte wählen Sie eine IP-Adresse mit einem Doppelklick aus:"

        Try

            '### IP-Adressen in Listbox1 aufführen

            Dim Addresslist() As IPAddress =
          Dns.GetHostByName(Dns.GetHostName()).AddressList
        Dim IPs As IPAddress

        ' alle IP-Adressen auflisten
        ListBox1.Items.Clear()

            For Each IPs In Addresslist
                ListBox1.Items.Add(IPs.ToString)
            Next IPs


        Catch ex As Exception

        End Try


    End Sub



End Class