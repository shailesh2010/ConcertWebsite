<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bandlogin.aspx.cs" Inherits="bandlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table >

         <tr>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;SIGN IN
                    </td>
                
            </tr>
            <tr>
                <td >
                    BandID</td>
                <td >
                    <asp:TextBox ID="txtbandid" runat="server" Width="156px" 
                        style="margin-left: 0px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="enter band id " ControlToValidate="txtbandid"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td >
                    Password</td>
                <td >
                    <asp:TextBox ID="txtpassword" runat="server" Width="155px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="enter password" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td  colspan="2" >
                    <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" />
                    </td>
                
                
            </tr>
            <tr>
                <td  colspan="2">
                    <asp:Label ID="Label1" runat="server" ForeColor="#FF6666"></asp:Label>
                </td>
               
            </tr>
            <tr>
            <td colspan="2" class="style3">
                <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="#FF0066" 
                    NavigateUrl="~/login.aspx">Home</asp:HyperLink>
            </td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                    <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#CC0000" 
                        NavigateUrl="~/bandsignup.aspx">band sign up</asp:HyperLink>
                </td>
               
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
