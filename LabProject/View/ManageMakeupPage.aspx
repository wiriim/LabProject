<%@ Page Title="" Language="C#" MasterPageFile="~/Master/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageMakeupPage.aspx.cs" Inherits="LabProject.View.ManageMakeupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Manage Makeup</h3>
    <div>
        <h4>Makeup List</h4>
        <asp:GridView runat="server" ID="makeupGridView" AutoGenerateColumns="False" OnRowDeleting="makeupGridView_RowDeleting" OnRowUpdating="makeupGridView_RowUpdating" >
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="Makeup ID" SortExpression="MakeupID" />
                <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupTypeID" HeaderText="Type ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupBrandID" HeaderText="Brand ID" SortExpression="MakeupBrandID" />

                <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Update" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />

            </Columns>

        </asp:GridView>

        <asp:Button runat="server" ID="insertMakeupBtn" Text="Insert Makeup" OnClick="insertMakeupBtn_Click" />
    </div>

    <div>
        <h4>Makeup Type List</h4>
        <asp:GridView runat="server" AutoGenerateColumns="False" ID="makeupTypeGridView" OnRowDeleting="makeupTypeGridView_RowDeleting" OnRowUpdating="makeupTypeGridView_RowUpdating">
            <Columns>
                <asp:BoundField DataField="MakeupTypeID" HeaderText="Makeup Type ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Type Name" SortExpression="MakeupTypeName" />
                <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Update" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
            </Columns>

        </asp:GridView>
        <asp:Button runat="server" ID="insertTypebtn" Text="Insert Makeup Type" OnClick="insertTypebtn_Click" />
    </div>

    <div>
        <h4>Makeup Brand List</h4>
        <asp:GridView runat="server" AutoGenerateColumns="False" ID="makeupBrandGridView" OnRowDeleting="makeupBrandGridView_RowDeleting" OnRowUpdating="makeupBrandGridView_RowUpdating">
            <Columns>
                <asp:BoundField DataField="MakeupBrandID" HeaderText="Makeup Brand ID" SortExpression="MakeupBrandID" />
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Brand Name" SortExpression="MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrandRating" HeaderText="Brand Rating" SortExpression="MakeupBrandRating" />
                <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Update" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
            </Columns>

        </asp:GridView>
        <asp:Button runat="server" ID="insertBrandBtn" Text="Insert Makeup Brand" OnClick="insertBrandBtn_Click" />
    </div>
    
</asp:Content>
