<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="InsertTypePage.aspx.cs" Inherits="LabProject.View.InsertTypePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Insert Makeup Type</h3>

    <div>
        <asp:Label ID="typeNameLbl" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="typeNameTxt" runat="server"></asp:TextBox>
    </div>
    <asp:Label ID="errorLbl" runat="server" ForeColor="Red" Text="Error"></asp:Label>
    <div>
        <asp:Button runat="server" ID="insertBtn" Text="Insert new makeup type" OnClick="insertBtn_Click"/>
    </div>
    <asp:Button runat="server" ID="backBtn" Text="Back" OnClick="backBtn_Click"/>
</asp:Content>
