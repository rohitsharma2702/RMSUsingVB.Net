

Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class frmAdminPanel
    Inherits System.Web.UI.Page

    Dim CS As String = WebConfigurationManager.AppSettings("DBCS")
    Dim con As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCommand


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Call GetDataFromDatabase()
            ViewState("Action_On_Click") = "Insert"
            Button1.Attributes.Add("onclick", "return btnSave_Click()")
            RadioButtonList1.SelectedIndex = 0
        End If

        If ViewState("Action_On_Click") = "Insert" Then
            Button1.Text = "Save"
        Else
            Button1.Text = "Update"
            ViewState("Action_On_Click") = "Update"
        End If

    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ViewState("Action_On_Click") = "Insert" Then         ''''''''''''' Data Insertion
            con = New SqlConnection(CS)
            cmd = New SqlCommand("spInsertResource", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim parameter As SqlParameter() = New SqlParameter(4) {}
            parameter(0) = New SqlParameter("@name", TextBox1.Text)
            parameter(1) = New SqlParameter("@gender", RadioButtonList1.SelectedItem.Text)
            parameter(2) = New SqlParameter("@salary", Val(TextBox2.Text))
            parameter(3) = New SqlParameter("@country", TextBox3.Text)
            parameter(4) = New SqlParameter("@message", SqlDbType.VarChar, 100)
            parameter(4).Direction = ParameterDirection.Output
            For Each param As SqlParameter In parameter
                cmd.Parameters.Add(param)
            Next
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "message", "alert('" + parameter(4).Value.ToString() + "')", True)
            Call GetDataFromDatabase()
            Call Clear()
        ElseIf ViewState("Action_On_Click") = "Update" Then                       ''''' Data Updation
            con = New SqlConnection(CS)
            cmd = New SqlCommand("spUpdateResource", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim parameter As SqlParameter() = New SqlParameter(5) {}
            parameter(0) = New SqlParameter("@id", ViewState("Id").ToString())
            parameter(1) = New SqlParameter("@name", TextBox1.Text)
            parameter(2) = New SqlParameter("@gender", RadioButtonList1.SelectedItem.Text)
            parameter(3) = New SqlParameter("@salary", Val(TextBox2.Text))
            parameter(4) = New SqlParameter("@country", TextBox3.Text)
            parameter(5) = New SqlParameter("@message", SqlDbType.VarChar, 100)
            parameter(5).Direction = ParameterDirection.Output
            For Each param As SqlParameter In parameter
                cmd.Parameters.Add(param)
            Next
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "message", "alert('" + parameter(5).Value.ToString() + "')", True)
            Call GetDataFromDatabase()
            Call Clear()
            ViewState("Action_On_Click") = "Insert"
            Button1.Text = "Save"

        End If

    End Sub


    Protected Sub GetDataFromDatabase()

        con = New SqlConnection(CS)
        da = New SqlDataAdapter("select * from resources order by id", con)
        ds = New DataSet()
        da.Fill(ds)
        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Call Clear()
        Button1.Text = "Save"
        TextBox1.Focus()

    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand

        If e.CommandName = "insrt" Then
            Call Clear()
            TextBox1.Focus()

        ElseIf e.CommandName = "updt" Then
            con = New SqlConnection(CS)
            da = New SqlDataAdapter("select name,gender,salary,country from resources where id = " + e.CommandArgument.ToString(), con)
            ds = New DataSet()
            da.Fill(ds)
            TextBox1.Text = ds.Tables(0).Rows(0).Item(0)
            If ds.Tables(0).Rows(0).Item(1).ToString() = "Male" Then
                RadioButtonList1.SelectedIndex = 0
            Else
                RadioButtonList1.SelectedIndex = 1
            End If
            TextBox2.Text = ds.Tables(0).Rows(0).Item(2).ToString()
            TextBox3.Text = ds.Tables(0).Rows(0).Item(3).ToString()
            Button1.Text = "Update"
            ViewState("Action_On_Click") = "Update"
            ViewState("Id") = e.CommandArgument.ToString()
            TextBox1.Focus()

        ElseIf e.CommandName = "del" Then
            con = New SqlConnection(CS)
            cmd = New SqlCommand("delete from resources where id = " + e.CommandArgument.ToString(), con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "message", "alert('Row Deleted Successfully')", True)
            Call GetDataFromDatabase()
        End If

    End Sub

    Protected Sub Clear()

        TextBox1.Text = ""
        RadioButtonList1.SelectedIndex = 0
        TextBox2.Text = ""
        TextBox3.Text = ""

    End Sub

End Class




