<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EBooks.Web.Author.Index" %>

<%@ Register Src="~/UserControls/AuthorSearch.ascx" TagPrefix="uc1" TagName="AuthorSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:AuthorSearch runat="server" id="AuthorSearch" />
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
            <h3>All authors</h3>
            <asp:GridView ID="AuthorsGridView" runat="server"
                AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
                OnPageIndexChanging="AuthorsGridView_PageIndexChanging"
                CssClass="table table-hover table-striped" GridLines="None">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFormatString="View.aspx?authorId={0}"
                         DataNavigateUrlFields="Id" HeaderText="Author Name" DataTextField="Name" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="Edit.aspx?authorId={0}"
                        DataNavigateUrlFields="Id" HeaderText="" Text="Edit" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="Delete.aspx?authorId={0}"
                        DataNavigateUrlFields="Id" HeaderText="" Text="Delete" />
                </Columns>
                <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>
            <asp:HyperLink ID="btnCreate" NavigateUrl="~/Author/Create.aspx"
                CssClass="btn btn-primary" runat="server">Create</asp:HyperLink>
        </div>
    </div>
</asp:Content>
