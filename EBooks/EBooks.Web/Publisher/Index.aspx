<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EBooks.Web.Publishers.Default" EnableEventValidation="false" %>

<%@ Register Src="~/UserControls/PublisherSearch.ascx" TagPrefix="uc1" TagName="PublisherSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:PublisherSearch runat="server" ID="PublisherSearch" />
        </div>
        <div class="col-md-9">
            <asp:GridView runat="server" ID="PublishersData" AutoGenerateColumns="false">
                <Columns>
                    <asp:HyperLinkField HeaderText="Id" DataTextField="Id" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Publisher/{0}" />
                    <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Publisher/{0}" />
                </Columns>
            </asp:GridView>

            <h2><%: SelectedPublisher %>  </h2>

            <asp:ListView runat="server" ID="BooksData">
                <LayoutTemplate>
                    <table border="1">
                        <tr>
                            <th> Title </th>
                            <th> Description </th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td> <%#Eval("Title") %> </td>
                        <td> <asp:LinkButton runat="server" OnClick="ShowDetails_Click" Text='<%#Eval("Description") %>' CommandArgument='<%#Eval("Id") %>' /> </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

            <asp:UpdatePanel runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <h2 runat="server" id="AdditionalInfoHeader" visible="false"> Additional Information </h2>
                    <asp:DetailsView runat="server" ID="AdditionalBookData" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BooksData" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
