<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="updateMakeupTypePage.aspx.cs" Inherits="LabProject.View.updateMakeupTypePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Update Makeup Type</h3>

    <div>
        <asp:Label ID="typeNameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="typeNameTxt" runat="server"></asp:TextBox>
    </div>
    <asp:Label ID="errorLbl" runat="server" ForeColor="Red" Text="Error"></asp:Label>
    <div>
        <asp:Button runat="server" ID="updateBtn" Text="update makeup type" OnClick="updateBtn_Click"/>
    </div>
    <asp:Button runat="server" ID="backBtn" Text="Back" OnClick="backBtn_Click"/>
</asp:Content>
