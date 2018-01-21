
Module Module1

    Sub Main()
        Dim folderDlg As New System.Windows.Forms.FolderBrowserDialog With {
            .ShowNewFolderButton = True
        }
        If (folderDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            'TextBox1.Text = folderDlg.SelectedPath
            'Dim root As Environment.SpecialFolder = folderDlg.RootFolder

            Console.WriteLine(folderDlg.SelectedPath)

        End If


        If MsgBox(String.Format("Hello! We are almost ready to reset files time in folder. Should we proceed '{0}'?", folderDlg.SelectedPath), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            Console.WriteLine(String.Format("Resetting file time in folder '{0}'", folderDlg.SelectedPath))

            Dim orderedFiles = New System.IO.DirectoryInfo(folderDlg.SelectedPath).GetFiles().OrderBy(Function(x) x.CreationTime)

            For Each f As System.IO.FileInfo In orderedFiles
                ''
                System.IO.File.SetLastAccessTime(f.FullName, System.DateTime.Now)
                'f.LastAccessTime = System.DateTime.Now
                System.IO.File.SetLastWriteTime(f.FullName, System.DateTime.Now)
                'f.LastWriteTime = System.DateTime.Now
                'Console.WriteLine(String.Format("{0,-15} {1,12}", f.Name, f.CreationTime.ToString))
                Console.WriteLine(String.Format("{0,-15} {1,12}", f.FullName, f.LastAccessTime.ToString)) ', f.CreationTime.ToString))

            Next

        End If

        Console.Read()

    End Sub

End Module