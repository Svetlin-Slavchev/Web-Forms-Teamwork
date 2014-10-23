<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="EBooks.Web.Publisher.Delete" %>

<%@ Register Src="~/UserControls/ModifyPublisher.ascx" TagPrefix="uc" TagName="ModifyPublisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ModifyPublisher ID="ModifyPublisher" runat="server" Action="Delete" />
</asp:Content>