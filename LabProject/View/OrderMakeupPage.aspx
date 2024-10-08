<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="OrderMakeupPage.aspx.cs" Inherits="LabProject.View.OrderMakeupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h3>Order Makeup</h3>
    <asp:GridView runat="server" AutoGenerateColumns="false" ID="makeupsGridView" OnRowUpdating="order">
        <Columns>
            <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID"></asp:BoundField>
            <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName"></asp:BoundField>
            <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice"></asp:BoundField>
            <asp:BoundField DataField="MakeupWeight" HeaderText="Weight in Grams" SortExpression="MakeupWeight"></asp:BoundField>
            <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" SortExpression="MakeupTypeId.MakeupTypeName"></asp:BoundField>
            <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrandId.MakeupBrandName"></asp:BoundField>
            
            
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="QuantityTxt" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:ButtonField CommandName="Update" Text="Order" ButtonType="Button"></asp:ButtonField>
        </Columns>
    </asp:GridView>
    </div>
    <div>
        <h3>Here is Your Cart:</h3>
        <asp:GridView ID="cartGridView" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="Makeup ID" SortExpression="MakeupID"></asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="cartErrorLbl" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="ClearBtn" runat="server" Text="Clear Cart" OnClick="ClearBtn_Click" />
    </div>
    <div>
        <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click" />
    </div>
    <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
</asp:Content>
