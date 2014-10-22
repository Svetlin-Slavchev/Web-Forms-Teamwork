<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EBooks.Web.Book.Index" %>

<%@ Register Src="~/UserControls/BookSearch.ascx" TagPrefix="uc1" TagName="BookSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:BookSearch runat="server" ID="AllBooksSearch" />
        </div>
        <div class="col-md-9">
        </div>
    </div>
</asp:Content>
