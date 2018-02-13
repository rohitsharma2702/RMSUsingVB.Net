
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace RMS
	Public Partial Class frmSignUp
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(sender As Object, e As EventArgs)
			If Not IsPostBack Then
				FillDepartments()
				FillGenders()
			End If
		End Sub

		Protected Sub btnCreate_Click(sender As Object, e As EventArgs)
			Dim CS As String = ConfigurationManager.ConnectionStrings("DBCS").ConnectionString
			Dim con As New SqlConnection(CS)
			Dim cmd As New SqlCommand("spInsertResource", con)
			cmd.CommandType = CommandType.StoredProcedure
			Dim parameters As SqlParameter() = New SqlParameter() {New SqlParameter("FirstName", txtFirstName.Text), New SqlParameter("LastName", txtLastName.Text), New SqlParameter("Gender", ddlGender.SelectedItem.Text), New SqlParameter("ContactNumber", txtContactNumber.Text), New SqlParameter("AadharId", txtAadharId.Text), New SqlParameter("EmailId", txtEmailId.Text), _
				New SqlParameter("Username", txtUsername.Text), New SqlParameter("Password", txtPassword.Text), New SqlParameter("DateOfBirth", txtDateOfBirth.Text), New SqlParameter("Salary", txtSalary.Text), New SqlParameter("Address", txtAddress.Text), New SqlParameter("DepartmentId", ddlDepartment.SelectedValue), _
				New SqlParameter("Message", SqlDbType.VarChar, 50)}
			parameters(12).Direction = ParameterDirection.Output
			For Each parameter As SqlParameter In parameters
				cmd.Parameters.Add(parameter)
			Next
			con.Open()
			cmd.ExecuteNonQuery()
			Response.Write("<script>alert('" + parameters(12).Value.ToString() + "')</script>")
			con.Close()
			Clear()
		End Sub

		Protected Sub FillGenders()
			Dim CS As String = ConfigurationManager.ConnectionStrings("DBCS").ConnectionString
			Dim con As New SqlConnection(CS)
			Dim da As New SqlDataAdapter("select Id,Type from Gender", con)
			Dim ds As New DataSet()
			da.Fill(ds)
			ddlGender.DataSource = ds.Tables(0)
			ddlGender.DataTextField = "Type"
			ddlGender.DataValueField = "Id"
			ddlGender.DataBind()
			ddlGender.Items.Insert(0, New ListItem("Please Select Gender", ""))
		End Sub

		Protected Sub FillDepartments()
			Dim CS As String = ConfigurationManager.ConnectionStrings("DBCS").ConnectionString
			Dim con As New SqlConnection(CS)
			Dim da As New SqlDataAdapter("select Id,Name from Department", con)
			Dim ds As New DataSet()
			da.Fill(ds)
			ddlDepartment.DataSource = ds.Tables(0)
			ddlDepartment.DataTextField = "Name"
			ddlDepartment.DataValueField = "Id"
			ddlDepartment.DataBind()
			ddlDepartment.Items.Insert(0, New ListItem("Please Select Department", ""))
		End Sub



		Private Sub Clear()
			txtFirstName.Text = ""
			txtLastName.Text = ""
			ddlGender.SelectedIndex = 0
			txtContactNumber.Text = ""
			txtAadharId.Text = ""
			txtEmailId.Text = ""
			txtUsername.Text = ""
			txtDateOfBirth.Text = ""
			txtSalary.Text = ""
			txtAddress.Text = ""
			ddlDepartment.SelectedIndex = 0
		End Sub


	End Class
End Namespace

