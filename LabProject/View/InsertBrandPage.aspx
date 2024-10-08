<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="InsertBrandPage.aspx.cs" Inherits="LabProject.View.InsertBrandPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Insert Makeup Brand</h3>
    <div>
        <asp:Label ID="brandNameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="brandNameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="brandRatingLbl" runat="server" Text="Rating"></asp:Label>
        <asp:TextBox ID="brandRatingTxt" runat="server"></asp:TextBox>
    </div>
    <asp:Label ID="errorLbl" runat="server" ForeColor="Red" Text="Error"></asp:Label>
    <div>
        <asp:Button runat="server" ID="insertBtn" Text="Insert new makeup Brand" OnClick="insertBtn_Click"/>
    </div>
    <asp:Button runat="server" ID="backBtn" Text="Back" OnClick="backBtn_Click"/>
</asp:Content>
