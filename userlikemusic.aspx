<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userlikemusic.aspx.cs" Inherits="userlikemusic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Panel ID="Panel1" runat="server" Visible="False">
            <br />
            <asp:Button ID="Button3" runat="server" Text="submit likes" 
                onclick="Button3_Click" />
                <br />
            <br />
                <br />
        </asp:Panel>
           <br />
                <br />
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/login.aspx" 
            Visible="False">Login</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/bandlogin.aspx" 
            Visible="False">band login</asp:HyperLink>
    </div>
    </form>
</body>
</html>
