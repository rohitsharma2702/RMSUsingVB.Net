<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmLogin.aspx.vb" Inherits="RMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 135px;
        }

        .auto-style2 {
            width: 157px;
        }

        table, th, tr, td {
            border-collapse: collapse;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div style="position: absolute; left: 295px; top: 152px; text-align: center; width: 406px;">

                <fieldset>

                    <legend><strong>Login Panel</strong></legend>
                    <br />
                    <br />
                    <table border="1">
                        <tr>
                            <td class="auto-style2"><strong>Username : </strong></td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtUsername" runat="server" Width="179px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2"><strong>Password :</strong> </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="179px"></asp:TextBox></td>
                        </tr>

                    </table>
                    <br />
                    <div style="text-align: center">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Button1_Click" Width="60px" />
                    </div>
                    <br />
                </fieldset>

            </div>

            <br />
            <br />
            <br />
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WELCOME&nbsp; TO&nbsp; RESOURCE MANAGEMENT SYSTEM</strong><br />

        </div>

    </form>


    <script src="Scripts/jquery-1.12.3.js"></script>

    <script>

        $(document).ready(function () {


            function fnValidationCheck() {
                if ($('#txtUsername').val().length == 0) {
                    alert('Pleae Enter Username...');
                    return false;
                }
                else if ($('#txtPassword').val().length == 0) {
                    alert('Pleae Enter Password...');
                    return false;
                }
                return true;
            }


            $('#btnLogin').on('click', fnValidationCheck);

        });

    </script>



</body>
</html>
