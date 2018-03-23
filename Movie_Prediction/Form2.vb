Imports MySql.Data.MySqlClient
Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim con As MySqlConnection = New MySqlConnection("DataSource =  localhost; Database = movie_recommendation ; UserID = root ;")
        Dim sql As MySqlCommand = New MySqlCommand("Select * from login_details", con)
        Dim ds As DataSet = New DataSet()
        Dim adpt As MySqlDataAdapter = New MySqlDataAdapter()
        con.Open()
        adpt.SelectCommand = sql
        adpt.Fill(ds, "login1")
        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim con As MySqlConnection = New MySqlConnection("DataSource =  localhost; Database = movie_recommendation ; UserID = root ;")
        Dim sql As MySqlCommand = New MySqlCommand("insert into login_details (USERNAME, Pass, phone_no) values('" + TextBox2.Text + "','" + TextBox4.Text + "', '" + TextBox1.Text + "')", con)
        'Dim ds As DataSet = New DataSet()
        'Dim adpt As MySqlDataAdapter = New MySqlDataAdapter()
        con.Open()
        Try
            sql.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ID already exists")
        End Try
        con.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class