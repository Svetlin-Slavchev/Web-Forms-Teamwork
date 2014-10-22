<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EBooks.Web.Author.Index" %>

<%@ Register Src="~/UserControls/SearchPanel.ascx" TagPrefix="uc1" TagName="SearchPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:SearchPanel runat="server" ID="SearchPanel" />
        </div>
        <div class="col-md-9">
            <h3>All authors</h3>
            <asp:GridView ID="AuthorsGridView" runat="server"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFormatString="View.aspx?authorId={0}"
                         DataNavigateUrlFields="Id" HeaderText="Author Name" DataTextField="Name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
