<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GuestMaster.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="LabProject.View.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
       <h1>Welcome to MakeMeUpzz</h1>
        <h3>Login</h3>
    </div>
    <div>
        <asp:Label ID="UserLbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="UserTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="PassLbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="PassTxt" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:CheckBox ID="RememberCB" Text="Remember Me" runat="server" />
    </div>
    <div>
        <asp:Button ID="LoginBtn" runat="server" Text="Login"  OnClick="LoginBtn_Click"/>
    </div>
    <div>
        <asp:Label ID="ErrorLbl" runat="server" Text="Error Message" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <p>Don't have an account?</p>
        <a href="RegisterPage.aspx">Register</a>
    </div>
</asp:Content>
