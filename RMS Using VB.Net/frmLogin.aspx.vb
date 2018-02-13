Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class Login
    Inherits System.Web.UI.Page

    Dim cs As String = WebConfigurationManager.AppSettings("DBCS").ToString()
    Dim con As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        con = New SqlConnection(cs)
        da = New SqlDataAdapter("select count(*) from resources where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'", con)
        ds = New DataSet()
        da.Fill(ds)
        If Integer.Parse(ds.Tables(0).Rows(0)(0)) > 0 Then
            da = New SqlDataAdapter("select FirstName,LastName,Gender from resources where lower(Username) = '" + txtUsername.Text.ToLower() + "'", con)
            ds = New DataSet()
            da.Fill(ds)
            Session("FirstName") = ds.Tables(0).Rows(0)(0).ToString()
            Response.Redirect("frmAdminPanel.aspx?FirstName=" + ds.Tables(0).Rows(0)(0).ToString() + "&LastName=" + ds.Tables(0).Rows(0)(1).ToString() + "&Gender=" + ds.Tables(0).Rows(0)(2).ToString())
        Else
            Response.Write("<script>alert('Invalid Credentials...')</script>")
        End If

    End Sub
End Class