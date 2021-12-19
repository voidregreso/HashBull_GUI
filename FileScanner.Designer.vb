<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileScanner
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileScanner))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ScannerCrackBtn = New System.Windows.Forms.Button()
        Me.ScannerStopBtn = New System.Windows.Forms.Button()
        Me.StartKryptoBtn = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.EndeSub = New System.Windows.Forms.Label()
        Me.Sieben = New System.Windows.Forms.Label()
        Me.RAR = New System.Windows.Forms.Label()
        Me.zip = New System.Windows.Forms.Label()
        Me.XLS = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DOC = New System.Windows.Forms.Label()
        Me.PDF = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(961, 165)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(94, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ScannerCrackBtn
        '
        Me.ScannerCrackBtn.Location = New System.Drawing.Point(952, 74)
        Me.ScannerCrackBtn.Name = "ScannerCrackBtn"
        Me.ScannerCrackBtn.Size = New System.Drawing.Size(112, 25)
        Me.ScannerCrackBtn.TabIndex = 3
        Me.ScannerCrackBtn.Text = "Crack"
        Me.ScannerCrackBtn.UseVisualStyleBackColor = True
        '
        'ScannerStopBtn
        '
        Me.ScannerStopBtn.Enabled = False
        Me.ScannerStopBtn.Location = New System.Drawing.Point(952, 43)
        Me.ScannerStopBtn.Name = "ScannerStopBtn"
        Me.ScannerStopBtn.Size = New System.Drawing.Size(112, 25)
        Me.ScannerStopBtn.TabIndex = 2
        Me.ScannerStopBtn.Text = "Stop"
        Me.ScannerStopBtn.UseVisualStyleBackColor = True
        '
        'StartKryptoBtn
        '
        Me.StartKryptoBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartKryptoBtn.Location = New System.Drawing.Point(952, 12)
        Me.StartKryptoBtn.Name = "StartKryptoBtn"
        Me.StartKryptoBtn.Size = New System.Drawing.Size(112, 25)
        Me.StartKryptoBtn.TabIndex = 1
        Me.StartKryptoBtn.Text = "START"
        Me.StartKryptoBtn.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.InfoText
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Chartreuse
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(1101, 584)
        Me.ListBox1.TabIndex = 10
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 552)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(218, 20)
        Me.TextBox1.TabIndex = 16
        Me.TextBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(952, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 25)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Settings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'EndeSub
        '
        Me.EndeSub.AutoSize = True
        Me.EndeSub.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.EndeSub.Location = New System.Drawing.Point(1033, 344)
        Me.EndeSub.Name = "EndeSub"
        Me.EndeSub.Size = New System.Drawing.Size(22, 52)
        Me.EndeSub.TabIndex = 32
        Me.EndeSub.Text = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    )" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ")" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.EndeSub.Visible = False
        '
        'Sieben
        '
        Me.Sieben.AutoSize = True
        Me.Sieben.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Sieben.Location = New System.Drawing.Point(684, 424)
        Me.Sieben.Name = "Sieben"
        Me.Sieben.Size = New System.Drawing.Size(699, 117)
        Me.Sieben.TabIndex = 31
        Me.Sieben.Text = resources.GetString("Sieben.Text")
        Me.Sieben.Visible = False
        '
        'RAR
        '
        Me.RAR.AutoSize = True
        Me.RAR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RAR.Location = New System.Drawing.Point(684, 424)
        Me.RAR.Name = "RAR"
        Me.RAR.Size = New System.Drawing.Size(699, 130)
        Me.RAR.TabIndex = 30
        Me.RAR.Text = resources.GetString("RAR.Text")
        Me.RAR.Visible = False
        '
        'zip
        '
        Me.zip.AutoSize = True
        Me.zip.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.zip.Location = New System.Drawing.Point(716, 437)
        Me.zip.Name = "zip"
        Me.zip.Size = New System.Drawing.Size(699, 117)
        Me.zip.TabIndex = 29
        Me.zip.Text = resources.GetString("zip.Text")
        Me.zip.Visible = False
        '
        'XLS
        '
        Me.XLS.AutoSize = True
        Me.XLS.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.XLS.Location = New System.Drawing.Point(740, 411)
        Me.XLS.Name = "XLS"
        Me.XLS.Size = New System.Drawing.Size(699, 143)
        Me.XLS.TabIndex = 28
        Me.XLS.Text = resources.GetString("XLS.Text")
        Me.XLS.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(684, 437)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(699, 117)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = resources.GetString("Label6.Text")
        Me.Label6.Visible = False
        '
        'DOC
        '
        Me.DOC.AutoSize = True
        Me.DOC.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.DOC.Location = New System.Drawing.Point(694, 424)
        Me.DOC.Name = "DOC"
        Me.DOC.Size = New System.Drawing.Size(699, 130)
        Me.DOC.TabIndex = 26
        Me.DOC.Text = resources.GetString("DOC.Text")
        Me.DOC.Visible = False
        '
        'PDF
        '
        Me.PDF.AutoSize = True
        Me.PDF.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.PDF.Location = New System.Drawing.Point(810, 437)
        Me.PDF.Name = "PDF"
        Me.PDF.Size = New System.Drawing.Size(699, 117)
        Me.PDF.TabIndex = 25
        Me.PDF.Text = resources.GetString("PDF.Text")
        Me.PDF.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(924, 370)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 26)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "@echo off" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(952, 105)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 23)
        Me.Button2.TabIndex = 33
        Me.Button2.Text = "Copy hits"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FileScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1101, 584)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.EndeSub)
        Me.Controls.Add(Me.Sieben)
        Me.Controls.Add(Me.RAR)
        Me.Controls.Add(Me.zip)
        Me.Controls.Add(Me.XLS)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DOC)
        Me.Controls.Add(Me.PDF)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ScannerCrackBtn)
        Me.Controls.Add(Me.ScannerStopBtn)
        Me.Controls.Add(Me.StartKryptoBtn)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FileScanner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Encrypted-File-Scanner"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ScannerCrackBtn As Button
    Friend WithEvents ScannerStopBtn As Button
    Friend WithEvents StartKryptoBtn As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents EndeSub As Label
    Friend WithEvents Sieben As Label
    Friend WithEvents RAR As Label
    Friend WithEvents zip As Label
    Friend WithEvents XLS As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DOC As Label
    Friend WithEvents PDF As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
End Class
