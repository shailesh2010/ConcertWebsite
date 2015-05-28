<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="user" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style7
        {
            width: 173px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Image ID="Image1" runat="server" Height="130px" Width="130px" />
    <asp:Button ID="Button5" runat="server" Text="change picture" 
        CausesValidation="False" onclick="Button5_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button7" runat="server" onclick="Button7_Click" Text="Logout" 
        CausesValidation="False" />
    <asp:Panel ID="Panel3" runat="server" Visible="false">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="change" 
            style="height: 26px" />
    </asp:Panel>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" ></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server"></asp:Label>
    &nbsp;<asp:Label ID="Label5" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="Label6" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="Label7" runat="server" ></asp:Label>
    <br />
    <asp:Label ID="Label8" runat="server" ></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label9" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" 
        Text="edit profile" CausesValidation="False" />
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <table style="width: 27%;">
            <tr>
                <td class="style7">
                    firstname
                </td>
                <td>
                    <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                        ControlToValidate="firstname" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    lastname
                </td>
                <td>
                    <asp:TextBox ID="lastname" runat="server"></asp:TextBox>                    
                </td>
            </tr>
            <tr>
                <td class="style7">
                    dob
                </td>
                <td>
                    <dx:ASPxCalendar ID="ASPxCalendar1" runat="server">
                    </dx:ASPxCalendar>
                </td>
            </tr>
            <tr>
                <td>
                    email
                </td>
                <td>
                    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="email"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ErrorMessage="RegularExpressionValidator" ControlToValidate="email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    city
                </td>
                <td>
                    <asp:TextBox ID="city" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="RequiredFieldValidator" ControlToValidate="city"></asp:RequiredFieldValidator>
            <tr>
                <td>
                    aboutself
                </td>
                <td>
                    <asp:TextBox ID="aboutself" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
          
            <tr>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="submit" onclick="Button2_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="Label1" runat="server" ></asp:Label>
    <br />
    <asp:Button ID="Button3" runat="server" Text="change password" 
        onclick="Button3_Click" CausesValidation="False" />
    <br />
    <asp:Panel ID="Panel2" runat="server" Visible="False">
    <table>
        <tr>
            <td>
                Enter old password
            </td>
            <td>
                <asp:TextBox ID="pwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="enter some value" ControlToValidate="pwd"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Enter new password
            </td>
            <td>
                <asp:TextBox ID="newpwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="enter some value" ControlToValidate="newpwd"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Re-enter password
            </td>
            <td>
                <asp:TextBox ID="rnewpwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="enter some value" ControlToValidate="rnewpwd"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Enter same password" ControlToValidate="rnewpwd" ControlToCompare="newpwd"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" Text="change" onclick="Button4_Click" 
                    style="height: 26px" />
            </td>
        </tr>
    </table>        
        <br />
        <br />        
    </asp:Panel>
    <asp:Label ID="Label2" runat="server" ></asp:Label>
     <br />
        <br /> 
    <asp:TextBox ID="searchuser" runat="server"></asp:TextBox>
        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
        onclick="LinkButton1_Click" CausesValidation="False">search user</asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="searchband" runat="server" Height="22px"></asp:TextBox>
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
        CausesValidation="False">searchband</asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="searchconcert" runat="server"></asp:TextBox>
    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
        onclick="LinkButton3_Click">search concert</asp:LinkButton>
    <br />
    <br />
    <br />
    <asp:TextBox ID="userpost" runat="server" Width="719px" TextMode="MultiLine" 
        Height="36px">whats on your mind</asp:TextBox>
&nbsp;
    <asp:Button ID="Button8" runat="server" Text="tell" CausesValidation="False" 
        onclick="Button8_Click" />
    <br />
    <asp:Label ID="Label13" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Panel ID="Panel7" runat="server">
        Posts by your friends<br />
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel8" runat="server">
        Recommended Posts by Friends<br />
    </asp:Panel>
    <br />
    Recommended Concerts by Friends<asp:Panel ID="Panel4" runat="server">
        <asp:Label ID="Label10" runat="server"></asp:Label>
    </asp:Panel>
    <br />
    Website Recommended Concerts<asp:Panel ID="Panel5" runat="server">
        <asp:Label ID="Label11" runat="server"></asp:Label>

    </asp:Panel>
    <br />
    <asp:Panel ID="Panel6" runat="server">
        Concerts that may interest you<br />
        <asp:Label ID="Label12" runat="server" ></asp:Label>
    </asp:Panel>
    <br />
    <asp:Button ID="Button9" runat="server" Text="add concert" 
        CausesValidation="False" onclick="Button9_Click" />
    <asp:Panel ID="Panel9" runat="server" Visible="False">
        <table>
            <tr>
                <td>
                    Select Concert Date
                </td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" 
                BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="#663399" Height="200px" ondayrender="Calendar1_DayRender" 
                onselectionchanged="Calendar1_SelectionChanged" ShowGridLines="True" 
                Width="220px">
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" 
                    Height="1px" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" 
                    Font-Size="9pt" ForeColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    Select Time
                </td>
                <td>
                    &nbsp; Hours<asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp; Minutes<asp:DropDownList ID="DropDownList2" 
                        runat="server">
                        <asp:ListItem>00</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>33</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                        <asp:ListItem>44</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>46</asp:ListItem>
                        <asp:ListItem>47</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>49</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>51</asp:ListItem>
                        <asp:ListItem>52</asp:ListItem>
                        <asp:ListItem>53</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                        <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>57</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Select Venue
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server" 
                DataSourceID="SqlDataSource1" DataTextField="vname" DataValueField="vname">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:abcd %>" 
                SelectCommand="SELECT [vname] FROM [venue]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    Upload picture
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" 
                Height="22px" Width="217px" />
                    <asp:Label ID="Label14" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Enter Ticket Price
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="Enter Price"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Select Music Type
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    
                    Select Band</td>
                <td>

                    <asp:DropDownList ID="DropDownList5" runat="server">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button10" runat="server" 
                onclick="Button10_Click" Text="Submit" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="Label15" runat="server" ></asp:Label>
    </form>
</body>
</html>
