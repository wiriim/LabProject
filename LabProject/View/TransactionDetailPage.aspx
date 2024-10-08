<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="LabProject.View.TransacationDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Transaction Details</h3>

    <asp:GridView ID="TransactionDetailGridView" runat="server"  AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID"></asp:BoundField>
            <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Makeup Name" SortExpression="Makeup.MakeupName"></asp:BoundField>
            <asp:BoundField DataField="Makeup.MakeupPrice" HeaderText="Makeup Price" SortExpression="Makeup.MakeupPrice"></asp:BoundField>
            <asp:BoundField DataField="Makeup.MakeupWeight" HeaderText=" Makeup Weight" SortExpression="Makeup.MakeupWeight"></asp:BoundField>
            <asp:BoundField DataField="Makeup.MakeupType.MakeupTypeName" HeaderText="Makeup Type" SortExpression="Makeup.MakeupTypeId.MakeupTypeName"></asp:BoundField>
            <asp:BoundField DataField="Makeup.MakeupBrand.MakeupBrandName" HeaderText="Makeup Brand" SortExpression="Makeup.MakeupBrandId.MakeupBrandName"></asp:BoundField>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
        </Columns>
    </asp:GridView>

</asp:Content>
