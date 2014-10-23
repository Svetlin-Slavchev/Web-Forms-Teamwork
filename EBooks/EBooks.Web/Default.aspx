<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EBooks.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>All books</h3>
            <asp:GridView ID="BooksGridView" runat="server"
                AutoGenerateColumns="false" AllowPaging="true" PageSize="3"
                OnPageIndexChanging="BooksGridView_PageIndexChanging"
                CssClass="table table-hover table-striped" GridLines="None">
                <Columns>
                    <asp:BoundField HeaderText="" DataField="Id" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="Book/View.aspx?bookId={0}"
                        DataNavigateUrlFields="Id" HeaderText="Book Title" DataTextField="Title" />
                </Columns>
                <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>
</asp:Content>
