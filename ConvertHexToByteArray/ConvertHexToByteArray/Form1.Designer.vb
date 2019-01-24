<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rtxt1 = New System.Windows.Forms.RichTextBox()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.rtxt2 = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.rtxt3 = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rtxt1
        '
        Me.rtxt1.Location = New System.Drawing.Point(50, 40)
        Me.rtxt1.Name = "rtxt1"
        Me.rtxt1.Size = New System.Drawing.Size(490, 191)
        Me.rtxt1.TabIndex = 0
        Me.rtxt1.Text = ""
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(564, 40)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(183, 23)
        Me.btn1.TabIndex = 1
        Me.btn1.Text = "Convert to RTF Content"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'rtxt2
        '
        Me.rtxt2.Location = New System.Drawing.Point(50, 270)
        Me.rtxt2.Name = "rtxt2"
        Me.rtxt2.Size = New System.Drawing.Size(490, 191)
        Me.rtxt2.TabIndex = 2
        Me.rtxt2.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "HEX String"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "RTF Content"
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(564, 270)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(183, 23)
        Me.btn2.TabIndex = 5
        Me.btn2.Text = "Convert to Hex String"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'rtxt3
        '
        Me.rtxt3.Location = New System.Drawing.Point(50, 513)
        Me.rtxt3.Name = "rtxt3"
        Me.rtxt3.Size = New System.Drawing.Size(490, 191)
        Me.rtxt3.TabIndex = 6
        Me.rtxt3.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 486)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Html Content"
        '
        'btn3
        '
        Me.btn3.Location = New System.Drawing.Point(564, 511)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(183, 23)
        Me.btn3.TabIndex = 8
        Me.btn3.Text = "Convert to Html"
        Me.btn3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 783)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rtxt3)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rtxt2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.rtxt1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rtxt1 As RichTextBox
    Friend WithEvents btn1 As Button
    Friend WithEvents rtxt2 As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btn2 As Button
    Friend WithEvents rtxt3 As RichTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btn3 As Button
End Class
