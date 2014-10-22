<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="EBooks.Web.Author.View" %>

<%@ Register Src="~/UserControls/SearchPanel.ascx" TagPrefix="uc1" TagName="SearchPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:SearchPanel runat="server" ID="SearchPanel" />
        </div>
        <div class="col-md-9">
            <h2>
                <asp:Label ID="AuthorName" runat="server"></asp:Label>
            </h2>

            <!-- This will be grid with all books in directory -->
            <asp:GridView ID="BooksByAuthorGridView" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFormatString="View.aspx?bookId={0}"
                         DataNavigateUrlFields="Id" HeaderText="Book Name" DataTextField="Title" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
