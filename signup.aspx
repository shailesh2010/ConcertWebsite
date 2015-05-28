<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
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
                <td bgcolor="#DC0000" colspan="2">
                    SIGN UP HERE
                </td>
            </tr>
            <tr>
                <td>
                    Enter your First Name
                </td>
                <td>
                    <asp:TextBox ID="firstname" runat="server" Height="21px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your first name"
                        ControlToValidate="firstname"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Enter your Last Name
                </td>
                <td>
                    <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Select Date of Birth
                </td>
                <td>
                    &nbsp; &nbsp;
                    <dx:ASPxCalendar ID="ASPxCalendar1" runat="server" Theme="Office2010Blue" 
                        ondayrender="ASPxCalendar1_DayRender">
                    </dx:ASPxCalendar>
                </td>
            </tr>
            <tr>
                <td>
                    Enter Email Id
                </td>
                <td>
                    <asp:TextBox ID="emailid" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator"
                        ControlToValidate="emailid"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator"
                        ControlToValidate="emailid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Enter City
                </td>
                <td>
                    <asp:TextBox ID="city" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                        runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="city"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Enter About Your Self
                </td>
                <td>
                    <asp:TextBox ID="aboutself" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Upload picture
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Label ID="Label4" runat="server" text="only .jpg, .jpeg, .png files are allowed"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Enter UserID &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="uid" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Username is required"
                        ControlToValidate="uid"></asp:RequiredFieldValidator>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Enter Password &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="password" runat="server" Height="22px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="password is required"
                        ControlToValidate="password"></asp:RequiredFieldValidator>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Re-Enter Password &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="rpwd" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="password is reqired"
                        ControlToValidate="rpwd"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="enter same password"
                        ControlToValidate="rpwd" ControlToCompare="password"></asp:CompareValidator>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <cc1:CaptchaControl ID="Captcha1" runat="server" BackColor="Silver" BorderColor="#FF9900"
                        BorderWidth="10px" CaptchaBackgroundNoise="Medium" CaptchaHeight="60" CaptchaLength="5"
                        CaptchaLineNoise="None" CaptchaMaxTimeout="240" CaptchaMinTimeout="5" CaptchaWidth="200"
                        FontColor="#529E00" Style="top: 154px; left: 0px; position: absolute" Width="169px"
                        NoiseColor="DarkGray" Height="36px" />
                    <br />
                    &nbsp;<asp:Label ID="Label3" runat="server" Text="enter captcha here "></asp:Label>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    &nbsp;<br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="enter captcha value"
                        ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="SIGN UP" OnClick="Button1_Click" />
                </td>
          
            </tr>
        </table>
       
        </asp:Panel>
         <asp:Label ID="Label1" runat="server" ></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
            onclick="LinkButton1_Click" Visible="False">next</asp:LinkButton>
    </div>
    </form>
</body>
</html>
