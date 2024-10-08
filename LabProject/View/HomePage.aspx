<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GuestMaster.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="LabProject.View.HomePage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Home Page
    </h3>
    <div>
        <asp:Label ID="NameLbl" runat="server" Text="*User Name*"></asp:Label>
        <asp:Label ID="RoleLbl" runat="server" Text="*User Role*"></asp:Label>
    </div>
    <div id="onlyAdmin" runat="server">
        <h4>Customer List</h4>
        <asp:GridView AutoGenerateColumns="False" ID="userGridView" runat="server">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="UserEmail" HeaderText="User Email" SortExpression="UserEmail" />
                <asp:BoundField DataField="UserDOB" HeaderText="User DOB" SortExpression="UserDOB" DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="UserGender" HeaderText="User Gender" SortExpression="UserGender" />
                <asp:BoundField DataField="UserRole" HeaderText="User Role" SortExpression="UserRole" />
                <asp:BoundField DataField="UserPassword" HeaderText="User Password" SortExpression="UserPassword" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
