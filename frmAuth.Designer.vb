<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuth
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tburl = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbtoken = New System.Windows.Forms.TextBox()
        Me.tbsecrret = New System.Windows.Forms.TextBox()
        Me.btnSaveToken = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(17, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(230, 38)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "(1) Get URL"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tburl
        '
        Me.tburl.Location = New System.Drawing.Point(20, 70)
        Me.tburl.Name = "tburl"
        Me.tburl.Size = New System.Drawing.Size(250, 22)
        Me.tburl.TabIndex = 1
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(20, 170)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(227, 46)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "(2) Get the account access token"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 72)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Launch URL in browser, login and authorize the App to your account. Then click th" & _
    "e next button"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(22, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(225, 55)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Now the following can be used to login with this App to your account:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 287)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Token:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 312)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Secret:"
        '
        'tbtoken
        '
        Me.tbtoken.Location = New System.Drawing.Point(80, 284)
        Me.tbtoken.Name = "tbtoken"
        Me.tbtoken.Size = New System.Drawing.Size(166, 22)
        Me.tbtoken.TabIndex = 6
        '
        'tbsecrret
        '
        Me.tbsecrret.Location = New System.Drawing.Point(81, 309)
        Me.tbsecrret.Name = "tbsecrret"
        Me.tbsecrret.Size = New System.Drawing.Size(166, 22)
        Me.tbsecrret.TabIndex = 6
        '
        'btnSaveToken
        '
        Me.btnSaveToken.Location = New System.Drawing.Point(20, 385)
        Me.btnSaveToken.Name = "btnSaveToken"
        Me.btnSaveToken.Size = New System.Drawing.Size(226, 33)
        Me.btnSaveToken.TabIndex = 7
        Me.btnSaveToken.Text = "(3) Save Token"
        Me.btnSaveToken.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(22, 344)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(248, 34)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Click save to store them (encrypted) on your PC."
        '
        'frmAuth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 435)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnSaveToken)
        Me.Controls.Add(Me.tbsecrret)
        Me.Controls.Add(Me.tbtoken)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.tburl)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmAuth"
        Me.Text = "Authenticate account"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tburl As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbtoken As System.Windows.Forms.TextBox
    Friend WithEvents tbsecrret As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveToken As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
