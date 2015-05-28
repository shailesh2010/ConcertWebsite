<%@ Page Language="C#" AutoEventWireup="true" CodeFile="concert.aspx.cs" Inherits="concert" %>

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
        <asp:Button ID="Button3" runat="server" Text="rate and give review" 
            onclick="Button3_Click" Visible="False" />
        <br />
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0"></asp:ListItem>
                <asp:ListItem Value="1"></asp:ListItem>
                <asp:ListItem Value="2"></asp:ListItem>
                <asp:ListItem Value="3"></asp:ListItem>
            </asp:DropDownList>


            &nbsp;&nbsp;&nbsp; Enter Review
            <asp:TextBox ID="review" runat="server" TextMode="MultiLine"></asp:TextBox>
            &nbsp;<asp:Button ID="Button4" runat="server" Text="submit" 
                onclick="Button4_Click" />


            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="enter review" ControlToValidate="review"></asp:RequiredFieldValidator>


        </asp:Panel>
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            CausesValidation="False">back</asp:LinkButton>
    </div>
    </form>
</body>
</html>
