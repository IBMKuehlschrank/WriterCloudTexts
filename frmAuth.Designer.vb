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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuth))
        Me.btnStep2Assoc = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnStep1BrowseAuthRequest = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnStep2Assoc
        '
        Me.btnStep2Assoc.Location = New System.Drawing.Point(15, 283)
        Me.btnStep2Assoc.Name = "btnStep2Assoc"
        Me.btnStep2Assoc.Size = New System.Drawing.Size(457, 46)
        Me.btnStep2Assoc.TabIndex = 2
        Me.btnStep2Assoc.Text = "Associate account and store the token"
        Me.btnStep2Assoc.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoEllipsis = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(511, 104)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = resources.GetString("Label6.Text")
        '
        'btnStep1BrowseAuthRequest
        '
        Me.btnStep1BrowseAuthRequest.Location = New System.Drawing.Point(15, 116)
        Me.btnStep1BrowseAuthRequest.Name = "btnStep1BrowseAuthRequest"
        Me.btnStep1BrowseAuthRequest.Size = New System.Drawing.Size(457, 38)
        Me.btnStep1BrowseAuthRequest.TabIndex = 10
        Me.btnStep1BrowseAuthRequest.Text = "Open browser with DropBox authentication request"
        Me.btnStep1BrowseAuthRequest.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoEllipsis = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(511, 104)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = resources.GetString("Label7.Text")
        '
        'lbl
        '
        Me.lbl.AutoEllipsis = True
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.Location = New System.Drawing.Point(12, 351)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(499, 23)
        Me.lbl.TabIndex = 11
        '
        'frmAuth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 378)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.btnStep1BrowseAuthRequest)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnStep2Assoc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAuth"
        Me.Text = "Authenticate account"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStep2Assoc As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnStep1BrowseAuthRequest As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label

End Class
