Imports System.IO
Imports System.Data.OleDb

Public Class Form3

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim Myconnection As System.Data.OleDb.OleDbConnection
            Dim dataSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            Dim path As String = "C:\\Users\\DELL\\Desktop\\movies.xlsx"

            Myconnection = New System.Data.OleDb.OleDbConnection("Provider = Microsoft.Ace.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Movies$]", Myconnection)

            dataSet = New System.Data.DataSet
            MyCommand.Fill(dataSet)
            DataGridView1.DataSource = dataSet.Tables(0)


            Myconnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Shell("cmd.exe /k""moviebox -m " + TextBox2.Text)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim rowindex As String
        Dim found As Boolean = False
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells.Item("Title").Value = TextBox1.Text Then
                rowindex = row.Index.ToString()
                found = True
                Dim actie As String = row.Cells("ID").Value.ToString()
                TextBox2.Text = actie
                Exit For
            End If
        Next
        If Not found Then
            MsgBox("Item not found")
        End If
    End Sub
End Class