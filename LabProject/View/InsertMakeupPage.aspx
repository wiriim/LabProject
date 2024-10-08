<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="InsertMakeupPage.aspx.cs" Inherits="LabProject.View.InsertMakeupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Insert Makeup</h3>

    <div>
        <asp:Label ID="makeupNameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="makeupNameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="priceLbl" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="weightLbl" runat="server" Text="Weight"></asp:Label>
        <asp:TextBox ID="weightTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="typeIDLbl" runat="server" Text="Type ID"></asp:Label>
        <asp:TextBox ID="typeIDTxt" runat="server"></asp:TextBox>
    </div
        ><div>
        <asp:Label ID="brandIDLbl" runat="server" Text="Brand ID"></asp:Label>
        <asp:TextBox ID="brandIDTxt" runat="server"></asp:TextBox>
    </div>
    <asp:Label ID="errorLbl" runat="server" ForeColor="Red" Text="Error"></asp:Label>
    <div>
        <asp:Button runat="server" ID="insertBtn" Text="Insert new makeup" OnClick="insertBtn_Click" />
    </div>
    <asp:Button runat="server" ID="backBtn" Text="Back" OnClick="backBtn_Click" />
</asp:Content>
