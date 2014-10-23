<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EBooks.Web.Publishers.Default" EnableEventValidation="false" %>

<%@ Register Src="~/UserControls/PublisherSearch.ascx" TagPrefix="uc1" TagName="PublisherSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:PublisherSearch runat="server" ID="PublisherSearch" />
        </div>
        <div class="col-md-9">
            <h3>All Publishers</h3>
            <asp:GridView runat="server" ID="PublishersData" AutoGenerateColumns="false" AllowPaging="true" PageSize="5"
                OnPageIndexChanging="PublishersData_PageIndexChanging"
                CssClass="table table-hover table-striped" GridLines="None">
                <Columns>
                    <asp:HyperLinkField HeaderText="Id" DataTextField="Id" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Publisher/{0}" />
                    <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Publisher/{0}" />
                    <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Publisher/{0}/Edit" />
                    <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Publisher/{0}/Delete" />
                </Columns>
            </asp:GridView>

            <asp:HyperLink ID="btnCreate" NavigateUrl="~/Publisher/Create"
                CssClass="btn btn-primary" runat="server">Create</asp:HyperLink>

        </div>
    </div>
</asp:Content>
