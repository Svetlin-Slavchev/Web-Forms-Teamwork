<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EBooks.Web.Publishers.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView runat="server" ID="PublishersData" AutoGenerateColumns="false">
        <Columns>
            <asp:HyperLinkField HeaderText="Id" DataTextField="Id" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Default.aspx?id={0}" />
            <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Default.aspx?id={0}" />
        </Columns>
    </asp:GridView>

    <h2> <%: SelectedPublisher %>  </h2>

    <asp:GridView runat="server" ID="BooksData" />



</asp:Content>
