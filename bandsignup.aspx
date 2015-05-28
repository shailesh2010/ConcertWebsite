<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bandsignup.aspx.cs" Inherits="bandsignup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="Panel1" runat="server">
    <table>
        <tr>
            <td colspan="2" >
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Band Sign Up
            </td>
        </tr>
        <tr>
            <td>    
                Enter Band Name
            </td>
            <td>
                <asp:TextBox ID="bandname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Enter band name" ControlToValidate="bandname"></asp:RequiredFieldValidator>
            </td>
              <tr>
            <td>    
                Enter Band Info
            </td>
            <td>
                <asp:TextBox ID="bandinfo" runat="server" TextMode="MultiLine"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="enter band info" ControlToValidate="bandinfo"></asp:RequiredFieldValidator>

            </td>
        </tr>
          <tr>
            <td>    
               Upload Picture
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                &nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="upload picture" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        </tr>
          <tr>
            <td>    
                Enter BandID
            </td>
            <td>
                <asp:TextBox ID="bandid" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="enter bandid" ControlToValidate="bandid"></asp:RequiredFieldValidator>
            </td>
        </tr>
          <tr>
            <td>    
                Enter Password
            </td>
            <td>
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="enter password" ControlToValidate="password"></asp:RequiredFieldValidator>
            </td>
        </tr>
          <tr>
            <td>    
                Re-enter Password
            </td>
            <td>
                <asp:TextBox ID="rpassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="re-enter password" ControlToValidate="rpassword"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="enter same password" ControlToCompare="password" ControlToValidate="rpassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="submit" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
        
        </asp:Panel>
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
            Visible="False" onclick="LinkButton1_Click">next</asp:LinkButton>
    </div>
    </form>
</body>
</html>
