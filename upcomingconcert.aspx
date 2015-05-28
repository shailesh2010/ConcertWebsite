<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upcomingconcert.aspx.cs" Inherits="upcomingconcert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
        <br />
        <asp:Image ID="Image1" runat="server" Height="130px" Width="130px" />
        <br />
        <asp:Label ID="Label2" runat="server" ></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
&nbsp;<asp:Label ID="Label3" runat="server" ></asp:Label>
        <asp:Label ID="Label4" runat="server" ></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" ></asp:Label>
        &nbsp;<asp:Label ID="Label6" runat="server" ></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server"></asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server">Buy Ticket</asp:HyperLink>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="I will attend" 
            CausesValidation="False" onclick="Button1_Click" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Recommend" 
            CausesValidation="False" onclick="Button2_Click" Visible="False" />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            CausesValidation="False">back</asp:LinkButton>
    </div>
    </form>
</body>
</html>
