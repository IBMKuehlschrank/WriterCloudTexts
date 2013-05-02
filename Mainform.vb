Imports DropNet, DropNet.Models
Public Class Mainform

    Private dp As DropNet.DropNetClient
    Private K As Microsoft.Win32.RegistryKey

    Private Sub tsbConnect_Click(sender As Object, e As EventArgs) Handles tsbConnect.Click
        Mainform_Load(Nothing, Nothing)
    End Sub

    Private Sub Mainform_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'K.SetValue("SplitW", SplitContainer1.Panel1.Width)
        K.SetValue("FormT", Me.Top)
        K.SetValue("FormL", Me.Left)
        K.SetValue("FormH", Me.Height)
        K.SetValue("FormW", Me.Width)
    End Sub

    Private Sub Mainform_Load(sender As Object, e As EventArgs) Handles Me.Load
        Do
            'K = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\WriterCloudTexts", True)
            'Dim Crypt As New XMLConfigbase.Encrypt()
            'frmAuth.TokenStore.getInstance().Save(Crypt.Decrypt(K.GetValue("T")), Crypt.Decrypt(K.GetValue("S")))

            If sender Is Nothing Or (K Is Nothing OrElse K.GetValue("T", Nothing) Is Nothing) Then
                Dim f As New frmAuth()
                f.ShowDialog()
                sender = Me
            Else
                Me.Cursor = Cursors.WaitCursor
                Dim Usertoken As String = frmAuth.TokenStore.getInstance().Token
                Dim UserSec As String = frmAuth.TokenStore.getInstance().Secret
                ' You need to have these two ressources configured. They are not checked in with GIT.
                dp = New DropNet.DropNetClient(My.Resources.DropBoxAPIKEy, My.Resources.DropBoxAPISecret, Usertoken, UserSec)
                tsbRefresh_Click(Nothing, Nothing)
                Me.Cursor = Cursors.Default

                tb.Font = New Font("Calibri", K.GetValue("Fs", tb.Font.Size), tb.Font.Unit)
                lst.View = [Enum].Parse(GetType(Windows.Forms.View), K.GetValue("V", lst.View.ToString))
                'SplitContainer1.Panel1.Width = K.GetValue("SplitW", SplitContainer1.Panel1.Width)
                Me.Top = K.GetValue("FormT", Me.Top)
                Me.Left = K.GetValue("FormL", Me.Left)
                Me.Height = K.GetValue("FormH", Me.Height)
                Me.Width = K.GetValue("FormW", Me.Width)
                Exit Do
            End If
        Loop

    End Sub


    Public Class LI
        Inherits ListViewItem
        Private ReadOnly F As MetaData
        Private Shared Cache As CacheManager

        Public Sub New(File As MetaData)
            MyBase.New(New String() {File.Name, File.ModifiedDate.ToString(), File.Bytes})
            Me.F = File
            Me.ImageKey = "doc"
            If Cache Is Nothing Then Cache = New CacheManager()
        End Sub

        Public Function getText(dp As DropNetClient) As String
            Dim b() As Byte
            If Cache.isCached(F) Then
                b = Cache.GetFileFromCache(F)
            Else
                b = dp.GetFile(DropboxPath)
                Cache.Save2Cache(F, b)
            End If
            Return System.Text.UTF32Encoding.UTF8.GetString(b).Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
        End Function

        Public Sub SaveText(dp As DropNetClient, Text As String)
            Dim b() As Byte = System.Text.UTF32Encoding.UTF8.GetBytes(Text.Replace(vbCrLf, vbLf))
            dp.UploadFile(F.Path.Substring(0, F.Path.Length - F.Name.Length), F.Name, b)
        End Sub

        Public ReadOnly Property DropboxPath As String
            Get
                Return F.Path
            End Get
        End Property

        Private NotInheritable Class CacheManager
            Private ReadOnly CachePath As String
            Public Sub New()
                CachePath = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WriterCloudTexts")
                If IO.Directory.Exists(CachePath) = False Then IO.Directory.CreateDirectory(CachePath)
            End Sub
            Private Function getPath(File As MetaData) As String
                Return IO.Path.Combine(CachePath, File.Name & "-" & File.UTCDateModified.ToBinary.ToString())
            End Function
            Public Function isCached(File As MetaData) As Boolean
                Return IO.File.Exists(getPath(File))
            End Function
            Public Function GetFileFromCache(File As MetaData) As Byte()
                Dim FS As New IO.FileStream(getPath(File), IO.FileMode.Open, IO.FileAccess.Read)
                FS.Seek(0, IO.SeekOrigin.Begin)
                Dim b(FS.Length) As Byte
                FS.Read(b, 0, FS.Length)
                FS.Close()
                Return b
            End Function
            Public Sub Save2Cache(File As MetaData, b() As Byte)
                Dim FS As New IO.FileStream(getPath(File), IO.FileMode.Create, IO.FileAccess.Write)
                FS.Write(b, 0, b.Length)
                FS.Close()
            End Sub
        End Class
    End Class


    Private Sub tsbRefresh_Click(sender As Object, e As EventArgs) Handles tsbRefresh.Click
        lst.BeginUpdate()
        tb.ReadOnly = True
        tb.Text = ""
        tb.ReadOnly = False
        lst.Items.Clear()
        Dim MD As MetaData = dp.GetMetaData("/")
        For Each File As MetaData In MD.Contents
            If File.Extension.ToLower.EndsWith("txt") Then lst.Items.Add(New LI(File))
        Next
        lst.ListViewItemSorter = New ListViewDateColumnSorter(1, SortOrder.Descending)
        lst.Sort()
        lst.EndUpdate()
    End Sub

    Private Sub lst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst.SelectedIndexChanged
        tb.ReadOnly = True
        tb.Text = ""
        Cursor = Cursors.WaitCursor
        If lst.SelectedItems.Count = 1 Then tb.Text = CType(lst.SelectedItems(0), LI).getText(dp)
        Cursor = Cursors.Default
        tb.ReadOnly = False
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        Cursor = Cursors.WaitCursor
        If lst.SelectedItems.Count = 1 Then CType(lst.SelectedItems(0), LI).SaveText(dp, tb.Text)
        Cursor = Cursors.Default
    End Sub

    Private Sub tsbDel_Click(sender As Object, e As EventArgs) Handles tsbDel.Click
        If lst.SelectedItems.Count = 1 Then
            dp.Delete(CType(lst.SelectedItems(0), LI).DropboxPath)
            tsbRefresh_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tsbNew_Click(sender As Object, e As EventArgs) Handles tsbNew.Click
        Cursor = Cursors.WaitCursor
        Dim ip As String = InputBox("Enter the name of the file:", "Text.txt")
        If ip.EndsWith(".txt") = False Then ip &= ".txt"
        dp.UploadFile("/", ip, New Byte() {})
        Cursor = Cursors.Default
        tsbRefresh_Click(Nothing, Nothing)
    End Sub


    Private Sub tsbView_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tsbView.DropDownItemClicked
        Select Case e.ClickedItem.Name
            Case LargerTextToolStripMenuItem.Name
                tb.Font = New Font("Calibri", tb.Font.Size + 1, tb.Font.Unit)
            Case SmallerTextToolStripMenuItem.Name
                tb.Font = New Font("Calibri", tb.Font.Size - 1, tb.Font.Unit)
            Case DetailsToolStripMenuItem.Name
                lst.View = View.Details
            Case TilesToolStripMenuItem.Name
                lst.View = View.Tile
            Case ListToolStripMenuItem.Name
                lst.View = View.List
            Case IconsToolStripMenuItem.Name
                lst.View = View.LargeIcon
        End Select
        K.SetValue("V", lst.View.ToString)
        K.SetValue("Fs", tb.Font.Size)
    End Sub

    Private Sub tsbExport_Click(sender As Object, e As EventArgs) Handles tsbExport.Click
        Dim f As New SaveFileDialog()
        f.Filter = "Text files (.txt)|*.txt|*.*|*.*"
        f.DefaultExt = ".txt"
        If lst.SelectedItems.Count = 1 AndAlso f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim fw As New IO.StreamWriter(New IO.FileStream(f.FileName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None))
            fw.Write(tb.Text)
            fw.Close()
        End If
    End Sub
End Class