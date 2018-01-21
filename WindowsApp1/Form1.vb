Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
            'Dim root As Environment.SpecialFolder = folderDlg.RootFolder

            'Console.WriteLine(FolderBrowserDialog1.SelectedPath)

            Button2.Enabled = True

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If MsgBox(String.Format("Hello! We are almost ready to reset time for all files in folder. Should we proceed '{0}'?", FolderBrowserDialog1.SelectedPath), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            Dim orderedFiles = New System.IO.DirectoryInfo(FolderBrowserDialog1.SelectedPath).GetFiles().OrderBy(Function(x) x.CreationTime)

            For Each f As System.IO.FileInfo In orderedFiles

                'System.IO.File.SetLastAccessTime(f.FullName, System.DateTime.Now)
                'System.IO.File.SetLastWriteTime(f.FullName, System.DateTime.Now)
                'Console.WriteLine(String.Format("{0,-15} {1,12}", f.Name, f.CreationTime.ToString))
                'Console.WriteLine(String.Format("{0,-15} {1,12}", f.FullName, f.LastAccessTime.ToString)) ', f.CreationTime.ToString))
                TextBox2.Paste(String.Format("{0,-15} {1,12}", f.FullName, f.LastAccessTime.ToString))
                TextBox2.Paste(vbNewLine)

            Next

        End If

    End Sub
End Class
