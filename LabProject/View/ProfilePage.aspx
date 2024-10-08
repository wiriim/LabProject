<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="LabProject.View.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Profile</h3>

    <div>
        <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="DOBLbl" runat="server" Text="Date of Birth"></asp:Label>
        <asp:TextBox ID="DOBTxT" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButtonCalender" runat="server" ImageUrl="~/calenderIcon.jpg" Height="24px" Width="24px" ImageAlign="AbsBottom" OnClick="ImageButtonCalender_Click" />
        <asp:Calendar ID="CalendarDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="CalendarDate_SelectionChanged">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
    </div>
    <div>
        <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButtonList ID="GenderRB" runat="server">
            <asp:ListItem Value="Male">Male</asp:ListItem>
            <asp:ListItem Value="Female">Female</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div>
        <asp:Button ID="UpdateProfBtn" runat="server" Text="Update Profile" OnClick="UpdateProfBtn_Click" />
    </div>
    <div>
        <asp:Label ID="ErrorLbl1" runat="server" Text="Error Message" ForeColor="Red"></asp:Label>
    </div>

    <br />
    <h3>
        Change Password
    </h3>
    <div>
        <asp:Label ID="OldPassLbl" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="OldPassTxt" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="NewPassLbl" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="NewPassTxt" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="UpdatePassBtn" runat="server" Text="Update Password" OnClick="UpdatePassBtn_Click" />
    </div>
    <div>
        <asp:Label ID="ErrorLbl2" runat="server" Text="Error Message" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
