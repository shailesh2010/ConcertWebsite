﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchband.aspx.cs" Inherits="searchband" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <br />
    
        <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        </asp:Panel>

     <br />
      <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/user.aspx">back
        </asp:HyperLink>
    </div>
    </form>
</body>
</html>
