<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="EBooks.Web.Publisher.Create" %>

<%@ Register Src="~/UserControls/ModifyPublisher.ascx" TagPrefix="uc" TagName="ModifyPublisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ModifyPublisher runat="server" Action="Create" />
</asp:Content>
