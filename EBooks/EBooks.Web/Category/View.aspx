<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="EBooks.Web.Category.View" %>

<%@ Register Src="~/UserControls/SearchPanel.ascx" TagPrefix="uc1" TagName="SearchPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:SearchPanel runat="server" ID="SearchPanel" />
        </div>
        <div class="col-md-9">
        </div>
    </div>
</asp:Content>
