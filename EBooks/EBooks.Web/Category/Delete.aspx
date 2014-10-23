﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="EBooks.Web.Category.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Are you shure that you want to delete this?</h3>
    <asp:Button ID="DeleteButton" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="DeleteButton_Click" />
    <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="CancelButton_Click" />

    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Category/Index.aspx" runat="server">Back</asp:HyperLink>
</asp:Content>