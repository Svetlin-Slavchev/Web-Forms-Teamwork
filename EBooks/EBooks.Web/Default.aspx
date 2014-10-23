<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EBooks.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>All books</h3>
    <asp:GridView ID="BooksGridView" runat="server"
        AutoGenerateColumns="false" AllowPaging="true" PageSize="5"
        OnPageIndexChanging="BooksGridView_PageIndexChanging"
        CssClass="table table-hover table-striped" GridLines="None">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFormatString="View.aspx?bookId={0}"
                DataNavigateUrlFields="Id" HeaderText="Book Title" DataTextField="Title" />
            <asp:BoundField HeaderText="ISBN" DataField="ISBN" />
            <asp:BoundField HeaderText="Pages" DataField="Pages" />

        </Columns>
        <RowStyle CssClass="cursor-pointer" />
    </asp:GridView>

</asp:Content>
