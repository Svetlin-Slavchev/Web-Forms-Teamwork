<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="EBooks.Web.Author.Edit" %>

<%@ Register Src="~/UserControls/AuthorSearch.ascx" TagPrefix="uc1" TagName="AuthorSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:AuthorSearch runat="server" id="AuthorSearch" />
        </div>
        <div class="col-md-9">
        </div>
    </div>
</asp:Content>
