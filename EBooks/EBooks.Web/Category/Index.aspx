<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EBooks.Web.Category.Index" %>

<%@ Register Src="~/UserControls/SearchPanel.ascx" TagPrefix="uc1" TagName="SearchPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:SearchPanel runat="server" ID="SearchPanel" />
        </div>
        <div class="col-md-9">
            <h3>All categories</h3>
            <asp:GridView ID="CategoriesGridView" runat="server"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFormatString="View.aspx?categoryId={0}"
                         DataNavigateUrlFields="Id" HeaderText="Category Name" DataTextField="Name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
