Public Class frmAuth

    Private dp As DropNet.DropNetClient
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' You need to have these two ressources configured. They are not checked in with GIT.
        dp = New DropNet.DropNetClient(My.Resources.DropBoxAPIKEy, My.Resources.DropBoxAPISecret)
        lbl.Text = "Tokens are stored at: " & TokenStore.getInstance().ToString
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    dp.GetToken()
    '    Dim url As String = dp.BuildAuthorizeUrl
    '    tburl.Text = url
    'End Sub
    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    Dim Token As DropNet.Models.UserLogin = dp.GetAccessToken
    '    tbtoken.Text = Token.Token
    '    tbsecrret.Text = Token.Secret
    'End Sub
    'Private Sub btnSaveToken_Click(sender As Object, e As EventArgs) Handles btnSaveToken.Click
    '    Dim K As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\WriterCloudTexts")

    '    Dim Crypt As New XMLConfigbase.Encrypt()
    '    If XMLConfigbase.Encrypt.EncryptionSupportAvailable = False Then
    '        MsgBox("You do not have encryption support available on your Windows account. Make sure you own a certificate and have it accessible! I will store my tokens internally unencrypted now.")
    '        K.SetValue("unencrypted", "1")
    '        K.SetValue("T", tbtoken.Text)
    '        K.SetValue("S", tbsecrret.Text)
    '    Else
    '        K.SetValue("T", Crypt.Encrypt(tbtoken.Text))
    '        K.SetValue("S", Crypt.Encrypt(tbsecrret.Text))
    '        Try
    '            K.DeleteValue("unencrypted")
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    Private Sub btnStep1BrowseAuthRequest_Click(sender As Object, e As EventArgs) Handles btnStep1BrowseAuthRequest.Click
        dp.GetToken()
        Dim url As String = dp.BuildAuthorizeUrl
        Try
            Dim sip As New ProcessStartInfo(url)
            sip.UseShellExecute = True
            Process.Start(sip)
        Catch ex As Exception
            Clipboard.SetText(url)
            MsgBox("Unable to launch the URL. I copied it to te clipboard. Please open a browser and paste the URL!")
        End Try
    End Sub

   
    Private Sub btnStep2Assoc_Click(sender As Object, e As EventArgs) Handles btnStep2Assoc.Click
        Dim Token As DropNet.Models.UserLogin = dp.GetAccessToken
        '    tbtoken.Text = Token.Token
        '    tbsecrret.Text = Token.Secret
        TokenStore.getInstance().Save(Token.Token, Token.Secret)
        MsgBox("Account associated.")
        Me.Hide()
        Me.Dispose()
    End Sub


    Public Class TokenStore
        Inherits XMLConfigbase

        <XMLConfigbase.Encrypt()> Public Token As String
        <XMLConfigbase.Encrypt()> Public Secret As String

        Private Sub New()
            MyBase.New(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WriterCloudTexts.token"), False)
            'MyBase.New(False, True)
        End Sub

        Public Sub Save(Token As String, Secret As String)
            If XMLConfigbase.Encrypt.EncryptionSupportAvailable = False Then MsgBox("You do not have encryption support available on your Windows account. Make sure you own a certificate and have it accessible! I will store my tokens internally unencrypted now.")
            Me.Token = Token
            Me.Secret = Secret
            Me.SaveConfiguration()
        End Sub

        Protected Overrides Sub Defaults()
        End Sub

        Protected Shared _inst As TokenStore
        Public Shared Function getInstance() As TokenStore
            If _inst Is Nothing Then _inst = New TokenStore
            Return _inst
        End Function
    End Class
End Class
