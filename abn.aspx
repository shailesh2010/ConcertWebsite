<%@ Page Language="C#" AutoEventWireup="true" CodeFile="abn.aspx.cs" Inherits="abn" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        <br />
        <br />
        <dx:ASPxCalendar ID="ASPxCalendar1" runat="server" Theme="Office2010Blue" 
            ondayrender="ASPxCalendar1_DayRender">
        </dx:ASPxCalendar>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <br />
            <asp:Button ID="Button3" runat="server" Text="submit likes" 
                onclick="Button3_Click" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
