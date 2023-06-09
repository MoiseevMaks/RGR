<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="searchTest.aspx.cs" Inherits="WebApplication1.searchTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Поиск тестов</h1>

    <div>
        <input type="text" id="txtSearch" runat="server" />
        <asp:Button ID="btnSearch" runat="server" Text="Поиск" OnClick="btnSearch_Click" />
    </div>

    <h2>Результаты поиска:</h2>
    <asp:Repeater ID="rptTests" runat="server" OnItemCommand="rptTests_ItemCommand">
        <ItemTemplate>
            <div>
                <asp:LinkButton ID="lnkTest" runat="server" Text='<%# Eval("Name") %>' CommandName="ViewDetails" CommandArgument='<%# Eval("TestId") %>'></asp:LinkButton>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Label ID="lblNoResults" runat="server" Text="Нет результатов" Visible="false"></asp:Label>
</asp:Content>
