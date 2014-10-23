<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="EBooks.Web.Publisher.Edit" %>

<%@ Register Src="~/UserControls/ModifyPublisher.ascx" TagPrefix="uc" TagName="ModifyPublisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ModifyPublisher ID="ModifyPublisher" runat="server" Action="Update" />
</asp:Content>
