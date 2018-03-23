Imports MySql.Data.MySqlClient
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con As MySqlConnection = New MySqlConnection("DataSource =  localhost; Database = movie_recommendation ; UserID = root ;")
        Dim sql As MySqlCommand = New MySqlCommand("Select Username from login_details where username ='" + TextBox1.Text + "' and pass = '" + TextBox2.Text + "' ", con)
        Dim ds As DataTable = New DataTable()
        Dim adpt As MySqlDataAdapter = New MySqlDataAdapter()
        con.Open()
        adpt.SelectCommand = sql
        adpt.Fill(ds)
        If ds.Rows.Count = 0 Then
            MsgBox("Sorry, looks like you entered a wrong username or password")
        Else
            Me.Hide()
            Form3.Show()
        End If
        con.Close()

    End Sub
End Class
