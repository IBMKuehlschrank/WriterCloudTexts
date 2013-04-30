Public Class frmAuth

    Private dp As DropNet.DropNetClient

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dp = New DropNet.DropNetClient("udtp4214kkbj26t", "o4lzkxuj1i0vzxx")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dp.GetToken()
        Dim url As String = dp.BuildAuthorizeUrl
        tburl.Text = url
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Token As DropNet.Models.UserLogin = dp.GetAccessToken
        tbtoken.Text = Token.Token
        tbsecrret.Text = Token.Secret
    End Sub


    Private Sub btnSaveToken_Click(sender As Object, e As EventArgs) Handles btnSaveToken.Click
        Dim K As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\WriterCloudTexts")

        Dim Crypt As New XMLConfigbase.Encrypt()
        If XMLConfigbase.Encrypt.EncryptionSupportAvailable = False Then
            MsgBox("You do not have encryption support available on your Windows account. Make sure you own a certificate and have it accessible! I will store my tokens internally unencrypted now.")
            K.SetValue("unencrypted", "1")
            K.SetValue("T", tbtoken.Text)
            K.SetValue("S", tbsecrret.Text)
        Else
            K.SetValue("T", Crypt.Encrypt(tbtoken.Text))
            K.SetValue("S", Crypt.Encrypt(tbsecrret.Text))
            Try
                K.DeleteValue("unencrypted")
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
