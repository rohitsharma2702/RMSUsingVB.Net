
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace RMS
	Public Partial Class frmForgotPassword
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(sender As Object, e As EventArgs)

		End Sub

		Protected Sub btnGetPassword_Click(sender As Object, e As EventArgs)
			Dim CS As String = ConfigurationManager.ConnectionStrings("DBCS").ConnectionString
			Dim con As New SqlConnection(CS)
			Dim da As New SqlDataAdapter("spRecoverPassword", con)
			da.SelectCommand.CommandType = CommandType.StoredProcedure
			Dim parameters As SqlParameter() = New SqlParameter() {New SqlParameter("Username", txtUsername.Text), New SqlParameter("Message", SqlDbType.VarChar, 50)}
			parameters(1).Direction = ParameterDirection.Output
			For Each parameter As SqlParameter In parameters
				da.SelectCommand.Parameters.Add(parameter)
			Next
			Dim ds As New DataSet()
			da.Fill(ds)
			Response.Write("<script>alert('" + parameters(1).Value.ToString() + "')</script>")
		End Sub
	End Class
End Namespace

