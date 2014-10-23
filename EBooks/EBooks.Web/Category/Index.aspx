<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EBooks.Web.Category.Index" %>

<%@ Register Src="~/UserControls/CategorySearch.ascx" TagPrefix="uc1" TagName="CategorySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:CategorySearch runat="server" ID="CategorySearch" />
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
            <h3>All categories</h3>
            <asp:GridView ID="CategoriesGridView" runat="server"
                AutoGenerateColumns="false" AllowPaging="true" PageSize="3"
                OnPageIndexChanging="CategoriesGridView_PageIndexChanging"
                CssClass="table table-hover table-striped" GridLines="None">
                <Columns>
                    <asp:BoundField HeaderText="" DataField="Id" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="View.aspx?categoryId={0}"
                        DataNavigateUrlFields="Id" HeaderText="Category Name" DataTextField="Name" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="Edit.aspx?categoryId={0}"
                        DataNavigateUrlFields="Id" HeaderText="" Text="Edit" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="Delete.aspx?categoryId={0}"
                        DataNavigateUrlFields="Id" HeaderText="" Text="Delete" />
                </Columns>
                <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Category/Create.aspx"
                CssClass="btn btn-primary" runat="server">Create</asp:HyperLink>
        </div>
    </div>
</asp:Content>
