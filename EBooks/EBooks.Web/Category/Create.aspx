<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="EBooks.Web.Category.Create" %>

<%@ Register Src="~/UserControls/CategorySearch.ascx" TagPrefix="uc1" TagName="CategorySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:CategorySearch runat="server" ID="CategorySearch" />
        </div>
        <div class="col-md-9">
        </div>
    </div>
</asp:Content>
