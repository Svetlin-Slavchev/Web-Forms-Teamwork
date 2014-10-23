<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EBooks.Web.Book.Index" %>

<%@ Register Src="~/UserControls/BookSearch.ascx" TagPrefix="uc1" TagName="BookSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:BookSearch runat="server" ID="BookSearch" />
        </div>
        <div class="col-md-9">
            <asp:Panel ID="PanelError" runat="server" CssClass="alert alert-dismissable alert-danger"
                Visible="false">
                <asp:Label ID="Error" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="PanelSuccess" runat="server" CssClass="alert alert-dismissable alert-success"
                Visible="false">
                <asp:Label ID="Success" runat="server"></asp:Label>
            </asp:Panel>
            <h3>All books</h3>
            <asp:GridView ID="BooksGridView" runat="server"
                AutoGenerateColumns="false" AllowPaging="true" PageSize="3"
                OnPageIndexChanging="BooksGridView_PageIndexChanging"
                CssClass="table table-hover table-striped" GridLines="None">
                <Columns>
                    <asp:BoundField HeaderText="" DataField="Id" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="View.aspx?bookId={0}"
                        DataNavigateUrlFields="Id" HeaderText="Book Title" DataTextField="Title" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="Edit.aspx?bookId={0}"
                        DataNavigateUrlFields="Id" HeaderText="" Text="Edit" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="Delete.aspx?bookId={0}"
                        DataNavigateUrlFields="Id" HeaderText="" Text="Delete" />
                </Columns>
                <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>
            <% if (Roles.IsUserInRole(Page.User.Identity.Name, "admin"))
               { %>
                   <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Book/Create.aspx"
                    CssClass="btn btn-primary" runat="server">Create</asp:HyperLink>
            <% } %>
        </div>
    </div>
</asp:Content>
