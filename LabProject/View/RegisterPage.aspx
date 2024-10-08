<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GuestMaster.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="LabProject.View.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Welcome to MakeMeUpzz</h1>
        <h3>Register</h3>
    </div>
    <div>
        <asp:Label ID="UserLbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="UserTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButtonList ID="GenderRB" runat="server">
            <asp:ListItem Value="Male">Male</asp:ListItem>
            <asp:ListItem Value="Female">Female</asp:ListItem>
        </asp:RadioButtonList>
    </div>
     <div>
         <asp:Label ID="PassLbl" runat="server" Text="Password"></asp:Label>
         <asp:TextBox ID="PassTxt" TextMode="Password" runat="server"></asp:TextBox>
     </div>
    <div>
        <asp:Label ID="ConfLbl" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="ConfTxt" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="DOBLbl" runat="server" Text="Date of Birth"></asp:Label>
        <asp:Calendar ID="Calendar" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
    </div>
    <div>
        <asp:Button ID="SignInBtn" runat="server" Text="Register" OnClick="SignInBtn_Click" />
    </div>
    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text="Error Message" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <p>Already have an account?</p>
        <a href="LoginPage.aspx">Login</a>
    </div>
</asp:Content>
