<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="EBooks.Web.Publisher.View" %>

<%@ Register Src="~/UserControls/PublisherSearch.ascx" TagPrefix="uc1" TagName="PublisherSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <uc1:PublisherSearch runat="server" ID="PublisherSearch" />
        </div>
        <div class="col-md-9">
            <h2><%: SelectedPublisher %>  </h2>

            <asp:ListView runat="server" ID="BooksData" AllowPaging="true" PageSize="3" GridLines="None" >
                <LayoutTemplate>
                    <table class="table table-hover table-striped">
                        <tr>
                            <th>Title </th>
                            <th>Description </th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("Title") %> </td>
                        <td>
                            <asp:LinkButton runat="server" OnClick="ShowDetails_Click" Text='<%#Eval("Description") %>' CommandArgument='<%#Eval("Id") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

            <asp:UpdatePanel runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <h2 runat="server" id="AdditionalInfoHeader" visible="false"> Additional Information </h2>
                    <asp:DetailsView runat="server" ID="AdditionalBookData" CssClass="table table-hover table-striped" GridLines="None" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BooksData" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
