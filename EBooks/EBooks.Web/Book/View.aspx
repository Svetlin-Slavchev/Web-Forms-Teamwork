<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="EBooks.Web.Book.View" %>

<%@ Register Src="~/UserControls/SearchPanel.ascx" TagPrefix="uc1" TagName="SearchPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:SearchPanel runat="server" ID="SearchPanel" />
        </div>

        <div class="col-md-9">
            <h1 id="BookTitle" runat="server"></h1>
            <h3 id ="BookSubTitle" runat="server"></h3>

            <asp:Image ID="BookImage" runat="server" />

            <div id="ISBNContainer" runat="server"></div>
            <div id="PagesContainer" runat="server"></div>
            <div id="YearContainer" runat="server"></div>

            <div>
                <p id="DescriptionContainer" runat="server"></p>
            </div>
            
            <div>
                <span>Download here: </span>
                <asp:HyperLink ID="DownloadLink" runat="server"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
