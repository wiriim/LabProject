<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="LabProject.View.TransactionHistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Transaction History</h3>

    <div>
        <asp:GridView ID="TransactionGridView" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanged="TransactionGridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" SortExpression="TransactionId"></asp:BoundField>
                <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId"></asp:BoundField>
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate"></asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Details" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
