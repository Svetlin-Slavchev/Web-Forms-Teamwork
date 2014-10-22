<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EBooks.Web.Publishers.Default" %>

<%@ Register Src="~/UserControls/SearchPanel.ascx" TagPrefix="uc1" TagName="SearchPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:SearchPanel runat="server" ID="SearchPanel" />
        </div>
        <div class="col-md-9">
            <asp:GridView runat="server" ID="PublishersData" AutoGenerateColumns="false">
                <Columns>
                    <asp:HyperLinkField HeaderText="Id" DataTextField="Id" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Publishers/{0}" />
                    <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Publishers/{0}" />
                </Columns>
            </asp:GridView>

            <h2><%: SelectedPublisher %>  </h2>

            <asp:GridView runat="server" ID="BooksData" />
        </div>
    </div>
</asp:Content>
