<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="HandleTransactionPage.aspx.cs" Inherits="LabProject.View.HandleTransactionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Handled Transaction</h3>
    <asp:GridView runat="server" AutoGenerateColumns="False" ID="handledGridView">
        <Columns>
            <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" SortExpression="TransactionId"></asp:BoundField>
            <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
        </Columns>
    </asp:GridView>

    <h3>Unhandled Transaction</h3>
    <asp:GridView runat="server" AutoGenerateColumns="False" ID="unhandledGridView" OnRowUpdating="unhandledGridView_RowUpdating">
        <Columns>
            <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" SortExpression="TransactionId"></asp:BoundField>
            <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
            <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Handle" />
        </Columns>
    </asp:GridView>
</asp:Content>
